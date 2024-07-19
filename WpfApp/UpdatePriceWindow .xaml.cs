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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdatePriceWindow.xaml
    /// </summary>
    public partial class UpdatePriceWindow : Window
    {
        public decimal NewPrice { get; private set; }
        public UpdatePriceWindow()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtNewPrice.Text, out decimal newPrice))
            {
                NewPrice = newPrice;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid decimal price.");
            }
        }
    }

}
