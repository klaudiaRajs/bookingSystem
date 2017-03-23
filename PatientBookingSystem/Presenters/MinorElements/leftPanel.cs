using PatientBookingSystem.Helpers;
using System;
using System.Windows.Forms;

namespace PatientBookingSystem {
    public partial class leftPanel : UserControl {
        Main parent;

        public leftPanel(Main parent) {
            InitializeComponent();
            if (ApplicationState.userType.Equals("admin")) {
                historicAppointments.Text = "Surgery management";
            }
            this.parent = parent;
        }

        private void MenuSchedule_Click_1(object sender, EventArgs e) {
            parent.loadSchedulePanel();
        }

        private void homeButton_Click(object sender, EventArgs e) {
            parent.loadHomePanel();
        }

        private void personalInformationButton_Click(object sender, EventArgs e) {
            parent.loadPersonalInformationPanel();
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            parent.loadSettingsPanel();
        }

        private void homeHelpButton_Click(object sender, EventArgs e) {
            Help help = new Help();
            help.Show();
        }

        private void upcomingUppointmentsButton_Click(object sender, EventArgs e) {
            parent.loadUpcomingAppointmentsPanel();
        }

        private void logOutButton_Click(object sender, EventArgs e) {
            parent.logOut();
        }

        private void upcomingAppointmentsHeader_Click(object sender, EventArgs e) {
            parent.loadUpcomingAppointmentsPanel();
        }

        private void historicAppointments_Click(object sender, EventArgs e) {
            if (ApplicationState.userType.Equals("admin")) {
                parent.loadSurgeryManagementPanel();
            } else {
                parent.loadPastAppointmentsPanel();
            }
        }
    }
}
