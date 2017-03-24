using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class addSchedule : UserControl {
        public addSchedule() {
            InitializeComponent();
        }

        private void multipleEntries_Click(object sender, EventArgs e) {
            addScheduleContent.Controls.Clear(); 
            multipleScheduleEntriesPanel addMultipleEntries = new multipleScheduleEntriesPanel();
            addScheduleContent.Controls.Add(addMultipleEntries);
        }

        private void singleEntryButton_Click(object sender, EventArgs e) {
            addScheduleContent.Controls.Clear();
            singleEntrySchedulePanel addSingleScheduleEntry = new singleEntrySchedulePanel();
            addScheduleContent.Controls.Add(addSingleScheduleEntry);
        }
    }
}
