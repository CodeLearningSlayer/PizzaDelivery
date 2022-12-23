using MaterialDesignThemes.Wpf;
using PizzaDelivery.MVVM.Model;
using PizzaDelivery.MVVM.View;
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
    public class OrdersViewModel : ViewModelBase
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly CustomerService _customerService = new CustomerService();

        public ObservableCollection<OrderModel> AllOrders { get; set; }
        public ObservableCollection<OrderModel> ReadyOrders { get; set; }

        public ObservableCollection<OrderModel> CurrentCollection { get; set; }
        public ObservableCollection<PizzaModel> SelfMadeOrders { get; set; }
        public ObservableCollection<CustomerModel> Customers { get; set; }
        public OrderModel SelectedOrder { get; set; }

        private void GetOrders()
        {
            AllOrders = new ObservableCollection<OrderModel>(_orderService.GetOrders());

            foreach (var order in AllOrders)
            {
                order.CustomerName = _customerService.GetCustomerNameByID(order.CustomerID);
                order.Status = _orderService.GetStatusByID(order.Status);
            }

            OnPropertyChanged("AllOrders");
        }

        private void GetReadyOrders()
        {
            ReadyOrders = new ObservableCollection<OrderModel>(_orderService.GetReadyOrders());

            foreach(var order in ReadyOrders)
            {
                order.CustomerName = _customerService.GetCustomerNameByID(order.CustomerID);
                order.Status = _orderService.GetStatusByID(order.Status);
            }
            OnPropertyChanged("ReadyOrders");

        }

        private void GetCustomers()
        {
            Customers = new ObservableCollection<CustomerModel>(_customerService.GetCustomers());
            OnPropertyChanged("Customers");
        }

        private void GetTables()
        {
            GetOrders();
            GetReadyOrders();
            GetCustomers();
        }

        public ICommand ShowOrders { get; }
        public ICommand ShowReadyOrders { get; }
        public ICommand ShowCreateOrderDialog { get; }

        public OrdersViewModel()
        {
            AllOrders = new ObservableCollection<OrderModel>();
            ReadyOrders = new ObservableCollection<OrderModel>();
            SelfMadeOrders = new ObservableCollection<PizzaModel>();
            Customers = new ObservableCollection<CustomerModel>();

            ShowOrders = new ViewModelCommand(ExecuteShowOrdersCommand);
            ShowReadyOrders = new ViewModelCommand(ExecuteShowReadyOrdersCommand);

            //GetTables();
            //ExecuteShowOrdersCommand(null);

            //ShowCreateOrderDialog = new ViewModelCommand(ExecuteShowCreateOrderDialogCommand);
        }

        private void ExecuteShowCreateOrderDialogCommand(object obj)
        {
            var dialog = new OrderView(); // тут будет OrderView
            dialog.ShowDialog();
            GetTables();
            ExecuteShowOrdersCommand(null);
        }

        private void ExecuteShowOrdersCommand(object obj)
        {
            CurrentCollection = AllOrders;
            OnPropertyChanged(nameof(CurrentCollection));
        }

        private void ExecuteShowReadyOrdersCommand(object obj)
        {
            CurrentCollection = ReadyOrders;
            OnPropertyChanged(nameof(CurrentCollection));
        }

        private void ExecuteShowAllOrdersCommand(object obj)
        {
            CurrentCollection = AllOrders;
            OnPropertyChanged(nameof(CurrentCollection));
        }
    }


}
