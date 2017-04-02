using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is reponsible for managing addStaffExceptionDay view */
    public partial class addStaffExceptionDay : UserControl {

        private FeedbackWindow feedbackWindow;

        /** Method constructs the class and fills the doctors menu */
        public addStaffExceptionDay() {
            InitializeComponent();
            this.feedbackWindow = new FeedbackWindow();
            fillInTheDropDownMenuWithAllTheDoctors();
            allTheDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /** Method fills in the drop down menu with doctors */
        private void fillInTheDropDownMenuWithAllTheDoctors() {
            ListItem sourceLists = new ListItem();
            allTheDoctors.DataSource = sourceLists.getDataSourceForAllStaffMembers();
            allTheDoctors.DisplayMember = "text";
            allTheDoctors.ValueMember = "id";
        }

        /** Method initializes a process of saving and absance model to the database */
        private void saveButton_Click(object sender, EventArgs e) {
            AbsenceModel absence = this.getAbsenceModelFromPresenterForm();
            List<string> invalidFields = new List<string>();
            AbsenceController controller = new AbsenceController();

            if (allTheDoctors.Enabled) {
                invalidFields = controller.isDataValid(startDatePicker, endDatePicker, startTimePicker, endTimePicker, invalidFields, allTheDoctors);
            } else {
                invalidFields = controller.isDataValid(startDatePicker, endDatePicker, startTimePicker, endTimePicker, invalidFields);
            }
            if (invalidFields == null || invalidFields.Count == 0) {
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

        /** Method wrapps the data from the presenters form into a model */
        private AbsenceModel getAbsenceModelFromPresenterForm() {
            AbsenceModel absence = new AbsenceModel();

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
            return absence;
        }

        /** Method enables/disables time pickers if the absence is set to whole day  */
        private void wholeDayCheckBox_CheckedChanged(object sender, EventArgs e) {
            startTimePicker.Enabled = !wholeDayCheckBox.Checked;
            endTimePicker.Enabled = !wholeDayCheckBox.Checked;
        }

        /** Method enables/disables end date picker if the absence covers only single day */
        private void singleDayCheckBox_CheckedChanged(object sender, EventArgs e) {
            endDatePicker.Enabled = !singleDayCheckBox.Checked;
        }

        /** Method changes value of end date if start date is changed (to make sure that end date won't be earlier than start date) */
        private void startDatePicker_ValueChanged(object sender, EventArgs e) {
            endDatePicker.Value = startDatePicker.Value;
        }

        /** Method enables/disables staff members drop down list if the absence is to be set for the whole surgery */
        private void wholeSurgeryCheckBox_CheckedChanged(object sender, EventArgs e) {
            allTheDoctors.Enabled = !wholeSurgeryCheckBox.Checked;
        }
    }
}
