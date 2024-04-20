using LibraryManagment.Models;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class CategoryAcessor : DBAcessor
    {
        public CategoryAcessor() : base()
        {
        }

        public List<Category> Get()
        {
            connection.Open();

            var sql = @"SELECT * FROM categories";

            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (reader.Read())
            {
                Category obj = new Category
                {
                    CategoryId = reader.GetInt32("CategoryId"),
                    Name = reader.GetString("Name")
                };
                categories.Add(obj);
            }

            connection.Close();
            return categories;
        }
    }
}
