using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing booking window view and communicating with relevant controllers */
    partial class BookingWindow : Form {

        private string date;
        private SingleScheduleDayWindow parent;
        private int staffScheduleId;

        /** Constructor assigns parameters to fields */
        public BookingWindow(SingleScheduleDayWindow parent, string date, string time, string doctorsName, string surgeryFirstLineOfAddress, string surgerySecondLineOfAddress, string surgeryPhoneNumber, int staffScheduleId) {
            InitializeComponent();
            this.date = date;
            dateBooking.Text = this.date;
            timeOfBooking.Text = time;
            doctorsNameLabel.Text = doctorsName;
            surgeryAddress1Line.Text = surgeryFirstLineOfAddress;
            surgeryAddressSecondLine.Text = surgerySecondLineOfAddress;
            surgeryPhoneNumberLabel.Text = surgeryPhoneNumber;
            this.parent = parent;
            this.staffScheduleId = staffScheduleId;
            if (ApplicationState.userType.Equals("admin")) {
                patientListBox.Visible = true;
                fillInListOfAllPatients();
            }
        }

        /** Method initiates process of saving a booking */
        private void saveBookingButton_Click(object sender, EventArgs e) {
            BookingController controller = new BookingController();
            string startTime = timeOfBooking.Text.Substring(0, 5);
            string endTime = timeOfBooking.Text.Substring(7);
            int userId = ApplicationState.userId;
            if (ApplicationState.userType == "admin") {
                userId = (int)patientListBox.SelectedValue;
            }
            bool result = false;
            result = controller.bookAppointment(0, commentTextField.Text, 0, startTime, endTime, userId, staffScheduleId, 0);
            this.reloadScheduleOrShowFeedbackWindowBasedOnResult(result);
        }

        /** Method reloads schedule or shows feedback windown based on result passed as parameter */
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

        /** Method provides data source for patient drop down list */
        private void provideDataSourceForPatientDropDown(List<ListItem> dataSource ) {
            patientListBox.DataSource = dataSource;
            patientListBox.DisplayMember = "text";
            patientListBox.ValueMember = "id";
        }
    }
}
