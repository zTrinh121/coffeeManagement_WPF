using Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WpfApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly AccountRepository accountRepository;
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public LoginViewModel(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async void Login(string username, string password)
        {
            ValidateProperty(username, nameof(Username));
            ValidateProperty(password, nameof(Password));

            if (!HasErrors)
            {
                var user = await accountRepository.GetAccountByUserName(username);

                if (user != null && user.PassWord.Equals(password))
                {
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.ShowDialog();
                }
                else
                {
                    AddError(nameof(Username), "Invalid username or password.");
                    AddError(nameof(Password), "Invalid username or password.");
                }
            }
        }

        

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
                ValidateProperty(value, nameof(Username));

            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                ValidateProperty(value, nameof(Password));
            }
        }


        #region property_changed
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion


        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateProperty(object value, string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Username):
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        AddError(propertyName, "Username cannot be empty.");
                    }
                    else
                    {
                        RemoveError(propertyName, "Username cannot be empty.");
                    }
                    break;
                case nameof(Password):
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        AddError(propertyName, "Password cannot be empty.");
                    }
                    else
                    {
                        RemoveError(propertyName, "Password cannot be empty.");
                    }
                    break;
            }
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Contains(error))
            {
                _errors[propertyName].Remove(error);
                if (_errors[propertyName].Count == 0)
                {
                    _errors.Remove(propertyName);
                }
                OnErrorsChanged(propertyName);
            }
        }


    }
}
