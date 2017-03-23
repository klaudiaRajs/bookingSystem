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
        /*
        public PatientListItem(string firstName, string lastName, int id) {
            this.text = firstName + " " + lastName;
            this.id = id; 
        }*/

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
    }
}
