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

        public EmployeeController(IEmployeeProvider employeeProvider)
        {
            this.employeeProvider = employeeProvider;
        }

        // GET: api/employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeProvider.Get();
        }
    }
}