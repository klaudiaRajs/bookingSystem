using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.MinorElements;
using PatientBookingSystem.Presenters.Interfaces;

namespace PatientBookingSystem.Presenters.MainViews {
    public partial class pastAppointmentsPanel : UserControl, AppointmentBoxI{
        private Main main; 
        public pastAppointmentsPanel(Main main) {
            InitializeComponent();
            getAppointmentBoxes();
            this.main = main;
        }

        public void getAppointmentBoxes() {
            pastAppointmentsContainer.Controls.Clear();
            BookingRepo repo = new BookingRepo();
            List<IModel> bookedAppointments = repo.getAllPastAppointments();
            foreach (BookingModel booking in bookedAppointments) {
                string time = booking.getStartTime().Substring(0, 5) + " - " + booking.getEndTime().Substring(0, 5);
                appointmentBox box = new appointmentBox(this, booking, time);
                box.disableCancelButton();
                box.disableRescheduleButton();
                pastAppointmentsContainer.Controls.Add(box);
            }
        }

        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            //Implementation not required
        }
    }
}
