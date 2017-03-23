using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Presenters {
    public partial class upcomingAppointmentsBox : BasePresenter {
        BookingRepo repo;
        public upcomingAppointmentsBox() {
            InitializeComponent();
            repo = new BookingRepo();
            fillInUpcomingAppointments(); 
        }

        protected String getDateInPresenterFormat(String date) {
            string[] separator = new string[] { ".", " " };
            string[] dateContent = date.Split(separator, StringSplitOptions.None);
            DateTime newDate = new DateTime(Int32.Parse(dateContent[2]), Int32.Parse(dateContent[1]), Int32.Parse(dateContent[0]));
            String dateInFormat = newDate.ToString("dddd dd MMMM, yyyy");
            return dateInFormat;
        }

        private void fillInUpcomingAppointments() {
            List<IModel> bookings = repo.getAllUpcomingAppointments();
            //if (bookings.ElementAt(0) != null) {
            //    theClosestAppointmentLabel.Text = getDateInPresenterFormat(bookings.ElementAt(0).getScheduleModel().getDate().ToString());
            //} else {
            //    theClosestAppointmentLabel.Visible = false;
            //}
            //if (bookings.ElementAt(1) != null) {
            //    secondTheClosestAppointmentLabel.Text = getDateInPresenterFormat(bookings.ElementAt(1).getScheduleModel().getDate().ToString());
            //} else {
            //    secondTheClosestAppointmentLabel.Visible = false;
            //}
            //if (bookings.ElementAt(2) != null) {
            //    thirdTheClosestAppointmentLabel.Text = getDateInPresenterFormat(bookings.ElementAt(2).getScheduleModel().getDate().ToString());
            //} else {
            //    thirdTheClosestAppointmentLabel.Visible = false;
            //}
        }
    }
}
