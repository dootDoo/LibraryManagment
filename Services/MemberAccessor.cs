using Dapper;
using LibraryManagment.Models;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class MemberAcessor : DBAcessor
    {
        public MemberAcessor() : base()
        {
        }

        public List<Member> Get()
        {
            try
            {
                OpenConnection();

                var sql = "SELECT * FROM members";

                var members = connection.Query<Member>(sql).AsList();

                return members;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to retrieve members.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Add(Member member)
        {
            try
            {
                OpenConnection();

                var sql = $@"
    INSERT INTO members(MemberId, FirstName, LastName, Phone, Email)
    VALUES('{member.MemberId}', '{member.FirstName}', '{member.LastName}', '{member.Phone}', '{member.Email}'
    )";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to add members.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Remove book in DB
        public void Remove(Member member)
        {
            try
            {
                OpenConnection();

                var sql = $@"
    DELETE FROM members
    WHERE MemberId = {member.MemberId}";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to remove members.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
