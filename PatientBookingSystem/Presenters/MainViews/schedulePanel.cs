using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    /** Class is responsible for manipulation schedulePanel view and communicating with relevant controllers */
    public partial class schedulePanel : UserControl {
        
        DateTime date = DateTime.Today;

        /** List of all day boxes per month */
        List<dayOfaWeekBox> dayBoxes = new List<dayOfaWeekBox>();

        public schedulePanel() {
            InitializeComponent();
            generateDayBoxes();
            fillInStaffMembersDropDown();
        }

        /** Method provides data source for filling in staff member drop down */
        private void fillInStaffMembersDropDown() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";
        }
        
        /** Method generates boxes containing number of appointments and day */
        private void generateDayBoxes() {
            AbsenceRepo absenceRepo = new AbsenceRepo();
            monthLabel.Text = date.ToString("MMMM").ToUpper();
            yearLabel.Text = date.ToString("yyyy").ToUpper();
            appointmentDaysPanel.Visible = false;
            foreach (int dayNo in this.getWorkingDays(this.date.Year, this.date.Month)) {
                string dateToBeAdded = new DateTime(this.date.Year, this.date.Month, dayNo).ToString("yyyy-MM-dd");
                List<IModel> absences = absenceRepo.getSurgeryAbsencesPerDate(dateToBeAdded);
                if (absences == null) {
                    dayOfaWeekBox dayBox = new dayOfaWeekBox();
                    dayOfaWeekBox boxToBeDisplayed = dayBox.getBox(dayNo, this.date.Month, this.date.Year); 
                    if( boxToBeDisplayed.morningAppointments + boxToBeDisplayed.afternoonAppointments == 0) {
                        boxToBeDisplayed.BackColor = System.Drawing.Color.Silver; 
                        boxToBeDisplayed.Click -= new System.EventHandler(boxToBeDisplayed.openSingleDayAppointmentsView_Click);
                        boxToBeDisplayed.Click += new System.EventHandler(boxToBeDisplayed.openNoAppointmentsFeedbackMessage_Click);
                    }
                    appointmentDaysPanel.Controls.Add(boxToBeDisplayed);
                    this.dayBoxes.Add(dayBox);
                }
            }
            appointmentDaysPanel.Visible = true;
        }

        /** Method generates working days (according to surgery working days) per given month */
        private List<int> getWorkingDays(int year, int month) {
            DayOfWeek[] nonWorkingDays = SurgeryInfo.nonWorkingDays;
            List<int> workingDaysPerMonth = new List<int>();
            int numberOfDaysInMonth = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < numberOfDaysInMonth; i++) {
                DateTime day = new DateTime(year, month, i);
                if (!nonWorkingDays.Contains(day.DayOfWeek)) {
                    workingDaysPerMonth.Add(i);
                }
            }
            return workingDaysPerMonth;
        }

        /** Method reloads day boxes */
        private void reloadDayBoxes() {
            appointmentDaysPanel.Controls.Clear();
            appointmentDaysPanel.Visible = false;
            generateDayBoxes();
            appointmentDaysPanel.Visible = true;
        }

        /** Method changes date to following month */
        private void nextMonthButton_Click(object sender, EventArgs e) {
            this.date = this.date.AddMonths(1);
            reloadDayBoxes();
        }

        /** Method changes date to previous month */ 
        private void previousMonthButton_Click(object sender, EventArgs e) {
            this.date = this.date.AddMonths(-1);
            reloadDayBoxes();
        }

        /** Method filters results to days containing motning appointments */
        private void morningAppointmentsCheckbox_CheckedChanged(object sender, EventArgs e) {
            foreach (dayOfaWeekBox box in dayBoxes) {
                if (box.morningAppointments == 0) {
                    if (isStaffMemberAvailable(box, (ListItem)allTheStaffMembers.SelectedItem)) {
                        box.Visible = !morningAppointmentsCheckbox.Checked;
                    }
                }
            }
        }

        /** Method filters results to days containing appointments for selected staff member */
        private bool isStaffMemberAvailable(dayOfaWeekBox box, ListItem selectedStaffMember) {
            if (selectedStaffMember.id != 0) {
                foreach(  KeyValuePair<int, string> entry in box.staffMembersPerDate) {
                    if( entry.Key == selectedStaffMember.id ) {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        /** Method checks if there are any morning appointmnets in given dayBox */
        private bool areMorningAppointmentsRequestedAndAvailable(dayOfaWeekBox box) {
            if (morningAppointmentsCheckbox.Checked) {
                return (box.morningAppointments > 0);
            }
            return true;
        }

        /** Method checks if there are any afternoon appointments in given dayBox */
        private bool areAfternoonAppointmentsRequestedAndAvailable(dayOfaWeekBox box) {
            if (afternoonAppointmentsCheckbox.Checked) {
                return (box.morningAppointments > 0);
            }
            return true;
        }

        /** Method hides/shows day boxes meeting requirement of containing afternoon appointments */ 
        private void afternoonAppointmentsCheckbox_CheckedChanged(object sender, EventArgs e) {
            foreach (dayOfaWeekBox box in dayBoxes) {
                if (box.afternoonAppointments == 0) {
                    if (isStaffMemberAvailable(box, (ListItem)allTheStaffMembers.SelectedItem)) {
                        box.Visible = !afternoonAppointmentsCheckbox.Checked;
                    }
                }
            }
        }

        /** Method hides/shows day boxes meeting requirement of containing appointments with selected doctor */
        private void allTheStaffMembers_SelectedIndexChanged(object sender, EventArgs e) {
            if (allTheStaffMembers.SelectedIndex != 0) {
                foreach (dayOfaWeekBox box in dayBoxes) {
                    bool found = false;
                    foreach( KeyValuePair<int, string> entry in box.staffMembersPerDate) {
                        if( entry.Key == ((ListItem)allTheStaffMembers.SelectedItem).id) {
                            found = true;
                        }
                    }
                    if (areMorningAppointmentsRequestedAndAvailable(box) && areAfternoonAppointmentsRequestedAndAvailable(box)) {
                        box.Visible = found;
                    }
                }
            } else {
                foreach (dayOfaWeekBox box in dayBoxes) {
                    if (areMorningAppointmentsRequestedAndAvailable(box) && areAfternoonAppointmentsRequestedAndAvailable(box)) {
                        box.Visible = true;
                    }
                }
            }
        }
    }
}
