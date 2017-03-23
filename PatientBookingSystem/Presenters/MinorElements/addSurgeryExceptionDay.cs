using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Presenters.Interfaces;

namespace PatientBookingSystem.Presenters.MinorElements {
     partial class addSurgeryExceptionDay : UserControl {
        public addSurgeryExceptionDay() {
            InitializeComponent();
            startDatePicker.MinDate = DateTime.Today;
            startDatePicker.Value = DateTime.Today;
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e) {
            endDatePicker.Value = startDatePicker.Value; 
        }
    }
}
