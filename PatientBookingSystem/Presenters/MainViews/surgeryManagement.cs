using System;
using System.Windows.Forms;
using PatientBookingSystem.Presenters.MinorElements;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing surgeryManagement view and initiating actions provided by this view */
    public partial class surgeryManagement : UserControl {

        public surgeryManagement() {
            InitializeComponent();
        }

        /** Method loads add staff member panel */
        private void addStaffMember_Click(object sender, EventArgs e) {
            addStaffMember addStaffMemberPanel = new addStaffMember();
            addStaffMemberPanel.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(addStaffMemberPanel);
        }

        /** Method loads add staffExceptionDay panel */
        private void addExceptionDayForStaffMember_Click(object sender, EventArgs e) {
            addStaffExceptionDay addExceptionDayPanel = new addStaffExceptionDay();
            addExceptionDayPanel.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(addExceptionDayPanel);
        }

        /** Method loads add surgery panel */
        private void addSurgeryExceptionDay_Click(object sender, EventArgs e) {
            addSurgeryExceptionDay surgeryExceptionDayPanel = new addSurgeryExceptionDay();
            surgeryExceptionDayPanel.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(surgeryExceptionDayPanel);
        }

        /** Method loads appointment cancellation panel */
        private void cancelAppointmentButton_Click(object sender, EventArgs e) {
            appointmentCancellation appointmentCancellation = new appointmentCancellation();
            appointmentCancellation.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Clear();
            managementContentPanel.Controls.Add(appointmentCancellation);
        }

        /** Method loads add patient panel */
        private void addPatient_Click(object sender, EventArgs e) {
            managementContentPanel.Controls.Clear();
            addUser addPatient = new addUser();
            addPatient.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Add(addPatient);
        }

        /** Method loads add schedule panel */
        private void addScheduleButton_Click(object sender, EventArgs e) {
            managementContentPanel.Controls.Clear();
            addSchedule addSchedule = new addSchedule();
            addSchedule.Dock = DockStyle.Fill;
            managementContentPanel.Controls.Add(addSchedule);
        }
    }
}
