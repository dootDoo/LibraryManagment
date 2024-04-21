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
            try
            {
                OpenConnection();

                var sql = "SELECT * FROM employees";

                var employees = connection.Query<Employee>(sql).AsList();

                return employees;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to retrieve employees.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Add(Employee employee)
        {
            try
            {
                OpenConnection();

                var sql = $@"
    INSERT INTO employees(EmployeeId, FirstName, LastName, Phone, Email)
    VALUES('{employee.EmployeeId}', '{employee.FirstName}', '{employee.LastName}', '{employee.Phone}', '{employee.Email}'
    )";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to add employees.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Remove book in DB
        public void Remove(Employee employee)
        {
            try
            {
                OpenConnection();

                var sql = $@"
    DELETE FROM employees
    WHERE EmployeeId = {employee.EmployeeId}";

                connection.Execute(sql);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Failed to remove employees.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
