using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.MinorElements;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    public partial class upcomingAppointmentsContainer : UserControl, AppointmentBoxI {
        Main parent;
        public upcomingAppointmentsContainer(Main parent) {
            InitializeComponent();
            this.parent = parent;
            getAppointmentBoxes();
        }

        public void getAppointmentBoxes() {
            appointmentsContainer.Controls.Clear();
            BookingRepo repo = new BookingRepo();
            List<IModel> bookedAppointments;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            if (!ApplicationState.userType.Equals("admin")) {
                bookedAppointments = repo.getAllUpcomingAppointments();
            } else {
                bookedAppointments = repo.getBookedAppointmentsPerDate(today);
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
