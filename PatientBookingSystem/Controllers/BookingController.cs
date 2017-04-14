using System.Collections.Generic;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Controllers {
    /** Class is responsible for communication between presenters and booking repository */
    public class BookingController {

        private BookingRepo repo;
        private const string ATTENDANCE_ON_TIME = "Attended on time";
        private const string ATTENDANCE_LATE = "Attended late";
        private const string ATTENDANCE_CANCELLED = "Cancelled on time";
        private const string ATTENDANCE_IGNORED = "Ignored";
        private const string ATTENDANCE_INCORRECT_DATA = "Incorrect data";
        private const string ATTENDANCE_NOT_CONFIRMED = "Not confirmed yet";

        public Dictionary<string, Dictionary<string, int>> attendanceOptions = new Dictionary<string, Dictionary<string, int>>(); 

        public BookingController() {
            this.repo = new BookingRepo();
            this.attendanceOptions = this.getAttendanceOptions(); 
        }

        /** Method returns Dictionary of values representing attendance options */
        public Dictionary<string, Dictionary<string, int>> getAttendanceOptions() {
            Dictionary<string, Dictionary<string, int>> attendanceOptions = new Dictionary<string, Dictionary<string, int>>();
            attendanceOptions.Add(ATTENDANCE_ON_TIME, this.getAppointmentStatusValues(1, 1, 0));
            attendanceOptions.Add(ATTENDANCE_LATE, this.getAppointmentStatusValues(2, 1, 0));
            attendanceOptions.Add(ATTENDANCE_CANCELLED, this.getAppointmentStatusValues(0, 0 , 0));
            attendanceOptions.Add(ATTENDANCE_IGNORED, this.getAppointmentStatusValues(1, 1, 1));
            attendanceOptions.Add(ATTENDANCE_NOT_CONFIRMED, this.getAppointmentStatusValues(0, 2, 0));
            return attendanceOptions;
        }

        /** Method initiaties the proess of updating booking status */
        public bool updateAttendanceStatus(BookingModel booking) {
            if( Validator.validateBookingForUpdate(booking)) {
                return repo.updateBookingStatus(booking);
            }
            return false;
        }

        /** Method returns list of booked appointments for a month since today */
        public List<IModel> getBookedAppointmentsForNextMonth() {
            string today = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string oneMonthFromToday = DateTime.Today.AddMonths(1).Date.ToString("yyyy-MM-dd");
            return repo.getBookedAppointmentsForNextMonth(today, oneMonthFromToday); 
        }

        /** Method returns values representing appointments status */
        private Dictionary<string, int> getAppointmentStatusValues(int attendance, int confirmation, int cancellation) {
            Dictionary<string, int> attendedLate = new Dictionary<string, int>() {
                { "attendance", attendance },
                { "confirmation", confirmation},
                { "lackOfCancellation", cancellation}
            };
            return attendedLate;
        }

        /** Method returns a string with attendance status */
        public string getAttendanceTextPerBooking(BookingModel booking) {
            if( booking.getAttendance() == 1 && booking.getConfirmation() == 1 && booking.getLackOfCancellation() == 0) {
                return ATTENDANCE_ON_TIME;
            }
            if (booking.getAttendance() == 2 && booking.getConfirmation() == 1 && booking.getLackOfCancellation() == 0) {
                return ATTENDANCE_LATE;
            }
            if (booking.getAttendance() == 0 && booking.getConfirmation() == 0 && booking.getLackOfCancellation() == 0) {
                return ATTENDANCE_CANCELLED;
            }
            if (booking.getAttendance() == 1 && booking.getConfirmation() == 1 && booking.getLackOfCancellation() == 1) {
                return ATTENDANCE_IGNORED;
            }
            if (booking.getAttendance() == 0 && booking.getConfirmation() == 2 && booking.getLackOfCancellation() == 0) {
                return ATTENDANCE_NOT_CONFIRMED;
            }
            return ATTENDANCE_INCORRECT_DATA; 
        }

        /** Method returns full name of the most often attended staff member for patient */
        public string getFullNameOfTheMostOftenAttendedDoctor() {
            return repo.getFullNameOfTheMostOftenAttendedDoctor();
        }

        /** Method returns list of all patient's past appointments */
        public List<IModel> getPastAppointmentsPerUser() {
            return repo.getAllPastAppointments(); 
        }

        /** Method returns booked appointments per day */
        public List<IModel> getBookedAppointmentsPerDate(string date) {
            return repo.getBookedAppointmentsPerDate(date); 
        }

        /** Method returns all the upcoming appointments */
        public List<IModel> getAllUpcomingAppointments() {
            return repo.getAllUpcomingAppointments(); 
        }

        /** Method returns all upcoming appointments based on given search parameters */
        public List<IModel> getAllUpcomingAppointmentsForSearchParameters(int staffId, DateTime date, int patientId) {
            return repo.getAllUpcomingAppointmentsForSearch(staffId, patientId, date);
        }

        /** Method returns a list of all the staff members that had ever had an appointment with given patient */
        public List<IModel> getStaffMembersBasedOnPatient(int patientId) {
            return repo.getStaffMembersBasedOnPatient(patientId);
        }

        /** Method returns the most often attended nurse */
        public List<IModel> getTheMostOftenAttendedNurse() {
            return repo.getTheMostAttendedNurse();
        }

        /** Method returns the last appoinment */
        public string getLastAppointment() {
            return repo.getLastAppointment();
        }

        /** Method returns the most often attended doctor */
        public string getTheMostOftenAttendedDoctor() {
            return repo.getTheMostAttendedDoctor().getFullStaffName();
        }

        /** Method initializes a process of saving a booking */
        public bool bookAppointment(int attendance, string comment, int confirmation, string startTime, string endTime, int userId, int staffScheduleId, int lackOfCancellation) {
            return repo.bookAppointment(attendance, comment, confirmation, startTime, endTime, userId, staffScheduleId, lackOfCancellation);
        }

        /** Method returns status of appointment - is it booked or available */
        public bool isBookedAppointment(string date, string time, int staffId) {
            List<IModel> allBookedAppointments = repo.getBookedAppointmentsPerDatePerLoggedInPatient(date);
            foreach (BookingModel booking in allBookedAppointments) {
                if (booking.getStartTime().Equals(time) && booking.getStaffModel().getStaffId() == staffId) {
                    return true;
                }
            }
            return false;
        }

        /** Method initializes process of cancelling (deleting) appointment booking*/
        public bool cancelAppointment(int bookingId) {
            return repo.cancelAppointment(bookingId); 
        }

        public string getOnTimeAppointmentStatus() {
            return ATTENDANCE_ON_TIME;
        }

        public string getLateAppointmentStatus() {
            return ATTENDANCE_LATE;
        }

        public string getIgnoredAppointmentStatus() {
            return ATTENDANCE_IGNORED; 
        }

        public string getCancelledAppointmentStatus() {
            return ATTENDANCE_CANCELLED;
        }

        public string getIncorrectDataAppointmentStatus() {
            return ATTENDANCE_INCORRECT_DATA;
        }

        public string getNotConfirmedAppointmentStatus() {
            return ATTENDANCE_NOT_CONFIRMED;
        }
    }
}
