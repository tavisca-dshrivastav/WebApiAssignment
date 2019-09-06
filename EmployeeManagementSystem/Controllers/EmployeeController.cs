using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeData>> Get()
        {
            return EmployeeList.employeeList ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult<EmployeeData> GetEmployee(string id)
        {
            return EmployeeList.GetEmployeeData(id) ?? (ActionResult<EmployeeData>)StatusCode(404);
        }

       
        // POST api/values
        [HttpPost("add")]
        public ActionResult Post([FromBody] EmployeeData record)
        {
            try
            {
                record.AddEmployee();
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(409);
            }
            
        }

        // PUT api/employee/update/5
        [HttpPut("update/{id}")]
        public ActionResult Put(string id, [FromBody] EmployeeData record)
        {
            bool isSuccessfullyUpdated = EmployeeList.updateEmployeeData(id, record);
            if (!isSuccessfullyUpdated)
                return StatusCode(409);
            return StatusCode(202);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
