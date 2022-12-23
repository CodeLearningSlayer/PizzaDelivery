using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.MVVM.Model
{
    public class OrderModel : INotifyPropertyChanged
    {

        private int id;
        private int status;
        private DateTime date;
        private int customerID;
        private int orderSum;
        private string customerName;
        private string orderAdress;
        private int courierID;
        private int employeeID;

        public string CustomerName
        {
            get { return customerName; }
            set
            {
                customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));

            }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set
            {
                employeeID = value;
                OnPropertyChanged(nameof(EmployeeID));
            }
        }

        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public int CustomerID
        {
            get { return customerID; }
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        public int CourierID
        {
            get { return courierID; }
            set
            {
                courierID = value;
                OnPropertyChanged(nameof(CourierID));
            }
        }

        public int OrderSum
        {
            get { return orderSum; }
            set
            {
                orderSum = value;
                OnPropertyChanged("OrderSum");
            }
        }

        public string OrderAdress
        {
            get
            {
                return orderAdress;
            }
            set
            {
                orderAdress = value;
                OnPropertyChanged("OrderAdress");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public OrderModel() { }

        public OrderModel(Order order)
        {
            CustomerID = order.Customer_id;
            Status = order.Order_state;
            Date = order.Order_date;
            OrderSum = order.Order_sum;
            OrderAdress = order.Order_adress;
        }
       
    }
}
