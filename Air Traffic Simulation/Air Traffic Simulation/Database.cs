using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Air_Traffic_Simulation
{
    class Database
    {
        /*
        #region Declaration
        public MySqlConnection connection;


        public Database()
        {
            String connectionInfo = "server: studmysql01.fhict.local" +
                                    "database=dbi364927;" +
                                    "user id=dbi364927;" +
                                    "password= Yoannanumber1;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public void SQLStatement(string query)
        {

            try
            {
                connection.Open();
                MySqlCommand updateParticipant = new MySqlCommand(query, connection);
                updateParticipant.ExecuteNonQuery();

            }
            catch
            {
                
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region Login
        public bool GetLogin(string name, string password)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Login WHERE Name=" + name + " AND Password=" + password;
                MySqlCommand getEmp = new MySqlCommand(query, connection);
                MySqlDataReader datareader = getEmp.ExecuteReader();
                if (datareader != null)
                {
                    return true;
                }

                return false;

            }
            catch
            {
                
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        #endregion

        */
    }
}
