using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing a single schedule day window and communicating with relevant controllers */
    public partial class SingleScheduleDayWindow : Form {

        private SurgeryInfo surgeryInfo;
        private ScheduleController controller;

        private string date;

        private AppointmentBoxI parent;

        /** 
         * Contructor is responsible for creating the object, initializing fields and calling on methods generating schedule 
         * 
         * @param parent class implementing AppointmentBoxI interface 
         * @param date 
         */
        public SingleScheduleDayWindow(AppointmentBoxI parent, string date) {
            InitializeComponent();
            controller = new ScheduleController(date);
            surgeryInfo = new SurgeryInfo();

            this.parent = parent;
            this.date = date;

            dateInfoLabel.Text = date;
            generateTimeTableHeader();
            generateTimeTableSlots();
            timetable.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
            this.CenterToScreen();
        }

        /** Method is responsibke for handling onclick event on schedule table */ 
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
                BookingWindow booking = new BookingWindow(this, this.date, timeRange, doctorsName, staffScheduleId);
                booking.Show();
            }
        }

        /** Method is responsible for reloading schedule table and provides debugging tool */ 
        internal void reloadSchedule() {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            controller.refresh();
            generateTimeTableSlots();
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long diff = end - start;
            Console.WriteLine("------------ Diff: " + diff);
        }

        /** 
         * Method returns all the staff members per date 
         * 
         * @return dictionary representing staff members per date
         */
        internal Dictionary<int,string> getAllTheStaffMembersPerDate() {
            return controller.getAllAvailableStaffMembersPerDate(); 
        }

        /** Method generates timetable's header */
        private void generateTimeTableHeader() {
            Dictionary<int, string> availableDoctors = controller.getAllAvailableStaffMembersPerDate();
            foreach (KeyValuePair<int, string> entry in availableDoctors) {
                timetable.Columns.Add(entry.Key.ToString(), entry.Value);
            }
        }

        /** Method generates timetable's slots */
        private void generateTimeTableSlots() {
            int lengthOfRegularAppointment = surgeryInfo.regularAppointmentLength;

            TimeSpan surgeryOpeningTime = surgeryInfo.openingTime;
            TimeSpan surgeryClosingTIme = surgeryInfo.closingTime;

            this.refreshTimetable(); 
            //reloads parent (Upcoming/Past Appointments) content after booking appointment     
            if (this.parent != null) {
                parent.getAppointmentBoxes();
            }
            int numberOfMorningAppointments = 0;
            int numberOfAfternoonAppointments = 0;
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
                    if( slotStatusName.Equals("Available") && appointmentStartTime <= new TimeSpan(12,0,0) ){
                        numberOfMorningAppointments++;
                    }
                    if( slotStatusName.Equals("Available") && appointmentStartTime > new TimeSpan(12,0,0)) {
                        numberOfAfternoonAppointments++;
                    }
                    timetable.Rows[timetable.RowCount - 1].Cells[staffId].Value = (slotStatus == ScheduleController.slotStatus.NotAvailable ? "" : slotStatusName);
                }
                appointmentStartTime = appointmentEndTime;
            }
            timetable.Visible = true;
            parent.setNumberOfAppointmentsPerDay(numberOfMorningAppointments, numberOfAfternoonAppointments);
        }

        /** Method refreshes timetable */
        private void refreshTimetable() {
            timetable.Visible = false;
            timetable.Rows.Clear();
            timetable.Refresh();
        }

        /** Method closes the single schedule day window */
        private void exitButton_Click(object sender, EventArgs e) {
            this.Hide();
        }
    }
}
