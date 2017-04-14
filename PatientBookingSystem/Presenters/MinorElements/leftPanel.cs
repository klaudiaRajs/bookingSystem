using PatientBookingSystem.Helpers;
using System;
using System.Windows.Forms;

namespace PatientBookingSystem {
    /** Class is responsible for managing leftPanel element */
    public partial class leftPanel : UserControl {

        Main parent;

        /** Constructor prepares element base on user type */
        public leftPanel(Main parent) {
            InitializeComponent();
            if (ApplicationState.userType.Equals("admin")) {
                this.changePastAppointmentsToSurgeryManagementLabel();
            }
            this.parent = parent;
            if( ApplicationState.userType == "admin") {
                upcomingAppointmentsBox1.Visible = false;
            }
        }

        /** Method changes past appointments label to surgery management label */
        private void changePastAppointmentsToSurgeryManagementLabel() {
            historicAppointments.Text = "Surgery management";
        }

        /** Method loads schedule panel */
        private void MenuSchedule_Click_1(object sender, EventArgs e) {
            parent.loadSchedulePanel();
        }

        /** Method loads home panel */
        private void homeButton_Click(object sender, EventArgs e) {
            if (ApplicationState.userType == "admin") {
                parent.loadSurgeryManagementPanel();
            } else {
                parent.loadHomePanel();
            }
        }

        /** Method loads personal information panel */
        private void personalInformationButton_Click(object sender, EventArgs e) {
            parent.loadPersonalInformationPanel();
        }

        /** Method loads settings panel */
        private void settingsButton_Click(object sender, EventArgs e) {
            parent.loadSettingsPanel();
        }

        /** Method opens help window  */
        private void homeHelpButton_Click(object sender, EventArgs e) {
            HelpWindow help = new HelpWindow();
            help.Show();
        }

        /** Method loads upcoming appointments panel */
        private void upcomingUppointmentsButton_Click(object sender, EventArgs e) {
            parent.loadUpcomingAppointmentsPanel();
        }

        /** Method closes the application */
        private void logOutButton_Click(object sender, EventArgs e) {
            parent.exitApplication();
        }

        /** Method loads upcoming appointments panel when box with upcoming appointments is clicked  */
        private void upcomingAppointmentsHeader_Click(object sender, EventArgs e) {
            parent.loadUpcomingAppointmentsPanel();
        }

        /** Method decides if either surgery management panel or past appointmens panel should be loaded */
        private void historicAppointments_Click(object sender, EventArgs e) {
            if (ApplicationState.userType.Equals("admin")) {
                parent.loadSurgeryManagementPanel();
            } else {
                parent.loadPastAppointmentsPanel();
            }
        }
    }
}
