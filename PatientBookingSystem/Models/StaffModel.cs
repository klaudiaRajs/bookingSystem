namespace PatientBookingSystem.Models {
    /** Class is a database model of staff table - contains all the getters and setters */
    public class StaffModel : IModel{
        private int staffId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string staffType; 

        public string getFullStaffName() {
            return this.firstName + " " + this.lastName;
        }

        public int getStaffId() {
            return this.staffId; 
        }

        public void setStaffId(int staffId) {
            this.staffId = staffId; 
        }

        public string getFirstName() {
            return this.firstName; 
        }

        public void setFirstName(string firstName) {
            this.firstName = firstName; 
        }

        public string getLastName() {
            return this.lastName; 
        }

        public void setLastName(string lastName) {
            this.lastName = lastName; 
        }

        public string getPhoneNumber() {
            return this.phoneNumber;
        }

        public void setPhoneNumber(string phoneNumber) {
            this.phoneNumber = phoneNumber; 
        }

        public string getStaffType() {
            return this.staffType; 
        }

        public void setStaffType(string staffType) {
            this.staffType = staffType; 
        }
    }
}
