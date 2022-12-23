using PizzaDelivery.MVVM.Model;
using PizzaDelivery.MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaDelivery.MVVM.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        
        public AccountViewModel()
        {
            userRepository = new UserRepository();
        }

        //private void LoadCurrentUserData()
        //{
        //    var user = userRepository.GetByUserName();
        //    if (user != null)
        //    {
        //        CurrentUserAccount = new UserAccountModel()
        //        {
        //            Username = user.Username,
        //            DisplayName = $"Привет, {user.Username} ;"
        //        };
        //    }
        //    else
        //    {
        //        MessageBox.Show("Пользователь не авторизован");
        //        Application.Current.Shutdown();
        //    }
        //}
    }
}
