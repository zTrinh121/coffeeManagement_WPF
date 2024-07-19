using BusinessObjects;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
            if (currentTable != null)
            {
                cboTable.SelectedValue = currentTable.TableId;
            }
        }

        private void cboTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

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
                new MessageBoxCustom("Bàn bị trống", MessageType.Warning, MessageButtons.Ok).ShowDialog();
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

        #region bill_info_View
        public ObservableCollection<BillInfo> BillInfoCollection
        {
            get { return _billInfoCollection; }
            set
            {
                _billInfoCollection = value;
                OnPropertyChanged();
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
                
                dgData.ItemsSource = null;
                TotalBill = 0;
                new MessageBoxCustom("Hóa đơn trống", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
        }

        #endregion

        #region drinkAddDelleteBill

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
                        currentTable = table;

                        BillInfo newBillInfo = new BillInfo
                        {
                            IdDrink = selectedDrink.DrinkId,
                            Count = count,
                            IdBill = billInserted.BillId
                        };
                        currentBillId = billInserted.BillId;
                        billInfoRepository.InsertBillInfo(newBillInfo);
                        new MessageBoxCustom("Thêm đồ uống thành công", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                        txtNumber.Text = string.Empty;
                    }
                    else
                    {
                        new MessageBoxCustom("Vui lòng điền số lượng đồ uống", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                    }
                }
                else
                {
                     new MessageBoxCustom("Vui lòng chọn giá trị hợp lệ", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                 new MessageBoxCustom("Thêm đồ uống thất bại", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            finally
            {
                LoadTable();
                showBill(currentTableId);
                cboDrink.SelectedIndex = -1;
                LoadTotalBill(currentBillId);

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

        #endregion

        #region pay

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
                   


                    try
                    {
                        if (dgData.Items.Count > 0)
                        {
                            
                            using (var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
                            {
                                System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
                                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                                {
                                    string folderPath = folderBrowserDialog.SelectedPath;
                                    Table table = await tableRepository.GetTable(currentTableId);
                                    Bill billInserted = currentBill;
                                    DateTime checkInDate = billInserted.DateCheckIn;
                                    string formattedCheckInDate = checkInDate.ToString("yyyy-MM-dd_HH-mm-ss");
                                    string fileName = $"HoaDon_{table.TableName}_{formattedCheckInDate}.pdf";
                                    string filePath = Path.Combine(folderPath, fileName);

                                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                                    {
                                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                                        doc.Open();

                                        // Font settings
                                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                        var titleFont = new Font(baseFont, 18, Font.BOLD);
                                        var headerFont = new Font(baseFont, 12, Font.BOLD);
                                        var bodyFont = new Font(baseFont, 12, Font.NORMAL);

                                        // Title
                                        Paragraph title = new Paragraph("Hóa Đơn Thanh Toán\n\n", titleFont);
                                        title.Alignment = Element.ALIGN_CENTER;
                                        doc.Add(title);

                                        // Bill information
                                        string formattedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                        Paragraph billInfo = new Paragraph($"Số bàn: {table.TableName}\nNgày: {formattedDateTime}\n\n", bodyFont);
                                        doc.Add(billInfo);

                                        // Table
                                        PdfPTable pdfTable = new PdfPTable(4);
                                        pdfTable.WidthPercentage = 100;
                                        pdfTable.SetWidths(new float[] { 30f, 20f, 25f, 25f });

                                        // Header
                                        pdfTable.AddCell(new PdfPCell(new Phrase("Tên đồ uống", headerFont)));
                                        pdfTable.AddCell(new PdfPCell(new Phrase("Số lượng", headerFont)));
                                        pdfTable.AddCell(new PdfPCell(new Phrase("Giá/đồ uống", headerFont)));
                                        pdfTable.AddCell(new PdfPCell(new Phrase("", headerFont)));

                                        // Data
                                        foreach (BillInfo billInfoItem in dgData.Items)
                                        {
                                            pdfTable.AddCell(new PdfPCell(new Phrase(billInfoItem.IdDrinkNavigation.DrinkName, bodyFont)));
                                            pdfTable.AddCell(new PdfPCell(new Phrase(billInfoItem.Count.ToString(), bodyFont)));
                                            pdfTable.AddCell(new PdfPCell(new Phrase(billInfoItem.IdDrinkNavigation.Price.ToString("N0"), bodyFont)));
                                            pdfTable.AddCell(new PdfPCell(new Phrase("", bodyFont))); // Empty cell for "Thao tác"
                                        }

                                        doc.Add(pdfTable);

                                        // Total bill
                                        Paragraph totalBillParagraph = new Paragraph($"\nTổng tiền: {TotalBill:N0} VND\n", bodyFont);
                                        totalBillParagraph.Alignment = Element.ALIGN_RIGHT;
                                        doc.Add(totalBillParagraph);

                                        doc.Close();
                                    }

                                    new MessageBoxCustom("Xuất hóa đơn và thanh toán thành công", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                                    currentBill.DateCheckOut = DateTime.Now;
                                    currentBill.Status = 1;
                                    billRepository.UpdateBill(currentBill);
                                }
                                else
                                {
                                    new MessageBoxCustom("Vui lòng chọn thư mục hợp lệ", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            new MessageBoxCustom("Không có dữ liệu để xuất hóa đơn", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxCustom($"Xuất hóa đơn thất bại: {ex.Message}", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                    } 
                    showBill(currentTableId);
                    LoadTable();

                }

            }
            catch (Exception ex)
            {
                bool? result = new MessageBoxCustom("Thanh toán thất bại", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
        }

        #endregion





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
            DrinkWindow drinkViewWindow = new DrinkWindow(account);
            drinkViewWindow.Show();
            this.Close();
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
            personallProfileWindow.Show();
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

        #region common_button
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

        #endregion


    }
}