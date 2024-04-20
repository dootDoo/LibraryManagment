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
            connection.Open();

            var sql = @"SELECT * FROM members";

            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();

            List<Member> members = new List<Member>();

            while (reader.Read())
            {
                Member obj = new Member
                {
                    MemberId = reader.GetInt32("MemberId"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Phone = reader.GetString("Phone"),
                    Email = reader.GetString("Email")
                };
                members.Add(obj);
            }

            connection.Close();
            return members;
        }

        public void Add(Member member)
        {
            connection.Open();

            var sql = $@"
    INSERT INTO members(MemberId, FirstName, LastName, Phone, Email)
    VALUES('{member.MemberId}', '{member.FirstName}', '{member.LastName}', '{member.Phone}', '{member.Email}'
    )";

            connection.Execute(sql);

            connection.Close();
        }

        //Remove book in DB
        public void Remove(Member member)
        {
            connection.Open();

            var sql = $@"
    DELETE FROM members
    WHERE MemberId = {member.MemberId}";

            connection.Execute(sql);

            connection.Close();
        }
    }
}
