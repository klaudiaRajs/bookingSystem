using PatientBookingSystem.Controllers;
using System.Windows.Forms;
using System;

namespace PatientBookingSystem.Presenters {
    /** Class is a representation of statistics overview */
    public partial class statisticsOverviewBox : UserControl {
        
        public statisticsOverviewBox() {
            InitializeComponent();
            getStatistics();
        }

        /** Method fills in the statistics fetched from the controller */
        private void getStatistics() {
            BookingController controller = new BookingController();
            appointmentsAttendedLate.Text += controller.getNumberOfAppointmentsAttendedLate().ToString();
            appointmentAttendedOnTime.Text += controller.getNumberOfAppointmentsAttendedOnTime().ToString();
            appointmentsCancelled.Text += controller.getNumberOfCancelledAppointments().ToString();
            appointmentsIgnored.Text += controller.getIgnoredAppointmentsNumber().ToString();
        }
    }
}
