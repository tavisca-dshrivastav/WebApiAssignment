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
            return empData;
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
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