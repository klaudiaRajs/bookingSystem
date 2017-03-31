using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    public static class ApplicationState {       

        public static int userId;
        public static string userLogin; 
        public static string userPassword;
        public static string userType;

        public static string notifications;
        public static string verifications;
        public static string confirmations;

        public static void refreshUser() {
            UserRepo repo = new UserRepo();
            Logger logger = new Logger();
            UserModel user = logger.getUserByLoginCredentials(ApplicationState.userLogin, ApplicationState.userPassword);
            ApplicationState.notifications = user.getNotificationSettings() == null ? "" : user.getNotificationSettings();
            ApplicationState.verifications = user.getVerificationSettings() == null ? "" : user.getVerificationSettings();
            ApplicationState.confirmations = user.getConfirmationSettings() == null ? "" : user.getConfirmationSettings();
        } 
    }
}
