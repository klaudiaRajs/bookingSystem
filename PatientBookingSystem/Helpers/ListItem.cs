using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace PatientBookingSystem.Helpers {
    /** Class is responsible for providing data sources and accessing fields for drop down lists(comboBoxes) */
    class ListItem {
        /** Value to be returned from drop down list element */
        public int id { get; set; }
        /** Value to be displayed in the drop down list element */
        public string text { get; set; }

        /** 
         * Method returns a list of staff members prepared to be a data source for a drop down list 
         * 
         * @return list of all the staff members
         */
        public List<ListItem> getDataSourceForAllStaffMembers() {
            StaffController controller = new StaffController();
            List<IModel> allTheStaffMembers = controller.getAllStaffMembers();
            List<ListItem> listOfStaffMembers = new List<ListItem>();
            listOfStaffMembers.Add(new ListItem { text = "Select staff member", id = 0 });
            foreach (StaffModel staffMember in allTheStaffMembers) {
                listOfStaffMembers.Add(new ListItem { text = staffMember.getFullStaffName(), id = staffMember.getStaffId() });
            }
            return listOfStaffMembers;
        }

        /** 
         * Method returns a list of staff types prepared to be a data source for a drop down list 
         * 
         * @return list of staff types 
         */
        public List<ListItem> getListOfStaffTypesForComboBox() {
            List<ListItem> staffTypesData = new List<ListItem>();
            staffTypesData.Insert(0, new ListItem { text = "Select a staffType", id = 0 });
            string[] myEnumMember = Enum.GetNames(typeof(SurgeryInfo.staffTypes));
            staffTypesData = fillInList(staffTypesData, myEnumMember);
            return staffTypesData;
        }

        /** 
         * Method returns a list of user types prepared to be a data source for a drop down list 
         * 
         * @return prepared for combobox list of user types
         */
        public List<ListItem> getListOfUserTypes() {
            List<ListItem> userTypesData = new List<ListItem>();
            userTypesData.Insert(0, new ListItem { text = "Select a user type", id = 0 });
            string[] userTypes = Enum.GetNames(typeof(SurgeryInfo.userTypes));
            userTypesData = fillInList(userTypesData, userTypes);
            return userTypesData;
        }

        /** 
         * Method returns a list of confirmation methods to be a data source for a drop down list 
         * 
         * @return prepared for comboBox list of confirmation methods
         */
        public List<ListItem> getListOfConfirmationMethodsForComboBox() {
            List<ListItem> confirmationMethods = new List<ListItem>();
            confirmationMethods.Insert(0, new ListItem { text = "Select confirmation method", id = 0 });
            string[] availableMethods = Enum.GetNames(typeof(SurgeryInfo.verificationMethod));
            confirmationMethods = fillInList(confirmationMethods, availableMethods);
            return confirmationMethods;
        }

        /** 
         * Method returns a list of attendance options for the admin to set 
         * 
         * @return prepared for comboBox list of possible attendance statuses
         */
        public List<ListItem> getDateSourceOfAllPossibleAttendanceStatuses() {
            List<ListItem> attendanceOptions = new List<ListItem>();
            attendanceOptions.Insert(0, new ListItem { text = "Select attendance status", id = 0 });
            int counter = 1;
            BookingController controller = new BookingController();
            Dictionary<string, Dictionary<string, int>> attendanceOptionsDescriptionsAndValues = controller.getAttendanceOptions();
            foreach (KeyValuePair<string, Dictionary<string, int>> entry in attendanceOptionsDescriptionsAndValues) {
                attendanceOptions.Add(new ListItem { text = entry.Key.ToString(), id =  counter});
                counter++;
            }
            return attendanceOptions;
        }

        /** 
         * Method fills in the list with enum values 
         * 
         * @param list list of items prepared to be list elements
         * @param enumNames list of possible names
         * 
         * @return 
         */
        private List<ListItem> fillInList(List<ListItem> list, string[] enumNames) {
            for (int i = 0; i < enumNames.Length; i++) {
                list.Add(new ListItem { text = enumNames[i], id = i + 1 });
            }
            return list;
        }
    }
}
