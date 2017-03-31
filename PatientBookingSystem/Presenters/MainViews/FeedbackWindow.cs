using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters {
    public partial class FeedbackWindow : Form {
        public FeedbackWindow() {
            InitializeComponent();
        }

        public void setMessageForExceptionReporting() {
            feedbackMessage.Text = "Something went wrong with your credentials. Please contact administration."; 
        }

        public void setMessageForBooking() {
            feedbackMessage.Text = "Something's wrong with your booking. You can't book this slot. Contact administration";
        }

        public void setMessageForAbsences() {
            feedbackMessage.Text = "Something's wrong. You can't save this absence. Contact administration";
        }

        public void setMessageForSuccessfullOperation() {
            feedbackMessage.Text = "Success!";
        }

        public void setMessageForInvalidFieldsValues(List<string> invalidFields) {
            feedbackMessage.Text = "The following fields values are invalid: ";
            foreach (string fieldName in invalidFields) {
                feedbackMessage.Text += fieldName;
                if (!fieldName.Equals(invalidFields[(invalidFields.Count - 1)])) {
                    feedbackMessage.Text += ", ";
                }
            }
        }

        private void keyHandler(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Hide();
            }
            if (e.KeyCode == Keys.Escape) {
                this.Hide();
            }
        }

        public void setMessageForSavingError() {
            feedbackMessage.Text = "Something went terribly wrong. Try again or contact administration"; 
        }

        private void FeedbackWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
