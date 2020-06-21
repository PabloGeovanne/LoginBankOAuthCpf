using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSOUE.Models.UseFul
{
    public class DalModel
    {

        private static readonly string Server = "localhost";
        private static readonly string Database = "databaseqa_soue";
        private static readonly string User = "soue_user";
        private static readonly string Password = "123";
        private static readonly string Ssl = "Preferred";
        private static readonly string Charset = "utf8";
        private static readonly string Port = "3306";

        private static readonly string ConnectionString = $"Server={Server};Port={Port};Database={Database};Uid={User};Pwd={Password};SslMode={Ssl};Charset={Charset};";

        private static MySqlConnection Connection;

        public DalModel()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        public DataTable ReturnDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(Command);
            da.Fill(data);

            return data;
        }

        public DataTable ReturnDataTable(MySqlCommand Command)
        {
            DataTable data = new DataTable();
            Command.Connection = Connection;
            MySqlDataAdapter da = new MySqlDataAdapter(Command);
            da.Fill(data);

            return data;
        }

        public void ExecuteCommandSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        public void ExecuteCommandSQL(MySqlCommand Command)
        {
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
