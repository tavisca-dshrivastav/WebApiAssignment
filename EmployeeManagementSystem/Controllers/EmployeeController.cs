using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
        // GET api/values
        [HttpGet("employee")]
        public ActionResult<IEnumerable<EmployeeData>> Get()
        {
            var recordList = ControllerUtility.GetEmployeeDataFromRecord(EmployeeList.employeeList);
            return recordList ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound();
        }

        // GET api/values/5
        [HttpGet("manager/{id}/employee")]
        public ActionResult<IEnumerable<EmployeeData>> Get(string id)
        {
            var recordList = ControllerUtility.GetEmployeeListUnderManager(id);
            List<EmployeeData> empData = ControllerUtility.GetEmployeeDataFromRecord(recordList);
            return empData ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound();
        }

        // POST api/values
        [HttpPost("employee/add")]
        public ActionResult Post([FromBody] EmployeeData record)
        {
            Employee emp = new EmployeeFactory().MakeEmployee(record);
            EmployeeList.employeeList.Add(emp);
      
            return (ActionResult)CreatedAtAction("status code", 201);
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
