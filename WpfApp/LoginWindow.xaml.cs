using BusinessObjects;
using Repositories;
using System.Windows;
using WpfApp.ViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountRepository _accountRepository;
        private readonly LoginViewModel loginViewModel;

        public LoginWindow()
        {
            InitializeComponent();
            _accountRepository = new AccountRepository();
            loginViewModel = new LoginViewModel(new AccountRepository());
            DataContext = loginViewModel;
        }


        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loginViewModel.Login(txtUserName.Text, txtPassword.Password);
                //this.Close();
            }
            catch (Exception ex)
            {
                new MessageBoxCustom(ex.Message, MessageType.Error, MessageButtons.Ok).ShowDialog();
            }

            //Account account = await _accountRepository.GetAccountByUserName("Admin");
            //MainWindow mainWindow = new MainWindow(account);
            //mainWindow.Show();
            //this.Close();
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
