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
            catch(Exception ex)
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
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    receiptTable.InsertQuery(Convert.ToInt32(DeposMoneyBox.Text), (int)TouristID.SelectedValue, (int)VoucherID.SelectedValue);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
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
            catch(Exception ex)
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
                    DataRowView receipRowView = ReceiptDataGrid.SelectedItem as DataRowView;
                    DeposMoneyBox.Text = receipRowView.Row[1].ToString();
                    TouristID.SelectedValue = Convert.ToInt32(receipRowView.Row[2]);
                    VoucherID.SelectedValue = Convert.ToInt32(receipRowView.Row[3]);
                }
            }
            catch(Exception ex)
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
        }
    }
}
