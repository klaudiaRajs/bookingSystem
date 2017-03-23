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

namespace PatientBookingSystem {
    public partial class schedulePanel : UserControl {

        ScheduleController controller = new ScheduleController(DateTime.Today.ToString());
        AbsenceRepo absenceRepo = new AbsenceRepo();

        DateTime date = DateTime.Today;
        
        public schedulePanel() {
            InitializeComponent();
            generateDayBoxes();
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
    }
}
