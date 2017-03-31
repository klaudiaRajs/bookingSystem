using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Controllers {
    class Logger {

        String[] errors = new String[100];
        int counter = 0;
        UserModel model = new UserModel();
        UserRepo repo = new UserRepo(); 
        const String ENTER_LOGIN_MESSAGE = " Please enter the login! ";
        const String ENTER_PASSWORD_MESSAGE = " Please enter the password! ";

        public Logger() {
        }

        public Boolean logUserIn(String login, String password) {
            errors = this.validateLoginCredentials(login, password); 
            if (errors[0] == null) {
                UserModel user = this.getUserByLoginCredentials(login, password); 
                if (user != null) {
                    ApplicationState.userId = user.getId();
                    ApplicationState.userLogin = user.getLogin(); 
                    ApplicationState.userPassword = user.getPassword();
                    ApplicationState.userType = user.getUserType();
                    return true;
                }
            }
            return false;
        }

        public UserModel getUserByLoginCredentials(string login, string password) {
            UserModel user = repo.getUserByLoginCredentials(login, password);
            return user;
        }

        private String[] validateLoginCredentials(string login, string password) {

            if (login.Length > 0 && login != ENTER_LOGIN_MESSAGE &&
                password.Length > 0 && password != ENTER_PASSWORD_MESSAGE) {
                errors[0] = null;
            } else {
                if (login.Length < 1) {
                    errors[counter] = ENTER_LOGIN_MESSAGE;
                    counter++;
                }
                if (password.Length < 1) {
                    errors[counter] = ENTER_PASSWORD_MESSAGE;
                    counter++;
                }
            }

            return errors;

        }
    }
}
