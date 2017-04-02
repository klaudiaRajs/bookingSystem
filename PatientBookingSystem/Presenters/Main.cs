using System;
using System.Windows.Forms;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Presenters;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    /** Entry point to the system */ 
    public partial class Main : Form {
        const string helpMessageForLoggin = " Your login and password should be obtained from your surgery."
            + "Please contact the surgery if the one provided by them doesn't work";

        public Main() {
            InitializeComponent();
            HomePanel.Visible = false;
            LogInPanel.Visible = true;
        }

        /** Method loads upcoming appointments panel */ 
        public void loadUpcomingAppointmentsPanel() {
            windowContentContainer.Controls.Clear();
            upcomingAppointmentsContainer upcomingAppointments = new upcomingAppointmentsContainer(this);
            upcomingAppointments.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(upcomingAppointments);
        }

        /** Method is responsible for starting process of logging the user in or showing feedback message */ 
        private void logInButton_Click(object sender, EventArgs e) {
            Logger logger = new Logger();
            FeedbackWindow message = new FeedbackWindow();
            try {
                if (Validator.validateLogger(loginField.Text, passwordField.Text)) {
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
                        message.Show();
                    }
                } else {
                    message.setCustomizedMessage(Validator.getEmptyLoginMessage());
                    message.Show();
                }
            }
            catch (Exception) {
                message.setMessageForExceptionReporting();
                message.Show();
            }
        }

        /** Method is responsible for exit application */
        public void exitApplication() {
            Application.Exit();
        }

        /** Method loads schedule panel */
        public void loadSchedulePanel() {
            windowContentContainer.Controls.Clear();
            schedulePanel scheduleA = new schedulePanel();
            scheduleA.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(scheduleA);
        }

        /** Method loads surgery management panel */
        public void loadSurgeryManagementPanel() {
            windowContentContainer.Controls.Clear();
            surgeryManagement management = new surgeryManagement();
            management.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(management);
        }

        /** Method loads past appointments panel */
        public void loadPastAppointmentsPanel() {
            windowContentContainer.Controls.Clear();
            pastAppointmentsPanel history = new pastAppointmentsPanel(this);
            history.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(history);
        }

        /** Method loads settings panel */
        public void loadSettingsPanel() {
            windowContentContainer.Controls.Clear();
            settingsPanel settings = new settingsPanel();
            settings.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(settings);
        }

        /** Method loads personal information panel */
        public void loadPersonalInformationPanel() {
            windowContentContainer.Controls.Clear();
            personalInformationPanel personalInformation = new personalInformationPanel();
            personalInformation.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(personalInformation);
        }

        /** Method loads home panel */
        public void loadHomePanel() {
            windowContentContainer.Controls.Clear();
            homePanel home = new homePanel();
            home.Dock = DockStyle.Fill;
            windowContentContainer.Controls.Add(home);
        }

        /** Method loads initial information panel */
        private void loadInitialInformationPanel() {
            initialInstructionsPanel instruction = new initialInstructionsPanel();
            instruction.Dock = DockStyle.Fill;
            dockOfHeader.Controls.Add(instruction);
        }

        /** Method loads left panel of main window */
        private void loadLeftPanel() {
            leftPanel leftPanel = new leftPanel(this);
            leftPanel.Dock = DockStyle.Fill;
            leftPanelContainer.Controls.Add(leftPanel);
        }

        /** Method fires logInButton_Click event on pressing enter on the keyboard */
        private void loginField_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                logInButton_Click(this, new EventArgs());
            }
        }

        /** Method closes application */
        private void exitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        /** Method shows up a help window */
        private void helpButton_Click(object sender, EventArgs e) {
            Help help = new Help();
            help.setHelpMessage(helpMessageForLoggin);
            help.Show();
        }
    }
}
