using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WsCACC.Model
{
    public class ConnectionMySql
    {
        public static string connectionString { get; set; }
        public MySqlConnection conn { get; set; }
        public MySqlTransaction transaction { get; set; }

        public ConnectionMySql(string connectionString)
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public ConnectionMySql()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public void StartTransaction()
        {
            transaction = conn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction.Commit();
        }

        public void RollBackTransaction()
        {
            transaction.Rollback();
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlDataReader ExecuteQuery(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                return command.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
