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
using System.Collections;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    public partial class schedulePanel : UserControl {

        ScheduleController controller = new ScheduleController(DateTime.Today.ToString());
        AbsenceRepo absenceRepo = new AbsenceRepo();

        DateTime date = DateTime.Today;

        List<dayOfaWeekBox> dayBoxes = new List<dayOfaWeekBox>();

        public schedulePanel() {
            InitializeComponent();
            generateDayBoxes();
            fillInStaffMembers();
        }

        private void fillInStaffMembers() {
            ListItem comboBoxElements = new ListItem();
            allTheStaffMembers.DataSource = comboBoxElements.getDataSourceForAllStaffMembers();
            allTheStaffMembers.DisplayMember = "text";
            allTheStaffMembers.ValueMember = "id";

        }

        private void generateDayBoxes() {
            monthLabel.Text = date.ToString("MMMM").ToUpper();
            yearLabel.Text = date.ToString("yyyy").ToUpper();
            appointmentDaysPanel.Visible = false;
            foreach (int dayNo in this.getWorkingDays(this.date.Year, this.date.Month)) {
                string dateToBeAdded = new DateTime(this.date.Year, this.date.Month, dayNo).ToString("yyyy-MM-dd");
                List<IModel> absences = absenceRepo.getSurgeryAbsencesPerDate(dateToBeAdded);
                if (absences == null) {
                    dayOfaWeekBox dayBox = new dayOfaWeekBox();
                    appointmentDaysPanel.Controls.Add(dayBox.getBox(dayNo, this.date.Month, this.date.Year));
                    this.dayBoxes.Add(dayBox);
                }
            }
            appointmentDaysPanel.Visible = true;
        }

        private List<int> getWorkingDays(int year, int month) {
            DayOfWeek[] nonWorkingDays = new DayOfWeek[2] { DayOfWeek.Saturday, DayOfWeek.Sunday };
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

        private void reloadBoxDays() {
            appointmentDaysPanel.Controls.Clear();
            appointmentDaysPanel.Visible = false;
            generateDayBoxes();
            appointmentDaysPanel.Visible = true;
        }

        private void nextMonthButton_Click(object sender, EventArgs e) {
            this.date = this.date.AddMonths(1);
            reloadBoxDays();
        }

        private void previousMonthButton_Click(object sender, EventArgs e) {
            this.date = this.date.AddMonths(-1);
            reloadBoxDays();
        }

        private void morningAppointmentsCheckbox_CheckedChanged(object sender, EventArgs e) {
            foreach (dayOfaWeekBox box in dayBoxes) {
                if (box.morningAppointments == 0) {
                    if (isStaffMemberAvailable(box, (ListItem)allTheStaffMembers.SelectedItem)) {
                        box.Visible = !morningAppointmentsCheckbox.Checked;
                    }
                }
            }
        }

        private bool isStaffMemberAvailable(dayOfaWeekBox box, ListItem selectedStaffMember) {
            if (selectedStaffMember.id != 0) {
                foreach (StaffScheduleModel staffMember in box.staffMembersPerDate) {
                    if (staffMember.getStaffMember().getStaffId() == selectedStaffMember.id) {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        private bool areMorningAppointmentsRequestedAndAvailable(dayOfaWeekBox box) {
            if (morningAppointmentsCheckbox.Checked) {
                return (box.morningAppointments > 0);
            }
            return true;
        }

        private bool areAfternoonAppointmentsRequestedAndAvailable(dayOfaWeekBox box) {
            if (afternoonAppointmentsCheckbox.Checked) {
                return (box.morningAppointments > 0);
            }
            return true;
        }

        private void afternoonAppointmentsCheckbox_CheckedChanged(object sender, EventArgs e) {
            foreach (dayOfaWeekBox box in dayBoxes) {
                if (box.afternoonAppointments == 0) {
                    if (isStaffMemberAvailable(box, (ListItem)allTheStaffMembers.SelectedItem)) {
                        box.Visible = !afternoonAppointmentsCheckbox.Checked;
                    }
                }
            }
        }

        private void allTheStaffMembers_SelectedIndexChanged(object sender, EventArgs e) {
            if (allTheStaffMembers.SelectedIndex != 0) {
                foreach (dayOfaWeekBox box in dayBoxes) {
                    bool found = false;
                    foreach (StaffScheduleModel staffMember in box.staffMembersPerDate) {
                        if (staffMember.getStaffMember().getStaffId() == ((ListItem)allTheStaffMembers.SelectedItem).id) {
                            found = true;
                        }
                    }
                    if (areMorningAppointmentsRequestedAndAvailable(box) && areAfternoonAppointmentsRequestedAndAvailable(box)) {
                        box.Visible = found;
                    }
                }
            } else {
                foreach( dayOfaWeekBox box in dayBoxes) {
                    if (areMorningAppointmentsRequestedAndAvailable(box) && areAfternoonAppointmentsRequestedAndAvailable(box)) {
                        box.Visible = true;
                    }
                }
            }
        }
    }
}
