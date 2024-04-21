using LibraryManagment.Models;
using Dapper;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class CheckoutAccessor : DBAcessor
    {
        public CheckoutAccessor() : base()
        {
        }

        public List<Checkout> Get()
        {
            try
            {
                OpenConnection(); // Abstracted connection management

                var sql = @"
                SELECT
                    c.CheckoutId,
                    c.ISBN,
                    c.MemberId,
                    c.CheckOutDate,
                    c.ReturnDate,
                    CONCAT(b.Title, ' by ', b.Author) AS Title,
                    CONCAT(m.LastName, ', ', m.FirstName) AS Member
                FROM
                    Checkouts c
                    INNER JOIN Books b ON c.ISBN = b.ISBN
                    INNER JOIN Members m ON c.MemberId = m.MemberId;";

                var checkouts = connection.Query<Checkout>(sql).AsList();

                return checkouts;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to retrieve checkouts.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Add(Checkout checkout)
        {
            try
            {
                OpenConnection(); // Abstracted connection management

                var sql = $@"
    INSERT INTO checkouts(CheckoutId, ISBN, MemberId, CheckOutDate, ReturnDate)
    VALUES('{checkout.CheckoutId}', '{checkout.ISBN}', {checkout.MemberId}, '{checkout.CheckOutDate.ToString("yyyy-MM-dd")}', '{checkout.ReturnDate.ToString("yyyy-MM-dd")}'
    )";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to add checkouts.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Remove book in DB
        public void Remove(Checkout checkout)
        {
            try
            {
                OpenConnection(); // Abstracted connection management

                var sql = $@"
    DELETE FROM checkouts
    WHERE CheckoutId = {checkout.CheckoutId}";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to remove checkouts.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
