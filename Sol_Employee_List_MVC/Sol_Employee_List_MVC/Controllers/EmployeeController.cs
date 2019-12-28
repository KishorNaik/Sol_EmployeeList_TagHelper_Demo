using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Employee_List_MVC.Models;
using Sol_Employee_List_MVC.Repository;
using Sol_Employee_List_MVC.ViewModel;

namespace Sol_Employee_List_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository = null;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            EmployeeVM = new EmployeeViewModel();
        }

        [BindProperty]
        public EmployeeViewModel EmployeeVM { get; set; }

        [BindProperty(SupportsGet =true)]
        public int id { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            EmployeeVM.ListEmployee = (await this.employeeRepository?.GetEmployeeData()).ToList();
            return View(EmployeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> OnSearch()
        {
            EmployeeVM.Employee = new Models.EmployeeModel()
            {
                FirstName = EmployeeVM.SearchText,
                LastName = EmployeeVM.SearchText,
                Department = EmployeeVM.SearchText
            };

            var searchData = await employeeRepository?.GetSearchData(EmployeeVM.Employee);

            EmployeeVM.ListEmployee = searchData.ToList();

            return View("Index",EmployeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> OnView()
        {
            EmployeeVM.Employee = await employeeRepository?.GetSingleEmployeeData(new EmployeeModel()
            {
                Id = id
            });

            return View(EmployeeVM);
        }
    }
}