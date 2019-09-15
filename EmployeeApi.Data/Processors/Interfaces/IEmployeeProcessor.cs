using EmployeeApi.Data.Models;
using System.Collections.Generic;

namespace EmployeeApi.Data
{
    public interface IEmployeeProcessor
    {
        void Create(Employee employee);

        IEnumerable<Employee> Get();

        void Update(Employee employee);

        void Delete(int employeeId);
    }
}
