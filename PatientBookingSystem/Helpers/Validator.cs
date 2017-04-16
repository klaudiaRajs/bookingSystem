using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientBookingSystem.Helpers {
    /** Class provide tool for validating different types of data used within the system */
    public static class Validator {

        /** Messages  */
        private const string ENTER_LOGIN_MESSAGE = " Credentials you provided does not meet the requirements ";
        private const string ENTER_PASSWORD_MESSAGE = " Password you provided does not meet the requirements ";


        /** Return message for empty password */
        public static string getEmptyPasswordMessage() {
            return Validator.ENTER_PASSWORD_MESSAGE;
        }

        /** Returns message for empty login */
        public static string getEmptyLoginMessage() {
            return ENTER_LOGIN_MESSAGE;
        }

        /** 
         * Method validates data for staffSchedule model  
         * 
         * @param staffId 
         * @param scheduleIdList list of schedule id to be linked with staffmember
         */
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

        /** 
         * Method validates multiple entries months list 
         * 
         * @param months list of months to apply schedule to
         * @return list of errors 
         */
        public static List<string> validateMultipleEntriesMonth(List<DateTime> months) {
            List<string> errors = new List<string>();
            if (months.Count == 0) {
                errors.Add("months");
            }
            return errors;
        }

        /**
         *  Method validates if schedule information per day are valid
         *  
         *  @param day string to modify the message
         *  @param workStart time of shift start 
         *  @param workEnd time of shift end 
         *  @param breakStart time of break start 
         *  @param breakEnd time of break end
         *  
         *  @return list of errors
         */
        public static List<string> validateDayForScheduleMultipleEntries(string day, DateTimePicker workStart, DateTimePicker workEnd, DateTimePicker breakStart, DateTimePicker breakEnd) {
            List<string> errors = new List<string>();
            if (workStart.Enabled) {
                if (workStart.Value >= workEnd.Value) {
                    errors.Add(day + "'s work start time is later than end time");
                }
                if (breakStart.Enabled) {
                    if (breakStart.Value <= workStart.Value) {
                        errors.Add(day + "'s break starts earlier than work");
                    }
                    if (breakStart.Value >= workEnd.Value) {
                        errors.Add(day + "'s break ends later than work");
                    }
                    if (breakEnd.Value <= breakStart.Value) {
                        errors.Add(day + "'s break ends before it starts");
                    }
                    if (breakEnd.Value <= workStart.Value) {
                        errors.Add(day + "'s break ends before work starting time");
                    }
                    if (breakEnd.Value >= workEnd.Value) {
                        errors.Add(day + "'s break end after work ends");
                    }
                }
            }
            return errors;
        }

        /** 
         * Method validates absence parametrs 
         * 
         * @param startDatePicker absence start date 
         * @param endDatePicker absence end date 
         * @param startTimePicker absence start time 
         * @param endTimePicker absence end time 
         * @param invalidFieldsList list of invalid fields
         * @param allTheDoctors comboBox with staff members 
         * @return list of errors
         */
        public static List<string> validateAbsenceParameters(DateTimePicker startDatePicker, DateTimePicker endDatePicker, 
            DateTimePicker startTimePicker, DateTimePicker endTimePicker, List<string> invalidFieldsList, ComboBox allTheDoctors = null) {
            List<string> invalidFields = invalidFieldsList;
            bool result = true;
            if (allTheDoctors != null) {
                if ((int)allTheDoctors.SelectedValue <= 0) {
                    invalidFields.Add("doctor's name");
                    result = false;
                }
            }

            if (startDatePicker.Value < DateTime.Today) {
                invalidFields.Add("start date");
                result = false;
            }

            if (endDatePicker.Enabled && endDatePicker.Value.Date < startDatePicker.Value.Date) {
                invalidFields.Add("end date");
                result = false;
            }

            if (!endDatePicker.Enabled && startTimePicker.Value >= endTimePicker.Value) {
                invalidFields.Add("time fields");
                result = false;
            }

            if (!result) {
                return invalidFields;
            }

            return null;
        }

        /** 
         * Method validates schedule entry for single entry. 
         * 
         * @param workStartTime start time of the shift 
         * @param workEndTime end time of the shift 
         * @param breakStartTime start time of the break 
         * @param breakEndTime end time of the break          * 
         * @return List of errors 
         */
        public static List<string> validateScheduleEntry(DateTime workStartTime, DateTime workEndTime, DateTime breakStartTime, DateTime breakEndTime) {
            List<string> errors = new List<string>();
            if (workStartTime > workEndTime) {
                errors.Add("Time of the end of the shift cannot be earlier than start shift time");
            }
            if (breakStartTime > breakEndTime) {
                errors.Add("Time of break start cannot be later than break end time");
            }
            return errors;
        }

        /** 
         * Method validates staff member model 
         * 
         * @param staffMember stafFModel
         * @param staffType default value indicating that no staffType is passed
         * @return list of errors
         */
        public static List<string> validateStaffMember(StaffModel staffMember, int staffType = -1) {
            List<string> errors = new List<string>();
            if (String.IsNullOrEmpty(staffMember.getFirstName())) {
                errors.Add("first name");
            }
            if (staffMember.getFirstName().Length < 4) {
                errors.Add("first name (at least 3 characters)");
            }
            if (String.IsNullOrEmpty(staffMember.getLastName())) {
                errors.Add("last name");
            }
            if (staffMember.getLastName().Length < 4) {
                errors.Add("last name (at least 3 characters)");
            }
            if (staffType == 0) {
                errors.Add("staff type");
            }
            return errors;
        }

        /** 
         * Method validates user model 
         * 
         * @param user UserModel 
         * @return list of errors
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

        /** 
         * Method validates if booking model contains required information 
         * 
         * @param booking BookingModel
         * @return result
         */
        public static bool validateBookingForUpdate(BookingModel booking) {
            bool result = true;
            if (booking.getBookingId() == 0) {
                result = false;
            }
            return result;
        }

        /** 
         * Method validates login and password for their requirements 
         * 
         * @param login
         * @param password
         * @return result
         */
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

        /** 
         * Method validates if absence model meet the requirements for saving 
         * 
         * @param abcence AbsenceModel
         * @return list of errors
         */
        public static List<string> validateAbsenceForSaving(AbsenceModel absence) {
            List<string> errors = new List<string>();
            if (DateHelper.getDateTimeObjectFromString(absence.startDate).Date < DateTime.Today.Date) {
                errors.Add("startDate");
            }
            return errors;
        }

        /** 
         * Method validates if login credentials meet the requirements 
         * 
         * @param login
         * @param password 
         * @return list of errors
         */
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
