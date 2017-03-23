using PatientBookingSystem.Presenters.MinorElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    partial class cancelAppointmentConfirmation : Form {
        string date;
        string time;
        string staffName;
        string typeOfAppointment;
        appointmentBox parent;
        bool reschedule = false;

        public cancelAppointmentConfirmation(string date, string time, string staffName, string typeOfAppointment, appointmentBox parent) {
            InitializeComponent();
            this.parent = parent;
            this.date = date;
            this.time = time;
            this.staffName = staffName;
            this.typeOfAppointment = typeOfAppointment;
            fillInData();
        }

        //nazwij to metode troche inaczej
        public void markIfConfirmationIsOfRescheduling() {
            this.reschedule = true;
        }

        private void fillInData() {
            dateLabel.Text = this.date;
            timeLabel.Text = this.time;
            staffNameLabel.Text = this.staffName;
            typeOfAppointmentLabel.Text = this.typeOfAppointment;
        }

        private void confirmCancellation_Click(object sender, EventArgs e) {
            //TODO fix it to actually deleting the appointment
            if (!parent.cancelAppointmentAfterConfirmation()) {
                //if (false) {
                dateLabel.Visible = false;
                timeLabel.Visible = false;
                staffNameLabel.Visible = false;
                typeOfAppointmentLabel.Visible = false;
                firstPartOfText.Text = "Something went ";
                secondPartOfText.Text = " Reload and try again";
            } else {
                if (reschedule) {
                    parent.shouldOpenSchedule(true);
                }
                this.Close();
            }
        }

        private void rejectCancellationButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
