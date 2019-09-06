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
