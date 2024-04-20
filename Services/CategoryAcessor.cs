using Dapper;
using LibraryManagment.Models;

namespace LibraryManagment.Services
{
    public class CategoryAccessor : DBAcessor
    {
        public CategoryAccessor() : base()
        {
        }

        public List<Category> Get()
        {
            OpenConnection();

            var sql = "SELECT * FROM categories";

            List<Category> categories = connection.Query<Category>(sql).AsList();

            CloseConnection();
            return categories;
        }
    }
}
