using System;
using System.Windows.Forms;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Presenters;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    public partial class Main : Form {
        const string helpMessageForLoggin = " Your login and password should be obtained from your surgery."
            + "Please contact the surgery if the one provided by them doesn't work";

        public Main() {
            InitializeComponent();
            HomePanel.Visible = false;
            LogInPanel.Visible = true;
        }

        public void handleLogIn() {

        }

        public void loadUpcomingAppointmentsPanel() {
            windowContentContainer.Controls.Clear();
            upcomingAppointmentsContainer upcomingAppointments = new upcomingAppointmentsContainer(this);
            upcomingAppointments.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(upcomingAppointments);
        }

        private void logInButton_Click(object sender, EventArgs e) {
            // Loading the initial, home page. 
            Logger logger = new Logger();
            if (logger.logUserIn(loginField.Text, passwordField.Text) == true) {
                LogInPanel.Visible = false;
                HomePanel.Visible = true;
                loadLeftPanel();
                loadInitialInformationPanel();
                if (ApplicationState.userType != "admin") {
                    loadHomePanel();
                } else {
                    loadSurgeryManagementPanel();
                }
            } else {
                FeedbackWindow message = new FeedbackWindow();
                message.Show();
            }
        }

        public void logOut() {
            Application.Exit();
        }

        public void loadSchedulePanel() {
            windowContentContainer.Controls.Clear();
            schedulePanel scheduleA = new schedulePanel();
            scheduleA.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(scheduleA);
        }

        public void loadSurgeryManagementPanel() {
            windowContentContainer.Controls.Clear();
            surgeryManagement management = new surgeryManagement();
            management.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(management);
        }

        public void loadPastAppointmentsPanel() {
            windowContentContainer.Controls.Clear();
            pastAppointmentsPanel history = new pastAppointmentsPanel(this);
            history.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(history);
        }

        public void loadSettingsPanel() {
            windowContentContainer.Controls.Clear();
            settingsPanel settings = new settingsPanel();
            settings.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(settings);
        }

        public void loadPersonalInformationPanel() {
            windowContentContainer.Controls.Clear();
            personalInformationPanel personalInformation = new personalInformationPanel();
            personalInformation.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(personalInformation);
        }

        public void loadHomePanel() {
            windowContentContainer.Controls.Clear();
            homePanel home = new homePanel();
            home.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(home);
        }

        private void loadInitialInformationPanel() {
            initialInstructionsPanel instruction = new initialInstructionsPanel();
            instruction.Dock = DockStyle.Fill;
            dockOfHeader.Controls.Add(instruction);
        }

        private void loadLeftPanel() {
            leftPanel leftPanel = new leftPanel(this);
            leftPanel.Dock = DockStyle.Fill;
            leftPanelContainer.Controls.Add(leftPanel);
        }

        private void loginField_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                logInButton_Click(this, new EventArgs());
            }
        }

        private void exitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void helpButton_Click(object sender, EventArgs e) {
            Help help = new Help();
            help.setHelpMessage(helpMessageForLoggin);
            help.Show();
        }
    }
}
