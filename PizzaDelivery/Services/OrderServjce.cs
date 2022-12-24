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
    public class OrderService
    {
        PizzaDeliveryContext db;

        public OrderService()
        {
            db = new PizzaDeliveryContext();
        }

        public List<OrderModel> GetOrders()
        {
            return db.Order.AsEnumerable().Select(o => new OrderModel(o)).ToList();
        }

        public List<OrderModel> GetAllOrdersByCustomerID(int id)
        {
            return db.Order.AsEnumerable().Select(o => new OrderModel(o)).Where(c => c.CustomerID == id).ToList();
        }

        public List<OrderModel> GetReadyOrders()
        {
            return db.Order.AsEnumerable().Select(o => new OrderModel(o)).Where(s => s.Status == 2).ToList();
        }

        public int GetStatusByID(int id)
        {
            return db.Order.Where(i => Convert.ToInt32(i.Order_id) == id).Select(i => i.Order_state).SingleOrDefault();
        }

        public void AddOrder(OrderModel order)
        {
            var o = new Order()
            {
                Order_state = 0,
                Customer_id = order.CustomerID,
                Order_adress = order.OrderAdress,
                Order_date = order.Date,
                Order_sum = order.OrderSum,
                Courier_id = order.CourierID,
                Employee_code = order.EmployeeID,
                
            };
            db.Order.Add(o);
            db.SaveChanges();
        }

        internal void AddToOrder(PizzaModel selectedPizza)
        {
            
        }

        public void DeleteOrder(OrderModel order)
        {
            if (order.ID == 0) return;
            Order o = db.Order.Where(i => Convert.ToInt32(i.Order_id) == order.ID).First();
            db.Order.Remove(o);
            db.SaveChanges();
        }

        public void EditOrder(OrderModel order)
        {
            var o = db.Order.FirstOrDefault(i => i.Order_id == order.ID);
            o.Order_state = 0;
            o.Customer_id = order.CustomerID;
            o.Order_adress = order.OrderAdress;
            o.Order_date = order.Date;
            o.Order_sum = order.OrderSum;
            o.Courier_id = order.CourierID;
            o.Employee_code = order.EmployeeID;
            db.SaveChanges();
        }
    }
}
