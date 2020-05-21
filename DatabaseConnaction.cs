using Oracle.ManagedDataAccess.Client;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace RoryBot
{
    class DatabaseConnaction
    {
        //declare a list to store the values from the database 
        private List<string> data;
        //declare a oracleConneaction to the database
        private MySqlConnection con;
        //declare a datareader to read the data from the database 
        private MySqlDataReader dr;
        //declare a oracleCommand to excute sql command
        private MySqlCommand cmd;
        //declare the connaction string that will contain the conncation information to the database
        private string connectionString;
        //default constractor 
        public DatabaseConnaction()
        {
            //instantiate code list 
            data = new List<string>();
            //store the infomation for the connection of the database
            connectionString = "server=remotemysql.com;user=xxW2jCQYg6;database=xxW2jCQYg6;port=3306;password=ZPbYjRyAJS;"; ;
            con = new MySqlConnection(connectionString);
        }

        //get or set the values in a list that house the data from the database 
        public List<string> myData
        {
            get { return data; }
            set { data = value; }
        }




        public List<string> getCode(string solution, string unitId)
        {
            string sql = $"select code from code where code_type='{solution}' and unit_id={unitId}";
            //open a connection to the database
            con.Open();
            ////OracleCommand object with sql command
            cmd = new MySqlCommand(sql, con);
            ////sql command
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //read the data from the database 
            dr = cmd.ExecuteReader();

            //loop until the data reader have data to read 
            while (dr.Read())
            {
                //return the data in a string format and store then in the list
                data.Add(dr.GetValue(0).ToString());
            }
            //close the connaction with the database 
            con.Dispose();
            //return codes list
            return data;

        }

        public List<string> getOnce(string solution, string unitId,string numberOfSolution)
        {
            string sql = $"select code from code where code_type='{solution}' and unit_id={unitId} and code_number={numberOfSolution}";
            //open a connection to the database
            con.Open();
            ////OracleCommand object with sql command
            cmd = new MySqlCommand(sql, con);
            ////sql command
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //read the data from the database 
            dr = cmd.ExecuteReader();

            //loop until the data reader have data to read 
            while (dr.Read())
            {
                //return the data in a string format and store then in the list
                data.Add(dr.GetValue(0).ToString());
            }
            //close the connaction with the database 
            con.Dispose();
            //return codes list
            return data;

        }



        public List<string> getUnit(string unitId)
        {
            string sql = $"select unit_description from unit where unit_id='{unitId}'";
            //open a connection to the database
            con.Open();
            ////OracleCommand object with sql command
            cmd = new MySqlCommand(sql, con);
            ////sql command
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //read the data from the database 
            dr = cmd.ExecuteReader();

            //loop until the data reader have data to read 
            while (dr.Read())
            {
                //return the data in a string format and store then in the list
                data.Add(dr.GetValue(0).ToString());
            }
            //close the connaction with the database 
            con.Dispose();
            //return codes list
            return data;

        }



    }

}


