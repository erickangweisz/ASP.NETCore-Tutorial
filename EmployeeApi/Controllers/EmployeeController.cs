using EmployeeApi.Data;
using EmployeeApi.Data.Models;
using EmployeeApi.Data.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider employeeProvider;
        private readonly IEmployeeProcessor employeeProcessor;

        public EmployeeController(IEmployeeProvider employeeProvider, IEmployeeProcessor employeeProcessor)
        {
            this.employeeProvider = employeeProvider;
            this.employeeProcessor = employeeProcessor;
        }

        // GET: api/employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeProvider.Get();
        }

        // POST: api/employee
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            employeeProcessor.Create(employee);
        }
    }
}