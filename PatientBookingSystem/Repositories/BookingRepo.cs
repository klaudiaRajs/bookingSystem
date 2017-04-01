using System;
using System.Collections.Generic;
using System.Linq;
using PatientBookingSystem.Models;
using MySql.Data.MySqlClient;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Mappers;

namespace PatientBookingSystem.Repositories {
    class BookingRepo : BaseRepo {

        string table = "pbs_booking";
        string view = "bookingView";
        string staffScheduleTable = "pbs_staffSchedule";
        string scheduleTable = "pbs_schedule";
        string today = DateTime.Today.ToString("yyyy-MM-dd");

        public bool bookAppointment(int attendance, string comment, int confirmation, string startTime, string endTime, int userId, int staffScheduleId, int lackOfCancellation) {
            string query;
            query = "INSERT INTO " + table + " (`attendance`, `comment`, `confirmation`, `startTime`, `endTime`, `userId`, `staffScheduleId`, `lackOfCancellation`) " +
                " VALUES ( "
                + attendance + ", "
                + (string.IsNullOrEmpty(comment) ? "NULL" : ('"' + comment + '"')) + ", "
                + confirmation + ", "
                + '"' + startTime + '"' + ", "
                + '"' + endTime + '"' + ", "
                + userId + ", "
                + staffScheduleId + ", "
                + lackOfCancellation + ")";
            return this.db.Execute(query);
        }


        public List<IModel> getAllPastAppointments() {
            string query = "SELECT * from " + view + " where patientId = " + ApplicationState.userId + " AND date < \"" + today + "\" ORDER BY date ASC";
            List<IModel> pastAppointments = this.db.Query(query, new BookingMapper());
            return pastAppointments;
        }

        internal string getTheMostOftenAttendedDoctor() {
            string query = "SELECT * from " + view + " WHERE patientId= " + ApplicationState.userId + " AND staffType = " + "\"doctor\"";
            List<IModel> bookings = this.db.Query(query, new BookingMapper());

            StaffModel theMostAttendedDoctor = new StaffModel();
            Dictionary<int, int> statistics = new Dictionary<int, int>();
            int theMostOftenAttended = 0;
            foreach (BookingModel booking in bookings) {
                if (statistics.ContainsKey(booking.getStaffModel().getStaffId())) {
                    statistics[booking.getStaffModel().getStaffId()]++;
                    if (statistics[booking.getStaffModel().getStaffId()] >= theMostOftenAttended) {
                        theMostAttendedDoctor.setFirstName(booking.getStaffModel().getFirstName());
                        theMostAttendedDoctor.setLastName(booking.getStaffModel().getLastName());
                    }
                } else {
                    statistics.Add(booking.getStaffModel().getStaffId(), 0);
                }
            }
            return theMostAttendedDoctor.getFullStaffName();
        }

        public bool cancelAppointment(int bookingId) {
            string query = "DELETE FROM " + table + " WHERE bookingId = " + bookingId;
            bool result = this.adjustDb(query);
            return result;
        }

        public List<IModel> getAllUpcomingAppointmentsForSearch(int staffId, DateTime date, int patientId) {
            string query = "SELECT * from " + view + " WHERE date = \"" + date.ToString("yyyy-MM-dd") + '"';
            if( patientId != 0) {
                query += " AND patientId = " + patientId; 
            }
            if (staffId != 0) {
                query += " AND staffId = " + staffId;
            }
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings; 
        }

