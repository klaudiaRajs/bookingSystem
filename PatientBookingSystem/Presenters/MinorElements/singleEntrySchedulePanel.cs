using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** 
     * Class is responsible for managing singleEntrySchedulePanel view 
     * and communicating changes to the other parts of the system 
     */
    public partial class singleEntrySchedulePanel : UserControl {

        private FeedbackWindow feedback = new FeedbackWindow();

        /** Constructor prepares the view by filling in the dropdowns and preparing elements */
        public singleEntrySchedulePanel() {
            InitializeComponent();
            fillInAllTheStaffMembers();
            prepareElementsOfTheView();
        }

        /** Method prepares elements of the view */ 
        private void prepareElementsOfTheView() {
            dateToBeScheduled.MinDate = DateTime.Today.Date;
            allTheStaffMembers.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /** Method fills in allthestaffMembers drop down */
        private void fillInAllTheStaffMembers() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";
        }

        /** Method enables/disables time pickers for break time */
        private void noBreakCheckBox_CheckedChanged(object sender, EventArgs e) {
            breakStartTime.Enabled = !noBreakCheckBox.Checked;
            breakEndTime.Enabled = !noBreakCheckBox.Checked;
        }

        /** Method performs actions preparing data for saving and the firing the process */
        private void saveButton_Click(object sender, EventArgs e) {
            ScheduleModel schedule = new ScheduleModel();
            ScheduleController controller = new ScheduleController();
            int staffId = ((ListItem)allTheStaffMembers.SelectedItem).id;
            if( staffId == 0) {
                feedback.setMessageForInvalidFieldsValues(new List<string>() { "staff member" });
                feedback.Show();
                return;
            }
            schedule.setDate(dateToBeScheduled.Value.Date.ToString("yyyy-MM-dd"));
            List<int> scheduleIdList = new List<int>();
            if (!noBreakCheckBox.Checked) {
                schedule.setStartTime(workStartTime.Value.TimeOfDay.ToString());
                schedule.setEndTime(breakStartTime.Value.TimeOfDay.ToString());
                if (controller.saveSchedule(schedule)) {
                    scheduleIdList.Add(controller.getScheduleIdBasedOnOtherScheduleInformation(schedule));
                }
                schedule.setStartTime(breakEndTime.Value.TimeOfDay.ToString());
                schedule.setEndTime(workEndTime.Value.TimeOfDay.ToString());
                if (controller.saveSchedule(schedule)) {
                    scheduleIdList.Add(controller.getScheduleIdBasedOnOtherScheduleInformation(schedule));
                }
            } else {
                schedule.setStartTime(workStartTime.Value.TimeOfDay.ToString());
                schedule.setEndTime(workEndTime.Value.TimeOfDay.ToString());
                controller.saveSchedule(schedule);
                scheduleIdList.Add(controller.getScheduleIdBasedOnOtherScheduleInformation(schedule));
            }

            List<bool> errors = controller.saveStaffSchedules(staffId, scheduleIdList);
            if( errors.Count == 0) {
                feedback.setMessageForSuccessfullOperation();
            } else {
                feedback.setMessageForSavingError();
            }
            feedback.Show();
        }
    }
}
