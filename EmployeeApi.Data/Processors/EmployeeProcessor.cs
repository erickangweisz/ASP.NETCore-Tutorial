using System;
using System.Data.SqlClient;
using Dapper;
using EmployeeApi.Data.Models;

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

        public void Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
