using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PizzaDelivery.MVVM.Model
{
    public class PizzaModel : INotifyPropertyChanged
    {
        private string name;
        private int price;
        private int id;
        private bool type;
        private bool isAvailable;
        private string _imageSource;

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

       
        public string ImageToShow
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageToShow));
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

        public string strPrice
        {
            get { return price + " руб."; }
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

        public PizzaModel() { }
        public PizzaModel(Pizza pizza)
        {
            ID = pizza.Pizza_id;
            Price = (int)pizza.Pizza_price;
            Type = pizza.Pizza_type;
            IsAvailable = pizza.isAvalaible;
            ImageToShow = pizza.Photo;
            Name = pizza.Pizza_name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
