using System;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is responsible for managing addSurgeryExceptionDay view */
     partial class addSurgeryExceptionDay : UserControl {
        
        /** Constructor prepares start values for the view */
        public addSurgeryExceptionDay() {
            InitializeComponent();
            startDatePicker.MinDate = DateTime.Today;
            startDatePicker.Value = DateTime.Today;
        }

        /** Method keeps the endDate value at no earlier than start date value */
        private void startDatePicker_ValueChanged(object sender, EventArgs e) {
            endDatePicker.Value = startDatePicker.Value; 
        }
    }
}
