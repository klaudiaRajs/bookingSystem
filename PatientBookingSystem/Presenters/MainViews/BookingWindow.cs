using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** 
     * Class is responsible for managing booking window view and communicating with relevant controllers 
     */
    public partial class BookingWindow : Form {

        internal string date;
        private SingleScheduleDayWindow parent;
        private int staffScheduleId;
        private string doctorsName;

        /** 
         * Constructor assigns parameters to fields 
         * 
         * @param parent parent window 
         * @param date 
         * @param time 
         * @param doctorsName name of the staff member 
         * @param staffScheudleId
         */
        public BookingWindow(SingleScheduleDayWindow parent, string date, string time, string doctorsName, int staffScheduleId) {
            InitializeComponent();
            SurgeryInfo surgeryInfo = new SurgeryInfo();
            this.date = date;
            dateBooking.Text = this.date;
            timeOfBooking.Text = time;
            doctorsNameLabel.Text = doctorsName;
            surgeryAddress1Line.Text = surgeryInfo.getFirstLineOfAddress();
            surgeryAddressSecondLine.Text = surgeryInfo.getSecondLineOfAddress();
            surgeryPhoneNumberLabel.Text = surgeryInfo.getPhoneNumber();
            this.parent = parent;
            this.staffScheduleId = staffScheduleId;
            this.doctorsName = doctorsName;
            if (ApplicationState.userType.Equals("admin")) {
                patientListBox.Visible = true;
                fillInListOfAllPatients();
            }
            manageUserConfirmationSettings();
            this.CenterToScreen();
        }

        /** Method manages user confirmation settings */
        private void manageUserConfirmationSettings() {
            ApplicationState.refreshUser();
            string[] confirmationPreferances = ApplicationState.getConfirmationArray(); 
            if( Array.IndexOf(confirmationPreferances, "print") != -1) {
                printCheckBox.Checked = true;
            }
            if (Array.IndexOf(confirmationPreferances, "email") != -1) {
                emailCheckBox.Checked = true;
            }
        }

        /** Method initiates process of saving a booking */
        private void saveBookingButton_Click(object sender, EventArgs e) {
            BookingController controller = new BookingController();
            string startTime = timeOfBooking.Text.Substring(0, 5);
            string endTime = timeOfBooking.Text.Substring(7);
            int userId = ApplicationState.userId;
            if (ApplicationState.userType == "admin") {
                if( (int)patientListBox.SelectedValue == 0) {
                    FeedbackWindow message = new FeedbackWindow();
                    message.setCustomizedMessage("You are required to choose a patient");
                    message.Show();
                    return;
                } else {
                    userId = (int)patientListBox.SelectedValue;
                }
            }
            bool result = false;
            result = controller.bookAppointment(commentTextField.Text, startTime, endTime, userId, staffScheduleId);
            this.reloadScheduleOrShowFeedbackWindowBasedOnResult(result);
            if( result && (printCheckBox.Checked || emailCheckBox.Checked)) {
                PrintingPrompt printingPrompt = new PrintingPrompt(this.date, startTime, endTime, this.doctorsName, staffScheduleId );
                printingPrompt.Show();
            }
        }

        /** 
         * Method reloads schedule or shows feedback windown based on result passed as parameter 
         * 
         * @param result of saving the appointment
         */
        private void reloadScheduleOrShowFeedbackWindowBasedOnResult(bool result) {
            if (result) {
                parent.reloadSchedule();
                this.Close();
            } else {
                FeedbackWindow window = new FeedbackWindow();
                window.setMessageForBookingProblem();
                window.Show();
            }
        }

        /** Method fill the patient list in */
        private void fillInListOfAllPatients() {
            UserController controller = new UserController();
            List<IModel> users = controller.getAllUsers();
            users.OrderBy(user => (user as UserModel).getLastName());
            List<ListItem> patients = new List<ListItem>();
            patients.Insert(0, new ListItem { text = "Select a patient", id = 0 });
            foreach (UserModel user in users) {
                if (!user.getUserType().Equals("admin")) {
                    patients.Add(new ListItem { text = user.getFirstName() + " " + user.getLastName(), id = user.getId() });
                }
            }
            this.provideDataSourceForPatientDropDown(patients);
        }

        /** 
         * Method provides data source for patient drop down list 
         * 
         * @param dataSource date source for patient drop-down
         */
        private void provideDataSourceForPatientDropDown(List<ListItem> dataSource ) {
            patientListBox.DropDownStyle = ComboBoxStyle.DropDownList;
            patientListBox.DataSource = dataSource;
            patientListBox.DisplayMember = "text";
            patientListBox.ValueMember = "id";
        }

        /** Method allows the user to close the booking window by pressing escape button on the keyabord */
        private void BookingWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }
    }
}
