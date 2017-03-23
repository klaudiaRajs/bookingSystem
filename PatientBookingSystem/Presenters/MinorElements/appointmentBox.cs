using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Presenters.MinorElements {
    partial class appointmentBox : UserControl {
        int bookingId;
        string typeOfAppointment;
        string doctorsName;
        string comment;
        string date;
        string time;
        string patient;
        AppointmentBoxI parent;
        cancelAppointmentConfirmation confirmation;
        
        public appointmentBox(AppointmentBoxI parent, BookingModel booking,  string time) {
            InitializeComponent();
            this.typeOfAppointment = booking.getStaffModel().getStaffType();
            this.doctorsName = booking.getStaffModel().getFullStaffName();
            if (!String.IsNullOrEmpty(booking.getComment())) {
                this.comment = booking.getComment();
            } else {
                this.comment = "No comment provided";
            }
            this.date = booking.getScheduleModel().getDate();
            this.time = time;
            this.bookingId = booking.getBookingId();
            this.patient = booking.getUserModel().getFirstName() + " " + booking.getUserModel().getLastName();
            this.parent = parent;
            this.confirmation = new cancelAppointmentConfirmation(this.date, this.time, this.doctorsName, this.typeOfAppointment, this);
            fillInAppointmentData();
        }

        internal void disableRescheduleButton() {
            Reschedule.Visible = false;
        }

        private void fillInAppointmentData() {
            typeOfAppointmentLabel.Text = this.typeOfAppointment;
            doctorsNameLabel.Text = this.doctorsName;
            commentLabel.Text = this.comment;
            appointmentDateLabel.Text = this.date + " " + this.time;
            if(ApplicationState.userType.Equals("admin")) {
                patientNameLabel.Visible = true;
                patientNameLabel.Text = this.patient; 
            }
        }

        private void cancelAppointment_Click(object sender, EventArgs e) {
            confirmation.Show();
        }

        public bool cancelAppointmentAfterConfirmation() {
            BookingRepo repo = new BookingRepo();
            bool result = repo.cancelAppointment(this.bookingId);
            if (!result) {
                // set some message here
                return false;
            }
            parent.getAppointmentBoxes();
            return true;
        }

        public void disableCancelButton() {
            cancelAppointmentButton.Visible = false;
        }

        private void printConfirmationButton_Click(object sender, EventArgs e) {
            printConfirmation print = new printConfirmation(this.date, this.time, this.doctorsName, this.typeOfAppointment, this);
            print.Show();
        }

        private void Reschedule_Click(object sender, EventArgs e) {
            this.confirmation.markIfConfirmationIsOfRescheduling();
            this.confirmation.Show(); 
        }

        public void shouldOpenSchedule( bool shouldOpen ) {
            if( shouldOpen) {
                //home.loadSchedulePanel();
                SingleScheduleDay dayOfBookedAppointment = new SingleScheduleDay(parent, DateHelper.getDateInMySqlFormat(this.date));
                dayOfBookedAppointment.Show();
            }
        }
    }
}
