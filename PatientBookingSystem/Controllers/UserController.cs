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

    }
}
