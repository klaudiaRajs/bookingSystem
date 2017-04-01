using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    /** Class provide tool for validating different types of data used within the system */
    static class Validator {

        /**
         * Method validates staff member model 
         */
        public static bool validateStaffMember(StaffModel staffMember, int staffType = -1) {
            bool result = true;
            if (String.IsNullOrEmpty(staffMember.getFirstName()) || String.IsNullOrEmpty(staffMember.getLastName()) || staffType == 0) {
                result = false;
            }
            return result;
        }

        /** 
         * Method validates user model
         */
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
            if( !user.getUserType().Equals("patient") && !user.getUserType().Equals("admin")) {
                errors.Add("user type");
            }
            return errors; 
        }

        /** 
         * Method validates login and password for their requirements
         */
        public static bool validateLogger(string login, string password) {
            bool result = true;
            if( login.Length < 3) {
                result = false;
            }
            if( password.Length < 3) {
                result = false;
            }
            return result;
            
        }

        /** 
         * Method validates if absence model meet the requirements for saving
         */
        public static List<string> validateAbsenceForSaving(AbsenceModel absence) {
            List<string> errors = new List<string>(); 
            if( DateHelper.getDateTimeObjectFromString(absence.startDate).Date < DateTime.Today.Date) {
                errors.Add("startDate");
            }
            return errors;
        }
    }
}
