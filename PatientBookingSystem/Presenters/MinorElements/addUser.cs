using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MinorElements {
    /** Class is responsible for managing addUser view and communicating with relevant controllers */
    public partial class addUser : UserControl {

        ListItem itemsForComboBoxes;
        const string DISABLED_FIELD = "None";

        /** Constructor initializes components and prepares drop downs */
        public addUser() {
            InitializeComponent();
            this.itemsForComboBoxes = new ListItem();
            dobPicker.MaxDate = DateTime.Today;
            dobPicker.Value = DateTime.Today;
            confirmationMethodsDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            userTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.fillInUserTypes();
            this.fillInConfirmationMethods();
        }

        /** Methods assigns data for confirmation method drop down (fills in values) */
        private void fillInConfirmationMethods() {
            confirmationMethodsDropDown.DataSource = this.itemsForComboBoxes.getListOfConfirmationMethodsForComboBox();
            confirmationMethodsDropDown.DisplayMember = "text";
            confirmationMethodsDropDown.ValueMember = "id";
        }

        /** Method assigns data for user types (fills in values) */
        private void fillInUserTypes() {
            userTypes.DataSource = this.itemsForComboBoxes.getListOfUserTypes();
            userTypes.DisplayMember = "text";
            userTypes.ValueMember = "id";
        }

        /** Method proceeds data from form to be validated and saved */
        private void saveButton_Click(object sender, EventArgs e) {
            UserModel user = this.getUserModelFromDataForm(); 
            this.save(Validator.validateUser(user), user);
        }

        /** Method wrapps data from the form into user model */
        private UserModel getUserModelFromDataForm() {
            SurgeryInfo surgery = new SurgeryInfo();
            UserModel user = new UserModel();
            user.setFirstName(firstName.Text);
            user.setLastName(lastName.Text);
            user.setLogin(login.Text);
            user.setPassword(password.Text);
            user.setPhoneNumber(phoneNumber.Text);
            if (String.IsNullOrEmpty(phoneNumber.Text) || phoneNumber.Text.Equals(DISABLED_FIELD)) {
                user.setPhoneNumber("NULL");
            }
            user.setNiN(NiN.Text);
            if (String.IsNullOrEmpty(NiN.Text) || NiN.Text.Equals(DISABLED_FIELD)) {
                user.setNiN("NULL");
            }
            user.setAddress(address.Text);
            user.setEmailAddress(emailAddress.Text);
            user.setUserType(this.getValueFromDropDown(userTypes, surgery.defaultUserType));
            user.setDOBd(dobPicker.Value);
            return user;
        }

        /** Method calls on saving controller method based on validation */
        private void save(List<string> errors, UserModel user) {
            UserController controller = new UserController();
            FeedbackWindow feedback = new FeedbackWindow();
            if (errors.Count != 0) {
                feedback.setMessageForInvalidFieldsValues(errors);
            } else if (!controller.save(user)) {
                feedback.setMessageForSavingError();
            } else {
                feedback.setMessageForSuccessfullOperation();
            }
            feedback.Show();
        }

        /** Method returns value from passed drop down */
        private string getValueFromDropDown(ComboBox dropDown, string defaultValue) {
            if (dropDown.Enabled) {
                if ((int)dropDown.SelectedValue == 0) {
                    return DISABLED_FIELD;
                }
                return ((ListItem)dropDown.SelectedItem).text;
            } else {
                return defaultValue;
            }
        }

        /** Method enables/disables national insurance number field and sets its default value */
        private void noNiN_CheckedChanged(object sender, EventArgs e) {
            if (noNiN.Checked) {
                NiN.Text = DISABLED_FIELD;
            } else {
                NiN.Text = String.Empty;
            }
            NiN.Enabled = !noNiN.Checked;
        }

        /** Method enables/disables phone number field and sets its default values */
        private void noPhoneNumber_CheckedChanged(object sender, EventArgs e) {
            if (noPhoneNumber.Checked) {
                phoneNumber.Text = DISABLED_FIELD;
            } else {
                phoneNumber.Text = String.Empty;
            }
            phoneNumber.Enabled = !noPhoneNumber.Checked;
        }

        /** Method enables/disables confirmation method drop down */ 
        private void defaultConfirmation_CheckedChanged(object sender, EventArgs e) {
            confirmationMethodsDropDown.Enabled = !defaultConfirmation.Checked;
        }

        /** Method enables/disables user type method drop down */
        private void defaultUserType_CheckedChanged(object sender, EventArgs e) {
            userTypes.Enabled = !defaultUserType.Checked;
        }
    }
}
