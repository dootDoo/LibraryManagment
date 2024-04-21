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
            try
            {
                OpenConnection();

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

                var books = connection.Query<Book>(sql).AsList();

                return books;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to retrieve books.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        //Add book to DB
        public void Add(Book book)
        {
            try
            {
                OpenConnection();

                var sql = $@"
    INSERT INTO books(ISBN, Title, Author, Category, Publisher, PublicationYear)
    VALUES('{book.ISBN}', '{book.Title}', '{book.Author}', '{book.Category}', '{book.Publisher}', '{book.PublicationYear}'
    )";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to add books.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Remove book in DB
        public void Remove(Book book)
        {
            try
            {
                OpenConnection();

                var sql = $@"
    DELETE FROM books
    WHERE ISBN = {book.ISBN}";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to remove books.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
