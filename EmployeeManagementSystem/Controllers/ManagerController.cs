using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem;
namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeData>> Get()
        {
            var managers = EmployeeList.empUnderManagerList.Keys;
            var empData = ControllerUtility.GetEmployeeDataFromRecord(managers.ToList<Employee>());
            return empData ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeData> Get(string id)
        {
            foreach(var emp in EmployeeList.employeeList)
            {
                bool isManager = emp.GetType() == typeof(Manager);
                if (isManager && emp.GetEmployeeData().Id.Equals(id))
                    return emp.GetEmployeeData();
            }
            return NotFound();
        }

        
        // POST api/values
        [HttpPost("add/")]
        public ActionResult Post([FromBody] EmployeeUnderManager employeeUnderManager)
        {
            Employee emp = employeeUnderManager.ManagerId.GetEmployee();
            bool isManager = emp != null ? emp is Manager ? true : false : false;
            List <Employee> employees = new List<Employee>();
            foreach(var empId in employeeUnderManager.Employees)
            {
                var t = empId.GetEmployee();
                if (t != null)
                    employees.Add(t);
            }
           
            if (isManager)
            {
                EmployeeList.AddManager(emp, employees);
                return StatusCode(201);
            }

            //return employeeUnderManager;
            return StatusCode(409);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}