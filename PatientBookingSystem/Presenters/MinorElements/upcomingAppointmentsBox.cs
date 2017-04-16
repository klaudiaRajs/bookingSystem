using System;
using System.Collections.Generic;
using System.Linq;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters {
    /** Class is responsible for preparing and managing upcomingAppointmentsBox element */
    public partial class upcomingAppointmentsBox : UserControl{
        
        /** Constructor prepares the view and calls on method filling in the data */
        public upcomingAppointmentsBox() {
            InitializeComponent();
            this.fillInUpcomingAppointments();
        }

        /** 
         * Method returns date in displayable format 
         * 
         * @param date
         * @return date in human readable format 
         */
        protected string getDateInPresenterFormat(string date) {
            string[] separator = new string[] { ".", " " };
            string[] dateContent = date.Split(separator, StringSplitOptions.None);
            DateTime newDate = new DateTime(Int32.Parse(dateContent[2]), Int32.Parse(dateContent[1]), Int32.Parse(dateContent[0]));
            string dateInFormat = newDate.ToString("dddd dd MMMM, yyyy");
            return dateInFormat;
        }

        /** Method fill in the data for the upcoming appointments box */
        private void fillInUpcomingAppointments() {
            BookingController controller = new BookingController(); 
            List<IModel> bookings = controller.getAllUpcomingAppointments();
            if (bookings.Count >= 1 && bookings.ElementAt(0) != null) {
                theClosestAppointmentLabel.Text = this.getDateInPresenterFormat(((BookingModel)bookings[0]).getScheduleModel().getDate().ToString());
            } else {
                theClosestAppointmentLabel.Text = "No upcoming appointments";
            }
            theClosestAppointmentLabel.Visible = true;
            if (bookings.Count >= 2 && bookings.ElementAt(1) != null) {
                secondTheClosestAppointmentLabel.Text = this.getDateInPresenterFormat(((BookingModel)bookings[1]).getScheduleModel().getDate().ToString());
                secondTheClosestAppointmentLabel.Visible = true;
            }
            if (bookings.Count >= 3 && bookings.ElementAt(2) != null) {
                thirdTheClosestAppointmentLabel.Text = this.getDateInPresenterFormat(((BookingModel)bookings[2]).getScheduleModel().getDate().ToString());
                thirdTheClosestAppointmentLabel.Visible = true;
            }
        }
    }
}
