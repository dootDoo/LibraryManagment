using MySqlConnector;

namespace LibraryManagment.Services
{
    public abstract class DBAcessor
    {
        public static MySqlConnection connection;

        public DBAcessor()
        {
            try
            {
                string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
                string dbUser = Environment.GetEnvironmentVariable("DB_USER");
                string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

                var builder = new MySqlConnectionStringBuilder
                {
                    Server = dbHost,
                    UserID = dbUser,
                    Password = dbPassword,
                    Database = "library",
                };

                connection = new MySqlConnection(builder.ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to initialize database connection.", ex);
            }
        }

        protected void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to open database connection.", ex);
            }
        }

        protected void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to close database connection.", ex);
            }
        }
    }
}
