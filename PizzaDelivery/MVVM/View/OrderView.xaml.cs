using PizzaDelivery.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaDelivery.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для OrderV.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        public OrderView()
        {
            InitializeComponent();
        }
        private void buttonCloseWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
        }

        private void buttonSubmitForm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
