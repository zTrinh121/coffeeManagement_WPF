using BusinessObjects;
using DataAccessLayer;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private readonly AccountDAO accountDAOInstance = AccountDAO.Instance;
        private Account account;
        private ObservableCollection<Account> accounts;

        private AccountDAO accountDAO;
        private readonly IAccountRepository accountRepository;
        private int accountId;
        private string userName;
        private int type;

        public EmployeeWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            this.DataContext = this;
            LoadAccountsAsync();
        }

        private async Task LoadAccountsAsync()
        {
            try
            {
                IEnumerable<Account> accounts = await accountDAOInstance.GetAccounts();
                TableStackPanel.DataContext = accounts;
                dgData.ItemsSource = accounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task InsertAccount(Account account)
        {
            try
            {
                await accountDAOInstance.InsertAccount(account);
                MessageBox.Show("Thêm nhân viên thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                await LoadAccountsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding new account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task UpdateAccount(Account account)
        {
            try
            {
                await accountDAOInstance.UpdateAccount(account);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating account: {ex.Message}");
            }
        }

        private async Task DeleteAccount(Account account)
        {
            try
            {
                AccountRepository accountRepository = new AccountRepository();
                await accountRepository.DeleteAccount(account);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting account: {ex.Message}");
            }
        }

        #region Common Button Click Handlers

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        private void drink_Click(object sender, RoutedEventArgs e)
        {
            new DrinkWindow(account).Show();
            this.Close();
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            new ReportWindow(account).Show();
            this.Close();
        }

        private void employee_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeWindow(account).Show();
            this.Close();
        }

        private void mnPersonal_Click(object sender, RoutedEventArgs e)
        {
            new PersonalProfileWindow(account).Show();
            this.Close();
        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result == true)
            {
                Application.Current.Shutdown();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result == true)
            {
                Application.Current.Shutdown();
            }
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(account);
            mainWindow.Show();
            this.Close();
        }

        #endregion

        #region DataGrid and Button Click Handlers

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem != null)
            {
                Account selectedAccount = (Account)dgData.SelectedItem;
            }
        }

        //private async void btnModify_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (dgData.SelectedItem is Account selectedAccount)
        //        {
        //            await UpdateAccount(selectedAccount);
        //            MessageBox.Show($"Updated account with ID {selectedAccount.AccountId}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //            await LoadAccountsAsync(); // Refresh the accounts after update
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select an account to modify.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error updating account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private async void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgData.SelectedItem is Account selectedAccount)
                {
                    if (selectedAccount.Type == 0)
                    {
                        MessageBoxResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản với ID {selectedAccount.AccountId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            await DeleteAccount(selectedAccount);
                            MessageBox.Show($"Deleted account with ID {selectedAccount.AccountId}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            await LoadAccountsAsync();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có quyền xóa tài khoản này.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an account to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btnAddnv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string newUserName = txtUserName.Text;
                int newType = int.Parse(txtType.Text); 

                Account newAccount = new Account
                {
                    UserName = newUserName,
                    Type = newType
                };

                await InsertAccount(newAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding new account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtUserName.Text.Clear();
            txtType.Text.Clear();
        }

        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int accountId)
            {
                MessageBox.Show($"View detail for account with ID {accountId}");
            }
        }

        #endregion
    }
}
