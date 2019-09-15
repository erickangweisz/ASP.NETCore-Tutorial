using EmployeeApi.Data;
using EmployeeApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProcessor employeeProcessor;

        public EmployeeController(IEmployeeProcessor employeeProcessor)
        {
            this.employeeProcessor = employeeProcessor;
        }

        // GET: api/employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeProcessor.Get();
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee employee)
        {
            employeeProcessor.Create(employee);
            return Ok(employee);
        }

        // PUT: api/employee/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee employee)
        {
            employee.Id = id;
            employeeProcessor.Update(employee);
        }

        // DELETE: api/employee/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeProcessor.Delete(id);
        }
    }
}