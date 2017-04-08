using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace PatientBookingSystem.Helpers {
    /** Class provide tool for validating different types of data used within the system */
    public static class Validator {

        /** Messages  */
        private const String ENTER_LOGIN_MESSAGE = " Credentials you provided does not meet the requirements ";
        private const String ENTER_PASSWORD_MESSAGE = " Password you provided does not meet the requirements ";


        /** Return message for empty password */
        public static string getEmptyPasswordMessage() {
            return Validator.ENTER_PASSWORD_MESSAGE;
        }

        /** Returns message for empty login */
        public static string getEmptyLoginMessage() {
            return ENTER_LOGIN_MESSAGE;
        }

        /** Method validates data for staffSchedule model  */
        public static bool validateStaffSchedule(int staffId, List<int> scheduleIdList) {
            bool result = true;
            if (staffId == 0 || scheduleIdList.Count == 0) {
                result = false;
            }
            foreach (int scheduleId in scheduleIdList) {
                if (scheduleId == 0) {
                    result = false;
                }
            }
            return result;
        }

        /** Method validates staff member model */
        public static List<string> validateStaffMember(StaffModel staffMember, int staffType = -1) {
            List<string> errors = new List<string>();
            if (String.IsNullOrEmpty(staffMember.getFirstName())) {
                errors.Add("first name");
            }
            if (String.IsNullOrEmpty(staffMember.getLastName())) {
                errors.Add("last name");
            }
            if (staffType == 0) {
                errors.Add("staff type");
            }
            return errors;
        }

        /** Method validates user model */
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
            if (user.getDOBd().Date >= DateTime.Today.Date) {
                errors.Add("date of birth");
            }
            if (String.IsNullOrEmpty(user.getEmail()) || user.getEmail().IndexOf('@') == -1 || user.getEmail().IndexOf('.') == -1) {
                errors.Add("email");
            }
            if (String.IsNullOrEmpty(user.getAddress()) || user.getAddress().IndexOf(' ') == -1) {
                errors.Add("address");
            }
            if (!user.getUserType().Equals("patient") && !user.getUserType().Equals("admin")) {
                errors.Add("user type");
            }
            return errors;
        }

        /** Method validates login and password for their requirements */
        public static bool validateLogger(string login, string password) {
            bool result = true;
            if (login.Length < 3) {
                result = false;
            }
            if (password.Length < 3) {
                result = false;
            }
            return result;

        }

        /** Method validates if absence model meet the requirements for saving */
        public static List<string> validateAbsenceForSaving(AbsenceModel absence) {
            List<string> errors = new List<string>();
            if (DateHelper.getDateTimeObjectFromString(absence.startDate).Date < DateTime.Today.Date) {
                errors.Add("startDate");
            }
            return errors;
        }

        /** Method validates if login credentials meet the requirements */
        public static List<string> validateLoginCredentials(string login, string password) {
            List<string> errors = new List<string>();
            if (!(login.Length > 0 && login != ENTER_LOGIN_MESSAGE &&
                password.Length > 0 && password != ENTER_PASSWORD_MESSAGE)) {
                if (login.Length < 1) {
                    errors.Add(ENTER_LOGIN_MESSAGE);
                }
                if (password.Length < 1) {
                    errors.Add(ENTER_PASSWORD_MESSAGE);
                }
            }
            return errors;
        }
    }
}
