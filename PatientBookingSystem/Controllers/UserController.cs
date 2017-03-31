using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;

namespace PatientBookingSystem.Controllers {
    class UserController {
        UserModel model = new UserModel();
        UserRepo repo = new UserRepo(); 
        
        public List<IModel> getAllUsers() {
            List<IModel> users = repo.getListOfAllUsers();
            return users;
        }

        public bool save(UserModel user) {
            return repo.save(user);
        }

        internal bool saveSettings(List<string> notification, List<string> verification, List<string> confirmation) {

            string notifications = (string.Join(",", notification.ToArray()).Length == 0 ? "NULL" : string.Join(",", notification.ToArray()));
            string confirmations = (string.Join(",", confirmation.ToArray()).Length == 0 ? "NULL" : string.Join(",", confirmation.ToArray()));
            string verifications = (string.Join(",", verification.ToArray()).Length == 0 ? "NULL" : string.Join(",", verification.ToArray()));

            return repo.saveSettings(notifications, verifications, confirmations);
        }
    }
}
