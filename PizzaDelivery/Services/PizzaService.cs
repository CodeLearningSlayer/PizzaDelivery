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
            return db.Pizza.AsEnumerable().Select(p => new PizzaModel(p)).ToList();
        }

        public List<PizzaModel> GetReadyPizza()
        {
            return db.Pizza.AsEnumerable().Where(p => p.Pizza_type == "Ready").Select(p => new PizzaModel(p)).ToList();
        }

        public void AddPizza(PizzaModel pizza)
        {
            var p = new Pizza()
            {
                isAvalaible = pizza.IsAvailable,
                Pizza_name = pizza.Name,
                Pizza_price = pizza.Price,
                Pizza_type = "selfmade",
                Photo = pizza.ImageToShow
            };
            db.Pizza.Add(p);
            db.SaveChanges();
        }

        internal int GetPizzaPriceByID(int id)
        {
            return (int)db.Pizza.Where(i => i.Pizza_id == id).Select(i => i.Pizza_price).SingleOrDefault();
        }

        internal bool GetPizzaAvailableByID(int id)
        {
            return db.Pizza.Where(i => i.Pizza_id == id).Select(i => i.isAvalaible).SingleOrDefault();

        }

        internal string GetPizzaNameByID(int id)
        {
            return db.Pizza.Where(i => i.Pizza_id == id).Select(i => i.Pizza_name).SingleOrDefault();
        }

        internal string GetPizzaPhotoByID(int id)
        {
            return db.Pizza.Where(i => i.Pizza_id == id).Select(i => i.Photo).Single();
        }

        public void AddIngredientsList(IngredientsListModel ingredientsList)
        {
            var list = new Ingredients()
            {
                Ingredient_code = ingredientsList.IngredientCode,
                Pizza_code = ingredientsList.PizzaCode,
                Ingredients_num = ingredientsList.Quantinty
            };
            db.Ingredients.Add(list);
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

        public void CreatePizzaFromIngredients(ObservableCollection<IngredientModel> ingredients, int price)
        {
            var newPizza = new PizzaModel()
            {
                IsAvailable = true,
                Name = "CustomPizza",
                Price = price,
                Type = "selfmade"
            };

            AddPizza(newPizza); //тут же добавить в заказ
           
            foreach(var ingredient in ingredients)
            {
                var newIngredientsList = new IngredientsListModel()
                {
                    IngredientCode = ingredient.ID,
                    PizzaCode = db.Pizza.OrderByDescending(i => i.Pizza_id).FirstOrDefault().Pizza_id,
                    Quantinty = ingredient.Quantity
                };
                AddIngredientsList(newIngredientsList);
            }
        }

       


    }
}
