using System;
using System.Collections.Generic;
using System.Linq;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Mappers;

namespace PatientBookingSystem.Repositories {
    /** Class is responsible for communication with booking database booking table and view */
    class BookingRepo : BaseRepo {

        private string table = "pbs_booking";
        private string view = "bookingView";
        private string today = DateTime.Today.ToString("yyyy-MM-dd");

        /** 
         * Method is responsible for saving booking to the database 
         * 
         * @param comment booking comment
         * @param startTime appointment's start time 
         * @param endTime appointment's end time 
         * @param userId 
         * @param staffScheduleId id of connection between staff and schedule
         * @return result of saving
         */
        public bool bookAppointment(string comment, string startTime, string endTime, int userId, int staffScheduleId) {
            string query;
            query = "INSERT INTO " + table + " (`attendance`, `comment`, `confirmation`, `startTime`, `endTime`, `userId`, `staffScheduleId`, `lackOfCancellation`) " +
                " VALUES ( "
                + "0" + ", "
                + (string.IsNullOrEmpty(comment) ? "NULL" : ('"' + comment + '"')) + ", "
                + "2" + ", "
                + '"' + startTime + '"' + ", "
                + '"' + endTime + '"' + ", "
                + userId + ", "
                + staffScheduleId + ", "
                + "0"  + ")";
            return this.db.Execute(query);
        }

        /** 
         * Method returns list of all the past appointments 
         * 
         * @return list of all past appointments
         */
        public List<IModel> getAllPastAppointments() {
            string query = "SELECT * from " + view + " where patientId = " + ApplicationState.userId + " AND date < \"" + today + "\" ORDER BY date ASC";
            List<IModel> pastAppointments = this.db.Query(query, new BookingMapper());
            return pastAppointments;
        }

