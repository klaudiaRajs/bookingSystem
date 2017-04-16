using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;

namespace PatientBookingSystem.Controllers {
    /** Class is responsible for communication between presenters and user repository */
    class UserController {

        private UserRepo repo = new UserRepo();

        /** 
         * Method returns all the users 
         * 
         * @return list of all users
         */
        public List<IModel> getAllUsers() {
            return repo.getListOfAllUsers();
        }

        /** 
         * Method returns user model for given login and password 
         * 
         * @param login 
         * @param password 
         * @return user model corresponding to the credentials
         */
        public UserModel getUserByLoginCredentials(string login, string password) {
            List<IModel> usersByCredentials = repo.getListOfUsersByLoginCredentials(login, password);
            if (usersByCredentials.Count == 0 || usersByCredentials.Count > 2) {
                throw new Exception("Problem with users listing");
            }
            return usersByCredentials[0] as UserModel; 
        } 

        /** 
         * Method initiates process of saving user to the database 
         * 
         * @param user userModel
         * @return result of saving user
         */ 
        public bool save(UserModel user) {
            return repo.save(user);
        }

        /** 
         * Method initiates saving user settings for notifications, confirmations and verifications 
         * 
         * @param notification 
         * @param verification
         * @param confirmation 
         * @return result of saving the settings
         */
        internal bool saveSettings(List<string> notification, List<string> verification, List<string> confirmation) {
            string notifications = (string.Join(",", notification.ToArray()).Length == 0 ? "NULL" : string.Join(",", notification.ToArray()));
            string confirmations = (string.Join(",", confirmation.ToArray()).Length == 0 ? "NULL" : string.Join(",", confirmation.ToArray()));
            string verifications = (string.Join(",", verification.ToArray()).Length == 0 ? "NULL" : string.Join(",", verification.ToArray()));

            return repo.saveSettings(notifications, verifications, confirmations);
        }

        /** 
         * Method returns list of all patients
         * 
         * @return list of all the patients 
         */
        public List<IModel> getListOfAllPatients() {
            return repo.getListOfAllPatients();
        }

        /** 
         * Method returns list of patients having upcoming appointments for given staff member 
         * 
         * @param selectedStaffMember
         * @return list of patients having upcoming appointments for selected staff member
         */
        public List<IModel> getListOfPatientsHavingUpcomingAppointmentsForGivenStaffMember(int selectedStaffMember) {
            return repo.getListOfPatientsHavingUpcomingAppointmentsForGivenStaffMember(selectedStaffMember);
        }
    }
}