        public List<IModel> getBookedAppointmentsPerDate(string date) {
            string query = "SELECT * FROM " + view + " WHERE date = " + '"' + date + '"';
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        public List<IModel> getDoctorsBasedOnPatient(int patientId) {
            string query = "SELECT * FROM " + view + " WHERE patientId = " + patientId + " GROUP BY staffId";
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        public List<IModel> getBookedAppointmentsPerDatePerLoggedInPatient(string date) {
            string query = "SELECT * FROM " + view + " WHERE date = " + '"' + date + '"' + " AND bookingView.patientId = " + ApplicationState.userId;
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        public List<IModel> getBookingsPerUser() {
            Dictionary<int, BookingModel> dict = new Dictionary<int, BookingModel>();
            string query = "SELECT * FROM " + view + " WHERE `patientId` = " + ApplicationState.userId;
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        internal List<IModel> getPatientsBasedOnDoctor(int id) {
            string query = "SELECT * from " + view + " WHERE staffId = " + id + " GROUP BY patientId";
            return this.db.Query(query, new BookingMapper());
        }

        public List<IModel> getTheMostAttendedNurse() {
            string query = "select pbs_staff.*, count(*) as frequency from " + table +
                   " inner join pbs_staffschedule on pbs_booking.staffScheduleId = pbs_staffschedule.staffScheduleId " +
                   "inner join pbs_staff on pbs_staff.staffId = pbs_staffschedule.staffId " +
                   " where pbs_booking.userId = 1 and pbs_staff.staffType = \"nurse\" group by pbs_staff.staffId order by count(*) desc";
            List<IModel> theMostOftenAttendedNurse = this.db.Query(query, new StaffMapper());
            return theMostOftenAttendedNurse;
        }

        public StaffModel getTheMostAttendedDoctor() {
            StaffModel staffMember = new StaffModel();
            string query = "select pbs_staff.*, count(*) as frequency from " + table +
                   " inner join pbs_staffschedule on pbs_booking.staffScheduleId = pbs_staffschedule.staffScheduleId " +
                   "inner join pbs_staff on pbs_staff.staffId = pbs_staffschedule.staffId " +
                   " where pbs_booking.userId = 1 AND pbs_staff.staffType = \"doctor\" group by pbs_staff.staffId order by count(*) desc";
            List<IModel> theMostOftenAttendedDoctor = this.db.Query(query, new StaffMapper());
            return (theMostOftenAttendedDoctor.First() as StaffModel);
        }

        public int countAttendedOnTime() {
            string query = "SELECT lackOfCancellation FROM " + table + " INNER JOIN " + staffScheduleTable + " on " + table + ".staffScheduleId = "
                + staffScheduleTable + ".staffScheduleId" + " INNER JOIN " + scheduleTable + " on " + staffScheduleTable
                + ".scheduleId = " + scheduleTable + ".scheduleId WHERE `userId` = "
                + ApplicationState.userId + " AND `attendance` = " + 1 + " AND " + scheduleTable + ".date < " + '"' + today + '"';
            MySqlDataReader reader = this.getFromDb(query);
            int counter = 0;
            while (reader.Read()) {
                counter++;
            }
            return counter;
        }

        public int countCancelledAppointents() {
            string query = getAttendanceCancellationStatisticsQueryPerUser(0, 0);
            MySqlDataReader reader = this.getFromDb(query);
            int counter = 0;
            while (reader.Read()) {
                counter++;
            }
            return counter;
        }

        public int countNotCancelledAppointents() {
            string query = getAttendanceCancellationStatisticsQueryPerUser(0, 1);
            MySqlDataReader reader = this.getFromDb(query);
            int counter = 0;
            while (reader.Read()) {
                counter++;
            }
            return counter;
        }

        public string getLastAppointment() {
            string query = "SELECT * from " + view + " WHERE patientId = " + ApplicationState.userId + " AND attendance = 1 AND date < " + '"' + today + "\" ORDER by date DESC";
            List<IModel> appointments = this.db.Query(query, new BookingMapper());
            if (appointments != null && appointments.Count != 0) {
                string theMostRecentAppointment = (appointments.First() as BookingModel).getScheduleModel().getDate();
                return theMostRecentAppointment;
            }
            return null;
        }

        private string getAttendanceCancellationStatisticsQueryPerUser(int attendance, int cancellation) {
            string query = "SELECT lackOfCancellation FROM " + table + " INNER JOIN " + staffScheduleTable + " on " + table + ".staffScheduleId = "
            + staffScheduleTable + ".staffScheduleId" + " INNER JOIN " + scheduleTable + " on " + staffScheduleTable
            + ".scheduleId = " + scheduleTable + ".scheduleId WHERE `userId` = "
            + ApplicationState.userId + " AND `attendance` = " + attendance + " AND `lackOfCancellation` = " + cancellation + " AND " + scheduleTable + ".date < " + '"' + today + '"';
            return query;
        }

        public List<IModel> getAllUpcomingAppointments() {
            string query = "SELECT * from " + view
                + " where patientId = " + ApplicationState.userId
                + " AND date > " + '"' + today + '"'
                + " ORDER BY date ASC";
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }
    }
}

