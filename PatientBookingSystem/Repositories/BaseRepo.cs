using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Repositories {
    class BaseRepo {
        protected DbConnector db;

        public BaseRepo() {
            db = new DbConnector();
        }

        /** 
         * Method returns a string in MySQL insertable format 
         * 
         * @param content 
         * @return string in format that can be saved by MySQL database
         */
        protected string getStringInMySqlInsertableFormat(string content) {
            return content.Equals("NULL") ? content : '"' + content + '"';
        }

        /** 
         * Method updates contents of the database 
         * 
         * @param query
         * @return result of updating
         */
        protected bool adjustDb(string query) {
            MySqlCommand command = db.connection.CreateCommand();
            command.CommandText = query;
            db.OpenConnection();
            int result = command.ExecuteNonQuery();
            if (result == -1) {
                return false;
            }
            return true;
        }
    }
}
