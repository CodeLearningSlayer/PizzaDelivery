using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PizzaDelivery.MVVM.Model;
using PizzaDelivery.Services;

namespace PizzaDelivery.MVVM.ViewModel
{
    public class CreatePizzaViewModel : ViewModelBase
    {
        private readonly IngredientService _ingredientsService = new IngredientService();
        public ObservableCollection<IngredientModel> CurrentCollection { get; set; }
        public IngredientModel SelectedIngredient { get; set; }
        public int CurrentIngredientQuantity { get; set; }
        public ObservableCollection<IngredientModel> AllIngredients { get; set; }

        public isPossibleToAdd
        

        private void GetAvailableIngredients()
        {
            AllIngredients = new ObservableCollection<IngredientModel>(_ingredientsService.GetIngredients());

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

        public CreatePizzaViewModel()
        {
            AllIngredients = new ObservableCollection<IngredientModel>();
            CurrentIngredientQuantity = 0;
            GetAvailableIngredients();
            ShowAvailableIngredients = new ViewModelCommand(ExecuteShowAvailableIngredientsCommand);
            AddIngredientCommand = new ViewModelCommand(ExecuteAddIngredientCommand);
            SubtractIngredientCommand = new ViewModelCommand(ExecuteSubtractIngredientCommand);

            ExecuteShowAvailableIngredientsCommand(null);
        }


        private void ExecuteShowAvailableIngredientsCommand(object obj)
        {
            CurrentCollection = AllIngredients;
            OnPropertyChanged(nameof(CurrentCollection));
        }

        public void ExecuteAddIngredientCommand(object obj) // забирать выбранный ингредиент
        {
            CurrentIngredientQuantity += 1;
            OnPropertyChanged(nameof(CurrentIngredientQuantity));
        }
        public void ExecuteSubtractIngredientCommand(object obj)
        {
            if (CurrentIngredientQuantity > 0)
                CurrentIngredientQuantity -= 1;
            OnPropertyChanged(nameof(CurrentIngredientQuantity));
        }

    }
}
