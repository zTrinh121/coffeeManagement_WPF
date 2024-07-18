using BusinessObjects;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private Account account;
        public EmployeeWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        #region common_button

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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(account).Show();
            this.Close();
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

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        #endregion
    }
}
