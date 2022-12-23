using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        private string _headerTitle;

        public ViewModelBase CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public string HeaderTitle
        {
            get { return _headerTitle; }
            set
            {
                _headerTitle = value;
                OnPropertyChanged(nameof(HeaderTitle));
            }
        }

        public ICommand ShowOrdersViewCommand { get; }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowReportsViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowCreatePizzaViewCommand { get; }

        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViemCommand);
            ShowOrdersViewCommand = new ViewModelCommand(ExecuteShowOrdersViewCommand);
            ShowCreatePizzaViewCommand = new ViewModelCommand(ExecuteShowCreatePizzaViewCommand);
            ShowReportsViewCommand = new ViewModelCommand(ExecuteShowReportsViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);

            ExecuteShowHomeViemCommand(null);
        }

        private void ExecuteShowHomeViemCommand(object obj)
        {
            CurrentView = new HomeViewModel();
            HeaderTitle = "Пицца";
        }

        private void ExecuteShowOrdersViewCommand(object obj)
        {
            CurrentView = new OrdersViewModel();
            HeaderTitle = "Заказы";
        }

        private void ExecuteShowReportsViewCommand(object obj)
        {
            CurrentView = new ReportsViewModel();
            HeaderTitle = "Отчёты";
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            CurrentView = new UserViewModel();
            HeaderTitle = "Пользователь";
        }

        private void ExecuteShowCreatePizzaViewCommand(object obj)
        {
            CurrentView = new CreatePizzaViewModel();
            HeaderTitle = "Создание пиццы";
        }
    }
}
