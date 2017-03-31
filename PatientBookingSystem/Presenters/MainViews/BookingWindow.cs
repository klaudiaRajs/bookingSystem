using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
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
    partial class BookingWindow : Form {

        private string date;
        SingleScheduleDay parent;
        int staffScheduleId;

        public BookingWindow(SingleScheduleDay parent, string date, string time, string doctorsName, string surgeryFirstLineOfAddress, string surgerySecondLineOfAddress, string surgeryPhoneNumber, int staffScheduleId) {
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
            getListOfAllPatientsIfAdmin();
            //if( ApplicationState.bookingConfirmation[ApplicationState.bookingConfirmationMethod.print.ToString()]) {
            //    printCheckBox.Visible = true;
            //}
            //if (ApplicationState.bookingConfirmation[ApplicationState.bookingConfirmationMethod.email.ToString()]) {
            //    emailCheckBox.Visible = true;
            //}
        }

        private void saveBookingButton_Click(object sender, EventArgs e) {
            BookingController controller = new BookingController();
            string startTime = timeOfBooking.Text.Substring(0, 5);
            string endTime = timeOfBooking.Text.Substring(7);
            bool result = false;
            int userId = ApplicationState.userId;
            if (ApplicationState.userType == "admin") {
                userId = (int)patientListBox.SelectedValue;
            }
            result = controller.bookAppointment(0, commentTextField.Text, 0, startTime, endTime, userId, staffScheduleId, 0);
            if (result) {
                parent.reloadSchedule();
                this.Close();
            } else {
                FeedbackWindow window = new FeedbackWindow();
                window.setMessageForBooking();
                window.Show();
            }
        }

        //Zmien nazwe! Przenies if do kontruktora! (zaargumentuj dlaczego przenosic lub nie). Pole domyslnie ustaw jako Visible = false
        private void getListOfAllPatientsIfAdmin() {
            if (ApplicationState.userType.Equals("admin")) {
                UserController controller = new UserController();
                List<IModel> users = controller.getAllUsers();
                patientListBox.DisplayMember = "Text";
                patientListBox.ValueMember = "Value";
                users.OrderBy(user => (user as UserModel).getLastName());
                List<ListItem> patients = new List<ListItem>();
                patients.Insert(0, new ListItem { text = "Select a sector", id = 0 });
                foreach (UserModel user in users) {
                    if (!user.getUserType().Equals("admin")) {
                        patients.Add(new ListItem { text = user.getFirstName() + " " + user.getLastName(), id = user.getId() });
                    }
                }
                patientListBox.DataSource = patients;
                patientListBox.DisplayMember = "text";
                patientListBox.ValueMember = "id";
            } else {
                patientListBox.Visible = false;
            }
        }
    }
}
