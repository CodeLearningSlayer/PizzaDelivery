using DAL;
using DAL.Entities;
using PizzaDelivery.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Services
{
    public class CustomerService
    {
        PizzaDeliveryContext db;

        public CustomerService()
        {
            db = new PizzaDeliveryContext();
        }

        public List<CustomerModel> GetCustomers()
        {
            return db.Customer.AsEnumerable().Select(c => new CustomerModel(c)).ToList();
        }

        public string GetCustomerNameByID(int id)
        {
            return db.Customer.Where(i => i.Customer_id == id).Select(i => i.Customer_name).SingleOrDefault();
        }
    }
}
