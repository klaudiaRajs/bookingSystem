using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool OpenConnection() {
            try {
                connection.Open();
                return true;
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                /*switch (ex.Number) {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }*/
                return false;
            }
        }

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

        public List<IModel> Query(String query, IDataMapper mapper) {
            //Open connection
            if (!this.OpenConnection()) {
                return null;
            }
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command

            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            List<IModel> result = new List<IModel>();
            while (dataReader.Read()) {
                result.Add(mapper.map(dataReader));
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();
            return result;
        }

        public bool Execute(string command) {
            if (!this.OpenConnection()) {
                return false;
            }
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = command;
            //Assign the connection using Connection
            cmd.Connection = connection;
            //Execute query
            bool result = true;
            try {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.Write(e);
                result = false;
            }
            //close connection
            this.CloseConnection();
            return result;
        }
    }
}
