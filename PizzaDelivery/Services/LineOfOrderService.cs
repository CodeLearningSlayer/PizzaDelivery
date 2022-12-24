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
    public class LineOfOrderService
    {
        PizzaDeliveryContext db;

        public LineOfOrderService()
        {
            db = new PizzaDeliveryContext();
        }

        public List<LineOfOrderModel> GetLinesOfOrder()
        {
            return db.Line_of_order.AsEnumerable().Select(i => new LineOfOrderModel(i)).ToList();
        }

        public int GetLineCostByID(int id)
        {
            var pizzaCode = GetPizzaCodeByID(id);
            var pizzaNum = GetPizzaQuantityByID(id);
            var priceForOne = db.Pizza.Where(i => i.Pizza_id == pizzaCode).Select(i => i.Pizza_price).SingleOrDefault();
            return (int)priceForOne * pizzaNum;
        }

        public int GetOrderCodeByID(int id)
        {
            return db.Line_of_order.Where(i => i.Line_id == id).Select(i => i.Order_code).SingleOrDefault();
        }

        public int GetPizzaCodeByID(int id)
        {
            return db.Line_of_order.Where(i => i.Line_id == id).Select(i => i.Pizza_code).SingleOrDefault();
        }

        public int GetPizzaQuantityByID(int id)
        {
            return db.Line_of_order.Where(i => i.Line_id == id).Select(i => i.Quantity_of_pizza).SingleOrDefault();
        }

        public void AddToLine(LineOfOrderModel line)
        {
            var ln = new Line_of_order()
            {
                Line_cost = line.LineCost,
                Line_id = line.ID,
                Quantity_of_pizza = line.QuantityOfPizza,
                Order_code = line.OrderCode,
                Pizza_code = line.PizzaCode
            };
            db.Line_of_order.Add(ln);
            db.SaveChanges();
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
    }
}
