using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class singleEntrySchedulePanel : UserControl {
        FeedbackWindow feedback = new FeedbackWindow();

        public singleEntrySchedulePanel() {
            InitializeComponent();
            fillInAllTheStaffMembers();
            dateToBeScheduled.MinDate = DateTime.Today.Date;
            allTheStaffMembers.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fillInAllTheStaffMembers() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";
        }

        private void noBreakCheckBox_CheckedChanged(object sender, EventArgs e) {
            breakStartTime.Enabled = !noBreakCheckBox.Checked;
            breakEndTime.Enabled = !noBreakCheckBox.Checked;
        }

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
                    scheduleIdList.Add(controller.getScheduleId(schedule));
                }
                schedule.setStartTime(breakEndTime.Value.TimeOfDay.ToString());
                schedule.setEndTime(workEndTime.Value.TimeOfDay.ToString());
                if (controller.saveSchedule(schedule)) {
                    scheduleIdList.Add(controller.getScheduleId(schedule));
                }
            } else {
                schedule.setStartTime(workStartTime.Value.TimeOfDay.ToString());
                schedule.setEndTime(workEndTime.Value.TimeOfDay.ToString());
                controller.saveSchedule(schedule);
                scheduleIdList.Add(controller.getScheduleId(schedule));
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
