using _20._101_Kargin_authorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._101_Kargin_authorization.ViewModel
{
    public class AuthorizationViewModel : ViewModelBase
    {
        LoginManager logManager = new LoginManager();
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; NotifyPropertyChanged(nameof(Login)); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged(nameof(Password)); }
        }
        public ActionCommand LogIn{get; set;}
        AuthorizationViewModel()
        {
            LogIn = new ActionCommand(() => TryLogIn());
            login=String.Empty; 
            password=String.Empty;
        }
        private void TryLogIn()
        {
            LoginCondition result = logManager.CheckLogInData(Login, Password);
            switch (result)
            {
                case LoginCondition.Success:
                    System.Windows.MessageBox.Show($"Успешный вход с ролью {logManager.AuthorizationRole}");
                    break;
                case LoginCondition.Failed:
                    System.Windows.MessageBox.Show("Введены неправильные данные");
                    break;


            }
        }
    }
}
