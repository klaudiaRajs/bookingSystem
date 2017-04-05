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

        public String getFirstName() {
            return this.firstName;
        }

        public String getLastName() {
            return this.lastName;
        }

        public String getLogin() {
            return this.login; 
        }

        public String getPassword() {
            return this.password; 
        }

        public DateTime getDOBd() {
            return this.DOBd; 
        }

        /** Method returns date in mysql format */
        public string getDobInMySqlFormat() {
            return this.DOBd.ToString("yyyy-MM-dd");
        }

        public String getPhoneNumber() {
            return this.phoneNumber; 
        }

        public String getEmail() {
            return this.email; 
        }

        public String getNiN() {
            return this.NiN; 
        }

        public String getAddress() {
            return this.address; 
        }


        public String getUserType() {
            return this.userType; 
        }
        
        public void setId(int id) {
            this.id = id; 
        }

        public void setFirstName(String firstName) {
            this.firstName = firstName;
        }

        public void setLastName(String lastName) {
            this.lastName = lastName;
        }

        public void setLogin(String login) {
            this.login = login;
        }

        public void setPassword(String password) {
            this.password = password;
        }

        public void setDOBs(String DOB) {
            this.DOBs = DOB;
        }

        public void setDOBd(DateTime dob) {
            this.DOBd = dob;
        }
        public void setPhoneNumber(String phoneNumber) {
            this.phoneNumber = phoneNumber;
        }

        public void setEmailAddress(String emailAddress) {
            this.email = emailAddress;
        }

        public void setNiN(String NiN) {
            this.NiN = NiN;
        }

        public void setAddress(String address) {
            this.address = address;
        }


        public void setUserType(String userType) {
            this.userType = userType;
        }

    }
}
