using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.MVVM.Model
{
    public class PizzaModel : INotifyPropertyChanged
    {
        private string name;
        private int price;
        private int id;
        private bool type;
        private bool isAvailable;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Title");
            }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set
            {
                isAvailable = value;
                OnPropertyChanged("IsAvailable");
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string Type
        {
            get { return type == true ? "Ready" : "SelfMade"; }
            set
            {
                type = value == "Ready" ? true : false;
                OnPropertyChanged(nameof(Type));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
