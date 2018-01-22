using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace FilesFolders.Data
{
    class DataAccess
    {

        static string _ConnectionString = "DataSource=RIPSDB.db";

        static SQLiteConnection _Connection = null;

        public static SQLiteConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SQLiteConnection(_ConnectionString);
                    _Connection.Open();

                    return _Connection;
                }
                else if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();

                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            Connection.Close();

            return ds;
        }

        public static DataTable GetDataTable(string sql)
        {
            DataSet ds = GetDataSet(sql);

            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        public static int ExecuteSQL(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
            return cmd.ExecuteNonQuery();

        }

        public static string ExecuteReader(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, Connection);

            SQLiteDataReader reader = cmd.ExecuteReader();

            string result = string.Empty;

            try
            {
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                reader.Close();

            }
            return result;

        }



    }
}
