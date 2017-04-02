using System;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Helpers;
using System.Collections.Generic;

namespace PatientBookingSystem.Controllers {
    /** Class manages processes of logging user in */
    class Logger {

        /** Method is resposible for logging user in and setting the user as logged in */
        public Boolean logUserIn(String login, String password) {
            List<string> errors = Validator.validateLoginCredentials(login, password);
            if (errors.Count == 0) {
                UserModel user = this.getUserByLoginCredentials(login, password);
                ApplicationState.userId = user.getId();
                ApplicationState.userLogin = user.getLogin();
                ApplicationState.userPassword = user.getPassword();
                ApplicationState.userType = user.getUserType();
                return true;
            }
            return false;
        }

        /** Method returns user model retrieved based on login and password */
        public UserModel getUserByLoginCredentials(string login, string password) {
            UserRepo repo = new UserRepo();
            List<IModel> users = repo.getListOfUsersByLoginCredentials(login, password);
            if (users.Count == 0 || users.Count > 2) {
                throw new Exception("Such user doesn't exit");
            }
            return users[0] as UserModel;
        }


    }
}
