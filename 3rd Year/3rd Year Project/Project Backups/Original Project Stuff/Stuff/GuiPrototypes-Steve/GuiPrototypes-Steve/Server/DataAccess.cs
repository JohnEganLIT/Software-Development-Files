using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Security;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Data;

namespace Server {
    // Data Access Object
    public class DataAccess {
        //private BlackList blackList;
        private SqlConnection ppb;
        private MySqlConnection mla;
        private MySqlConnection mto;
        private Logger logger;
        private Dictionary<string, string> procs;

        public DataAccess(Logger log) {
            logger = log;

            // key must alreay exist ensuring only valid commands get executed
            // values must be stored procedures using the class member names.
            procs = new Dictionary<string, string>();
            //procs.Add("Login", "CALL Login(@UserName, @Cipher);");
            procs.Add("Login",          "LoginUser");
            procs.Add("AddUser",        "AddUser");
            procs.Add("EditUser",       "EditUser");
            procs.Add("ViewUser",       "ViewUser");
            procs.Add("ListUser",       "ListUser");
            procs.Add("RevokeUser",     "RevokeUser");
            procs.Add("ReactivateUser", "ReactivateUser");
            procs.Add("AddIdentity", "AddUserIdentity");
        }

        // ********************************************************************
        // Connect to the DataBase(s)
        // ********************************************************************
        public bool Connect() {
            try {
                ppb = new SqlConnection("Server=mssql3.gear.host;Database=dbppb;Uid=dbppb;Pwd=Qn7xT?U_6y69;");
              //ppb = new MySqlConnection("Server=localhost;Database=dbppb;Uid=root;Pwd=;");
                ppb.Open();
            } catch (Exception e) {
                logger.Alert("Failed to connect to the PPB database!" + e.Message);
                return false;
            }
/*
            try {
                mla = new MySqlConnection("Server=mssql4.gear.host;Database=mla;Uid=mla;Pwd=Gd4J6!-ieW1o;");
                mla.Open();
            } catch (Exception e) {
                logger.Alert("Failed to connect to the MLA database!" + e.Message);
                return false;
            }

            try {
                mto = new MySqlConnection("Server=mssql3.gear.host;Database=mto;Uid=mto;Pwd=Mz838?00_BF9;");
                mto.Open();
            } catch (Exception e) {
                logger.Alert("Failed to connect to the MTO database!" + e.Message);
                return false;
            }
            */

            // TODO: Populate this blacklist from a meta database
            //List<DataTranslator> rules = Select("BlackList");
            //Dictionary<string, bool> list = new Dictionary<string, bool>();
            //blackList = new BlackList(list);
            return true;
        }

        // ********************************************************************
        // Disconnect from the DataBase(s)
        // ********************************************************************
        ~DataAccess() {
            // It is wrong to manually Close these connections as they are
            // managed by the ODBC connector and will throw an exception when
            // the ODBC connector tries closing them
            //try { ppb.Close(); } catch (Exception e) { MessageBox.Show(e.Message); }
            //try { mla.Close(); } catch (Exception e) { MessageBox.Show(e.Message); }
            //try { mto.Close(); } catch (Exception e) { MessageBox.Show(e.Message); }
        }

        // ***************************************************************** //
        // Create - Inserts into a table (for testing purposes only)         //
        // ***************************************************************** //
        public object Insert(object record) {
            /*
            // if the access is forbidden
            string table = record.GetType().ToString();
            if (blackList.Forbid("Create", table)) {
                return null;
            }

            // proceed
            */
            return null;
        }

        // ***************************************************************** //
        // Delete - Deletes from a table (for testing purposes only)         //
        // ***************************************************************** //
        public object Delete(object record) {
            /*
            // if the access is forbidden
            string table = record.GetType().ToString();
            if (blackList.Forbid("Delete", table)) {
                return null;
            }

            // proceed
            */
            return null;
        }

        // ***************************************************************** //
        // Write - Selects from a table (for testing purposes only)          //
        // ***************************************************************** //
        public object Update(object record) {
            /*
            // if the access is forbidden
            string table = record.GetType().ToString();
            if (blackList.Forbid("Write", table)) {
                return null;
            }

            // proceed
            */
            return null;
        }

        // ***************************************************************** //
        // Read - Selects from a table (for testing purposes only)           //
        // ***************************************************************** //
        public Dictionary<string, object>[] Select(string table) {
            // if the access is forbidden, then do nothing
            //if (blackList.Forbid("Read", table)) return null;

            // build the query
            //MySqlCommand cmd = new MySqlCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM login WHERE 'UserName' = 'Colin';";
            cmd.Connection = ppb;

            // execute the query
            return ResultSet(cmd);
        }

        // ***************************************************************** //
        // Builds an SQL Stored Proceedure Query from a Given Name and Json. //
        // ***************************************************************** //
        public Dictionary<string, object>[] Call(string proc, string json) {
            // if the access is forbidden, then do nothing
            //if (blackList.Forbid("Read", table)) return null;

            // Deserialize the json string
            Dictionary<string, string> items = JsonConvert.
                DeserializeObject<Dictionary<string, string>>(json);
            if (items == null) return null;

            // build the query
            if (!procs.ContainsKey(proc)) return null;
            //MySqlCommand cmd = new MySqlCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ppb;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procs[proc];
            cmd.Prepare();

            DateTime bad = new DateTime();
            try { bad = DateTime.Parse(""); } catch (Exception e) { }

            foreach (KeyValuePair<string, string> item in items) {
                DateTime date = new DateTime();
                try {
                    date = DateTime.ParseExact(item.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                } catch (Exception e) { }

                if (!date.Equals(bad)) {
                    //MySqlParameter parameter = cmd.Parameters.Add("@"+item.Key, MySqlDbType.DateTime);
                    SqlParameter parameter = cmd.Parameters.Add("@"+item.Key, SqlDbType.DateTime);
                    parameter.Value = DateTime.Parse(item.Value);
                } else {
                    cmd.Parameters.AddWithValue("@"+item.Key, item.Value);
                }
            }

            // execute the query
            return ResultSet(cmd);
        }

        // ***************************************************************** //
        // Executes an SQL Query and converts the result set into an array   //
        // Output is suitable for conversion to a json encoded string.       //
        // ***************************************************************** //
        private Dictionary<string, object>[] ResultSet(SqlCommand cmd) {
            // execute the query
            //MySqlDataReader reader = null;
            SqlDataReader reader = null;
            try {
                reader = cmd.ExecuteReader();
            } catch (Exception e) {
                logger.Fail(e.Message);
                return null;
            }

            // populate list
            int columns = reader.FieldCount;
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            while (reader.Read()) {
                Dictionary<string, object> record = new Dictionary<string, object>();
                for (int i = 0; i < columns; i++) {
                    record.Add(reader.GetName(i), reader.GetValue(i));
                }
                list.Add(record);
            }
            reader.Close();
            return list.ToArray();
        }
    }

    public class Login {
        public string UserName;
        public string Cipher;
    }
}
