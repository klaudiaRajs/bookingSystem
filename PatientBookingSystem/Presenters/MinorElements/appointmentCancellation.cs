using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Presenters.Interfaces;
using System.ComponentModel;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is responsible for manipulating appointment cancellation presenter and communication with relevant controllers */
    public partial class appointmentCancellation : UserControl, AppointmentBoxI {

        BookingController bookingController = new BookingController();

        /** Lists of elements formatted for drop down lists */
        BindingList<ListItem> patientList = new BindingList<ListItem>();
        BindingList<ListItem> staffMemberList = new BindingList<ListItem>();

        int selectedPatient = 0;
        int selectedDoctor = 0;

        public appointmentCancellation() {
            InitializeComponent();
            this.provideInformationForDropDownLists();
            this.prepareAppointmentDatePicker();
            this.updateStaffMembersList();
            this.updatePatientList();
        }

        /** Method is responsible for preparing appointment date picker */
        private void prepareAppointmentDatePicker() {
            appointmentDatePicker.Value = DateTime.Today;
            appointmentDatePicker.MinDate = DateTime.Today;
        }

        /** Method provides data sources and display/value members for presenter's drop down lists */
        private void provideInformationForDropDownLists() {
            staffMemberDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            staffMemberDropDown.DataSource = staffMemberList;
            staffMemberDropDown.DisplayMember = "text";
            staffMemberDropDown.ValueMember = "id";
            patientsDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            patientsDropDown.DataSource = patientList;
            patientsDropDown.DisplayMember = "text";
            patientsDropDown.ValueMember = "id";
        }

        /** Method enables staffMembers drop down list and refreshes staffMembers and patients drop downs*/
        private void staffMemberCheck_CheckedChanged(object sender, EventArgs e) {
            staffMemberDropDown.Enabled = doctorCheck.Checked;
            selectedDoctor = 0;

            this.updateStaffMembersList();
            this.updatePatientList();
        }

        /** Method enables patients drop down list and refreshes staffMembers and patients drop downs*/
        private void patientCheck_CheckedChanged(object sender, EventArgs e) {
            patientsDropDown.Enabled = patientCheck.Checked;
            selectedPatient = 0;

            this.updateStaffMembersList();
            this.updatePatientList();
        }

        /** Method returns list of all the staff members */
        private List<IModel> getStaffMembers() {
            StaffController controller = new StaffController();
            if (selectedPatient == 0) {
                return controller.getAllStaffMembers();
            }

            List<IModel> bookings = bookingController.getStaffMembersBasedOnPatient(selectedPatient);
            List<IModel> staffMembers = new List<IModel>();
            foreach (BookingModel booking in bookings) {
                staffMembers.Add(booking.getStaffModel());
            }
            return staffMembers;
        }

        /** Method returns list of all patients */
        private List<IModel> getPatients() {
            UserController controller = new UserController();
            if (selectedDoctor == 0) {
                return controller.getListOfAllPatients();
            }

            return controller.getListOfPatientsHavingUpcomingAppointmentsForGivenStaffMember(selectedDoctor);
        }

        /** Method updates patients drop down list */
        private void updatePatientList() {
            patientList.Clear();
            patientList.Add(new ListItem { text = "Select a patient", id = 0 });
            if (!patientCheck.Checked) {
                return;
            }

            int found = -1;
            List<IModel> patients = getPatients();
            for (int i = 0; i < patients.Count; i++) {
                UserModel patient = (UserModel)patients[i];
                patientList.Add(new ListItem { text = patient.getFullName(), id = patient.getId() });
                if (selectedPatient == patient.getId()) {
                    found = i + 1;
                }
            }
            patientsDropDown.SelectedIndex = found == -1 ? 0 : found;
        }

        /** Method updates staff members drop down list */
        private void updateStaffMembersList() {
            staffMemberList.Clear();
            staffMemberList.Add(new ListItem { text = "Select a doctor", id = 0 });
            if (!doctorCheck.Checked) {
                return;
            }

            int found = -1;
            List<IModel> staffMembers = getStaffMembers();
            for (int i = 0; i < staffMembers.Count; i++) {
                StaffModel doctor = (StaffModel)staffMembers[i];
                staffMemberList.Add(new ListItem { text = doctor.getFullStaffName(), id = doctor.getStaffId() });
                if (selectedDoctor == doctor.getStaffId()) {
                    found = i + 1;
                }
            }
            staffMemberDropDown.SelectedIndex = found == -1 ? 0 : found;
        }

        /** Method updates selected doctor field and updates drop down list of patients */
        private void staffMembersDropDown_SelectionChangeCommitted(object sender, EventArgs e) {
            this.selectedDoctor = staffMemberDropDown.SelectedItem == null ? 0 : (staffMemberDropDown.SelectedItem as ListItem).id;
            this.updatePatientList();
        }

        /** Method updates selected patient field and updates drop down list of staff members */
        private void patientsDropDown_SelectionChangeCommitted(object sender, EventArgs e) {
            this.selectedPatient = staffMemberDropDown.SelectedItem == null ? 0 : (patientsDropDown.SelectedItem as ListItem).id;
            this.updateStaffMembersList();
        }

        /** Method fires generation of appointment booking boxes */
        private void searchButton_Click(object sender, EventArgs e) {
            this.getAppointmentBoxes();
        }

        /** Method generates appointment boxes meeting requirements from search parameters */
        public void getAppointmentBoxes() {
            List<IModel> bookedAppointments = this.getAllTheBookingsForSearch();
            appointmentBoxesContainer.Controls.Clear();
            if (bookedAppointments.Count != 0) {
                foreach (BookingModel booking in bookedAppointments) {
                    string time = booking.getStartTime().Substring(0, 5) + " - " + booking.getEndTime().Substring(0, 5);
                    appointmentBox box = new appointmentBox(this, booking, time);
                    box.disableRescheduleButton();
                    appointmentBoxesContainer.Controls.Add(box);
                    noAppointmentInformation.Visible = false;
                }
            } else {
                appointmentBoxesContainer.Controls.Add(noAppointmentInformation);
                noAppointmentInformation.Visible = true;
            }
        }

        /** Method returns list of bookings meeting requirements from search parameters */
        private List<IModel> getAllTheBookingsForSearch() {
            int staffId = ((ListItem)staffMemberDropDown.SelectedItem).id;
            DateTime date = appointmentDatePicker.Enabled ? appointmentDatePicker.Value.Date : new DateTime(1890, 12, 12);
            int patientId = ((ListItem)patientsDropDown.SelectedItem).id;
            return bookingController.getAllUpcomingAppointmentsForSearchParameters(staffId, date, patientId);
        }

        /** Method included into interface - not required in this implementation */
        public void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments) {
            //Implementation not required
        }

        /** Method disables/enables dateTime picker for search parametrs */
        private void dateCheck_CheckedChanged(object sender, EventArgs e) {
            appointmentDatePicker.Enabled = !dateCheck.Checked;
        }
    }
}