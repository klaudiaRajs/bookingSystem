using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    class ListItem {
        public int id { get; set; }
        public string text { get; set; }         

        public List<ListItem> getDataSourceForAllStaffMembers() {
            StaffController controller = new StaffController();
            List<IModel> allTheStaffMembers = controller.getAllStaffMembers();
            List<ListItem> listOfStaffMembers = new List<ListItem>();
            listOfStaffMembers.Add(new ListItem { text = "Select staff member", id = 0 });
            foreach ( StaffModel staffMember in allTheStaffMembers) {
                listOfStaffMembers.Add(new ListItem { text = staffMember.getFullStaffName(), id = staffMember.getStaffId() });
            }
            return listOfStaffMembers;
        }

         public List<ListItem> getListOfStaffTypesForComboBox() {
            List<ListItem> staffTypesData = new List<ListItem>();
            staffTypesData.Insert(0, new ListItem { text = "Select a staffType", id = 0 });
            string[] myEnumMember = Enum.GetNames(typeof(SurgeryInfo.staffTypes));
            staffTypesData = fillInList(staffTypesData, myEnumMember);            
            return staffTypesData; 
        }


        private List<ListItem> fillInList(List<ListItem> list, string[] enumNames) {
            for (int i = 0; i < enumNames.Length; i++) {
                list.Add(new ListItem { text = enumNames[i], id = i + 1 });
            }
            return list;
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
            confirmationMethods.Insert(0, new ListItem { text = "Select confirmation method", id = 0 });
            string[] availableMethods = Enum.GetNames(typeof(SurgeryInfo.confirmationMethod));
            confirmationMethods = fillInList(confirmationMethods, availableMethods);
            return confirmationMethods;
        }

    }
}
