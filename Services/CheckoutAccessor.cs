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
            connection.Open();

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

            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();

            List<Checkout> checkouts = new List<Checkout>();

            while (reader.Read())
            {
                Checkout obj = new Checkout
                {
                    CheckoutId = reader.GetInt32("CheckoutId"),
                    ISBN = reader.GetString("ISBN"),
                    MemberId = reader.GetInt32("MemberId"),
                    CheckOutDate = reader.GetDateTime("CheckOutDate"),
                    ReturnDate = reader.GetDateTime("ReturnDate"),
                    Title = reader.GetString("Title"),
                    Member = reader.GetString("Member")
                };
                checkouts.Add(obj);
            }

            connection.Close();
            return checkouts;
        }

        public void Add(Checkout checkout)
        {
            connection.Open();

            var sql = $@"
    INSERT INTO checkouts(CheckoutId, ISBN, MemberId, CheckOutDate, ReturnDate)
    VALUES('{checkout.CheckoutId}', '{checkout.ISBN}', {checkout.MemberId}, '{checkout.CheckOutDate.ToString("yyyy-MM-dd")}', '{checkout.ReturnDate.ToString("yyyy-MM-dd")}'
    )";

            connection.Execute(sql);

            connection.Close();
        }

        //Remove book in DB
        public void Remove(Checkout checkout)
        {
            connection.Open();

            var sql = $@"
    DELETE FROM checkouts
    WHERE CheckoutId = {checkout.CheckoutId}";

            connection.Execute(sql);

            connection.Close();
        }
    }
}
