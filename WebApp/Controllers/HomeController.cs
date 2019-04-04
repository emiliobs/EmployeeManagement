using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.ViewMoldels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


       
        public ViewResult Index() => View(employeeRepository.GetAllEmployee().OrderBy(e => e.Name));
      

        
        public ViewResult Details(int? id, string name)
        {



            var model = new EmployeeViewModel()
            {
                Employee = employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details",
            };


           
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult Create(Employee employee)
        {
           var newEmployee = this.employeeRepository.Add(employee);

            return RedirectToAction("Details", new { id = newEmployee.Id });
        }

    }
}
