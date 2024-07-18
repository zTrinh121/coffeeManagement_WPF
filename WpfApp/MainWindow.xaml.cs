using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region declaration
        private readonly ITableRepository tableRepository;
        private readonly IDrinkCategoryRepository categoryRepository;
        private readonly IDrinkRepository drinkRepository;
        private readonly IBillInfoRepository billInfoRepository;
        private readonly IBillRepository billRepository;
        private Account account;
        private ObservableCollection<Table> tables;
        private ObservableCollection<DrinkCategory> drinkCategories;
        private ObservableCollection<Drink> drinks;
        private ObservableCollection<BillInfo> _billInfoCollection;
        private int currentTableId;
        private Table currentTable;
        private int currentBillId;
        private decimal totalBill;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            tableRepository = new TableRepository();
            categoryRepository = new DrinkCategoryRepository();
            drinkRepository = new DrinkRepository();
            billInfoRepository = new BillInfoRepository();
            billRepository = new BillRepository();
        }


        public MainWindow(Account account)
        {
            InitializeComponent();
            DataContext = this;
            this.account = account;
            tableRepository = new TableRepository();
            categoryRepository = new DrinkCategoryRepository();
            drinkRepository = new DrinkRepository();
            billInfoRepository = new BillInfoRepository();
            billRepository = new BillRepository();

        }

        #region load_table

        public Table CurrentTable
        {
            get => currentTable;
            set
            {
                currentTable = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Table> Tables
        {
            get => tables;
            set
            {
                tables = value;
                OnPropertyChanged();
            }
        }

        private async void LoadTable()
        {
            Tables = new ObservableCollection<Table>(await tableRepository.GetTables());
            cboTable.ItemsSource = Tables;
            cboTable.DisplayMemberPath = "TableName";
            cboTable.SelectedValuePath = "TableId";
        }

        private void cboTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        #endregion

        #region load_drinkCategory

        //public ObservableCollection<DrinkCategory> DrinkCategories
        //{
        //    get => drinkCategories;
        //    set
        //    {
        //        drinkCategories = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public async void LoadDrinkCategory()
        //{
        //    DrinkCategories = new ObservableCollection<DrinkCategory>(await categoryRepository.GetDrinkCategories());
        //    cboDrinkCategory.ItemsSource = DrinkCategories;
        //    cboDrinkCategory.DisplayMemberPath = "DrinkCategoryName";
        //    cboDrinkCategory.SelectedValuePath = "DrinkCategoryId";
        //}
        //private void cboDrinkCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        #endregion

        #region load_drink
        public ObservableCollection<Drink> Drinks
        {
            get => drinks;
            set
            {
                drinks = value;
                OnPropertyChanged();
            }
        }

        public async void LoadDrink()
        {
            Drinks = new ObservableCollection<Drink>(await drinkRepository.GetDrinks());
            cboDrink.ItemsSource = Drinks;
            cboDrink.DisplayMemberPath = "DrinkName";
            cboDrink.SelectedValuePath = "DrinkId";

        }

        private async void btnMoveTable_Click(object sender, RoutedEventArgs e)
        {
            if (cboTable.SelectedItem == null)
            {
                new MessageBoxCustom("Table choice is empty", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return;
            }

            var selectedTable = (Table)cboTable.SelectedItem;

            if (selectedTable.TableStatus == "Có người")
            {
                new MessageBoxCustom("Table is occupied. Please choose another table", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return;
            }

            try
            {
                // Update the status of the selected table to occupied (0)
                await tableRepository.UpdateTableStatus(selectedTable.TableId, 0);

                // Update the status of the current table to empty (1)
                await tableRepository.UpdateTableStatus(currentTableId, 1);

                // Retrieve the current bill
                Bill bill = await billRepository.GetBill(currentBillId);

                // Change the table association
                bill.IdTable = selectedTable.TableId;
                billRepository.UpdateBill(bill);



                CurrentTable = await tableRepository.GetTable(selectedTable.TableId);
                cboTable.SelectedItem = CurrentTable;


                // Show success message
                currentTableId = selectedTable.TableId;
                BillHeader.Text = $"Hóa đơn bàn {currentTableId}";
                LoadTable();
                showBill(selectedTable.TableId);
                new MessageBoxCustom("Chuyển bàn thành công", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();

            }
            catch (Exception ex)
            {
                new MessageBoxCustom("Chuyển bàn thất bại: " + ex.Message, MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
        }




        private void cboDrink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #endregion

        #region totalBill
        public decimal TotalBill
        {
            get => totalBill;
            set
            {
                totalBill = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadTotalBill(int billId)
        {
            TotalBill = await billInfoRepository.GetTotalBillOfATable(billId);

        }

        #endregion

        public ObservableCollection<BillInfo> BillInfoCollection
        {
            get { return _billInfoCollection; }
            set
            {
                _billInfoCollection = value;
                OnPropertyChanged();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            BillInfo billInfo = (BillInfo)button.DataContext;
            if (billInfo != null)
            {
                try
                {
                    await billInfoRepository.DeleteBillInfo(billInfo);
                    new MessageBoxCustom("Xóa đồ uống thành công", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();

                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log or show error message)
                    MessageBox.Show($"Error deleting item from database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    showBill(currentTableId);
                }
            }
        }

        private async void ViewBill_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                int tableId = (int)button.Tag;
                string tableHeaderText = $"Hóa đơn bàn {tableId}";
                currentTableId = tableId;
                CurrentTable = await tableRepository.GetTable(tableId);
                BillHeader.Text = tableHeaderText;
                Table table = await tableRepository.GetTable(tableId);
                showBill(tableId);
            }
        }

        private async void showBill(int tableFoodId)
        {
            try
            {
                Bill bill = await billRepository.GetBillTableStatusPaid(tableFoodId, 0);
                if (bill == null)
                {
                    dgData.ItemsSource = null;
                    TotalBill = 0;
                }
                else
                {
                    currentBillId = bill.BillId;
                    IEnumerable<BillInfo> billInfoUnpaidTable = await billInfoRepository.GetBillInfosByBillId(bill.BillId);
                    dgData.ItemsSource = new ObservableCollection<BillInfo>(billInfoUnpaidTable);
                    OnPropertyChanged(nameof(BillInfoCollection));
                    LoadTotalBill(currentBillId);
                }

            }
            catch (Exception ex)
            {
                bool? result = new MessageBoxCustom("Hóa đơn trống", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
        }

        private async void btnAddDrink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboDrink.SelectedItem != null && !string.IsNullOrWhiteSpace(txtNumber.Text))
                {
                    Drink selectedDrink = cboDrink.SelectedItem as Drink;
                    if (selectedDrink != null && int.TryParse(txtNumber.Text, out int count))
                    {
                        //check table has people or not
                        Table table = await tableRepository.CheckTableStatus(currentTableId, 0);
                        if (table == null)
                        {
                            await tableRepository.UpdateTableStatus(currentTableId, 0);
                            Bill bill = new Bill
                            {
                                IdTable = currentTableId,
                                DateCheckIn = DateTime.Now,
                                Status = 0
                            };
                            await billRepository.InsertBill(bill);
                        }

                        Bill billInserted = await billRepository.GetBillTableStatusPaid(currentTableId, 0);

                        BillInfo newBillInfo = new BillInfo
                        {
                            IdDrink = selectedDrink.DrinkId,
                            Count = count,
                            IdBill = billInserted.BillId
                        };
                        currentBillId = billInserted.BillId;
                        billInfoRepository.InsertBillInfo(newBillInfo);
                        bool? result = new MessageBoxCustom("Thêm đồ uống thành công", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                        txtNumber.Text = string.Empty;
                    }
                    else
                    {
                        bool? result = new MessageBoxCustom("Vui lòng điền số lượng đồ uống", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                    }
                }
                else
                {
                    bool? result = new MessageBoxCustom("Vui lòng chọn giá trị hợp lệ", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                bool? result = new MessageBoxCustom("Thêm đồ uống thất bại", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            finally
            {
                LoadTable();
                showBill(currentTableId);
                cboDrink.SelectedIndex = -1;
                LoadTotalBill(currentBillId);

            }

        }

        private async void btnPay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Table currentTable = await tableRepository.GetTable(currentTableId);
                if (currentTable.TableStatus == "Trống")
                {
                    new MessageBoxCustom("Table is empty. You cannot pay", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                    return;
                }
                else
                {
                    //Update status of table into empty
                    tableRepository.UpdateTableStatus(currentTableId, 1);

                    Bill currentBill = await billRepository.GetBill(currentBillId);
                    currentBill.DateCheckOut = DateTime.Now;
                    currentBill.Status = 1;
                    billRepository.UpdateBill(currentBill);
                    bool? result = new MessageBoxCustom("Pay success", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                    showBill(currentTableId);
                    LoadTable();

                }

            }
            catch (Exception ex)
            {
                bool? result = new MessageBoxCustom("Pay fail", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }


        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadTable();
                //LoadDrinkCategory();
                LoadDrink();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnDrinkView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDrinkCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnPersonal_Click(object sender, RoutedEventArgs e)
        {
            PersonalProfileWindow personallProfileWindow = new PersonalProfileWindow(account);
            this.Close();

        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }

        }



        #region property changed
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }




        #endregion

        #region sidebar_btn
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Bạn có muốn thoát khỏi chương trình", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        #endregion

        private void drink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void employee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}