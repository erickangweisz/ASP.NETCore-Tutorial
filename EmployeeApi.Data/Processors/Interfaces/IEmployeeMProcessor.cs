using EmployeeApi.Data.Models;

namespace EmployeeApi.Data
{
    public interface IEmployeeMProcessor
    {
        void Create(Employee employee);

        void Update(Employee employee);

        void Delete(int employeeId);
    }
}
