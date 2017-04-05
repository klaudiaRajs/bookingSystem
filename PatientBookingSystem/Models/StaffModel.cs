using System;

namespace PatientBookingSystem.Models {
    /** Class is a database model of staff table - contains all the getters and setters */
    public class StaffModel : IModel{
        int staffId;
        String firstName;
        String lastName;
        String phoneNumber;
        String staffType; 

        public String getFullStaffName() {
            return this.firstName + " " + this.lastName;
        }

        public int getStaffId() {
            return this.staffId; 
        }

        public void setStaffId(int staffId) {
            this.staffId = staffId; 
        }

        public String getFirstName() {
            return this.firstName; 
        }

        public void setFirstName(String firstName) {
            this.firstName = firstName; 
        }

        public String getLastName() {
            return this.lastName; 
        }

        public void setLastName(String lastName) {
            this.lastName = lastName; 
        }

        public String getPhoneNumber() {
            return this.phoneNumber;
        }

        public void setPhoneNumber(String phoneNumber) {
            this.phoneNumber = phoneNumber; 
        }

        public String getStaffType() {
            return this.staffType; 
        }

        public void setStaffType(String staffType) {
            this.staffType = staffType; 
        }
    }
}
