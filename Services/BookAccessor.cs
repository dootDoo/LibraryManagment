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
            OpenConnection(); // Abstracted connection handling
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

            List<Book> books = connection.Query<Book>(sql).AsList();

            CloseConnection();
            return books;
        }
        //Add book to DB
        public void Add(Book book)
        {
            OpenConnection();

            var sql = $@"
    INSERT INTO books(ISBN, Title, Author, Category, Publisher, PublicationYear)
    VALUES('{book.ISBN}', '{book.Title}', '{book.Author}', '{book.Category}', '{book.Publisher}', '{book.PublicationYear}'
    )";

            connection.Execute(sql);

            CloseConnection();
        }

        //Remove book in DB
        public void Remove(Book book)
        {
            OpenConnection();

            var sql = $@"
    DELETE FROM books
    WHERE ISBN = {book.ISBN}";

            connection.Execute(sql);

            CloseConnection();
        }
    }
}
