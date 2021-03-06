﻿using PatientBookingSystem.Presenters.MinorElements;
using System;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing appointment cancellation view */
    partial class CancelAppointmentConfirmation : Form {

        private string date;
        private string time;
        private string staffName;
        private string typeOfAppointment;
        private appointmentBox parent;
        private bool reschedule = false;

        /** 
         * Constructor assings values to fields and prepares the view 
         * 
         * @param date 
         * @param time
         * @param staffName name of the staff member 
         * @param typeOfAppointment appointmentType 
         * @param parent appointmentBox object
         */
        public CancelAppointmentConfirmation(string date, string time, string staffName, string typeOfAppointment, appointmentBox parent) {
            InitializeComponent();
            this.parent = parent;
            this.date = date;
            this.time = time;
            this.staffName = staffName;
            this.typeOfAppointment = typeOfAppointment;
            fillInAppointmentInformation();
            this.CenterToScreen();
        }

        /** Method marks the process as reschedulling */
        public void isReschedullingProcess() {
            this.reschedule = true;
        }

        /** Method fills in the appointment information */
        private void fillInAppointmentInformation() {
            dateLabel.Text = this.date;
            timeLabel.Text = this.time;
            staffNameLabel.Text = this.staffName;
            typeOfAppointmentLabel.Text = this.typeOfAppointment;
        }

        /** Method allow the user to confirm or reject the booking cancellation */
        private void confirmCancellation_Click(object sender, EventArgs e) {
            if (!parent.cancelAppointmentAfterConfirmation()) {
                this.adjustViewForErrorReporting();
            } else {
                if (reschedule) {
                    parent.shouldOpenSchedule(true);
                }
                this.Close();
            }
        }

        /** Method adjusts view for error reporting */
        private void adjustViewForErrorReporting() {
            dateLabel.Visible = false;
            timeLabel.Visible = false;
            staffNameLabel.Visible = false;
            typeOfAppointmentLabel.Visible = false;
            firstPartOfText.Text = "Something went ";
            secondPartOfText.Text = " Reload and try again";
        }

        /** Method closes the window */
        private void rejectCancellationButton_Click(object sender, EventArgs e) {
            this.Hide();
        }

        /** Method allows closing the window by using escape key on keyboard*/
        private void cancelAppointmentConfirmation_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.rejectCancellationButton_Click(this, new EventArgs());
            }
        }
    }
}
