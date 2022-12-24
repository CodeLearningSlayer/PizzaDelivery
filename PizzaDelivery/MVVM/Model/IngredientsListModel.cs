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
    public class IngredientsListModel : INotifyPropertyChanged
    {
        private int pizzaCode;
        private int ingredientCode;
        private int quantity;

        public int PizzaCode { 
            get => pizzaCode; set 
            {  pizzaCode = value;
                OnPropertyChanged(nameof(PizzaCode));
            } 
        }
        public int IngredientCode 
        { 
            get => ingredientCode;
            set 
            { 
                ingredientCode = value;
                OnPropertyChanged(nameof(IngredientCode));
            } 
        }
        public int Quantinty { 
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantinty));
            }

        }

        public IngredientsListModel() { }

        public IngredientsListModel(Ingredients ingredient)
        {
            PizzaCode = ingredient.Pizza_code;
            IngredientCode = ingredient.Ingredient_code;
            Quantinty = ingredient.Ingredients_num;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
