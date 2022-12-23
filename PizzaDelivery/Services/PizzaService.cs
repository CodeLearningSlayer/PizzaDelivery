using DAL.Entities;
using PizzaDelivery.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Services
{
    public class PizzaService
    {
        PizzaDeliveryContext db;

        public PizzaService()
        {
            db = new PizzaDeliveryContext();
        }

        public List<PizzaModel> GetPizzaList()
        {
            return db.Pizza.AsEnumerable().Select(p => new PizzaModel()).ToList();
        }

        public void AddPizza(PizzaModel pizza)
        {
            var p = new Pizza()
            {
                isAvalaible = pizza.IsAvailable,
                Pizza_name = pizza.Name,
                Pizza_price = pizza.Price,
                Pizza_type = "selfmade",
            };
            db.Pizza.Add(p);
            db.SaveChanges();
        }

        public int GetPriceByIngredients(ObservableCollection<IngredientModel> ingredients)
        {
            var total = 0;
            foreach(var ingr in ingredients)
            {
                total += ingr.Cost * ingr.Quantity;
            }
            return total;
        }

        //public PizzaModel CreatePizzaFromIngredients(ObservableCollection<IngredientModel> ingredients)
        //{
        //    v
        //}

        


    }
}
