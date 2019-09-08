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
        public async Task<ActionResult<IEnumerable<EmployeeData>>> Get()
        {
            return await Task.Run(() => { return service.GetAllEmployee().Result.Select(x => x.Record).ToList<EmployeeData>() ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound("No Employee Found"); });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeData>> GetEmployee(string id)
        {
            return await Task.Run(()=> { return service.GetEmployee(id).Result.Record ?? (ActionResult<EmployeeData>)NotFound("Employee Not Found"); });
        }


        // POST api/values
        [HttpPost("add")]
        public async Task Post([FromBody] EmployeeData record)
        {
            await Task.Run(()=>service.AddEmployee(EmployeeFactory.CreateEmployee(record)));
        }

        // PUT api/employee/update/5
        [HttpPut("update/{id}")]
        public async Task Put(string id, [FromBody] EmployeeData record)
        {
            await Task.Run(()=>service.UpdateEmployee(id, EmployeeFactory.CreateEmployee(record)));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await Task.Run(()=>service.DeleteEmployee(id));
        }
        
    }
}
