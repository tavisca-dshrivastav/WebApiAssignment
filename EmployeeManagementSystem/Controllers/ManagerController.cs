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
        public async Task<ActionResult<IEnumerable<EmployeeData>>> Get()
        {
            return await Task.Run(()=> {
                return service.GetAllManager()?.Select(x => x.Record).ToList<EmployeeData>()
                ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound("No Manager Found");
            });
        }

        // GET api/manager/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeData>> Get(string id)
        {
            return await Task.Run(()=>{
                return service.GetManager(id)?.Record 
                ?? (ActionResult<EmployeeData>)NotFound("No Manager Found");
            });
        }

        // GET api/manager/5/employees
        [HttpGet("{id}/employees")]
        public async Task<ActionResult<IEnumerable<EmployeeData>>> GetEmployeesUnderManager(string id)
        {
            return await Task.Run(() => { 
                return service.GetEmployeeUnderManager(id).Select(x => x.Record).ToList<EmployeeData>() ?? (ActionResult<IEnumerable<EmployeeData>>)NotFound("No Manager Found");
                });
        }


        // POST api/manager/add/
        [HttpPost("add/")]
        public async Task Post([FromBody] EmployeeUnderManager employeeUnderManager)
        {
            await Task.Run(()=>service.AddManager((Manager)EmployeeFactory.CreateEmployee(employeeUnderManager.ManagerInfo), employeeUnderManager.EmployeesIdUnderManager));
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