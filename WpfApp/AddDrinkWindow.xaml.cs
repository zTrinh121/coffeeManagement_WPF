using Microsoft.Win32;
using System;
using System.Windows;

namespace WpfApp
{
    public partial class AddDrinkWindow : Window
    {
        public string DrinkName => DrinkNameTextBox.Text;
        public int CategoryId => int.Parse(CategoryIdTextBox.Text);
        public decimal Price => decimal.Parse(PriceTextBox.Text);
        public string ImagePath => ImagePathTextBox.Text;

        public AddDrinkWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DrinkName) || CategoryId <= 0 || Price <= 0 || string.IsNullOrWhiteSpace(ImagePath))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
