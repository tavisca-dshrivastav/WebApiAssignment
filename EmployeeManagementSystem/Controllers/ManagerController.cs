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
        // GET api/manager
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeData>> Get()
        {
            return EmployeeList.GetManagersData() ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound("No Manager Found");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeData> Get(string id)
        {
            return EmployeeList.GetManager(id) ?? (ActionResult<EmployeeData>)NotFound("No Manager Found");
        }

        // GET api/manager/5/employees
        [HttpGet("{id}/employees")]
        public ActionResult<IEnumerable<EmployeeData>> GetEmployeesUnderManager(string id)
        {
            return EmployeeList.GetEmployeesUnderManager(id.GetEmployeeData()) ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound("No Employee Found");
        }


        // POST api/values
        [HttpPost("add/")]
        public ActionResult Post([FromBody] EmployeeUnderManager employeeUnderManager)
        {
            bool isSuccessfullyAssigned = EmployeeList.AssignEmployeesToManager(employeeUnderManager.ManagerId, employeeUnderManager.Employees);
            if(!isSuccessfullyAssigned)
                return StatusCode(409);
            return StatusCode(201);
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