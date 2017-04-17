using System;

namespace PatientBookingSystem.Models {
    /** Class is a database model of user table - contains all the getters and setters */
    public class UserModel : IModel {

        private int id { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string login { get; set; }
        private string password { get; set; }
        private string DOBs { get; set; }
        private DateTime DOBd { get; set; }
        private string phoneNumber { get; set; }
        private string email { get; set; }
        private string NiN { get; set; }
        private string address { get; set; }
        private string userType { get; set; }
        private string notification { get; set; }
        private string verification { get; set; }
        private string confirmation { get; set; }

        public string getConfirmationSettings() {
            return this.confirmation;
        }

        public void setConfirmation(string confirmation) {
            this.confirmation = confirmation;
        }

        public string getNotificationSettings() {
            return this.notification;
        }

        public void setNotification(string notification) {
            this.notification = notification;
        }

        public string getVerificationSettings() {
            return this.verification;
        }

        public void setVerification(string verification) {
            this.verification = verification;
        }

        public string getFullName() {
            return this.firstName + " " + this.lastName;
        }

        public int getId() {
            return this.id;
        }

        public string getFirstName() {
            return this.firstName;
        }

        public string getLastName() {
            return this.lastName;
        }

        public string getLogin() {
            return this.login; 
        }

        public string getPassword() {
            return this.password; 
        }

        public DateTime getDOBd() {
            return this.DOBd; 
        }

        /** 
         * Method returns date in mysql format
         * 
         * @return date in MySQL format
         */
        public string getDobInMySqlFormat() {
            return this.DOBd.ToString("yyyy-MM-dd");
        }

        public string getPhoneNumber() {
            return this.phoneNumber; 
        }

        public string getEmail() {
            return this.email; 
        }

        public string getNiN() {
            return this.NiN; 
        }

        public string getAddress() {
            return this.address; 
        }


        public string getUserType() {
            return this.userType; 
        }
        
        public void setId(int id) {
            this.id = id; 
        }

        public void setFirstName(string firstName) {
            this.firstName = firstName;
        }

        public void setLastName(string lastName) {
            this.lastName = lastName;
        }

        public void setLogin(string login) {
            this.login = login;
        }

        public void setPassword(string password) {
            this.password = password;
        }

        public void setDOBs(string DOB) {
            bool isDateTime = DOB.IndexOf(" ") >= 0;
            if (isDateTime) {
                DOB = DOB.Remove(DOB.IndexOf(" "));
            }
            this.DOBs = DOB;
        }

        public void setDOBd(DateTime dob) {
            this.DOBd = dob;
        }
        public void setPhoneNumber(string phoneNumber) {
            this.phoneNumber = phoneNumber;
        }

        public void setEmailAddress(string emailAddress) {
            this.email = emailAddress;
        }

        public void setNiN(string NiN) {
            this.NiN = NiN;
        }

        public void setAddress(string address) {
            this.address = address;
        }


        public void setUserType(string userType) {
            this.userType = userType;
        }

    }
}
