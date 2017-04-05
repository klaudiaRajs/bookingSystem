using System;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is responsible for managing addSchedule view */
    public partial class addSchedule : UserControl {

        public addSchedule() {
            InitializeComponent();
        }

        /** Method loads multipleEntries panel */
        private void multipleEntries_Click(object sender, EventArgs e) {
            addScheduleContent.Controls.Clear(); 
            multipleScheduleEntriesPanel addMultipleEntries = new multipleScheduleEntriesPanel();
            addScheduleContent.Controls.Add(addMultipleEntries);
        }

        /** Method loads singleEntrySchedule panel */
        private void singleEntryButton_Click(object sender, EventArgs e) {
            addScheduleContent.Controls.Clear();
            singleEntrySchedulePanel addSingleScheduleEntry = new singleEntrySchedulePanel();
            addScheduleContent.Controls.Add(addSingleScheduleEntry);
        }
    }
}
