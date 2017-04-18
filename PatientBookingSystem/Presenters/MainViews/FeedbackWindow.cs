using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters {
    /** Class manages a pop-up window containing all the require feedback for the user */
    public partial class FeedbackWindow : Form {
        public FeedbackWindow() {
            InitializeComponent();
        }

        /** Method sets message for promting user to enable the day in adding multiple schedule entries view */
        public void setPromptToEnableDay() {
            this.feedbackMessage.Text = "Enable this day first.";
        }

        /** Method sets message for booking not available for the date due to the date being in the past */
        public void setMessageForBookingNotAvailableForDateDueToDateInThePast() {
            this.feedbackMessage.Text = "Bookings are available only dates no earlier than today";
        }

        /** Method sets message for no appointments per day */
        public void setMessageForNoAppointmentsPerDay() {
            this.feedbackMessage.Text = "There are no appointments for this day";
        }

        /** 
         * Method sets customized message passed through parameter 
         * 
         * @param message message to be set
         */
        public void setCustomizedMessage(string message) {
            feedbackMessage.Text = message;
        }

        /** Method sets message for wrong credentials */
        public void setMessageForWrongCredentials() {
            feedbackMessage.Text = "Please, enter valid credentials";
        }

        /** Method sets message for exception reporting */
        public void setMessageForExceptionReporting() {
            feedbackMessage.Text = "Something went wrong. Please contact administration."; 
        }

        /** Method sets message for booking problem */
        public void setMessageForBookingProblem() {
            feedbackMessage.Text = "Something's wrong with your booking. You can't book this slot. Contact administration";
        }

        /**
         *  Method sets message for absence problem 
         */
        public void setMessageForAbsencesProblems() {
            feedbackMessage.Text = "Something's wrong. You can't save this absence. Contact administration";
        }

        /** Method sets message for saving problems */
        public void setMessageForSavingError() {
            feedbackMessage.Text = "Something went terribly wrong. Try again or contact administration"; 
        }

        /** Method sets message for successful operation */
        public void setMessageForSuccessfullOperation() {
            feedbackMessage.Text = "Success!";
        }

        /**
         *  Method sets message for invalid fields in the form
         *   
         *   @param list of invalid fields to display to the user 
         */
        public void setMessageForInvalidFieldsValues(List<string> invalidFields) {
            feedbackMessage.Text = "The following fields values are invalid: ";
            foreach (string fieldName in invalidFields) {
                feedbackMessage.Text += fieldName;
                if (!fieldName.Equals(invalidFields[(invalidFields.Count - 1)])) {
                    feedbackMessage.Text += ", ";
                }
            }
        }

        /** Method allows to close feedback window on pressing enter or escape button on keyboard */
        private void keyHandler(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Hide();
            }
            if (e.KeyCode == Keys.Escape) {
                this.Hide();
            }
        }

        /** Method prevents problems with reopening feedback window after resending forms */
        private void FeedbackWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void FeedbackWindow_Shown(object sender, System.EventArgs e) {
            this.CenterToScreen();
        }
    }
}
