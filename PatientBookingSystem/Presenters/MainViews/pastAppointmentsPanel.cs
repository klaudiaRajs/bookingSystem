using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.MinorElements;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing pastAppointmentsPanel view */
    public partial class pastAppointmentsPanel : UserControl, AppointmentBoxI{

        /** Used in appointmentBox */
        private Main main; 

        /** 
         * Constructor prepares view by generating appointment boxes 
         * 
         * @param main Main class required to be passed to one of the appointment box to modify the main window
         */
        public pastAppointmentsPanel(Main main) {
            InitializeComponent();
            getAppointmentBoxes();
            this.main = main;
        }

        /** Method generates appointment boxes */
        public void getAppointmentBoxes() {
            pastAppointmentsContainer.Controls.Clear();
            BookingController controller = new BookingController();
            List<IModel> bookedAppointments = controller.getPastAppointmentsPerUser();
            foreach (BookingModel booking in bookedAppointments) {
                string time = this.getTimeInDisplayableFormat(booking.getStartTime(), booking.getEndTime());
                appointmentBox box = new appointmentBox(this, booking, time);
                box.hideCancelButton();
                box.disableRescheduleButton();
                pastAppointmentsContainer.Controls.Add(box);
            }
        }

        /** 
         * Method returns time in displayable format 
         * 
         * @param startTime
         * @param endTime 
         * @return time range in human readable format
         */
        private string getTimeInDisplayableFormat(string startTime, string endTime) {
            return startTime.Substring(0, 5) + " - " + endTime.Substring(0, 5);
        }

        /** Implementation not required */
        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            //Implementation not required
        }
    }
}
