using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
namespace EmployeeManagementSystem.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService service = new EmployeeService();
       
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeData>> Get()
        {
            return service.GetAllEmployee().Select(x=>x.Record).ToList<EmployeeData>();
        }
        [HttpGet("{id}")]
        public ActionResult<EmployeeData> GetEmployee(string id)
        {
            return service.GetEmployee(id).Record;
        }


        // POST api/values
        [HttpPost("add")]
        public  void Post([FromBody] EmployeeData record)
        {
            service.AddEmployee(record);
        }

        // PUT api/employee/update/5
        [HttpPut("update/{id}")]
        public void Put(string id, [FromBody] EmployeeData record)
        {
            service.UpdateEmployee(id, record);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
