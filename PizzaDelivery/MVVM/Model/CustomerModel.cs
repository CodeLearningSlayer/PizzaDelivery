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
    public class CustomerModel : INotifyPropertyChanged
    {

        private int id;
        private string name;
        private string phone;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id
        {
            get
            { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                name = value;
                OnPropertyChanged("Phone");
            }
        }

        public CustomerModel() { }

        public CustomerModel(Customer customer)
        {
            Id = customer.Customer_id;
            Name = customer.Customer_name;
            Phone = customer.Customer_phone;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
