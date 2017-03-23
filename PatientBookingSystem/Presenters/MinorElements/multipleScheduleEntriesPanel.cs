﻿using System;
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
        public multipleScheduleEntriesPanel() {
            InitializeComponent();
            fillInMonthsForYearFromToday();
            monthsToApplySchedule.DropDownStyle = ComboBoxStyle.DropDownList;
            fillInStaffMember();
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
            List<int> scheduledDays = getDatesForSelectedPeriod(selectedMonths, daysToBeScheduled, timesPerDay);
        }


        private List<int> getDatesForSelectedPeriod(List<DateTime> monthsList, List<string> daysToBeScheduled, Dictionary<string, Dictionary<string, string>> timesPerDay) {
            if (monthsList.Count != 0) {
                ScheduleController controller = new ScheduleController();
                List<int> scheduleIdList = new List<int>();
                foreach (DateTime date in monthsList) {
                    DateTime resetedDate = date;
                    if (date.Date != DateTime.Today.Date) {
                        resetedDate = new DateTime(date.Year, date.Month, 1);
                    }
                    while (resetedDate.Date <= DateHelper.convertToLastDayOfMonth(resetedDate)) {
                        bool result = false;
                        foreach (string day in daysToBeScheduled) {
                            if (resetedDate.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")).ToLower() == day.ToLower()) {
                                ScheduleModel schedule = new ScheduleModel();
                                schedule.setDate(resetedDate.ToString("yyyy-MM-dd"));
                                schedule.setStartTime(timesPerDay[day.ToString()].First().Key);
                                schedule.setEndTime(timesPerDay[day.ToString()].First().Value);
                                result = controller.saveSchedule(schedule);
                                if( !result) {
                                    FeedbackWindow feedback = new FeedbackWindow();
                                    feedback.setMessageForSavingError();
                                    feedback.Show();
                                    return null;
                                } else {
                                    int scheduleId = controller.getScheduleId(schedule); 
                                    scheduleIdList.Add(scheduleId); 
                                }
                            }
                        }
                        resetedDate = resetedDate.AddDays(1);
                    }
                }
            }
            return (new List<int> { });
        }


        private Dictionary<string, Dictionary<string, string>> getTimesPerDay() {
            Dictionary<string, Dictionary<string, string>> timesPerDay = new Dictionary<string, Dictionary<string, string>>();
            timesPerDay.Add(monday.Text, (new Dictionary<string, string>() { { mondayWorkStartTime.Value.TimeOfDay.ToString(), mondayWorkEndTime.Value.TimeOfDay.ToString() } }));
            timesPerDay.Add(tuesday.Text, (new Dictionary<string, string>() { { tuesdayWorkStartTime.Value.TimeOfDay.ToString(), tuesdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            timesPerDay.Add(wednesday.Text, (new Dictionary<string, string>() { { wednesdayWorkStartTime.Value.TimeOfDay.ToString(), wednesdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            timesPerDay.Add(thursday.Text, (new Dictionary<string, string>() { { thursdayWorkStartTime.Value.TimeOfDay.ToString(), thursdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            timesPerDay.Add(friday.Text, (new Dictionary<string, string>() { { fridayWorkStartTime.Value.TimeOfDay.ToString(), fridayWorkEndTime.Value.TimeOfDay.ToString() } }));
            timesPerDay.Add(saturday.Text, (new Dictionary<string, string>() { { saturdayWorkStartTime.Value.TimeOfDay.ToString(), saturdayWorkEndTime.Value.TimeOfDay.ToString() } }));
            timesPerDay.Add(sunday.Text, (new Dictionary<string, string>() { { sundayWorkStartTime.Value.TimeOfDay.ToString(), sundayWorkEndTime.Value.TimeOfDay.ToString() } }));
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
