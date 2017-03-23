using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Presenters.MinorElements;

namespace PatientBookingSystem.Presenters.MainViews {
    public partial class surgeryManagement : UserControl {
        public surgeryManagement() {
            InitializeComponent();
        }

        private void addStaffMember_Click(object sender, EventArgs e) {
            addStaffMember addStaffMemberPanel = new addStaffMember();
            addStaffMemberPanel.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(addStaffMemberPanel);
        }

        private void addExceptionDayForStaffMember_Click(object sender, EventArgs e) {
            addStaffExceptionDay addExceptionDayPanel = new addStaffExceptionDay();
            addExceptionDayPanel.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(addExceptionDayPanel);
        }

        private void addSurgeryExceptionDay_Click(object sender, EventArgs e) {
            addSurgeryExceptionDay surgeryExceptionDayPanel = new addSurgeryExceptionDay();
            surgeryExceptionDayPanel.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(surgeryExceptionDayPanel);
        }

        private void cancelAppointmentButton_Click(object sender, EventArgs e) {
            appointmentCancellation appointmentCancellation = new appointmentCancellation();
            appointmentCancellation.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(appointmentCancellation);
        }

        private void addPatient_Click(object sender, EventArgs e) {
            managementContentPanel.Controls.Clear();
            addUser addPatient = new addUser();
            addPatient.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Add(addPatient);
        }

        private void addScheduleButton_Click(object sender, EventArgs e) {
            managementContentPanel.Controls.Clear();
            addSchedule addSchedule = new addSchedule();
            addSchedule.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Add(addSchedule);
        }
    }
}
