using Dapper;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class DBAcessor
    {
        protected MySqlConnection connection;

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

        public void InitializeDatabase()
        {
            connection.Open();

            var sql = @"CREATE TABLE IF NOT EXISTS books (
                BookId VARCHAR(36) PRIMARY KEY,
                Title VARCHAR(255) NOT NULL,
                Author VARCHAR(255) NOT NULL,
                Description TEXT,
                Category VARCHAR(255)   
            )";

            connection.Execute(sql);

            connection.Close();
        }
    }
}