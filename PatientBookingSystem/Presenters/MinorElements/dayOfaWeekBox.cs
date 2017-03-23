using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using PatientBookingSystem.Presenters.MainViews;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;

namespace PatientBookingSystem {
    public partial class dayOfaWeekBox : UserControl {

        public int morningAppointments { get; set; } 
        public int afternoonAppointments { get; set; }
        string date;
        BookingRepo repo; 


        public dayOfaWeekBox() {
            InitializeComponent();
            this.repo = new BookingRepo(); 
        }

        public dayOfaWeekBox getBox(int dayNo, int month, int year) {
            DateTime dateObject = new DateTime(year, month, dayNo);
            this.date = dateObject.ToString("yyyy-MM-dd");
            dayNumber.Text = dayNo.ToString();
            //int numberOfMorningAppointments = 0;
            //int numberOfAfternoonAppointments = 0;
            //ScheduleController schedule = new ScheduleController(this.date);
            //Dictionary<int, List<ScheduleModel>> scheduleMap = schedule.getScheduleMap();
            //foreach (KeyValuePair<int, List<ScheduleModel>> entry in scheduleMap) {
            //    foreach (ScheduleModel item in entry.Value) {
            //        TimeSpan startTime = new TimeSpan(item.getStartDateTime().TimeOfDay.Hours, item.getStartDateTime().TimeOfDay.Minutes, item.getStartDateTime().TimeOfDay.Minutes);
            //        if (startTime > new TimeSpan(12, 0, 0)) {
            //            numberOfMorningAppointments++;
            //        } else {
            //            numberOfAfternoonAppointments++;
            //        }
            //    }
            //}
            //numberOfFreeAppointmentsLabel.Text = (numberOfMorningAppointments + numberOfAfternoonAppointments).ToString();
            //numberOfMorningAppointmentsLabel.Text = numberOfMorningAppointments.ToString();
            //numberOfAfternoonAppointmentsLabel.Text = numberOfAfternoonAppointments.ToString();
            return this;
        }

        private void openSingleDayAppointmentsView_Click(object sender, EventArgs e) {
            SingleScheduleDay singleDay = new SingleScheduleDay(null, this.date);
            singleDay.Show(); 
        }
    }
}
