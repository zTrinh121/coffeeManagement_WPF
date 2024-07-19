using BusinessObjects;
using DataAccessLayer;
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
using Microsoft.Win32;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for DrinkWindow.xaml
    /// </summary>
    public partial class DrinkWindow : Window
    {
        private Account account;
        public DrinkWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            LoadDrinks();
        }


        #region common_button

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(account);
            mainWindow.Show();
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

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        private void mnPersonal_Click(object sender, RoutedEventArgs e)
        {
            new PersonalProfileWindow(account).Show();
            this.Close();
        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        #endregion

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }




        private async void LoadDrinks()
        {
            try
            {
                var drinks = await DrinkDAO.Instance.GetDrinks();  // Giả sử DrinkDAO là class truy cập dữ liệu
                lvDrinks.ItemsSource = drinks;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đồ uống: " + ex.Message);
            }
        }



        private async void UpdatePrice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int drinkId = (int)button.CommandParameter;
            var drinkToUpdate = await DrinkDAO.Instance.GetDrink(drinkId);

            var updateWindow = new UpdatePriceWindow();
            if (updateWindow.ShowDialog() == true)
            {
                drinkToUpdate.Price = updateWindow.NewPrice;
                await DrinkDAO.Instance.UpdateDrink(drinkToUpdate);
                MessageBox.Show("Price updated successfully.");
                LoadDrinks(); 
            }
        }

        private async void DeleteDrink_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int drinkId = (int)button.CommandParameter;
            var drinkToDelete = await DrinkDAO.Instance.GetDrink(drinkId);

            var confirmResult = MessageBox.Show("Are you sure you want to delete this drink?", "Confirm Delete", MessageBoxButton.YesNo);
            if (confirmResult == MessageBoxResult.Yes)
            {
                try
                {
                    await DrinkDAO.Instance.DeleteDrink(drinkToDelete);
                    MessageBox.Show("Drink deleted successfully.");
                    LoadDrinks(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting drink: " + ex.Message);
                }
            }
        }

        private async void AddDrink_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddDrinkWindow();
            if (addWindow.ShowDialog() == true)
            {
                var newDrink = new Drink
                {
                    DrinkName = addWindow.DrinkName,
                    Price = addWindow.Price,
                    IdCategory = addWindow.CategoryId,
                    Image = addWindow.ImagePath
                };

                try
                {
                    await DrinkDAO.Instance.InsertDrink(newDrink);
                    MessageBox.Show("Thêm đồ uống thành công.");
                    LoadDrinks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm đồ uống: " + ex.Message + "\nChi tiết lỗi: " + ex.InnerException?.Message + "\nInner Exception: " + ex.InnerException?.InnerException?.Message);
                }
            }
        }









    }
}
