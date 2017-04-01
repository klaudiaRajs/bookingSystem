using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using System.Collections;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class addStaffExceptionDay : UserControl {

        FeedbackWindow feedbackWindow;
        List<string> invalidFields = new List<string>();
        AbsenceController controller;

        public addStaffExceptionDay() {
            InitializeComponent();
            fillInTheDropDownMenuWithAllTheDoctors();
            this.feedbackWindow = new FeedbackWindow();
            controller = new AbsenceController();
            allTheDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fillInTheDropDownMenuWithAllTheDoctors() {
            List<IModel> staffMembers = getAllStaffMembers();
            allTheDoctors.DisplayMember = "Text";
            allTheDoctors.ValueMember = "Value";
            staffMembers.OrderBy(staffMember => (staffMember as StaffModel).getLastName());
            List<ListItem> doctors = new List<ListItem>();
            doctors.Insert(0, new ListItem { text = "Select a doctor", id = 0 });
            foreach (StaffModel staffMember in staffMembers) {
                doctors.Add(new ListItem { text = staffMember.getFullStaffName(), id = staffMember.getStaffId() });
            }
            allTheDoctors.DataSource = doctors;
            allTheDoctors.DisplayMember = "text";
            allTheDoctors.ValueMember = "id";
        }

        private List<IModel> getAllStaffMembers() {
            StaffController controller = new StaffController();
            return controller.getAllStaffMembers();
        }



        private void saveButton_Click(object sender, EventArgs e) {
            AbsenceModel absence = new AbsenceModel();
            if (allTheDoctors.Enabled) {
                invalidFields = controller.isDataValid(startDatePicker, endDatePicker, startTimePicker, endTimePicker, invalidFields, allTheDoctors);
            } else {
                invalidFields = controller.isDataValid(startDatePicker, endDatePicker, startTimePicker, endTimePicker, invalidFields);
            }
            if (invalidFields == null || invalidFields.Count == 0) {
                absence.endTime = endTimePicker.Value.ToString("HH:mm:ss");
                absence.startTime = startTimePicker.Value.ToString("HH:mm:ss");
                if (wholeDayCheckBox.Enabled) {
                    absence.startTime = "NULL";
                    absence.endTime = "NULL";
                }
                absence.reason = reasonText.Text;
                absence.staffId = (allTheDoctors.Enabled ? (int)allTheDoctors.SelectedValue : -1);
                absence.startDate = startDatePicker.Value.ToString("yyyy-MM-dd");
                absence.endDate = endDatePicker.Value.ToString("yyyy-MM-dd");
                if (singleDayCheckBox.Enabled) {
                    absence.endDate = "NULL";
                }

                if (!controller.save(absence)) {
                    this.feedbackWindow.setMessageForAbsencesProblems();
                } else {
                    this.feedbackWindow.setMessageForSuccessfullOperation();
                }
            } else {
                feedbackWindow.setMessageForInvalidFieldsValues(invalidFields);
            }
            feedbackWindow.Show();
        }


        private void wholeDayCheckBox_CheckedChanged(object sender, EventArgs e) {
            startTimePicker.Enabled = !wholeDayCheckBox.Checked;
            endTimePicker.Enabled = !wholeDayCheckBox.Checked;
        }

        private void singleDayCheckBox_CheckedChanged(object sender, EventArgs e) {
            endDatePicker.Enabled = !singleDayCheckBox.Checked;
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e) {
            endDatePicker.Value = startDatePicker.Value;
        }

        private void wholeSurgeryCheckBox_CheckedChanged(object sender, EventArgs e) {
            allTheDoctors.Enabled = !wholeSurgeryCheckBox.Checked;
        }
    }
}
