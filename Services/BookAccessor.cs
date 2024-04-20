using LibraryManagment.Models;
using Dapper;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class BookAccessor : DBAcessor
    {
        public BookAccessor() : base()
        {
        }

        //Return book items as list
        public List<Book> Get()
        {
            connection.Open();

            var sql = @"
    SELECT 
        b.ISBN, 
        b.Title, 
        b.Author, 
        c.Name AS Category,
        b.Publisher, 
        b.PublicationYear
    FROM 
        Books AS b
    JOIN 
        Categories AS c 
    ON 
        b.Category = c.CategoryId;";

            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();

            List<Book> books = new List<Book>();

            while (reader.Read())
            {
                Book obj = new Book
                {
                    ISBN = reader.GetString("ISBN"),
                    Title = reader.GetString("Title"),
                    Author = reader.GetString("Author"),
                    Category = reader.GetString("Category"),
                    Publisher = reader.GetString("Publisher"),
                    PublicationYear = reader.GetInt32("PublicationYear")
                };
                books.Add(obj);
            }

            connection.Close();
            return books;
        }
        //Add book to DB
        public void Add(Book book)
        {
            connection.Open();

            var sql = $@"
    INSERT INTO books(ISBN, Title, Author, Category, Publisher, PublicationYear)
    VALUES('{book.ISBN}', '{book.Title}', '{book.Author}', '{book.Category}', '{book.Publisher}', '{book.PublicationYear}'
    )";

            connection.Execute(sql);

            connection.Close();
        }

        //Remove book in DB
        public void Remove(Book book)
        {
            connection.Open();

            var sql = $@"
    DELETE FROM books
    WHERE ISBN = {book.ISBN}";

            connection.Execute(sql);

            connection.Close();
        }
    }
}
