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
            this.fillInTheDropDownMenuWithAllTheDoctors();
            allTheDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
            this.prepareDateTimePickers(); 
        }

        /** Method prepares dateTime pickers to prevent setting absence with the date in the past */
        private void prepareDateTimePickers() {
            startDatePicker.MinDate = DateTime.Today.Date;
            endDatePicker.MinDate = DateTime.Today.Date;
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

            if ( this.checkTimeValidity()) {
                return;
            }

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

        /** 
         * Method wrapps the data from the presenters form into a model 
         * 
         * @return absence model 
         */
        private AbsenceModel getAbsenceModelFromPresenterForm() {
            AbsenceModel absence = new AbsenceModel();

            absence.endTime = endTimePicker.Value.ToString("HH:mm:ss");
            absence.startTime = startTimePicker.Value.ToString("HH:mm:ss");
            if (wholeDayCheckBox.Checked || ( !wholeDayCheckBox.Checked && (startTimePicker.Value.TimeOfDay == endTimePicker.Value.TimeOfDay) && (startDatePicker.Value.Date == endDatePicker.Value.Date))) {
                absence.startTime = "NULL";
                absence.endTime = "NULL";
            } else {
                absence.startTime = startTimePicker.Value.ToString("HH:mm:ss");
                absence.endTime = endTimePicker.Value.ToString("HH:mm:ss");
            }
            absence.reason = reasonText.Text;
            absence.staffId = (allTheDoctors.Enabled ? (int)allTheDoctors.SelectedValue : -1);
            absence.startDate = startDatePicker.Value.ToString("yyyy-MM-dd");
            absence.endDate = endDatePicker.Value.ToString("yyyy-MM-dd");
            if (singleDayCheckBox.Checked || (!singleDayCheckBox.Checked && startDatePicker.Value.Date == endDatePicker.Value.Date )) {
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

        /** Method displays feedback message if the end date is earlier than start date */
        private void endDatePicker_ValueChanged(object sender, EventArgs e) {
            if( endDatePicker.Value.Date < startDatePicker.Value.Date) {
                endDatePicker.Value = DateTime.Today.Date; 
                feedbackWindow.setCustomizedMessage("End date cannot be earlier than start date. Please correct the form.");
                feedbackWindow.Show(); 
            }
        }

        /** Method prevents setting earlier end time than start time */
        private void endTimePicker_ValueChanged(object sender, EventArgs e) {
            if( (endTimePicker.Value.TimeOfDay < startTimePicker.Value.TimeOfDay) && (startDatePicker.Value.Date == endDatePicker.Value.Date)) {
                endTimePicker.Value = startTimePicker.Value;
                feedbackWindow.setCustomizedMessage("End time cannot be earlier than start time while setting absence for the same day. End time was changed to equal start time ");
                feedbackWindow.Show();
            }
        }

        /** 
         * Method makes sure that start time and end time are valid 
         * 
         * @return validation of time from the form
         */
        private bool checkTimeValidity() {
            if( (endTimePicker.Value.TimeOfDay < startTimePicker.Value.TimeOfDay) && (startDatePicker.Value.Date == endDatePicker.Value.Date)) {
                endTimePicker.Value = startTimePicker.Value;
                feedbackWindow.setCustomizedMessage("End time cannot be earlier than start time while setting absence for the same day. End time was changed to equal start time ");
                feedbackWindow.Show();
                return true; 
            }
            return false;
        }
    }
}
