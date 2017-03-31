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
using PatientBookingSystem.Models;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem.Presenters.MinorElements {
    public partial class addUser : UserControl {
        SurgeryInfo surgery;
        FeedbackWindow feedback;
        const string DISABLED_FIELD = "None";

        public addUser() {
            InitializeComponent();
            this.surgery = new SurgeryInfo();
            this.feedback = new FeedbackWindow();
            dobPicker.MaxDate = DateTime.Today;
            dobPicker.Value = DateTime.Today;
            confirmationMethodsDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            userTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            fillInUserTypes();
            fillInConfirmationMethods();
        }

        private void fillInConfirmationMethods() {
            confirmationMethodsDropDown.DataSource = this.surgery.getListOfConfirmationMethodsForComboBox();
            confirmationMethodsDropDown.DisplayMember = "text";
            confirmationMethodsDropDown.ValueMember = "id";
        }

        private void fillInUserTypes() {
            userTypes.DataSource = this.surgery.getListOfUserTypes();
            userTypes.DisplayMember = "text";
            userTypes.ValueMember = "id";
        }

        private void saveButton_Click(object sender, EventArgs e) {
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
            save(Validator.validateUser(user), user);
        }

        private void save(List<string> errors, UserModel user) {
            UserController controller = new UserController();
            if (errors.Count != 0) {
                this.feedback.setMessageForInvalidFieldsValues(errors);
            } else if (!controller.save(user)) {
                this.feedback.setMessageForSavingError();
            } else {
                this.feedback.setMessageForSuccessfullOperation();
            }
            this.feedback.Show();
        }

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

        private void noNiN_CheckedChanged(object sender, EventArgs e) {
            if (noNiN.Checked) {
                NiN.Text = DISABLED_FIELD;
            } else {
                NiN.Text = String.Empty;
            }
            NiN.Enabled = !noNiN.Checked;
        }

        private void noPhoneNumber_CheckedChanged(object sender, EventArgs e) {
            if (noPhoneNumber.Checked) {
                phoneNumber.Text = DISABLED_FIELD;
            } else {
                phoneNumber.Text = String.Empty;
            }
            phoneNumber.Enabled = !noPhoneNumber.Checked;
        }

        private void defaultConfirmation_CheckedChanged(object sender, EventArgs e) {
            confirmationMethodsDropDown.Enabled = !defaultConfirmation.Checked;
        }

        private void defaultUserType_CheckedChanged(object sender, EventArgs e) {
            userTypes.Enabled = !defaultUserType.Checked;
        }
    }
}
