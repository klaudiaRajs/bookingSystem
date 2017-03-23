using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Presenters {
    public partial class surgeryInfoBox : UserControl {

        SurgeryInfo surgery = new SurgeryInfo(); 

        public surgeryInfoBox() {
            InitializeComponent();

            surgeryName.Text += surgery.getSurgeryName(); 
            firstLineOfAddressLabel.Text += surgery.getFirstLineOfAddress();
            secondLineOfAddressLabel.Text += surgery.getSecondLineOfAddress();
            surgeryPhoneNumberLabel.Text += surgery.getPhoneNumber();
            
        }
    }
}
