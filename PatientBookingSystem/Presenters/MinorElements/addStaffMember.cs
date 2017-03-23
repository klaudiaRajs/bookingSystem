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
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class addStaffMember : UserControl {

        FeedbackWindow feedback;
        SurgeryInfo surgeryInfo; 

        public addStaffMember() {
            InitializeComponent();
            this.surgeryInfo = new SurgeryInfo(); 
            fillInDropDownStaffTypeMenu();
            this.feedback = new FeedbackWindow();
            staffTypes.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fillInDropDownStaffTypeMenu() {           
            staffTypes.DataSource = surgeryInfo.getListOfStaffTypesForComboBox();
            staffTypes.DisplayMember = "text";
            staffTypes.ValueMember = "id";
        }

        private void saveButton_Click(object sender, EventArgs e) {
            StaffController controller = new StaffController();
            bool isValid = Validator.validateStaffMember(doctorsFirstName.Text, doctorsLastName.Text, doctorsPhoneNumber.Text, (int)staffTypes.SelectedValue);
            if (isValid) {
                StaffModel staffMember = new StaffModel();
                staffMember.setFirstName(doctorsFirstName.Text);
                staffMember.setLastName(doctorsLastName.Text);
                staffMember.setPhoneNumber(doctorsPhoneNumber.Text);
                if( String.IsNullOrEmpty(doctorsPhoneNumber.Text)) {
                    staffMember.setPhoneNumber("NULL");
                }
                ListItem staffType = (ListItem)staffTypes.SelectedItem;
                staffMember.setStaffType(staffType.text); 
                bool result = controller.addStaffMember(staffMember);
                if (!result) {
                    feedback.setMessageForSavingError();
                } else {
                    feedback.setMessageForSuccessfullOperation();
                }
            }
            feedback.Show();
        }
    }
}
