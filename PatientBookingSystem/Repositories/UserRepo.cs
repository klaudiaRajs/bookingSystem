using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingSystem.Models;
using MySql.Data.MySqlClient;
using PatientBookingSystem.Mappers;

namespace PatientBookingSystem.Repositories {
    class UserRepo : BaseRepo {
        string table = "pbs_user";

        public List<IModel> getListOfAllUsers() {
            string query = "SELECT * FROM " + this.table;
            List<IModel> users = this.db.Query(query, new UserMapper());
            if( users.Count == 0) {
                return null; 
            }
            return users; 
        }

        public List<IModel> getListOfAllPatients() {
            string query = "SELECT * FROM " + this.table + " WHERE userType = \"patient\"";
            List<IModel> patients = this.db.Query(query, new UserMapper());
            if (patients.Count == 0) {
                return null;
            }
            return patients;
        }

        public bool save(UserModel user) {
            string query = "INSERT INTO " + table
                + " (`firstName`, `lastName`, `login`, `password`, `DOB`, `phoneNumber`, `email`, `NiN`, `address`, `confirmationMethod`, `userType`) VALUES ("
                + this.getStringInMySqlInsertableFormat(user.getFirstName()) + ", "
                + this.getStringInMySqlInsertableFormat(user.getLastName()) + ", "
                + this.getStringInMySqlInsertableFormat(user.getLogin()) + ", "
                + this.getStringInMySqlInsertableFormat(user.getPassword()) + ", "
                + this.getStringInMySqlInsertableFormat(user.getDobInMySqlFormat()) + ", "
                + (user.getPhoneNumber() == "NULL" ? user.getPhoneNumber() : this.getStringInMySqlInsertableFormat(user.getPhoneNumber())) + ", "
                + this.getStringInMySqlInsertableFormat(user.getEmail()) + ", "
                + (user.getNiN() == "NULL" ? user.getNiN() : this.getStringInMySqlInsertableFormat(user.getNiN())) + ", "
                + (user.getAddress() == "NULL" ? user.getAddress() : this.getStringInMySqlInsertableFormat(user.getAddress())) + ", "
                + this.getStringInMySqlInsertableFormat(user.getConfirmationMethod()) + ", "
                + this.getStringInMySqlInsertableFormat(user.getUserType()) + ")";
            return this.db.Execute(query); 
        }

        public List<IModel> getListOfPatientsHavingUpcomingAppointmentsForGivenDoctor(int doctorId) {
            string query = "SELECT u.* from " + this.table
                + " u JOIN pbs_booking b on b.userId = u.id "
                + " JOIN pbs_staffschedule ss on ss.staffScheduleId = b.staffScheduleId "
                + " JOIN pbs_staff s on s.staffId = ss.staffId "
                + " WHERE s.staffId = " + doctorId + " GROUP BY u.id";
            List<IModel> patients = this.db.Query(query, new UserMapper());
            return patients;
        }

        public UserModel getUserByLoginCredentials(String login, String password) {
            String query = "SELECT * FROM " + this.table + " WHERE login='" + login + "' and password ='" + password + "'";
            List<IModel> list = this.db.Query(query, new UserMapper());
            if (list.Count == 0) {
                return null;
            }
            return list.ElementAt(0) as UserModel;
        }

    }
}
