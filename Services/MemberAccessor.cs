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
            OpenConnection();

            var sql = "SELECT * FROM members";

            var members = connection.Query<Member>(sql).AsList();

            CloseConnection();
            return members;
        }

        public void Add(Member member)
        {
            OpenConnection();

            var sql = $@"
    INSERT INTO members(MemberId, FirstName, LastName, Phone, Email)
    VALUES('{member.MemberId}', '{member.FirstName}', '{member.LastName}', '{member.Phone}', '{member.Email}'
    )";

            connection.Execute(sql);

            CloseConnection();
        }

        //Remove book in DB
        public void Remove(Member member)
        {
            OpenConnection();

            var sql = $@"
    DELETE FROM members
    WHERE MemberId = {member.MemberId}";

            connection.Execute(sql);

            CloseConnection();
        }
    }
}
