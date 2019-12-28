using Sol_Employee_List_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Employee_List_MVC.TagHelpers
{
    public class EmployeeTagHelperModel
    {
        public List<EmployeeModel> ListEmployee { get; set; }

        public EmployeeModel Employee { get; set; }

        public String ViewActionName { get; set; }

        public String ControllerName { get; set; }
    }
}
