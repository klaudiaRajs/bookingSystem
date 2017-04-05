using System.Collections.Generic;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;

namespace PatientBookingSystem.Controllers {
    /** Class is responsible for communication between presenters and booking repository */
    class BookingController {

        BookingRepo repo; 

        public BookingController() {
            repo = new BookingRepo(); 
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
            return repo.getAllUpcomingAppointmentsForSearch(staffId, date, patientId);
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
    }
}
