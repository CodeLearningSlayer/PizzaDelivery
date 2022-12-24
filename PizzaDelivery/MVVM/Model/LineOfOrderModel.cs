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
    public class LineOfOrderModel : INotifyPropertyChanged
    {
        private int quantityOfPizza;
        private int pizzaCode;
        private int orderCode;
        private int lineCost;
        private int id;


        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public int QuantityOfPizza { 
            get => quantityOfPizza;
            set { 
                quantityOfPizza = value;
                OnPropertyChanged(nameof(QuantityOfPizza));
            } 
        }
        public int PizzaCode {
            get => pizzaCode;
            set { 
                pizzaCode = value;
                OnPropertyChanged(nameof(PizzaCode));
            } 
        }
        public int OrderCode { 
            get => orderCode;
            set 
            { 
                orderCode = value;
                OnPropertyChanged(nameof(OrderCode));
            } 
        }
        public int LineCost { 
            get => lineCost;
            set { 
                lineCost = value;
                OnPropertyChanged(nameof(LineCost));
            } 
        }

        public LineOfOrderModel() { }

        public LineOfOrderModel(Line_of_order lineOfOrder) 
        {
            QuantityOfPizza = lineOfOrder.Quantity_of_pizza;
            PizzaCode = lineOfOrder.Pizza_code;
            OrderCode = lineOfOrder.Order_code;
            LineCost = lineOfOrder.Line_cost;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
