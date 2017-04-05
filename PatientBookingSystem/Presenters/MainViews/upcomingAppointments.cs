using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.MinorElements;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem {
    /** Class is responsible for managing and modifying upcomingAppointments view and communicating with relevant controllers */
    public partial class upcomingAppointmentsContainer : UserControl, AppointmentBoxI {

        Main parent;

        /** Constructor initializes components and calls on method that generates appointment boxes */
        public upcomingAppointmentsContainer(Main parent) {
            InitializeComponent();
            this.parent = parent;
            getAppointmentBoxes();
        }

        /** Method generates appointment boxes */
        public void getAppointmentBoxes() {
            appointmentsContainer.Controls.Clear();
            BookingController controller = new BookingController();
            List<IModel> bookedAppointments;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            if (!ApplicationState.userType.Equals("admin")) {
                bookedAppointments = controller.getAllUpcomingAppointments();
            } else {
                bookedAppointments = controller.getBookedAppointmentsPerDate(today);
            }
            if (bookedAppointments != null) {
                foreach (BookingModel booking in bookedAppointments) {
                    string time = booking.getStartTime().Substring(0, 5) + " - " + booking.getEndTime().Substring(0, 5);
                    appointmentBox box = new appointmentBox(this, booking, time);
                    appointmentsContainer.Controls.Add(box);
                }
            }
        }

        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            //Implementation not required
        }
    }
}
