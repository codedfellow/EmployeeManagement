using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees;

        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Elvis Aghaulor", Email = "elvis@gmail.com", Department = Dept.HR},
                new Employee() { Id = 2, Name = "Michael Moemeke", Email = "michael@gmail.com", Department = Dept.IT },
                new Employee() { Id = 3, Name = "Esther Aliemeke", Email = "esther@gmail.com", Department = Dept.Payroll }
            };
        }
        
        public Employee GetEmployee(int Id)
        {
            return employees.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return employee;
        }
    }
}
