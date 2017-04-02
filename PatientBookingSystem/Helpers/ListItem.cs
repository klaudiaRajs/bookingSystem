﻿using PatientBookingSystem.Controllers;
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

        /** Method returns a list of staff members prepared to be a data source for a drop down list */
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

        /** Method returns a list of staff types prepared to be a data source for a drop down list */
        public List<ListItem> getListOfStaffTypesForComboBox() {
            List<ListItem> staffTypesData = new List<ListItem>();
            staffTypesData.Insert(0, new ListItem { text = "Select a staffType", id = 0 });
            string[] myEnumMember = Enum.GetNames(typeof(SurgeryInfo.staffTypes));
            staffTypesData = fillInList(staffTypesData, myEnumMember);            
            return staffTypesData; 
        }

        /** Method fills in the list with enum values */
        private List<ListItem> fillInList(List<ListItem> list, string[] enumNames) {
            for (int i = 0; i < enumNames.Length; i++) {
                list.Add(new ListItem { text = enumNames[i], id = i + 1 });
            }
            return list;
        }

        /** Method returns a list of user types prepared to be a data source for a drop down list */
        public List<ListItem> getListOfUserTypes() {
            List<ListItem> userTypesData = new List<ListItem>();
            userTypesData.Insert(0, new ListItem { text = "Select a user type", id = 0 });
            string[] userTypes = Enum.GetNames(typeof(SurgeryInfo.userTypes));
            userTypesData = fillInList(userTypesData, userTypes);
            return userTypesData;
        }

        /** Method returns a list of confirmation methods to be a data source for a drop down list */
        public List<ListItem> getListOfConfirmationMethodsForComboBox() {
            List<ListItem> confirmationMethods = new List<ListItem>();
            confirmationMethods.Insert(0, new ListItem { text = "Select confirmation method", id = 0 });
            string[] availableMethods = Enum.GetNames(typeof(SurgeryInfo.confirmationMethod));
            confirmationMethods = fillInList(confirmationMethods, availableMethods);
            return confirmationMethods;
        }

    }
}
