using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PizzaDelivery.MVVM.Repositories
{
    public class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = @"Data Source=DESKTOP-5B4IEUI\SQLEXPRESS01;Initial Catalog=Pizza Delivery;Encrypt=True;TrustServerCertificate=True;Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); 
        }
    }
}
