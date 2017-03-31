using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.Interfaces;

namespace PatientBookingSystem {
    public partial class dayOfaWeekBox : UserControl, AppointmentBoxI {

        string date;
        BookingRepo repo;
        SingleScheduleDay singleDay;

        public int morningAppointments;
        public int afternoonAppointments; 


        public dayOfaWeekBox() {
            InitializeComponent();
            this.repo = new BookingRepo(); 
        }

        public dayOfaWeekBox getBox(int dayNo, int month, int year) {
            DateTime dateObject = new DateTime(year, month, dayNo);
            this.date = dateObject.ToString("yyyy-MM-dd");
            // this line need to be here, so the morning and evening appointments on schedule panel counts correctly 
            singleDay = new SingleScheduleDay(this, this.date);
            dayNumber.Text = dayNo.ToString();
            return this;
        }

        private void openSingleDayAppointmentsView_Click(object sender, EventArgs e) {
            singleDay.Show(); 
        }

        public void setNumberMorningAppointments(int numberOfMorningAppointments) {
            this.numberOfMorningAppointmentsLabel.Text = numberOfMorningAppointments.ToString();
        }

        public void getAppointmentBoxes() {
            //Implementation not required
        }

        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            this.morningAppointments = morningAppointments;
            this.afternoonAppointments = afternoonAppointments; 
            this.setNumberMorningAppointments(morningAppointments);
            this.setNumberOfAfternoonAppointments(afternoonAppointments);
            this.setTotalNumberOfAvailableAppointments(morningAppointments, afternoonAppointments);
        }

        private void setTotalNumberOfAvailableAppointments(int morningAppointments, int afternoonAppointments) {
            numberOfFreeAppointmentsLabel.Text = (morningAppointments + afternoonAppointments).ToString();
        }

        private void setNumberOfAfternoonAppointments(int afternoonAppointments) {
            this.numberOfAfternoonAppointmentsLabel.Text = afternoonAppointments.ToString();
        }
    }
}
