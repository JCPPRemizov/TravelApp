using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TravelApp.DataSet1TableAdapters;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReceiptPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        ReceiptTableAdapter receiptTable = new ReceiptTableAdapter();
        TouristTableAdapter touristTable = new TouristTableAdapter();
        VoucherTableAdapter voucherTable = new VoucherTableAdapter();
        public ReceiptPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            DeposMoneyBox.Text = "";
            TouristID.ItemsSource = touristTable.GetData();
            TouristID.DisplayMemberPath = "tourist_surname";
            TouristID.SelectedValuePath = "tourist_id";
            VoucherID.ItemsSource = voucherTable.GetData();
            VoucherID.DisplayMemberPath = "voucher_name";
            VoucherID.SelectedValuePath = "voucher_id";
            ChangeMoney.Text = "";
            VoucherPrice.Text = "";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsFieldsEmpty())
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    if (ReceiptDataGrid.SelectedItem != null)
                    {
                        receiptTable.UpdateQuery(Convert.ToInt32(DeposMoneyBox.Text), (int)TouristID.SelectedValue, (int)VoucherID.SelectedValue, (int)(ReceiptDataGrid.SelectedItem as DataRowView).Row[0]);
                        UpdateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Выберите поле для редактирования!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsFieldsEmpty())
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var vouchers = voucherTable.GetData();
                    int voucherPrice = (int)vouchers.FindByvoucher_id((int)(ReceiptDataGrid.SelectedItem as DataRowView).Row[3])[8];
                    if (Convert.ToInt32(DeposMoneyBox.Text) < voucherPrice)
                    {
                        MessageBox.Show("Внесенных денег не достаточно!");
                        return;
                    }
                    receiptTable.InsertQuery(Convert.ToInt32(DeposMoneyBox.Text), (int)TouristID.SelectedValue, (int)VoucherID.SelectedValue);
                    UpdateDataGrid();
                    ReceiptDataGrid.SelectedIndex = ReceiptDataGrid.Items.Count - 1;
                    UploadReceipt();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiptDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    receiptTable.DeleteQuery((int)(ReceiptDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiptDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ReceiptDataGrid.SelectedItem != null)
                {
                    var vouchers = voucherTable.GetData();
                    DataRowView receipRowView = ReceiptDataGrid.SelectedItem as DataRowView;
                    DeposMoneyBox.Text = receipRowView.Row[1].ToString();
                    TouristID.SelectedValue = Convert.ToInt32(receipRowView.Row[2]);
                    VoucherID.SelectedValue = Convert.ToInt32(receipRowView.Row[3]);
                    ChangeMoney.Text = "Сдача: " + (Convert.ToInt32(DeposMoneyBox.Text) - Convert.ToInt32(vouchers.FindByvoucher_id((int)(VoucherID.SelectedValue))[8].ToString())).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(DeposMoneyBox.Text) || TouristID.SelectedItem == null || VoucherID.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdateDataGrid()
        {
            ReceiptDataGrid.ItemsSource = receiptTable.GetData();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            UploadReceipt();
        }
        private void UploadReceipt()
        {
            if (ReceiptDataGrid.SelectedItem != null)
            {
                var vouchers = voucherTable.GetData();
                var tourists = touristTable.GetData();
                string receiptNum = (ReceiptDataGrid.SelectedItem as DataRowView).Row[0].ToString();
                string touristName = tourists.FindBytourist_id((int)TouristID.SelectedValue)[1].ToString() + " " + tourists.FindBytourist_id((int)(ReceiptDataGrid.SelectedItem as DataRowView).Row[2])[2].ToString(); ;
                string voucherName = vouchers.FindByvoucher_id((int)(VoucherID.SelectedValue))[1].ToString();
                string voucherPrice = vouchers.FindByvoucher_id((int)(VoucherID.SelectedValue))[8].ToString();
                string deposMoney = (ReceiptDataGrid.SelectedItem as DataRowView).Row[1].ToString();
                string changeMoney = (Convert.ToInt32(deposMoney) - Convert.ToInt32(voucherPrice)).ToString();
                string receipt = $"Туристическое агенство\nЧек №{receiptNum}\n{voucherName} - {voucherPrice} руб.\nВыписано на имя: {touristName}\nИтого к оплате: {voucherPrice} руб.\nВнесено: {deposMoney} руб.\nСдача: {changeMoney} руб.";
                string fileName = $"\\Чек{receiptNum}.txt";
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + fileName, receipt);

            }
        }
        private void DeposMoneyBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("Разрешены только цифры!");
            }
        }

        private void VoucherID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VoucherID.SelectedItem != null)
            {
                var vouchers = voucherTable.GetData();
                VoucherPrice.Text = "Стоимость путевки: " + vouchers.FindByvoucher_id((int)(VoucherID.SelectedValue))[8].ToString();
            }
        }
    }
}
