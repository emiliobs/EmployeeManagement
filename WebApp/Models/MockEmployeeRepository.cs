using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
   public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> employees;


        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Emilio", Departmet = Department.HR, Email ="Emilio@gmail.com" },
                new Employee() { Id = 2, Name = "Rita", Departmet = Department.IT, Email ="rita@gmail.com" },                
                new Employee() { Id = 4, Name = "Katrina", Departmet = Department.Payroll, Email ="katrina@gmail.com" },
               
            };
        }

        public Employee Add(Employee employee)
        {
            var employeeId = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee() => employees.ToList();
      
        public Employee GetEmployee(int Id) => employees.FirstOrDefault(e => e.Id.Equals(Id)); 
     
    }
}
