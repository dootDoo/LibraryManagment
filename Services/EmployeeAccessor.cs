using Dapper;
using LibraryManagment.Models;
using MySqlConnector;

namespace LibraryManagment.Services
{
    public class EmployeeAccessor : DBAcessor
    {
        public EmployeeAccessor() : base()
        {
        }

        public List<Employee> Get()
        {
            connection.Open();

            var sql = @"SELECT * FROM employees";

            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();

            while (reader.Read())
            {
                Employee obj = new Employee
                {
                    EmployeeId = reader.GetInt32("EmployeeId"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Phone = reader.GetString("Phone"),
                    Email = reader.GetString("Email")
                };
                employees.Add(obj);
            }

            connection.Close();
            return employees;
        }

        public void Add(Employee employee)
        {
            connection.Open();

            var sql = $@"
    INSERT INTO employees(EmployeeId, FirstName, LastName, Phone, Email)
    VALUES('{employee.EmployeeId}', '{employee.FirstName}', '{employee.LastName}', '{employee.Phone}', '{employee.Email}'
    )";

            connection.Execute(sql);

            connection.Close();
        }

        //Remove book in DB
        public void Remove(Employee employee)
        {
            connection.Open();

            var sql = $@"
    DELETE FROM employees
    WHERE EmployeeId = {employee.EmployeeId}";

            connection.Execute(sql);

            connection.Close();
        }
    }
}
