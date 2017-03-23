using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters {
    public partial class appointmentTimeLabel : UserControl {
        public appointmentTimeLabel(String text) {
            InitializeComponent();
            timeText.Text = text; 
        }
    }
}
