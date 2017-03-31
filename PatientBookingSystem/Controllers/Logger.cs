using System;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Helpers;
using System.Collections.Generic;

namespace PatientBookingSystem.Controllers {
    class Logger {

        List<string> errors = new List<string>();
        UserModel model = new UserModel();
        UserRepo repo = new UserRepo();
        const String ENTER_LOGIN_MESSAGE = " Please enter the login! ";
        const String ENTER_PASSWORD_MESSAGE = " Please enter the password! ";

        public Boolean logUserIn(String login, String password) {
            errors = this.validateLoginCredentials(login, password);
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

        public UserModel getUserByLoginCredentials(string login, string password) {
            List<IModel> users = repo.getListOfUsersByLoginCredentials(login, password);
            if (users.Count == 0 || users.Count > 2) {
                throw new Exception("Such user doesn't exit");
            }
            return users[0] as UserModel;
        }

        private List<string> validateLoginCredentials(string login, string password) {
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