        /** 
         * Method returns full name of the most attended staff member (doctor) 
         * 
         * @return full name of the most often attended doctor
         */
        public string getFullNameOfTheMostOftenAttendedDoctor() {
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

        /** 
         * Method updates booking status (attendance status) 
         * 
         * @param booking booking model 
         * @returns results of updating 
         */
        public bool updateBookingStatus(BookingModel booking) {
            string query = "UPDATE pbs_booking SET `attendance` = " + booking.getAttendance() 
                + ", `confirmation` = " + booking.getConfirmation() 
                + ", `lackOfCancellation` = " + booking.getLackOfCancellation() 
                + " WHERE `bookingId` = " + booking.getId();
            bool result = this.adjustDb(query);
            return result;
        }

        /** 
         * Method returns a list of booking for all the patients for one month from today 
         * 
         * @param today current date
         * @param oneMonthFromToday date in one month from today
         * @return list of booked appointments for the next month
         */
        public List<IModel> getBookedAppointmentsForNextMonth(string today, string oneMonthFromToday) {
            string query = "SELECT * from " + view + " where date >= \"" + today + "\" AND date <= \"" + oneMonthFromToday + "\" ORDER BY date ASC";
            List<IModel> upcomingAppointments = this.db.Query(query, new BookingMapper());
            return upcomingAppointments;
        }

        /** 
         * Method cancells (delete) an appointment 
         * 
         * @param bookingId
         * @return result of cancelling
         */
        public bool cancelAppointment(int bookingId) {
            string query = "DELETE FROM " + table + " WHERE bookingId = " + bookingId;
            bool result = this.adjustDb(query);
            return result;
        }

        /** 
         * Method returns list of all upcoming appointments meeting the parameters passed 
         * 
         * @param staffId 
         * @param patientId
         * @param date 
         * @result list of all upcoming appointments meeting the search requirements
         */
        public List<IModel> getAllUpcomingAppointmentsForSearch(int staffId, int patientId, DateTime date ) {
            string query = "SELECT * from " + view + " WHERE ";
            if( date != new DateTime(1890, 12, 12)) {
                query += "date = \"" + date.ToString("yyyy-MM-dd") + '"';
            } else {
                query += "date >= \"" + (DateTime.Today.Date).ToString("yyyy-MM-dd") + '"';
            }
            if( patientId != 0 ) {
                query += " AND patientId = " + patientId; 
            }
            if (staffId != 0 ) {
                query += " AND staffId = " + staffId;
            }
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings; 
        }

        /** 
         * Method returns list of all the appointments per day 
         * 
         * @param date the date
         * @return list of booked appointments per date
         */
        public List<IModel> getBookedAppointmentsPerDate(string date) {
            string query = "SELECT * FROM " + view + " WHERE date = " + '"' + date + '"';
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        /** 
         * Method returns all the staff members associated with patient (based on booking) 
         * 
         * @param  patientId 
         * @return list of staff members associated with patients 
         */
        public List<IModel> getStaffMembersBasedOnPatient(int patientId) {
            string query = "SELECT * FROM " + view + " WHERE patientId = " + patientId + " GROUP BY staffId";
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        /** 
         * Method returns list of all booked appointments per date per patient 
         * 
         * @param date 
         * @return list of booked appointments per date per patient 
         */
        public List<IModel> getBookedAppointmentsPerDatePerLoggedInPatient(string date) {
            string query = "SELECT * FROM " + view + " WHERE date = " + '"' + date + '"' + " AND bookingView.patientId = " + ApplicationState.userId;
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        /** 
         * Method returns list of patients associated by staff member  
         * 
         * @param id  staff id 
         * @return list of patients based on staff member
         */
        public List<IModel> getPatientsBasedOnStaffMember(int id) {
            string query = "SELECT * from " + view + " WHERE staffId = " + id + " GROUP BY patientId";
            return this.db.Query(query, new BookingMapper());
        }

        /** 
         * Method returns the most often attended nurse 
         * 
         * @return list of the most often attended nurse
         */
        public List<IModel> getTheMostAttendedNurse() {
            string query = "select pbs_staff.*, count(*) as frequency from " + table +
                   " inner join pbs_staffschedule on pbs_booking.staffScheduleId = pbs_staffschedule.staffScheduleId " +
                   "inner join pbs_staff on pbs_staff.staffId = pbs_staffschedule.staffId " +
                   " where pbs_booking.userId = 1 and pbs_staff.staffType = \"nurse\" group by pbs_staff.staffId order by count(*) desc";
            List<IModel> theMostOftenAttendedNurse = this.db.Query(query, new StaffMapper());
            return theMostOftenAttendedNurse;
        }

        /** 
         * Method returns the most often attended doctor 
         * 
         * @return staff model 
         */
        public StaffModel getTheMostAttendedDoctor() {
            StaffModel staffMember = new StaffModel();
            string query = "select pbs_staff.*, count(*) as frequency from " + table +
                   " inner join pbs_staffschedule on pbs_booking.staffScheduleId = pbs_staffschedule.staffScheduleId " +
                   "inner join pbs_staff on pbs_staff.staffId = pbs_staffschedule.staffId " +
                   " where pbs_booking.userId = 1 AND pbs_staff.staffType = \"doctor\" group by pbs_staff.staffId order by count(*) desc";
            List<IModel> theMostOftenAttendedDoctor = this.db.Query(query, new StaffMapper());
            return (theMostOftenAttendedDoctor.First() as StaffModel);
        }

        /** 
         * Method counts number of appointments attended on time 
         * 
         * @return number of appointments attended on time 
         */
        public int countAttendedOnTime() {
            string query = getAttendanceCancellationStatisticsQueryPerUser(1, 1, 0);
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings.Count;
        }

        /** 
         * Method counts number of appointments attended late 
         * 
         * @return number of appointments attended late
         */
        public int countAttendedLate() {
            string query = getAttendanceCancellationStatisticsQueryPerUser(2, 1, 0);
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings.Count;
        }

        /** 
         * Method returns number of appointments cancelled on time 
         * 
         * @return number of appointments cancelled on time
         */
        public int countCancelledOnTimeAppointents() {
            string query = getAttendanceCancellationStatisticsQueryPerUser(0, 0, 0);
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings.Count;
        }

        /** 
         *  returns number of appointments that were not cancelled on time 
         *  
         *  @return number of appointments not cancelled 
         */
        public int countNotCancelledAppointents() {
            string query = getAttendanceCancellationStatisticsQueryPerUser(1, 1, 1);
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings.Count;
        }

        /** 
         * Method returns date (string) of the last attended appointment 
         * 
         * @return date of the last attended appointment
         */
        public string getLastAppointment() {
            string query = "SELECT * from " + view + " WHERE patientId = " + ApplicationState.userId + " AND attendance = 1 AND date < " + '"' + today + "\" ORDER by date DESC";
            List<IModel> appointments = this.db.Query(query, new BookingMapper());
            if (appointments != null && appointments.Count != 0) {
                string theMostRecentAppointment = (appointments.First() as BookingModel).getScheduleModel().getDate();
                return theMostRecentAppointment;
            }
            return null;
        }

        /** 
         * Method returns all the upcoming appointments 
         * 
         * @return list of all upcoming appointments
         */
        public List<IModel> getAllUpcomingAppointments() {
            string query = "SELECT * from " + view
                + " where patientId = " + ApplicationState.userId
                + " AND date > " + '"' + today + '"'
                + " ORDER BY date ASC";
            List<IModel> bookings = this.db.Query(query, new BookingMapper());
            return bookings;
        }

        /** 
         * Method provides query for counting cancellation statistics 
         * 
         * @param attendance value indicating attendance 
         * @param confirmation value indicating confirmation 
         * @param cancellation value indicating cancellation
         * @return query for counting cancellation statistics
         */
        private string getAttendanceCancellationStatisticsQueryPerUser(int attendance, int confirmation, int cancellation) {
            string query = "SELECT * FROM " + view + " WHERE " +
            "`patientId` = " + ApplicationState.userId +
            " AND `attendance` = " + attendance +
            " AND `lackOfCancellation` = " + cancellation +
            " AND `confirmation` = " + confirmation +
            " AND date < " + '"' + today + '"';
            return query;
        }
    }
}

