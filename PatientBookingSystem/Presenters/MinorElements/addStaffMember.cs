using System;
using System.Windows.Forms;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using System.Collections.Generic;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is responsible for presenting functionality of adding a new staff member */
    public partial class addStaffMember : UserControl {

        private FeedbackWindow feedback;
        private ListItem itemsForComboBoxes;

        /** Method prepares staff drop down and initializes ListItem and FeedbackWindow classes */
        public addStaffMember() {
            InitializeComponent();
            this.itemsForComboBoxes = new ListItem();
            this.feedback = new FeedbackWindow();
            fillInDropDownStaffTypeMenu();
            staffTypes.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /** Method fills in drop down containig staff types */
        private void fillInDropDownStaffTypeMenu() {
            staffTypes.DataSource = itemsForComboBoxes.getListOfStaffTypesForComboBox();
            staffTypes.DisplayMember = "text";
            staffTypes.ValueMember = "id";
        }

        /** Method calls on controller method for saving staff member */
        private void saveButton_Click(object sender, EventArgs e) {
            StaffController controller = new StaffController();
            StaffModel staffMember = this.getStaffModelFromForm();
            List<string> errors = Validator.validateStaffMember(staffMember, (int)staffTypes.SelectedValue);
            if ( errors.Count == 0 ) {
                bool result = controller.addStaffMember(staffMember);
                if (!result) {
                    feedback.setMessageForSavingError();
                } else {
                    feedback.setMessageForSuccessfullOperation();
                }
            } else {
                feedback.setMessageForInvalidFieldsValues(errors);
            }
            feedback.Show();
        }

        /**  
         * Method prepares staff model from data get from form 
         * 
         * @return staff model 
         */
        private StaffModel getStaffModelFromForm() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName(doctorsFirstName.Text);
            staffMember.setLastName(doctorsLastName.Text);
            staffMember.setPhoneNumber(doctorsPhoneNumber.Text);
            if (String.IsNullOrEmpty(doctorsPhoneNumber.Text)) {
                staffMember.setPhoneNumber("NULL");
            }
            ListItem staffType = (ListItem)staffTypes.SelectedItem;
            staffMember.setStaffType(staffType.text);
            return staffMember; 
        }
    }
}
