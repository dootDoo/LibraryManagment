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
            OpenConnection();

            var sql = "SELECT * FROM employees";

            var employees = connection.Query<Employee>(sql).AsList();

            CloseConnection();
            return employees;
        }

        public void Add(Employee employee)
        {
            OpenConnection();

            var sql = $@"
    INSERT INTO employees(EmployeeId, FirstName, LastName, Phone, Email)
    VALUES('{employee.EmployeeId}', '{employee.FirstName}', '{employee.LastName}', '{employee.Phone}', '{employee.Email}'
    )";

            connection.Execute(sql);

            CloseConnection();
        }

        //Remove book in DB
        public void Remove(Employee employee)
        {
            OpenConnection();

            var sql = $@"
    DELETE FROM employees
    WHERE EmployeeId = {employee.EmployeeId}";

            connection.Execute(sql);

            CloseConnection();
        }
    }
}
