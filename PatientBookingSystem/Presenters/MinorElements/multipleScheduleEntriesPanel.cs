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
        List<string> errors = new List<string>();

        /** 
         * Constructor initializes components, fills in and prepares drop downs 
         */
        public multipleScheduleEntriesPanel() {
            InitializeComponent();
            this.modifyBreakTimes();
            this.prepareDropDowns();
        }

        /** 
         * Method prepares drop down for view 
         */
        private void prepareDropDowns() {
            this.fillInMonthsForYearFromToday();
            this.allTheStaffMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.fillInStaffMember();
        }


        private void modifyBreakTimes() {
            // Make a sensible logic for setting default fields value 
        }

        /** 
         * Method provides data source for staff member drop down (fills it in) 
         */
        private void fillInStaffMember() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";
        }

        /** 
         * Method provides data source containing months for a year from today 
         */
        private void fillInMonthsForYearFromToday() {
            List<DateTime> months = this.getMonthsForYearFromToday();
            monthsToApplySchedule.DisplayMember = "text";
            monthsToApplySchedule.ValueSeparator = ", ";
            foreach (DateTime entry in months) {
                monthsToApplySchedule.Items.Add(new ListDate { text = entry.ToString("MMMM yy").ToUpper(), id = entry });
            }
        }

        /** 
         * Method returns ids of months checked in the comboBox 
         * 
         * @return list of months to apply the schedule to 
         */
        private List<DateTime> getCheckedMonths() {
            List<DateTime> months = new List<DateTime>();
            foreach (ListDate item in monthsToApplySchedule.CheckedItems) {
                months.Add(item.id);
            }            
            return months;
        }

        /**
         *  Method initaties process of selected months validation 
         *  
         *  @param list of months
         */
        private void validateMonths(List<DateTime> months) {
            List<string> monthErrors = Validator.validateMultipleEntriesMonth(months);
            if (monthErrors.Count != 0) {
                foreach (string error in monthErrors) {
                    this.errors.Add(error);
                }
            }
        }

        /** 
         * Method returns a list of DateTime objects for 12 months from today 
         */
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

        /** 
         * Method initiaties processed for saving staffSchedule model 
         */
        private void saveScheduleButton_Click(object sender, EventArgs e) {
            this.errors = new List<string>();
            this.validateSelection();
            if (errors.Count == 0) {
                List<DateTime> selectedMonths = getCheckedMonths();
                int staffId = getSelectedStaffId();
                List<string> daysToBeScheduled = getDaysToBeScheduled();
                Dictionary<string, Dictionary<string, string>> timesPerDay = getTimesPerDay();
                List<int> scheduledDays = getScheduleIdsPerPeriod(selectedMonths, daysToBeScheduled, timesPerDay);
                if (this.saveStaffSchedules(staffId, scheduledDays)) {
                    clearAllTheFields();
                }
            } else {
                feedback.setMessageForInvalidFieldsValues(errors);
                feedback.Show();
            }
        }

        /** 
         * Method initaites the process of validating fields of the form  
         */
        private void validateSelection() {
            if( getSelectedStaffId() == 0) {
                this.errors.Add("staff member");
            }
            this.validateMonths(getCheckedMonths());
            this.validateSelectedDays(getDaysToBeScheduled());
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("monday", mondayWorkStartTime, mondayWorkEndTime, mondayBreakStartTime, mondayBreakEndTime));
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("tuesday", tuesdayWorkStartTime, tuesdayWorkEndTime, tuesdayBreakStartTime, tuesdayBreakEndTime));
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("wednesday", wednesdayWorkStartTime, wednesdayWorkEndTime, wednesdayBreakStartTime, wednesdayBreakEndTime));
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("thursday", thursdayWorkStartTime, thursdayWorkEndTime, thursdayBreakStartTime, thursdayBreakEndTime));
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("friday", fridayWorkStartTime, fridayWorkEndTime, fridayBreakStartTime, fridayBreakEndTime));
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("saturday", saturdayWorkStartTime, saturdayWorkEndTime, saturdayBreakStartTime, saturdayBreakEndTime));
            this.addDaysErrors(Validator.validateDayForScheduleMultipleEntries("sunday", sundayWorkStartTime, sundayWorkEndTime, sundayBreakStartTime, sundayBreakEndTime));
        }

        /** 
         * Method initiates the process of validating selected days
         * 
         * @param selectedDays list of days to be scheduled
         */
        private void validateSelectedDays(List<string> selectedDays) {
            if( selectedDays.Count == 0) {
                this.errors.Add("at least one day must be selected");
            }
        }

        /** 
         * Method add errors per day to the error property
         * 
         * @param list of errors per day
         */
        private void addDaysErrors(List<string> errorsPerDay) {
            if (errorsPerDay.Count != 0) {
                foreach (string error in errorsPerDay) {
                    errors.Add(error);
                }
            }
        }

        /** 
         * Method clears all the fields in the form 
         */
        private void clearAllTheFields() {
            allTheStaffMembers.SelectedIndex = 0;
            monthsToApplySchedule.Items.Clear();
            fillInMonthsForYearFromToday();
        }

        /** 
         * Method analyzes validation and based on result shows appropriate message to the user 
         * 
         * @param staffId 
         * @param scheduleDays list of days to be scheduled
         * 
         * @return result of saving
         */
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

        /** 
         * Method return list of schedule ids for passed period of time 
         */
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


        /** 
         * Method returns a dictionary of the times to be added to the schedule. 
         * 
         * @return dictionary of the shifts to be saved
         */
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

        /** 
         * Method returns days to be scheduled 
         * 
         * @returns list of the days to be scheduled 
         */
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

        /** 
         * Method returns staffId selected in staffMembers drop down 
         */
        private int getSelectedStaffId() {
            int staffId = ((ListItem)allTheStaffMembers.SelectedItem).id;
            if (staffId != 0) {
                return staffId;
            }
            return 0;
        }

        /** 
         * Method enables/disables Monday breaktimes 
         */
        private void mondayBreak_CheckedChanged(object sender, EventArgs e) {
            if (mondayWorkStartTime.Enabled) {
                mondayBreakStartTime.Enabled = !mondayBreak.Checked;
                mondayBreakEndTime.Enabled = !mondayBreak.Checked;
            } else {
                mondayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables Tuesday breaktimes 
         */
        private void tuesdayBreak_CheckedChanged(object sender, EventArgs e) {
            if (tuesdayWorkStartTime.Enabled) {
                tuesdayBreakStartTime.Enabled = !tuesdayBreak.Checked;
                tuesdayBreakEndTime.Enabled = !tuesdayBreak.Checked;
            } else {
                tuesdayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables WEdnesday breaktimes 
         */
        private void wednesdayBreak_CheckedChanged(object sender, EventArgs e) {
            if (wednesdayWorkStartTime.Enabled) {
                wednesdayBreakStartTime.Enabled = !wednesdayBreak.Checked;
                wednesdayBreakEndTime.Enabled = !wednesdayBreak.Checked;
            } else {
                wednesdayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables Thursday breaktimes 
         */
        private void thursdayBreak_CheckedChanged(object sender, EventArgs e) {
            if (thursdayWorkStartTime.Enabled) {
                thursdayBreakStartTime.Enabled = !thursdayBreak.Checked;
                thursdayBreakEndTime.Enabled = !thursdayBreak.Checked;
            } else {
                thursdayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables Friday breaktimes 
         */
        private void fridayBreak_CheckedChanged(object sender, EventArgs e) {
            if (fridayWorkStartTime.Enabled) {
                fridayBreakStartTime.Enabled = !fridayBreak.Checked;
                fridayBreakEndTime.Enabled = !fridayBreak.Checked;
            } else {
                fridayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables Saturday breaktimes 
         */
        private void saturdayBreak_CheckedChanged(object sender, EventArgs e) {
            if (saturdayWorkStartTime.Enabled) {
                saturdayBreakStartTime.Enabled = !saturdayBreak.Checked;
                saturdayBreakEndTime.Enabled = !saturdayBreak.Checked;
            } else {
                saturdayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables Sunday breaktimes 
         */
        private void sundayBreak_CheckedChanged(object sender, EventArgs e) {
            if (sundayWorkStartTime.Enabled) {
                sundayBreakStartTime.Enabled = !sundayBreak.Checked;
                sundayBreakEndTime.Enabled = !sundayBreak.Checked;
            } else {
                sundayBreak.Checked = true;
                feedback.setPromptToEnableDay();
                feedback.Show();
            }
        }

        /** 
         * Method enables/disables Monday as day to be scheduled 
         */
        private void monday_CheckedChanged(object sender, EventArgs e) {
            mondayWorkStartTime.Enabled = monday.Checked;
            mondayWorkEndTime.Enabled = monday.Checked;
        }

        /** 
         * Method enables/disables Tuesday as day to be scheduled 
         */
        private void tuesday_CheckedChanged(object sender, EventArgs e) {
            tuesdayWorkStartTime.Enabled = tuesday.Checked;
            tuesdayWorkEndTime.Enabled = tuesday.Checked;
        }

        /** 
         * Method enables/disables Wednesday as day to be scheduled 
         */
        private void wednesday_CheckedChanged(object sender, EventArgs e) {
            wednesdayWorkStartTime.Enabled = wednesday.Checked;
            wednesdayWorkEndTime.Enabled = wednesday.Checked;
        }

        /** 
         * Method enables/disables Thursday as day to be scheduled 
         */
        private void thursday_CheckedChanged(object sender, EventArgs e) {
            thursdayWorkStartTime.Enabled = thursday.Checked;
            thursdayWorkEndTime.Enabled = thursday.Checked;
        }

        /** 
         * Method enables/disables Friday as day to be scheduled 
         */
        private void friday_CheckedChanged(object sender, EventArgs e) {
            fridayWorkStartTime.Enabled = friday.Checked;
            fridayWorkEndTime.Enabled = friday.Checked;
        }

        /** 
         * Method enables/disables Saturday as day to be scheduled 
         */
        private void saturday_CheckedChanged(object sender, EventArgs e) {
            saturdayWorkStartTime.Enabled = saturday.Checked;
            saturdayWorkEndTime.Enabled = saturday.Checked;
        }

        /** 
         * Method enables/disables Sunday as day to be scheduled 
         */
        private void sunday_CheckedChanged(object sender, EventArgs e) {
            sundayWorkStartTime.Enabled = sunday.Checked;
            sundayWorkEndTime.Enabled = sunday.Checked;
        }
    }
}
