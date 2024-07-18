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
    /// Interaction logic for PersonalProfileWindow.xaml
    /// </summary>
    public partial class PersonalProfileWindow : Window
    {
        private Account account;
        public PersonalProfileWindow(Account account)
        {
            InitializeComponent();
            this.account = account;

        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnPersonal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
