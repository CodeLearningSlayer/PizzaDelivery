using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PizzaDelivery.MVVM.Model;
using PizzaDelivery.Services;
using System.Windows;

namespace PizzaDelivery.MVVM.ViewModel
{
    public class CreatePizzaViewModel : ViewModelBase
    {
        private readonly IngredientService _ingredientsService = new IngredientService();
        private readonly PizzaService _pizzaService = new PizzaService();
        public ObservableCollection<IngredientModel> CurrentCollection { get; set; }
        public ObservableCollection<IngredientModel> IngredientsToCreate { get; set; }
        public IngredientModel SelectedIngredient { get; set; }
        public int CurrentIngredientQuantity { get; set; }
        public ObservableCollection<IngredientModel> AllIngredients { get; set; }

        public int TotalSum { get; set; }

        public bool isPossibleToAdd = false;
        

        private void GetAvailableIngredients()
        {
            AllIngredients = new ObservableCollection<IngredientModel>(_ingredientsService.GetIngredients());
            IngredientsToCreate = new ObservableCollection<IngredientModel>();

            foreach (var ingredient in AllIngredients)
            {
                ingredient.Name = _ingredientsService.GetIngredientNameByID(ingredient.ID);
                ingredient.Cost = _ingredientsService.GetIngredientCostByID(ingredient.ID);
                ingredient.Quantity = _ingredientsService.GetIngredientQuantityByID(ingredient.ID);
            }
            OnPropertyChanged(nameof(AllIngredients));
        }


        public ICommand ShowAvailableIngredients { get; }
        public ICommand AddIngredientCommand { get; }
        public ICommand SubtractIngredientCommand { get; }
        
        public ICommand SetChosenIngredientCommand { get; }
        public ICommand SetIngredientNum { get; }

        public ICommand ChangeSelectedIngredient { get; }

        public CreatePizzaViewModel()
        {
            AllIngredients = new ObservableCollection<IngredientModel>();
            CurrentIngredientQuantity = 0;
            GetAvailableIngredients();
            ShowAvailableIngredients = new ViewModelCommand(ExecuteShowAvailableIngredientsCommand);
            AddIngredientCommand = new ViewModelCommand(ExecuteAddIngredientCommand);
            SubtractIngredientCommand = new ViewModelCommand(ExecuteSubtractIngredientCommand);
            ChangeSelectedIngredient = new ViewModelCommand(ExecuteChangeSelectedIngredient);
            SetIngredientNum = new ViewModelCommand(ExecuteSetIngredientNumCommand);
            SetChosenIngredientCommand = new ViewModelCommand(ExecuteSetChosenIngredientCommand);
            ExecuteShowAvailableIngredientsCommand(null);
        }


        private void ExecuteShowAvailableIngredientsCommand(object obj)
        {
            CurrentCollection = AllIngredients;
            OnPropertyChanged(nameof(CurrentCollection));
        }

        public void ExecuteAddIngredientCommand(object obj) // забирать выбранный ингредиент
        {
            if (SelectedIngredient != null && CurrentIngredientQuantity < SelectedIngredient.Quantity)
                CurrentIngredientQuantity += 1;
            OnPropertyChanged(nameof(CurrentIngredientQuantity));
        }
        public void ExecuteSubtractIngredientCommand(object obj)
        {
            if (CurrentIngredientQuantity > 0 && SelectedIngredient != null)
                CurrentIngredientQuantity -= 1;

            OnPropertyChanged(nameof(CurrentIngredientQuantity));
        }

        public void ExecuteChangeSelectedIngredient(object obj)
        {
            CurrentIngredientQuantity = 0;
            OnPropertyChanged(nameof(CurrentIngredientQuantity));
        }

        public void ExecuteSetIngredientNumCommand(object obj)
        {
            var newIngredient = new IngredientModel()
            {
                ID = SelectedIngredient.ID,
                Cost = SelectedIngredient.Cost,
                Quantity = CurrentIngredientQuantity,
                Name = SelectedIngredient.Name
            };
            if (!IngredientsToCreate.Where(i => i.ID == newIngredient.ID).Any())
                IngredientsToCreate.Add(newIngredient);
            else
            {
                var existingIngredient = IngredientsToCreate.Where(i => i.ID == newIngredient.ID).Single();
                existingIngredient.Quantity = newIngredient.Quantity;
            }
            TotalSum = _pizzaService.GetPriceByIngredients(IngredientsToCreate);
            OnPropertyChanged(nameof(IngredientsToCreate));
            OnPropertyChanged(nameof(TotalSum));

        }

        public void ExecuteSetChosenIngredientCommand(object obj)
        {
            _pizzaService.CreatePizzaFromIngredients(IngredientsToCreate, TotalSum);
            _ingredientsService.EditIngredientNum(IngredientsToCreate);

            MessageBox.Show("Добавление успешно");

            OnPropertyChanged(nameof(AllIngredients));
        }

    }
}
