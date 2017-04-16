using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using PatientBookingSystem.Mappers;

namespace PatientBookingSystem.Models {
    class DbConnector {

        public MySqlConnection connection;

        public DbConnector() {
            Initialize();
        }

        private void Initialize() {
            connection = new MySqlConnection(config.connectionString);
        }

        /** 
         * Method prints out databases available on given host - used for debugging purposes 
         */
        public void printOutDatabases() {
            if (!this.OpenConnection()) {
                return;
            }
            MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) {
                for (int i = 0; i < dataReader.FieldCount; i++) {
                    string fieldName = dataReader.GetName(i);
                    Console.Write(fieldName);
                    Console.Write(":");
                    Console.WriteLine(dataReader.GetString(fieldName));
                }
            }
            Console.WriteLine("");
            this.CloseConnection();
        }

        /** Method used for printing out tables - used for debugging purposes */
        public void printOutTables() {
            if (!this.OpenConnection()) {
                return;
            }
            MySqlCommand cmd2 = new MySqlCommand("SHOW TABLES", connection);
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            while (dataReader2.Read()) {
                for (int i = 0; i < dataReader2.FieldCount; i++) {
                    string fieldName = dataReader2.GetName(i);
                    Console.Write(fieldName);
                    Console.Write(":");
                    Console.WriteLine(dataReader2.GetString(fieldName));
                }
            }
            Console.WriteLine("");
            this.CloseConnection();
        }

        /** Method used for debugging purposes - prints out the users */
        public void printOutUsers() {
            if (!this.OpenConnection()) {
                return;
            }
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM pbs_user", connection);
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            while (dataReader2.Read()) {
                for (int i = 0; i < dataReader2.FieldCount; i++) {
                    string fieldName = dataReader2.GetName(i);
                    Console.Write(fieldName);
                    Console.Write(":");
                    Console.WriteLine(dataReader2.GetString(fieldName));
                }
            }
            Console.WriteLine("");
            this.CloseConnection();
        }

        /** Method opens connection */
        public bool OpenConnection() {
            try {
                connection.Open();
                return true;
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /** Method closes connection */
        public bool CloseConnection() {
            try {
                connection.Close();
                return true;
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /** Method used for queries */
        public List<IModel> Query(String query, IDataMapper mapper) {
            if (!this.OpenConnection()) {
                return null;
            }
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<IModel> result = new List<IModel>();
            while (dataReader.Read()) {
                result.Add(mapper.map(dataReader));
            }
            dataReader.Close();
            this.CloseConnection();
            return result;
        }

        /** Method used for manipulating data of the */
        public bool Execute(string command) {
            if (!this.OpenConnection()) {
                return false;
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = command;
            cmd.Connection = connection;
            bool result = true;
            try {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.Write(e);
                result = false;
            }
            this.CloseConnection();
            return result;
        }
    }
}
