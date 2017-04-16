using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Presenters;

namespace PatientBookingSystem {
    /** Class is responsible for managing the setting panel view */
    public partial class settingsPanel : UserControl {

        private enum verificationOptions { call = 1, email = 0 };
        private enum confirmationOptions { email = 0, print = 1 };
        UserController controller = new UserController();

        public settingsPanel() {
            InitializeComponent();
            fillInSettingsBasedOnUserData();
            adjustAvailableConfirmationMethods();
        }

        /** Method adjusts available confirmation methods */
        private void adjustAvailableConfirmationMethods() {
            emailConfirmation.Enabled = settingsPanel.confirmationOptions.email != 0;
            printableConfirmation.Enabled = settingsPanel.confirmationOptions.print != 0;
        }

        /** Method adjusts available confirmation methods */
        private void adjustAvailableVerificationMethods() {
            emailVerification.Enabled = settingsPanel.verificationOptions.email != 0;
            onThePhoneVerification.Enabled = settingsPanel.verificationOptions.call != 0;
        }

        /** Method is responsible for filling in settings for logged in user*/
        private void fillInSettingsBasedOnUserData() {
            ApplicationState.refreshUser();
            string notifications = ApplicationState.notifications;
            string verification = ApplicationState.verifications;
            string confirmation = ApplicationState.confirmations;
            if (oneWeekNotificationCheckBox.Enabled && notifications.Contains("1week")) {
                oneWeekNotificationCheckBox.Checked = true;
            }
            if (sameDayNotification.Enabled && notifications.Contains("1day")) {
                sameDayNotification.Checked = true;
            }
            if (onThePhoneVerification.Enabled && verification.Contains(settingsPanel.verificationOptions.call.ToString())) {
                onThePhoneVerification.Checked = true;
            }
            if (emailVerification.Enabled && verification.Contains(settingsPanel.verificationOptions.email.ToString())) {
                emailVerification.Checked = true;
            }
            if (emailConfirmation.Enabled && confirmation.Contains(settingsPanel.confirmationOptions.email.ToString())) {
                emailConfirmation.Checked = true;
            }
            if (printableConfirmation.Enabled && confirmation.Contains(settingsPanel.confirmationOptions.print.ToString())) {
                printableConfirmation.Checked = true;
            }
        }

        /** Method is responsible for initiation of the process of saving the settings */
        private void saveUserSettings_Click(object sender, EventArgs e) {
            List<string> notification = new List<string>();
            List<string> verification = new List<string>();
            List<string> confirmation = new List<string>();

            if (onThePhoneVerification.Enabled && onThePhoneVerification.Checked) {
                verification.Add(settingsPanel.verificationOptions.call.ToString());
            }
            if (emailVerification.Enabled && emailVerification.Checked) {
                verification.Add(settingsPanel.verificationOptions.email.ToString());
            }
            if (printableConfirmation.Enabled && printableConfirmation.Checked) {
                confirmation.Add(settingsPanel.confirmationOptions.print.ToString());
            }
            if (emailConfirmation.Enabled && emailConfirmation.Checked) {
                confirmation.Add(settingsPanel.confirmationOptions.email.ToString());
            }

            FeedbackWindow feedback = new FeedbackWindow();
            if (!controller.saveSettings(notification, verification, confirmation)) {
                feedback.setMessageForSavingError();
            } else {
                feedback.setMessageForSuccessfullOperation();
            }
            feedback.Show();
            fillInSettingsBasedOnUserData();
        }
    }
}
