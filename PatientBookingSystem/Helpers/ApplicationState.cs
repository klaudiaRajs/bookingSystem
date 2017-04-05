using PatientBookingSystem.Controllers;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Helpers {
    /** Class is responsible for keeping the information about logged in user */
    public static class ApplicationState {       

        public static int userId;
        public static string userLogin; 
        public static string userPassword;
        public static string userType;

        public static string notifications;
        public static string verifications;
        public static string confirmations;

        /** Method refreshed user information - called when the changes are made */
        public static void refreshUser() {
            Logger logger = new Logger();
            UserModel user = logger.getUserByLoginCredentials(ApplicationState.userLogin, ApplicationState.userPassword);
            ApplicationState.notifications = user.getNotificationSettings() == null ? "" : user.getNotificationSettings();
            ApplicationState.verifications = user.getVerificationSettings() == null ? "" : user.getVerificationSettings();
            ApplicationState.confirmations = user.getConfirmationSettings() == null ? "" : user.getConfirmationSettings();
        } 
    }
}
