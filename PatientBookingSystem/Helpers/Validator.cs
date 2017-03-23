using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    static class Validator {

        public static bool validateStaffMember(string firstName, string lastName, string phoneNumber, int staffType) {
            bool result = true;
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || staffType == 0) {
                result = false;
            }
            return result;
        }

        public static List<string> validateUser(UserModel user) {
            List<string> errors = new List<string>();
            if (String.IsNullOrEmpty(user.getFirstName())) {
                errors.Add("first name");
            }
            if (String.IsNullOrEmpty(user.getLastName())) {
                errors.Add("last name");
            }
            if (String.IsNullOrEmpty(user.getLogin()) || user.getLogin().Length < 4 || user.getLogin().Length > 45) {
                errors.Add("login");
            }
            if (String.IsNullOrEmpty(user.getPassword()) || user.getPassword().Length < 4) {
                errors.Add("password");
            }
            if( user.getDOBd().Date >= DateTime.Today.Date) {
                errors.Add("date of birth");
            }
            if (String.IsNullOrEmpty(user.getEmail()) || user.getEmail().IndexOf('@') == -1 || user.getEmail().IndexOf('.') == -1) {
                errors.Add("email");
            }
            if (String.IsNullOrEmpty(user.getNiN())) {
                errors.Add("National Insurance Number");
            }
            if (String.IsNullOrEmpty(user.getAddress()) || user.getAddress().IndexOf(' ') == -1) {
                errors.Add("address");
            }
            if (!user.getConfirmationMethod().Equals("email") && !user.getConfirmationMethod().Equals("call")){
                errors.Add("confrimation method");
            }
            if( !user.getUserType().Equals("patient") && !user.getUserType().Equals("admin")) {
                errors.Add("user type");
            }
            return errors; 
        }
    }
}
