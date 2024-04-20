using Dapper;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public abstract class DBAcessor
    {
        public static MySqlConnection connection;

        public DBAcessor()
        {
            // get environemnt variable
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var builder = new MySqlConnectionStringBuilder
            {
                Server = dbHost,
                UserID = dbUser,
                Password = dbPassword,
                Database = "library", // Use maria db to create a database called library
            };

            connection = new MySqlConnection(builder.ConnectionString);
        }
        protected void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}