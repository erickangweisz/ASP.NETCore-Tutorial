using Dapper;
using EmployeeApi.Data.Models;
using System.Data.SqlClient;

namespace EmployeeApi.Data.Processors
{
    public class EmployeeProcessor : IEmployeeProcessor
    {
        private readonly string connectionString;

        public EmployeeProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO Employee (firstname, lastname, email, cellphone) VALUES (@Firstname, @Lastname, @Email, @Cellphone)",
                    new { employee.Firstname, employee.Lastname, employee.Email, employee.Cellphone });
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("UPDATE Employee SET firstname=@Firstname, lastname=@Lastname, email=@Email, cellphone=@Cellphone WHERE id=@Id",
                    new { employee.Id, employee.Firstname, employee.Lastname, employee.Email, employee.Cellphone });
            }
        }

        public void Delete(int employeeId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("DELETE FROM Employee WHERE id=@Id",
                    new { Id = employeeId });
            }
        }
    }
}
