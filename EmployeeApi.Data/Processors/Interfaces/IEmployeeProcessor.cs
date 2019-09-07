using EmployeeApi.Data.Models;

namespace EmployeeApi.Data
{
    public interface IEmployeeProcessor
    {
        void Create(Employee employee);

        void Update(Employee employee);

        void Delete(int employeeId);
    }
}
