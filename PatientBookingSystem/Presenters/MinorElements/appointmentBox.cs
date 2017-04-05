using System;
using System.Windows.Forms;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is responsible for managing appointmentBox element */
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

        /** Constructor prepares element by initializing fields and filling appointment information */
        public appointmentBox(AppointmentBoxI parent, BookingModel booking, string time) {
            InitializeComponent();
            this.initializeFields(parent, booking, time);
            this.fillInAppointmentData();
        }

        /** Method initializes fields with values passed as parametrs */
        private void initializeFields(AppointmentBoxI parent, BookingModel booking, string time) {
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
        }

        /** Method hides reschedule button */
        internal void disableRescheduleButton() {
            Reschedule.Visible = false;
        }

        /** Method fills the appointment data in */
        private void fillInAppointmentData() {
            typeOfAppointmentLabel.Text = this.typeOfAppointment;
            doctorsNameLabel.Text = this.doctorsName;
            commentLabel.Text = this.comment;
            appointmentDateLabel.Text = this.date + " " + this.time;
            if (ApplicationState.userType.Equals("admin")) {
                patientLabel.Visible = true;
                patientNameLabel.Visible = true;
                patientNameLabel.Text = this.patient;
            }
        }

        /** Method shows confirmation promp window for cancelling the appointment */
        private void cancelAppointment_Click(object sender, EventArgs e) {
            confirmation.Show();
        }

        /** Method calls the controller for cancelling the appointment and reloads appointment boxes in parent window */
        public bool cancelAppointmentAfterConfirmation() {
            BookingController controller = new BookingController();
            bool result = controller.cancelAppointment(this.bookingId);
            if (!result) {
                // set some message here
                return false;
            }
            parent.getAppointmentBoxes();
            return true;
        }

        /** Method hides cancel button */
        public void hideCancelButton() {
            cancelAppointmentButton.Visible = false;
        }

        /** Method opens dialog allowing user to print confirmation for the appointment */
        private void printConfirmationButton_Click(object sender, EventArgs e) {
            PrintConfirmationWindow print = new PrintConfirmationWindow(this.date, this.time, this.doctorsName, this.typeOfAppointment, this);
            print.Show();
        }

        /** Methor shows confirmation prompt for rescheduling the appointment */
        private void Reschedule_Click(object sender, EventArgs e) {
            this.confirmation.isReschedullingProcess();
            this.confirmation.Show();
        }

        /** Method shows timetable if method calling passes true */
        public void shouldOpenSchedule(bool shouldOpen) {
            if (shouldOpen) {
                SingleScheduleDayWindow dayOfBookedAppointment = new SingleScheduleDayWindow(parent, DateHelper.getDateInMySqlFormat(this.date));
                dayOfBookedAppointment.Show();
            }
        }
    }
}
