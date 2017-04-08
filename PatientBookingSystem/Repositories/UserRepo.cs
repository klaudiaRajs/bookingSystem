using System;
using System.Collections.Generic;
using System.Linq;
using PatientBookingSystem.Models;
using PatientBookingSystem.Mappers;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem.Repositories {
    /** Class is responsible for communication with database user table */
    class UserRepo : BaseRepo {

        string table = "pbs_user";

        /** Method returns list of all the users (admins and patients) */
        internal List<IModel> getListOfAllUsers() {
            string query = "SELECT * FROM " + this.table;
            List<IModel> users = this.db.Query(query, new UserMapper());
            return users; 
        }

        /** Method returns list of all the patients */
        internal List<IModel> getListOfAllPatients() {
            string query = "SELECT * FROM " + this.table + " WHERE userType = \"patient\"";
            List<IModel> patients = this.db.Query(query, new UserMapper());
            return patients;
        }

        /** Method saves user settings (updates row in the database) */
        internal bool saveSettings(string notification, string verification, string confirmation) {
            string query = "UPDATE " + this.table
                + " SET `notification` = " + this.getStringInMySqlInsertableFormat(notification)
                + ", `verification` = " + this.getStringInMySqlInsertableFormat(verification)
                + ", `confirmation` = " + this.getStringInMySqlInsertableFormat(confirmation)
                + " WHERE `id` = " + ApplicationState.userId;
            return this.db.Execute(query);
        }

        /** Method returns user's notification settings */
        internal string getNotificationSettings() {
            string query = "SELECT notification FROM " + table + " WHERE id = " + ApplicationState.userId;
            List<IModel> user = this.db.Query(query, new UserMapper());
            return ((UserModel)user.First()).getNotificationSettings();
        }

        /** MEthod saves user to the database */
        internal bool save(UserModel user) {
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
                + this.getStringInMySqlInsertableFormat(user.getUserType()) + ")";
            return this.db.Execute(query); 
        }

        /** Method returns list of all the patients having upcoming appointments for given staff member */
        public List<IModel> getListOfPatientsHavingUpcomingAppointmentsForGivenStaffMember(int staffMember) {
            string query = "SELECT u.* from " + this.table
                + " u JOIN pbs_booking b on b.userId = u.id "
                + " JOIN pbs_staffschedule ss on ss.staffScheduleId = b.staffScheduleId "
                + " JOIN pbs_staff s on s.staffId = ss.staffId "
                + " WHERE s.staffId = " + staffMember + " GROUP BY u.id";
            List<IModel> patients = this.db.Query(query, new UserMapper());
            return patients;
        }

        /** Method returns list of users by login credentials */
        public List<IModel> getListOfUsersByLoginCredentials(String login, String password) {
            //this.db.printOutDatabases();
            //this.db.printOutTables();
            //this.db.printOutUsers();

            String query = "SELECT * FROM " + this.table + " WHERE login='" + login + "' and password ='" + password + "'";
            List<IModel> list = this.db.Query(query, new UserMapper());

            return list;
        }

    }
}
