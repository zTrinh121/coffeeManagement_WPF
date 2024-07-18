using BusinessObjects;
using Repositories;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountRepository _accountRepository;

        public LoginWindow()
        {
            InitializeComponent();
            _accountRepository = new AccountRepository(); // Initialize the class-level _accountRepository field
        }


        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == null || txtPassword.Password == null)
            {
                MessageBox.Show("Field can not be empty");
                return;
            }

            var userName = txtUserName.Text;
            Account account = await _accountRepository.GetAccountByUserName(userName);
            if (account != null)
            {
                if (account.PassWord == txtPassword.Password)
                {
                    MainWindow mainWindow = new MainWindow(account);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    bool? Result = new MessageBoxCustom("Username or password is incorrect. Please try again!", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("Are you sure, You want to close application ?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (Result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        

    }
}
