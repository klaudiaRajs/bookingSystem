﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.Interfaces;

namespace PatientBookingSystem {
    /** Class is responsible for managing dayOfAWeekBox in schedule panel */
    public partial class dayOfaWeekBox : UserControl, AppointmentBoxI {

        private SingleScheduleDayWindow singleDay;

        public int morningAppointments;
        public int afternoonAppointments;

        internal List<IModel> staffMembersPerDate; 


        public dayOfaWeekBox() {
            InitializeComponent();
        }

        /** Method is responsible for creating a day box */
        public dayOfaWeekBox getBox(int dayNo, int month, int year) {
            DateTime dateObject = new DateTime(year, month, dayNo);
            string date = dateObject.ToString("yyyy-MM-dd");
            // this line need to be here, so the morning and evening appointments on schedule panel counts correctly 
            this.singleDay = new SingleScheduleDayWindow(this, date);
            this.staffMembersPerDate = this.singleDay.getAllTheStaffMembersPerDate(); 
            dayNumber.Text = dayNo.ToString();
            return this;
        }

        /** Method opens single day window */
        private void openSingleDayAppointmentsView_Click(object sender, EventArgs e) {
            this.singleDay.Show(); 
        }

        /** Method sets number of morning appointments */
        private void setNumberMorningAppointments(int numberOfMorningAppointments) {
            this.numberOfMorningAppointmentsLabel.Text = numberOfMorningAppointments.ToString();
        }

        public void getAppointmentBoxes() {
            //Implementation not required
        }

        /** Method sets number of appointments per day (total) */
        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            this.morningAppointments = morningAppointments;
            this.afternoonAppointments = afternoonAppointments; 
            this.setNumberMorningAppointments(morningAppointments);
            this.setNumberOfAfternoonAppointments(afternoonAppointments);
            this.setTotalNumberOfAvailableAppointments(morningAppointments, afternoonAppointments);
        }

        /** Method sets total number of available appointments */
        private void setTotalNumberOfAvailableAppointments(int morningAppointments, int afternoonAppointments) {
            numberOfFreeAppointmentsLabel.Text = (morningAppointments + afternoonAppointments).ToString();
        }

        /** Method sets a number of afternoon appointments */
        private void setNumberOfAfternoonAppointments(int afternoonAppointments) {
            this.numberOfAfternoonAppointmentsLabel.Text = afternoonAppointments.ToString();
        }
    }
}
