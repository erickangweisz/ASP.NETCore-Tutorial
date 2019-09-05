using EmployeeApi.Data.Models;
using System.Collections.Generic;

namespace EmployeeApi.Data.Providers.Interfaces
{
    public interface IEmployeeProvider
    {
        IEnumerable<Employee> Get();
    }
}