using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Controllers {
    class BookingController {
        BookingRepo repo; 
        int userId; 

        public BookingController() {
            repo = new BookingRepo(); 
            this.userId = ApplicationState.userId; 
        }

        public bool bookAppointment(int attendance, string comment, int confirmation, string startTime, string endTime, int userId, int staffScheduleId, int lackOfCancellation) {
            return repo.bookAppointment(attendance, comment, confirmation, startTime, endTime, userId, staffScheduleId, lackOfCancellation);
        }

        public bool isBookedAppointment(string date, string time, int staffId) {
            List<IModel> allBookedAppointments = repo.getBookedAppointmentsPerDatePerLoggedInPatient(date);
            foreach (BookingModel booking in allBookedAppointments) {
                if (booking.getStartTime().Equals(time) && booking.getStaffModel().getStaffId() == staffId) {
                    return true;
                }
            }
            return false;
        }

        public bool cancelAppointment(int bookingId) {
            return repo.cancelAppointment(bookingId); 
        }
    }
}
