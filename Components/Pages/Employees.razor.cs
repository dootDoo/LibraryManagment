using LibraryManagment.Models;
using LibraryManagment.Services;
using Microsoft.AspNetCore.Components;
using MySqlConnector;

namespace LibraryManagment.Components.Pages
{
    public partial class Employees : PagesInterface
    {
        // Initialize variables
        public List<Employee> employees = new List<Employee>();

        private Employee employee = new Employee();
        private Employee currentEmployee = new Employee();

        bool invalidPhone = false;
        bool invalidEmail = false;

        private EmployeeAccessor employeeAcessor = new EmployeeAccessor();

        //Get list of DB items into a list
        protected override void OnInitialized()
        {
            employees = employeeAcessor.Get();
        }

        //Add new book
        public void Add()
        {
            if (employees.Any(e => e.Phone == employee.Phone))
            {
                invalidPhone = true;
                return;
            }
            if (employees.Any(e => e.Email == employee.Email))
            {
                invalidEmail = true;
                return;
            }

            employeeAcessor.Add(employee);

            employees = employeeAcessor.Get();

            employee = new Employee{};

            invalidPhone = false;
            invalidEmail = false;
        }
        //Remove new book
        public void Remove(Employee employee)
        {
            employeeAcessor.Remove(employee);

            employees = employeeAcessor.Get();
        }
        //Select currentBook by id and display contents
        public void Select(ChangeEventArgs e)
        {
            int selectedId = int.Parse(e.Value.ToString());

            if (selectedId > 0)
            {
                currentEmployee = employees.FirstOrDefault(employee => employee.EmployeeId == selectedId);
            }
            return;
        }
    }
}
