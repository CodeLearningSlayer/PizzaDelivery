using PizzaDelivery.MVVM.Model;
using PizzaDelivery.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.MVVM.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        private readonly PizzaService _pizzaService = new PizzaService();
        private readonly OrderService _orderService = new OrderService();
        public ObservableCollection<PizzaModel> AllPizza { get; set; }
        public ObservableCollection<PizzaModel> ReadyPizza { get; set; }
        public PizzaModel SelectedPizza { get; set; }


        private void GetAllPizza()
        {
            AllPizza = new ObservableCollection<PizzaModel>(_pizzaService.GetPizzaList());
            ReadyPizza = new ObservableCollection<PizzaModel>(_pizzaService.GetReadyPizza());
            foreach (var pizza in AllPizza)
            {
                pizza.Name = _pizzaService.GetPizzaNameByID(pizza.ID);
                pizza.Price = _pizzaService.GetPizzaPriceByID(pizza.ID);
                pizza.IsAvailable = _pizzaService.GetPizzaAvailableByID(pizza.ID);
                pizza.ImageToShow = _pizzaService.GetPizzaPhotoByID(pizza.ID)?.Substring(2);
            }
            foreach (var pizza in ReadyPizza)
            {
                pizza.Name = _pizzaService.GetPizzaNameByID(pizza.ID);
                pizza.Price = _pizzaService.GetPizzaPriceByID(pizza.ID);
                pizza.IsAvailable = _pizzaService.GetPizzaAvailableByID(pizza.ID);
                pizza.ImageToShow = _pizzaService.GetPizzaPhotoByID(pizza.ID)?.Substring(2);
            }
        }

        private ICommand ChoosePizza { get; }
        private ICommand ShowReadyPizza{get;}

        public HomeViewModel()
        {
            AllPizza = new ObservableCollection<PizzaModel>();
            ChoosePizza = new ViewModelCommand(ExecuteChoosePizzaCommand);
            GetAllPizza();
        }

        private void ExecuteChoosePizzaCommand(object obj)
        {
            _orderService.AddToOrder(SelectedPizza);
        }
    }
}
