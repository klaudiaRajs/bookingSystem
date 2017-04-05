using System.Windows.Forms;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Presenters {
    /** Class is a representation of surgeryInfoBox view */
    public partial class surgeryInfoBox : UserControl {


        /** Constructor adjusts the information */
        public surgeryInfoBox() {
            InitializeComponent();
            SurgeryInfo surgery = new SurgeryInfo();

            surgeryName.Text += surgery.getSurgeryName();
            firstLineOfAddressLabel.Text += surgery.getFirstLineOfAddress();
            secondLineOfAddressLabel.Text += surgery.getSecondLineOfAddress();
            surgeryPhoneNumberLabel.Text += surgery.getPhoneNumber();

        }
    }
}
