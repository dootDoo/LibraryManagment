using Dapper;
using LibraryManagment.Models;
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

            CloseConnection();
            return checkouts;
        }

        public void Add(Checkout checkout)
        {
            OpenConnection(); // Abstracted connection management

            var sql = $@"
    INSERT INTO checkouts(CheckoutId, ISBN, MemberId, CheckOutDate, ReturnDate)
    VALUES('{checkout.CheckoutId}', '{checkout.ISBN}', {checkout.MemberId}, '{checkout.CheckOutDate.ToString("yyyy-MM-dd")}', '{checkout.ReturnDate.ToString("yyyy-MM-dd")}'
    )";

            connection.Execute(sql);

            CloseConnection();
        }

        //Remove book in DB
        public void Remove(Checkout checkout)
        {
            OpenConnection(); // Abstracted connection management

            var sql = $@"
    DELETE FROM checkouts
    WHERE CheckoutId = {checkout.CheckoutId}";

            connection.Execute(sql);

            CloseConnection();
        }
    }
}
