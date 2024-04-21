using LibraryManagment.Models;
using Dapper;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class CategoryAccessor : DBAcessor
    {
        public CategoryAccessor() : base()
        {
        }

        public List<Category> Get()
        {
            try
            {
                OpenConnection();

                var sql = "SELECT * FROM categories";

                List<Category> categories = connection.Query<Category>(sql).AsList();

                return categories;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to retrieve categories.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
