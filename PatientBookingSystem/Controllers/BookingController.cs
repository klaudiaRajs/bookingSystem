using System.Collections.Generic;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Controllers {
    /** 
     * Class is responsible for communication between presenters and booking repository 
     */
    public class BookingController {

        private BookingRepo repo;

        /** 
         * Statuses of the attendance
         */
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

        /** 
         * Method returns Dictionary of values representing attendance options 
         * 
         * @return dictionary of attendance options
         */
        public Dictionary<string, Dictionary<string, int>> getAttendanceOptions() {
            Dictionary<string, Dictionary<string, int>> attendanceOptions = new Dictionary<string, Dictionary<string, int>>();
            attendanceOptions.Add(ATTENDANCE_ON_TIME, this.getAppointmentStatusValues(1, 1, 0));
            attendanceOptions.Add(ATTENDANCE_LATE, this.getAppointmentStatusValues(2, 1, 0));
            attendanceOptions.Add(ATTENDANCE_CANCELLED, this.getAppointmentStatusValues(0, 0 , 0));
            attendanceOptions.Add(ATTENDANCE_IGNORED, this.getAppointmentStatusValues(1, 1, 1));
            attendanceOptions.Add(ATTENDANCE_NOT_CONFIRMED, this.getAppointmentStatusValues(0, 2, 0));
            return attendanceOptions;
        }

        /** 
         * Method initiaties the proess of updating booking status
         * 
         * @param booking Booking model 
         * @return result of updating 
         */
        public bool updateAttendanceStatus(BookingModel booking) {
            if( Validator.validateBookingForUpdate(booking)) {
                return repo.updateBookingStatus(booking);
            }
            return false;
        }

        /** 
         * Method returns list of booked appointments for a month since today 
         * 
         * @return list of booked appointments for following month
         */
        public List<IModel> getBookedAppointmentsForNextMonth() {
            string today = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string oneMonthFromToday = DateTime.Today.AddMonths(1).Date.ToString("yyyy-MM-dd");
            return repo.getBookedAppointmentsForNextMonth(today, oneMonthFromToday); 
        }


        /** 
         * Method returns a string with attendance status 
         * 
         * @param booking Booking Model 
         * @return text of booking's attendance status 
         */
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

        /** 
         * Method returns full name of the most often attended staff member for patient 
         * 
         * @return full name of the most often attended doctor
         */
        public string getFullNameOfTheMostOftenAttendedDoctor() {
            return repo.getFullNameOfTheMostOftenAttendedDoctor();
        }

        /** 
         * Method returns list of all patient's past appointments 
         * 
         * @return past appointments per user
         */
        public List<IModel> getPastAppointmentsPerUser() {
            return repo.getAllPastAppointments(); 
        }

        /** 
         * Method returns booked appointments per day 
         * 
         * @param date 
         * @return list of appointments per date
         */
        public List<IModel> getBookedAppointmentsPerDate(string date) {
            return repo.getBookedAppointmentsPerDate(date); 
        }

        /** 
         * Method returns all the upcoming appointments 
         * 
         * @return list of upcoming appointments
         */
        public List<IModel> getAllUpcomingAppointments() {
            return repo.getAllUpcomingAppointments(); 
        }

        /** 
         * Method returns all upcoming appointments based on given search parameters 
         * 
         * @param staffId 
         * @param date
         * @param patientId
         * @return list of upcoming appointments for search parameters
         */
        public List<IModel> getAllUpcomingAppointmentsForSearchParameters(int staffId, DateTime date, int patientId) {
            return repo.getAllUpcomingAppointmentsForSearch(staffId, patientId, date);
        }

        /** 
         * Method returns a list of all the staff members that had ever had an appointment with given patient 
         * 
         * @param patientId 
         * @return list of staff members associated with patient
         */
        public List<IModel> getStaffMembersBasedOnPatient(int patientId) {
            return repo.getStaffMembersBasedOnPatient(patientId);
        }

        /** 
         * Method returns the most often attended nurse 
         * 
         * @return list of nurses attended by the patient in order from the most often attended 
         */
        public List<IModel> getTheMostOftenAttendedNurse() {
            return repo.getTheMostAttendedNurse();
        }

        /** 
         * Method returns the last appoinment
         * 
         * @return date (string) of the the last appointment attended
         */
        public string getDateOfTheLastAppointment() {
            return repo.getLastAppointment();
        }

        /** 
         * Method returns the most often attended doctor 
         * 
         * @return full name of the most often attended doctor
         */
        public string getTheMostOftenAttendedDoctor() {
            return repo.getTheMostAttendedDoctor().getFullStaffName();
        }

        /** 
         * Method initializes a process of saving a booking 
         * 
         * @param comment booking comment
         * @param startTime appointment's start time 
         * @param endTime appointment's end time 
         * @param userId 
         * @param staffScheduleId id of connection between staff and schedule
         */
        public bool bookAppointment(string comment, string startTime, string endTime, int userId, int staffScheduleId) {
            return repo.bookAppointment(comment, startTime, endTime, userId, staffScheduleId);
        }

        /** 
         * Method returns status of appointment - is it booked or available 
         * 
         * @param date 
         * @param time 
         * @param staffId
         * @return appointment status(booked or not)
         */
        public bool isBookedAppointment(string date, string time, int staffId) {
            List<IModel> allBookedAppointments = repo.getBookedAppointmentsPerDatePerLoggedInPatient(date);
            foreach (BookingModel booking in allBookedAppointments) {
                if (booking.getStartTime().Equals(time) && booking.getStaffModel().getStaffId() == staffId) {
                    return true;
                }
            }
            return false;
        }

        /** 
         * Method initializes process of cancelling (deleting) appointment booking
         * 
         * @param bookingId
         * @return result of deleting appointment
         */
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

        /** Method returns number of appointments attended on time */
        internal int getNumberOfAppointmentsAttendedOnTime() {
            return repo.countAttendedOnTime();
        }

        /** Method returns number of appointments attended late */
        internal int getNumberOfAppointmentsAttendedLate() {
            return repo.countAttendedLate();
        }

        /** Method returns number of appointments cancelled on time */
        internal int getNumberOfCancelledAppointments() {
            return repo.countCancelledOnTimeAppointents();
        }

        /** Method returns number of appointments cancelled on time */
        internal int getIgnoredAppointmentsNumber() {
            return repo.countNotCancelledAppointents();
        }

        /** 
         * Method returns values representing appointment's status 
         * 
         * @param attendance attendance status 
         * @param confirmation confirmation status
         * @param cancellation cancellation status
         * @return dictionary containing values representing appointment status
         */
        private Dictionary<string, int> getAppointmentStatusValues(int attendance, int confirmation, int cancellation) {
            Dictionary<string, int> attendanceStatus = new Dictionary<string, int>() {
                { "attendance", attendance },
                { "confirmation", confirmation},
                { "lackOfCancellation", cancellation}
            };
            return attendanceStatus;
        }
    }
}
