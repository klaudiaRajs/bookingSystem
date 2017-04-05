using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Presenters.MinorElements {

    /** Class is responsible for managing multipleScheduleEntriesPanel view and communicating with relevant controllers */
    public partial class multipleScheduleEntriesPanel : UserControl {

        ScheduleController scheduleController = new ScheduleController();
        FeedbackWindow feedback = new FeedbackWindow();

        /** Constructor initializes components, fills in and prepares drop downs */
        public multipleScheduleEntriesPanel() {
            InitializeComponent();
            this.modifyBreakTimes();
            this.prepareDropDowns();
        }

        /** Method prepares drop down for view */
        private void prepareDropDowns() {
            this.fillInMonthsForYearFromToday();
            this.allTheStaffMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.fillInStaffMember();
        }


        private void modifyBreakTimes() {
            // Make a sensible logic for setting default fields value 
        }

        /** Method provides data source for staff member drop down (fills it in) */
        private void fillInStaffMember() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";
        }

        /** Method provides data source containing months for a year from today */
        private void fillInMonthsForYearFromToday() {
            List<DateTime> months = this.getMonthsForYearFromToday();
            monthsToApplySchedule.DisplayMember = "text";
            monthsToApplySchedule.ValueSeparator = ", ";
            foreach (DateTime entry in months) {
                monthsToApplySchedule.Items.Add(new ListDate { text = entry.ToString("MMMM yy").ToUpper(), id = entry });
            }
        }

        /** Method returns ids of months checked in the comboBox */
        private List<DateTime> getCheckedMonths() {
            List<DateTime> months = new List<DateTime>();
            foreach (ListDate item in monthsToApplySchedule.CheckedItems) {
                months.Add(item.id);
            }
            return months;
        }

        /** Method returns a list of DateTime objects for 12 months from today */
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

        /** Method initiaties processed for saving staffSchedule model */
        private void saveScheduleButton_Click(object sender, EventArgs e) {
            List<DateTime> selectedMonths = getCheckedMonths();
            int staffId = getSelectedStaffId();
            List<string> daysToBeScheduled = getDaysToBeScheduled();
            Dictionary<string, Dictionary<string, string>> timesPerDay = getTimesPerDay();
            List<int> scheduledDays = getScheduleIdsPerPeriod(selectedMonths, daysToBeScheduled, timesPerDay);
            if (this.saveStaffSchedules(staffId, scheduledDays)) {
                clearAllTheFields();
            }
        }

        /** Method clears all the fields in the form */
        private void clearAllTheFields() {
            allTheStaffMembers.SelectedIndex = 0;
            monthsToApplySchedule.Items.Clear();
            fillInMonthsForYearFromToday();
        }

        /** Method analyzes validation and based on result shows appropriate message to the user  */ 
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

        /** Method return list of schedule ids for passed period of time */
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

        /** Method returns days to be scheduled */
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

        /** Method returns staffId selected in staffMembers drop down */
        private int getSelectedStaffId() {
            int staffId = ((ListItem)allTheStaffMembers.SelectedItem).id;
            if (staffId != 0) {
                return staffId;
            }
            FeedbackWindow feedback = new FeedbackWindow();
            feedback.setMessageForInvalidFieldsValues(new List<string> { "staff member" });
            feedback.Show();
            return 0;
        }

        /** Method enables/disables Monday breaktimes */
        private void mondayBreak_CheckedChanged(object sender, EventArgs e) {
            mondayBreakStartTime.Enabled = !mondayBreak.Checked;
            mondayBreakEndTime.Enabled = !mondayBreak.Checked;
        }

        /** Method enables/disables Tuesday breaktimes */
        private void tuesdayBreak_CheckedChanged(object sender, EventArgs e) {
            tuesdayBreakStartTime.Enabled = !tuesdayBreak.Checked;
            tuesdayBreakEndTime.Enabled = !tuesdayBreak.Checked;
        }

        /** Method enables/disables WEdnesday breaktimes */
        private void wednesdayBreak_CheckedChanged(object sender, EventArgs e) {
            wednesdayBreakStartTime.Enabled = !wednesdayBreak.Checked;
            wednesdayBreakEndTime.Enabled = !wednesdayBreak.Checked;
        }

        /** Method enables/disables Thursday breaktimes */
        private void thursdayBreak_CheckedChanged(object sender, EventArgs e) {
            thursdayBreakStartTime.Enabled = !thursdayBreak.Checked;
            thursdayBreakEndTime.Enabled = !thursdayBreak.Checked;
        }

        /** Method enables/disables Friday breaktimes */
        private void fridayBreak_CheckedChanged(object sender, EventArgs e) {
            fridayBreakStartTime.Enabled = !fridayBreak.Checked;
            fridayBreakEndTime.Enabled = !fridayBreak.Checked;
        }

        /** Method enables/disables Saturday breaktimes */
        private void saturdayBreak_CheckedChanged(object sender, EventArgs e) {
            saturdayBreakStartTime.Enabled = !saturdayBreak.Checked;
            saturdayBreakEndTime.Enabled = !saturdayBreak.Checked;
        }

        /** Method enables/disables Sunday breaktimes */
        private void sundayBreak_CheckedChanged(object sender, EventArgs e) {
            sundayBreakStartTime.Enabled = !sundayBreak.Checked;
            sundayBreakEndTime.Enabled = !sundayBreak.Checked;
        }

        /** Method enables/disables Monday as day to be scheduled */
        private void monday_CheckedChanged(object sender, EventArgs e) {
            mondayWorkStartTime.Enabled = monday.Checked;
            mondayWorkEndTime.Enabled = monday.Checked;
        }

        /** Method enables/disables Tuesday as day to be scheduled */
        private void tuesday_CheckedChanged(object sender, EventArgs e) {
            tuesdayWorkStartTime.Enabled = tuesday.Checked;
            tuesdayWorkEndTime.Enabled = tuesday.Checked;
        }

        /** Method enables/disables Wednesday as day to be scheduled */
        private void wednesday_CheckedChanged(object sender, EventArgs e) {
            wednesdayWorkStartTime.Enabled = wednesday.Checked;
            wednesdayWorkEndTime.Enabled = wednesday.Checked;
        }

        /** Method enables/disables Thursday as day to be scheduled */
        private void thursday_CheckedChanged(object sender, EventArgs e) {
            thursdayWorkStartTime.Enabled = thursday.Checked;
            thursdayWorkEndTime.Enabled = thursday.Checked;
        }

        /** Method enables/disables Friday as day to be scheduled */
        private void friday_CheckedChanged(object sender, EventArgs e) {
            fridayWorkStartTime.Enabled = friday.Checked;
            fridayWorkEndTime.Enabled = friday.Checked;
        }

        /** Method enables/disables Saturday as day to be scheduled */
        private void saturday_CheckedChanged(object sender, EventArgs e) {
            saturdayWorkStartTime.Enabled = saturday.Checked;
            saturdayWorkEndTime.Enabled = saturday.Checked;
        }

        /** Method enables/disables Sunday as day to be scheduled */
        private void sunday_CheckedChanged(object sender, EventArgs e) {
            sundayWorkStartTime.Enabled = sunday.Checked;
            sundayWorkEndTime.Enabled = sunday.Checked;
        }
    }
}
