using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class multipleScheduleEntriesPanel : UserControl {

        ScheduleController scheduleController = new ScheduleController();
        FeedbackWindow feedback = new FeedbackWindow();

        public multipleScheduleEntriesPanel() {
            InitializeComponent();
            modifyBreakTimes();
            fillInMonthsForYearFromToday();
            allTheStaffMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            fillInStaffMember();
        }

        private void modifyBreakTimes() {
            // Make a sensible logic for setting default fields value 
        }

        private void fillInStaffMember() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";
        }

        private void fillInMonthsForYearFromToday() {
            List<DateTime> months = getMonthsForYearFromToday();
            monthsToApplySchedule.DisplayMember = "text";
            monthsToApplySchedule.ValueSeparator = ", ";
            foreach (DateTime entry in months) {
                monthsToApplySchedule.Items.Add(new ListDate { text = entry.ToString("MMMM yy").ToUpper(), id = entry });
            }
        }

        private List<DateTime> getCheckedMonths() {
            List<DateTime> months = new List<DateTime>();
            foreach (ListDate item in monthsToApplySchedule.CheckedItems) {
                months.Add(item.id);
            }
            return months;
        }

        private List<DateTime> getMonthsForYearFromToday() {
            DateTime date = DateTime.Today;
            List<DateTime> months = new List<DateTime>();
            months.Add(date);
            for (int i = 1; i < 12; i++) {
                date = date.AddMonths(1);
                months.Add(date);
            }
            return months;
        }

        private void saveScheduleButton_Click(object sender, EventArgs e) {
            List<DateTime> selectedMonths = getCheckedMonths();
            int staffId = getStaffId();
            List<string> daysToBeScheduled = getDaysToBeScheduled();
            Dictionary<string, Dictionary<string, string>> timesPerDay = getTimesPerDay();
            List<int> scheduledDays = getScheduleIdsPerPeriod(selectedMonths, daysToBeScheduled, timesPerDay);
            bool resultOfSavingStaffSchedules = saveStaffSchedules(staffId, scheduledDays);
            if (resultOfSavingStaffSchedules) {
                clearAllTheFields();
            }
        }

        private void clearAllTheFields() {
            allTheStaffMembers.SelectedIndex = 0;
            monthsToApplySchedule.Items.Clear();
            fillInMonthsForYearFromToday();
        }

        private bool saveStaffSchedules(int staffId, List<int> scheduledDays) {
            List<bool> errors = scheduleController.saveStaffSchedules(staffId, scheduledDays);
            if (errors.Count != 0) {
                feedback.setMessageForSavingError();
                feedback.Show();
                return false;
            }
            feedback.setMessageForSuccessfullOperation();
            feedback.Show();
            return true;
        }

        private List<int> getScheduleIdsPerPeriod(List<DateTime> monthsList, List<string> daysToBeScheduled, Dictionary<string, Dictionary<string, string>> timesPerDay) {
            List<int> scheduleIdList = new List<int>();
            if (monthsList.Count != 0) {
                foreach (DateTime date in monthsList) {
                    DateTime resetedDate = date;
                    if (date.Date != DateTime.Today.Date) {
                        resetedDate = new DateTime(date.Year, date.Month, 1);
                    }
                    while (resetedDate.Date <= DateHelper.convertToLastDayOfMonth(date)) {
                        bool result = false;
                        foreach (string day in daysToBeScheduled) {
                            if (resetedDate.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")).ToLower() == day.ToLower()) {
                                ScheduleModel schedule = new ScheduleModel();
                                schedule.setDate(resetedDate.ToString("yyyy-MM-dd"));
                                foreach (KeyValuePair<string, string> entry in timesPerDay[day.ToString()]) {
                                    schedule.setStartTime(entry.Key);
                                    schedule.setEndTime(entry.Value);
                                    result = scheduleController.saveSchedule(schedule);
                                    if (!result) {
                                        feedback.setMessageForSavingError();
                                        feedback.Show();
                                        return null;
                                    } else {
                                        int scheduleId = scheduleController.getScheduleIdBasedOnOtherScheduleInformation(schedule);
                                        scheduleIdList.Add(scheduleId);
                                    }
                                }
                            }
                        }
                        resetedDate = resetedDate.AddDays(1);
                    }
                }
            }
            return scheduleIdList;
        }


        private Dictionary<string, Dictionary<string, string>> getTimesPerDay() {
            Dictionary<string, Dictionary<string, string>> timesPerDay = new Dictionary<string, Dictionary<string, string>>();
            if (!mondayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(mondayWorkStartTime.Value.TimeOfDay.ToString(), mondayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(mondayBreakEndTime.Value.TimeOfDay.ToString(), mondayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(monday.Text, schedules);
            } else {
                timesPerDay.Add(monday.Text, (new Dictionary<string, string>() { { mondayWorkStartTime.Value.TimeOfDay.ToString(), mondayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            if (!tuesdayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(tuesdayWorkStartTime.Value.TimeOfDay.ToString(), tuesdayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(tuesdayBreakEndTime.Value.TimeOfDay.ToString(), tuesdayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(monday.Text, schedules);
            } else {
                timesPerDay.Add(tuesday.Text, (new Dictionary<string, string>() { { tuesdayWorkStartTime.Value.TimeOfDay.ToString(), tuesdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            if (!wednesdayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(wednesdayWorkStartTime.Value.TimeOfDay.ToString(), wednesdayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(wednesdayBreakEndTime.Value.TimeOfDay.ToString(), wednesdayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(wednesday.Text, schedules);
            } else {
                timesPerDay.Add(wednesday.Text, (new Dictionary<string, string>() { { wednesdayWorkStartTime.Value.TimeOfDay.ToString(), wednesdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            if (!thursdayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(thursdayWorkStartTime.Value.TimeOfDay.ToString(), thursdayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(thursdayBreakEndTime.Value.TimeOfDay.ToString(), thursdayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(thursday.Text, schedules);
            } else {
                timesPerDay.Add(thursday.Text, (new Dictionary<string, string>() { { thursdayWorkStartTime.Value.TimeOfDay.ToString(), thursdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            if (!fridayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(fridayWorkStartTime.Value.TimeOfDay.ToString(), fridayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(fridayBreakEndTime.Value.TimeOfDay.ToString(), fridayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(friday.Text, schedules);
            } else {
                timesPerDay.Add(friday.Text, (new Dictionary<string, string>() { { fridayWorkStartTime.Value.TimeOfDay.ToString(), fridayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            if (!saturdayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(saturdayWorkStartTime.Value.TimeOfDay.ToString(), saturdayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(saturdayBreakEndTime.Value.TimeOfDay.ToString(), saturdayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(saturday.Text, schedules);
            } else {
                timesPerDay.Add(saturday.Text, (new Dictionary<string, string>() { { saturdayWorkStartTime.Value.TimeOfDay.ToString(), saturdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            if (!sundayBreak.Checked) {
                Dictionary<string, string> schedules = new Dictionary<string, string>();
                schedules.Add(sundayWorkStartTime.Value.TimeOfDay.ToString(), sundayBreakStartTime.Value.TimeOfDay.ToString());
                schedules.Add(sundayBreakEndTime.Value.TimeOfDay.ToString(), sundayWorkEndTime.Value.TimeOfDay.ToString());
                timesPerDay.Add(sunday.Text, schedules);
            } else {
                timesPerDay.Add(sunday.Text, (new Dictionary<string, string>() { { sundayWorkStartTime.Value.TimeOfDay.ToString(), sundayWorkEndTime.Value.TimeOfDay.ToString() } }));
            }
            return timesPerDay;
        }

        private List<string> getDaysToBeScheduled() {
            List<string> selectedDays = new List<string>();
            if (monday.Checked) {
                selectedDays.Add(monday.Text);
            }
            if (tuesday.Checked) {
                selectedDays.Add(tuesday.Text);
            }
            if (wednesday.Checked) {
                selectedDays.Add(wednesday.Text);
            }
            if (thursday.Checked) {
                selectedDays.Add(thursday.Text);
            }
            if (friday.Checked) {
                selectedDays.Add(friday.Text);
            }
            if (saturday.Checked) {
                selectedDays.Add(saturday.Text);
            }
            if (sunday.Checked) {
                selectedDays.Add(sunday.Text);
            }
            return selectedDays;
        }

        private int getStaffId() {
            int staffId = ((ListItem)allTheStaffMembers.SelectedItem).id;
            if (staffId != 0) {
                return staffId;
            }
            FeedbackWindow feedback = new FeedbackWindow();
            feedback.setMessageForInvalidFieldsValues(new List<string> { "staff member" });
            feedback.Show();
            return 0;
        }

        private void mondayBreak_CheckedChanged(object sender, EventArgs e) {
            mondayBreakStartTime.Enabled = !mondayBreak.Checked;
            mondayBreakEndTime.Enabled = !mondayBreak.Checked;
        }

        private void tuesdayBreak_CheckedChanged(object sender, EventArgs e) {
            tuesdayBreakStartTime.Enabled = !tuesdayBreak.Checked;
            tuesdayBreakEndTime.Enabled = !tuesdayBreak.Checked;
        }

        private void wednesdayBreak_CheckedChanged(object sender, EventArgs e) {
            wednesdayBreakStartTime.Enabled = !wednesdayBreak.Checked;
            wednesdayBreakEndTime.Enabled = !wednesdayBreak.Checked;
        }

        private void thursdayBreak_CheckedChanged(object sender, EventArgs e) {
            thursdayBreakStartTime.Enabled = !thursdayBreak.Checked;
            thursdayBreakEndTime.Enabled = !thursdayBreak.Checked;
        }

        private void fridayBreak_CheckedChanged(object sender, EventArgs e) {
            fridayBreakStartTime.Enabled = !fridayBreak.Checked;
            fridayBreakEndTime.Enabled = !fridayBreak.Checked;
        }

        private void saturdayBreak_CheckedChanged(object sender, EventArgs e) {
            saturdayBreakStartTime.Enabled = !saturdayBreak.Checked;
            saturdayBreakEndTime.Enabled = !saturdayBreak.Checked;
        }

        private void sundayBreak_CheckedChanged(object sender, EventArgs e) {
            sundayBreakStartTime.Enabled = !sundayBreak.Checked;
            sundayBreakEndTime.Enabled = !sundayBreak.Checked;
        }

        private void monday_CheckedChanged(object sender, EventArgs e) {
            mondayWorkStartTime.Enabled = monday.Checked;
            mondayWorkEndTime.Enabled = monday.Checked;
        }

        private void tuesday_CheckedChanged(object sender, EventArgs e) {
            tuesdayWorkStartTime.Enabled = tuesday.Checked;
            tuesdayWorkEndTime.Enabled = tuesday.Checked;
        }

        private void wednesday_CheckedChanged(object sender, EventArgs e) {
            wednesdayWorkStartTime.Enabled = wednesday.Checked;
            wednesdayWorkEndTime.Enabled = wednesday.Checked;
        }

        private void thursday_CheckedChanged(object sender, EventArgs e) {
            thursdayWorkStartTime.Enabled = thursday.Checked;
            thursdayWorkEndTime.Enabled = thursday.Checked;
        }

        private void friday_CheckedChanged(object sender, EventArgs e) {
            fridayWorkStartTime.Enabled = friday.Checked;
            fridayWorkEndTime.Enabled = friday.Checked;
        }

        private void saturday_CheckedChanged(object sender, EventArgs e) {
            saturdayWorkStartTime.Enabled = saturday.Checked;
            saturdayWorkEndTime.Enabled = saturday.Checked;
        }

        private void sunday_CheckedChanged(object sender, EventArgs e) {
            sundayWorkStartTime.Enabled = sunday.Checked;
            sundayWorkEndTime.Enabled = sunday.Checked;
        }


    }
}
