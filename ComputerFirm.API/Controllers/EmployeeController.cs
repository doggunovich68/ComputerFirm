using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ComputerFirm.API.Controllers
{
     [Route("api/[controller]")]
     public class EmployeeController : Controller
     {
	[HttpGet]
        [Route("search")]
        public IActionResult Search(string searchString)
        {
            var hardCodedEmployees = new List<Employee>
            {
                new Employee {Name = "Josh"},
                new Employee {Name = "Joshua"},
                new Employee {Name = "Joseph"},
                new Employee {Name = "Bill"},
            };

            var Employees = hardCodedEmployees
                .Where(x => x.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(Employees);
        }
     }
	 	 public class Employee
    		{
       	 		public string Name { get; set; }
    		}	
}
