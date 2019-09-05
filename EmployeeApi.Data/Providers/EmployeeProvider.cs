using Dapper;
using EmployeeApi.Data.Providers.Interfaces;
using EmployeeApi.Data.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeApi.Data.Providers
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly string connectionString;

        public EmployeeProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> employee = null;

            using (var connection = new SqlConnection(connectionString))
            {
                employee = connection.Query<Employee>("select * from Employee");
            }

            return employee;
        }
    }
}
