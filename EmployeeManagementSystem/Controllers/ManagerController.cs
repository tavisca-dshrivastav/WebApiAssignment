using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem;
using EmployeeManagementSystem.Services;
namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
   
    public class ManagerController : ControllerBase
    {
        ManagerService service = new ManagerService();
        // GET api/manager/
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeData>> Get()
        {
            return service.GetAllManager().Select(x => x.Record).ToList<EmployeeData>();
        }

        // GET api/manager/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeData> Get(string id)
        {
            return service.GetManager(id).Record;
        }

        // GET api/manager/5/employees
        [HttpGet("{id}/employees")]
        public ActionResult<IEnumerable<EmployeeData>> GetEmployeesUnderManager(string id)
        {
            return service.GetEmployeeUnderManager(id).Select(x=>x.Record).ToList<EmployeeData>();
        }


        // POST api/manager/add/
        [HttpPost("add/")]
        public void Post([FromBody] EmployeeUnderManager employeeUnderManager)
        {
            service.AddManager(employeeUnderManager.ManagerInfo, employeeUnderManager.EmployeesIdUnderManager);
        }

        // PUT api/manager/update/5
        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        // DELETE api/manager/delete/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}