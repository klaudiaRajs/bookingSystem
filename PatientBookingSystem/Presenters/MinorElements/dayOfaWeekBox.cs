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

        DateTime date; 

        public dayOfaWeekBox(DateTime date) {
            InitializeComponent();

            this.date = date;
            // this line need to be here, so the morning and evening appointments on schedule panel counts correctly 
            this.singleDay = new SingleScheduleDayWindow(this, date.ToString("yyyy-MM-dd"));
            this.staffMembersPerDate = this.singleDay.getAllTheStaffMembersPerDate();
            dayNumber.Text = date.Day.ToString();

            if (this.morningAppointments + this.afternoonAppointments == 0) {
                this.BackColor = System.Drawing.Color.Silver;
            }
            if (this.date.Date < DateTime.Today.Date) {
                this.BackColor = System.Drawing.Color.Silver;
            }
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

        private void dayOfaWeekBox_Click(object sender, EventArgs e) {
            if (this.morningAppointments + this.afternoonAppointments == 0) {
                FeedbackWindow message = new FeedbackWindow();
                message.setMessageForNoAppointmentsPerDay();
                message.Show();
                return;
            }
            if (this.date.Date < DateTime.Today.Date) {
                FeedbackWindow message = new FeedbackWindow();
                message.setMessageForBookingNotAvailableForDateDueToDateInThePast();
                message.Show();
                return;
            }

            this.singleDay.ShowDialog();
        }
    }
}
