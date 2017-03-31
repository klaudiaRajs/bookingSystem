using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Repositories {
    class BaseRepo {
        //todo popeawic i usuac!!
        protected DbConnector db;

        public BaseRepo() {
            db = new DbConnector();
        }

        protected string getStringInMySqlInsertableFormat(string content) {
            return content.Equals("NULL") ? content : '"' + content + '"';
        }


        protected MySqlDataReader getFromDb(string query) {
            /*db.OpenConnection();
            MySqlCommand cmd = db.Select(query);
            if (cmd != null) {
                MySqlDataReader dataReader = cmd.ExecuteReader();
                return dataReader;
            }
            db.CloseConnection();*/
            return null;
        }

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

        protected bool deleteFromDb(string query) {
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
