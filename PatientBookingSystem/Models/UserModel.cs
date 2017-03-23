using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PatientBookingSystem.Models {
    class UserModel : IModel {
        private int id { get; set; }
        private String firstName { get; set; }
        private String lastName { get; set; }
        private String login { get; set; }
        private String password { get; set; }
        private string DOBs { get; set; }
        private DateTime DOBd { get; set; }
        private String phoneNumber { get; set; }
        private String email { get; set; }
        private String NiN { get; set; }
        private String address { get; set; }
        private String confirmationMethod { get; set; }
        private String userType { get; set; }


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

        public String getConfirmationMethod() {
            return this.confirmationMethod; 
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

        public void setConfirmationMethod(String confirmationMethod) {
            this.confirmationMethod = confirmationMethod;
        }

        public void setUserType(String userType) {
            this.userType = userType;
        }

    }
}
