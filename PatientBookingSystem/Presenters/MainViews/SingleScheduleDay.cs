using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.Interfaces;
using PatientBookingSystem.Presenters.MinorElements;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    partial class SingleScheduleDay : Form {
        int lengthOfRegularAppointment;
        SurgeryInfo surgeryInfo;
        ScheduleController controller;
        TimeSpan surgeryOpeningTime;
        TimeSpan surgeryClosingTIme;
        string date;
        AppointmentBoxI parent;

        public SingleScheduleDay(AppointmentBoxI parent, string date) {
            InitializeComponent();
            this.parent = parent;
            this.date = date;
            surgeryInfo = new SurgeryInfo();
            surgeryOpeningTime = surgeryInfo.openingTime;
            surgeryClosingTIme = surgeryInfo.closingTime;
            lengthOfRegularAppointment = surgeryInfo.regularAppointmentLength;
            dateInfoLabel.Text = date;
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            controller = new ScheduleController(date);
            generateTimeTableHeader();
            generateTimeTableSlots();
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long diff = end - start;
            Console.WriteLine("------------ Diff: " + diff);
            timetable.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (timetable.CurrentCell.ColumnIndex < 2) {
                return;
            }
            string timeRange = timetable.CurrentCell.OwningRow.Cells[1].Value as string;
            TimeSpan slotTime = TimeSpan.Parse(timetable.CurrentCell.OwningRow.Cells[0].Value as string);
            int staffId = Int32.Parse(timetable.CurrentCell.OwningColumn.Name);
            string doctorsName = timetable.CurrentCell.OwningColumn.HeaderText as string;

            ScheduleController.slotStatus slotStatus = controller.getSlotStatus(slotTime, staffId);
            int staffScheduleId = controller.getStaffScheduleId(slotTime, staffId);
            if (slotStatus == ScheduleController.slotStatus.Available) {
                BookingWindow booking = new BookingWindow(this, this.date, timeRange, doctorsName, surgeryInfo.getFirstLineOfAddress(), surgeryInfo.getSecondLineOfAddress(), surgeryInfo.getPhoneNumber(), staffScheduleId);
                booking.Show();
            }
        }

        public void reloadSchedule() {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            controller.refresh();
            generateTimeTableSlots();
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long diff = end - start;
            Console.WriteLine("------------ Diff: " + diff);
        }

        private void generateTimeTableHeader() {
            Dictionary<int, string> availableDoctors = controller.getAllAvailableDoctorsPerDate();
            foreach (KeyValuePair<int, string> entry in availableDoctors) {
                timetable.Columns.Add(entry.Key.ToString(), entry.Value);
            }
        }

        private void generateTimeTableSlots() {
            timetable.Visible = false;
            timetable.Rows.Clear();
            timetable.Refresh();
            //reloads parent (Upcoming/Past Appointments) content after booking appointment     
            if (this.parent != null) {
                parent.getAppointmentBoxes();
            }

            TimeSpan appointmentStartTime = surgeryOpeningTime;
            while (appointmentStartTime < surgeryClosingTIme) {
                TimeSpan appointmentEndTime = appointmentStartTime.Add(TimeSpan.FromMinutes(lengthOfRegularAppointment));
                string formattedAppointmentStartTime = string.Format("{0:00}:{1:00}", appointmentStartTime.Hours, appointmentStartTime.Minutes);
                string formattedAppointmentEndTime = string.Format("{0:00}:{1:00}", appointmentEndTime.Hours, appointmentEndTime.Minutes);
                string appointmentRange = formattedAppointmentStartTime + " - " + formattedAppointmentEndTime;
                timetable.Rows.Add(formattedAppointmentStartTime, appointmentRange);

                for (int columnIndex = 2; columnIndex < timetable.ColumnCount; columnIndex++) {
                    string staffId = timetable.Columns[columnIndex].Name;
                    ScheduleController.slotStatus slotStatus = controller.getSlotStatus(appointmentStartTime, Int32.Parse(staffId));
                    string slotStatusName = slotStatus.ToString();
                    timetable.Rows[timetable.RowCount - 1].Cells[staffId].Value = (slotStatus == ScheduleController.slotStatus.NotAvailable ? "" : slotStatusName);
                }
                appointmentStartTime = appointmentEndTime;
            }
            timetable.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
