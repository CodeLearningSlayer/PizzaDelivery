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
    public class IngredientService
    {
        PizzaDeliveryContext db;

        public IngredientService()
        {
            db = new PizzaDeliveryContext();
        }

        public List<IngredientModel> GetIngredients()
        {
            return db.Ingredient.AsEnumerable().Select(i => new IngredientModel(i)).ToList();
        }

        public void AddIngredient(IngredientModel ingredient)
        {
            var ing = new Ingredient()
            {
                Ingredient_code = ingredient.ID,
                Ingredient_cost = ingredient.Cost,
                Ingredient_quantity = ingredient.Quantity
            };
            db.Ingredient.Add(ing);
            db.SaveChanges();
        }

        public string GetIngredientNameByID(int id)
        {
            return db.Ingredient.Where(i => i.Ingredient_code == id).Select(i => i.Ingredient_name).SingleOrDefault();
        }

        public int GetIngredientCostByID(int id)
        {
            return db.Ingredient.Where(i => i.Ingredient_code == id).Select(i => i.Ingredient_cost).SingleOrDefault();
        }

        public int GetIngredientQuantityByID(int id)
        {
            return db.Ingredient.Where(i => i.Ingredient_code == id).Select(i => i.Ingredient_quantity).SingleOrDefault();
        }

        public void EditIngredient(IngredientModel ingredient)
        {
            var ingr = db.Ingredient.FirstOrDefault(i => i.Ingredient_code == ingredient.ID);
            ingr.Ingredient_cost = ingredient.Cost;
            ingr.Ingredient_name = ingredient.Name;
            ingr.Ingredient_quantity = ingredient.Quantity;
            db.SaveChanges();
        }

        public void DeleteIngredient(IngredientModel ingredient)
        {
            if (ingredient.ID == 0) return;
            Ingredient ingr = db.Ingredient.Where(i => Convert.ToInt32(i.Ingredient_code) == ingredient.ID).First();
            db.Ingredient.Remove(ingr);
            db.SaveChanges();
        }
    }
}
