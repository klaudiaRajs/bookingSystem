using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Presenters.Interfaces;
using System.ComponentModel;
using System.Linq;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class appointmentCancellation : UserControl, AppointmentBoxI {
        BookingRepo bookingRepo = new BookingRepo();
        StaffRepo staffRepo = new StaffRepo();
        UserRepo userRepo = new UserRepo();
        BindingList<ListItem> patientList = new BindingList<ListItem>();
        BindingList<ListItem> staffMemberList = new BindingList<ListItem>();
        int selectedPatient = 0;
        int selectedDoctor = 0;

        public appointmentCancellation() {
            InitializeComponent();

            doctorsDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorsDropDown.DataSource = staffMemberList;
            doctorsDropDown.DisplayMember = "text";
            doctorsDropDown.ValueMember = "id";
            patientsDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            patientsDropDown.DataSource = patientList;
            patientsDropDown.DisplayMember = "text";
            patientsDropDown.ValueMember = "id";

            appointmentDatePicker.Value = DateTime.Today;
            changeDoctorList();
            changePatientList();
        }

        private void doctorCheck_CheckedChanged(object sender, EventArgs e) {
            doctorsDropDown.Enabled = doctorCheck.Checked;
            selectedDoctor = 0;

            changeDoctorList();
            changePatientList();
        }

        private void patientCheck_CheckedChanged(object sender, EventArgs e) {
            patientsDropDown.Enabled = patientCheck.Checked;
            selectedPatient = 0;

            changeDoctorList();
            changePatientList();
        }

        private List<IModel> getStaffMembers() {
            if (selectedPatient == 0) {
                return staffRepo.getAllStaffMembers();
            }

            List<IModel> bookings = bookingRepo.getDoctorsBasedOnPatient(selectedPatient);
            List<IModel> staffMembers = new List<IModel>();
            foreach (BookingModel booking in bookings) {
                staffMembers.Add(booking.getStaffModel());
            }
            return staffMembers;
        }

        private List<IModel> getPatients() {
            if (selectedDoctor == 0) {
                return userRepo.getListOfAllPatients();
            }

            return userRepo.getListOfPatientsHavingUpcomingAppointmentsForGivenDoctor(selectedDoctor);
        }

        private void changePatientList() {
            patientList.Clear();
            patientList.Add(new ListItem { text = "Select a patient", id = 0 });
            if (!patientCheck.Checked) {
                return;
            }

            int found = -1;
            List<IModel> patients = getPatients();
            for (int i=0; i<patients.Count; i++) {
                UserModel patient = (UserModel)patients[i];
                patientList.Add(new ListItem { text = patient.getFullName(), id = patient.getId() });
                if (selectedPatient == patient.getId()) {
                    found = i + 1;
                }
            }
            patientsDropDown.SelectedIndex = found == -1 ? 0 : found;
        }

        private void changeDoctorList() {
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
            doctorsDropDown.SelectedIndex = found == -1 ? 0 : found;
        }

        private void doctorsDropDown_SelectionChangeCommitted(object sender, EventArgs e) {
            selectedDoctor = doctorsDropDown.SelectedItem == null ? 0 : (doctorsDropDown.SelectedItem as ListItem).id;
            changePatientList();
        }

        private void patientsDropDown_SelectionChangeCommitted(object sender, EventArgs e) {
            selectedPatient = doctorsDropDown.SelectedItem == null ? 0 : (patientsDropDown.SelectedItem as ListItem).id;
            changeDoctorList();
        }

        private void searchButton_Click(object sender, EventArgs e) {
            getAppointmentBoxes();
        }

        private List<IModel> getAllTheBookingsForSearch() {
            int staffId = ((ListItem)doctorsDropDown.SelectedItem).id;
            DateTime date = appointmentDatePicker.Value.Date;
            int patientId = ((ListItem)patientsDropDown.SelectedItem).id;
            return bookingRepo.getAllUpcomingAppointmentsForSearch(staffId, date, patientId);
        }

        public void getAppointmentBoxes() {
            appointmentBoxesContainer.Controls.Clear();
            List<IModel> bookedAppointments = this.getAllTheBookingsForSearch();
            foreach (BookingModel booking in bookedAppointments) {
                string time = booking.getStartTime().Substring(0, 5) + " - " + booking.getEndTime().Substring(0, 5);
                appointmentBox box = new appointmentBox(this, booking, time);
                box.disableRescheduleButton();
                appointmentBoxesContainer.Controls.Add(box);
            }
        }
    }
}