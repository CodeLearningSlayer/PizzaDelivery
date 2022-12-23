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
    public class IngredientModel : INotifyPropertyChanged
    {
        private string name;
        private int quantity;
        private int cost;
        private int id { get; set; }


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
                OnPropertyChanged("Name");
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public IngredientModel(Ingredient ingredient)
        {
            ID = ingredient.Ingredient_code;
            Name = ingredient.Ingredient_name;
            Cost = ingredient.Ingredient_cost;
            Quantity = ingredient.Ingredient_quantity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
