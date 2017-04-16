using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Presenters;

namespace PatientBookingSystem {
    /** Class is responsible for managing dayOfAWeekBox in schedule panel */
    public partial class dayOfaWeekBox : UserControl, AppointmentBoxI {

        private SingleScheduleDayWindow singleDay;

        public int morningAppointments;
        public int afternoonAppointments;

        internal Dictionary<int, string> staffMembersPerDate;

        string date; 

        public dayOfaWeekBox() {
            InitializeComponent();
        }

        /** 
         * Method is responsible for creating a day box 
         * 
         * @param dayNo number representing day of month
         * @param month
         * @param year 
         * @return modified day of a week box
         */
        public dayOfaWeekBox getBox(int dayNo, int month, int year) {
            DateTime dateObject = new DateTime(year, month, dayNo);
            this.date = dateObject.ToString("yyyy-MM-dd");
            // this line need to be here, so the morning and evening appointments on schedule panel counts correctly 
            this.singleDay = new SingleScheduleDayWindow(this, date);
            this.staffMembersPerDate = this.singleDay.getAllTheStaffMembersPerDate(); 
            dayNumber.Text = dayNo.ToString();
            return this;
        }


        /** 
         * Method sets number of appointments per day (total) 
         * 
         * @param morningAppointments number of morning appointments
         * @param afternoonAppoinments number of afternoon appointments
         */
        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            this.morningAppointments = morningAppointments;
            this.afternoonAppointments = afternoonAppointments;
            this.setNumberMorningAppointments(morningAppointments);
            this.setNumberOfAfternoonAppointments(afternoonAppointments);
            this.setTotalNumberOfAvailableAppointments(morningAppointments, afternoonAppointments);
        }

        /** Method opens single day window */
        internal void openSingleDayAppointmentsView_Click(object sender, EventArgs e) {
            this.singleDay = new SingleScheduleDayWindow(this, date); 
            this.singleDay.Show(); 
        }

        /** Method open a pop-up window informing the user that there are no appointments for this date */
        internal void openNoAppointmentsFeedbackMessage_Click(object sender, EventArgs e) {
            FeedbackWindow message = new FeedbackWindow();
            message.setMessageForNoAppointmentsPerDay();
            message.Show();
        }

        /** 
         * Method open a pop-up window informing the user that booking for this date 
         * is impossible due to the date being in the past 
         */
        internal void openBookingNotAvailableFeedbackMessage_Click(object sender, EventArgs e) {
            FeedbackWindow message = new FeedbackWindow();
            message.setMessageForBookingNotAvailableForDateDueToDateInThePast();
            message.Show();
        }

        /** 
         * Method sets number of morning appointments 
         * 
         * @param numberOfMorningAppointments 
         */
        private void setNumberMorningAppointments(int numberOfMorningAppointments) {
            this.numberOfMorningAppointmentsLabel.Text = numberOfMorningAppointments.ToString();
        }

        /** 
         * Method sets total number of available appointments 
         * 
         * @param morningAppointments number of morning appointments
         * @param afternoonAppoinments number of afternoon appointments
         */
        private void setTotalNumberOfAvailableAppointments(int morningAppointments, int afternoonAppointments) {
            numberOfFreeAppointmentsLabel.Text = (morningAppointments + afternoonAppointments).ToString();
        }

        /** 
         * Method sets a number of afternoon appointments 
         * 
         * @param afternoonAppointments number of afternoon appointments
         */
        private void setNumberOfAfternoonAppointments(int afternoonAppointments) {
            this.numberOfAfternoonAppointmentsLabel.Text = afternoonAppointments.ToString();
        }

        /** Implementation not required */
        public void getAppointmentBoxes() {
            //Implementation not required
        }
    }
}
