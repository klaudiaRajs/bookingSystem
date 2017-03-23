using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    class SurgeryInfo {
        String surgeryName = "Tay Court Surgery";
        String firstLineOfAddress = "50 Tay Street";
        String secondLineOfAddress = "DD11 Dundee";
        String phoneNumber = "01382 228228";

        public enum staffTypes { doctor = 1, nurse = 2, administration = 3 }; 
        public enum userTypes { patient = 1, admin = 2 };
        public enum confirmationMethod { email = 1, call = 2 };

        public TimeSpan openingTime;
        public TimeSpan closingTime;
        public int regularAppointmentLength = 15;
        public string defaultConfirmationMethod = SurgeryInfo.confirmationMethod.email.ToString();
        public string defaultUserType = SurgeryInfo.userTypes.patient.ToString();

        public SurgeryInfo() {
            openingTime = new TimeSpan(9, 30, 0);
            closingTime = new TimeSpan(17, 45, 0);
        }

        public List<ListItem> getListOfStaffTypesForComboBox() {
            List<ListItem> staffTypesData = new List<ListItem>();
            staffTypesData.Insert(0, new ListItem { text = "Select a staffType", id = 0 });
            string[] myEnumMember = Enum.GetNames(typeof(SurgeryInfo.staffTypes));
            staffTypesData = fillInList(staffTypesData, myEnumMember);            
            return staffTypesData; 
        }
        
        public List<ListItem> getListOfUserTypes() {
            List<ListItem> userTypesData = new List<ListItem>();
            userTypesData.Insert(0, new ListItem { text = "Select a user type", id = 0 });
            string[] userTypes = Enum.GetNames(typeof(SurgeryInfo.userTypes));
            userTypesData = fillInList(userTypesData, userTypes);
            return userTypesData;
        }

        public List<ListItem> getListOfConfirmationMethodsForComboBox() {
            List<ListItem> confirmationMethods = new List<ListItem>();
            confirmationMethods.Insert(0, new ListItem { text = "Select confirmation method", id = 0});
            string[] availableMethods = Enum.GetNames(typeof(SurgeryInfo.confirmationMethod));
            confirmationMethods = fillInList(confirmationMethods, availableMethods);
            return confirmationMethods;
        }

        private List<ListItem> fillInList(List<ListItem> list, string[] enumNames) {
            for (int i = 0; i < enumNames.Length; i++) {
                list.Add(new ListItem { text = enumNames[i], id = i + 1 });
            }
            return list;
        }

        public String getSurgeryName() {
            return this.surgeryName; 
        }

        public String getFirstLineOfAddress() {
            return this.firstLineOfAddress; 
        }

        public String getSecondLineOfAddress() {
            return this.secondLineOfAddress; 
        }

        public String getPhoneNumber() {
            return this.phoneNumber; 
        }
    }
}
