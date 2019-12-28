using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Employee_List_MVC.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public string Desgination { get; set; }

        public String Department { get; set; }

        public string ProfilePicUrl { get; set; }

        public String Address { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
    }
}
