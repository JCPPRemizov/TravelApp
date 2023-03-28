using System;
using System.Collections.Generic;
using System.Data;
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
using TravelApp.DataSet1TableAdapters;
using static TravelApp.DataSet1;

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для VoucherPage.xaml
    /// </summary>
    public partial class VoucherPage : Page
    {
        VoucherTableAdapter voucherTable = new VoucherTableAdapter();
        EmployeeTableAdapter employeeTable = new EmployeeTableAdapter();
        CitiesTableAdapter citiesTable = new CitiesTableAdapter();
        CountriesTableAdapter countriesTable = new CountriesTableAdapter();
        Additional_servicesTableAdapter servicesTable = new Additional_servicesTableAdapter();
        CarrierTableAdapter carrierTable = new CarrierTableAdapter();
        HotelsTableAdapter hotelsTable = new HotelsTableAdapter();
        public VoucherPage()
        {
            InitializeComponent();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            VoucherName.Text = "";
            EmployeeID.ItemsSource = employeeTable.GetData();
            EmployeeID.DisplayMemberPath = "employee_surname";
            EmployeeID.SelectedValuePath = "employee_id";
            CityID.ItemsSource = citiesTable.GetData();
            CityID.DisplayMemberPath = "city_name";
            CityID.SelectedValuePath = "city_id";
            CountryID.ItemsSource = countriesTable.GetData();
            CountryID.DisplayMemberPath = "country_name";
            CountryID.SelectedValuePath = "country_id";
            ServiceID.ItemsSource = servicesTable.GetData();
            ServiceID.DisplayMemberPath = "service_name";
            ServiceID.SelectedValuePath = "service_id";
            CarrierID.ItemsSource = carrierTable.GetData();
            CarrierID.DisplayMemberPath = "carrier_name";
            CarrierID.SelectedValuePath = "carrier_id";
            HotelID.ItemsSource = hotelsTable.GetData();
            HotelID.DisplayMemberPath = "hotel_name";
            HotelID.SelectedValuePath = "hotel_id";
            VoucherPrice.Text = "";
            DateBegin.DisplayDateStart = DateTime.Today;
            DateBegin.SelectedDate = DateTime.Today;
            DateEnd.Text = "";
            DateEnd.DisplayDateStart = DateTime.Today;
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
                    if (VouchereDataGrid.SelectedItem != null)
                    {
                        int VoucherID = (int)(VouchereDataGrid.SelectedItem as DataRowView).Row[0];
                        if (ServiceID.SelectedIndex == -1)
                        {
                            ServiceID.SelectedValue = null;
                        }
                        voucherTable.UpdateQuery(VoucherName.Text, (int)EmployeeID.SelectedValue, (int)CityID.SelectedValue, 
                            (int)CountryID.SelectedValue, (int?)ServiceID.SelectedValue, (int)CarrierID.SelectedValue, 
                            (int)HotelID.SelectedValue, Convert.ToInt32(VoucherPrice.Text), DateBegin.Text, DateEnd.Text, VoucherID);
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
                MessageBox.Show($"Ошибка: {ex.Message}");
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
                    if (ServiceID.SelectedIndex == -1)
                    {
                        ServiceID.SelectedValue = null;
                    }
                    voucherTable.InsertQuery(VoucherName.Text, (int)EmployeeID.SelectedValue, (int)CityID.SelectedValue, (int)CountryID.SelectedValue, (int)ServiceID.SelectedValue,
                        (int)CarrierID.SelectedValue, (int)HotelID.SelectedValue, Convert.ToInt32(VoucherPrice.Text), DateBegin.Text, DateEnd.Text);
                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VouchereDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView VoucherRowView = VouchereDataGrid.SelectedItem as DataRowView;
            if (VouchereDataGrid.SelectedItem != null)
            {
                VoucherName.Text = (string)VoucherRowView.Row[1];
                EmployeeID.SelectedValue = (int)VoucherRowView.Row[2];
                CityID.SelectedValue = (int)VoucherRowView.Row[3];
                CountryID.SelectedValue = (int)VoucherRowView.Row[4];
                if (VoucherRowView.Row[5] != DBNull.Value)
                {
                    ServiceID.SelectedValue = (int)VoucherRowView.Row[5];
                }
                else
                {
                    ServiceID.SelectedIndex = -1;
                }
                CarrierID.SelectedValue = (int)VoucherRowView.Row[6];
                HotelID.SelectedValue = (int)VoucherRowView.Row[7];
                VoucherPrice.Text = VoucherRowView.Row[8].ToString();
                DateBegin.SelectedDate = Convert.ToDateTime(VoucherRowView.Row[9]);
                DateEnd.SelectedDate = Convert.ToDateTime(VoucherRowView.Row[10]);

            }
        }

        private void VouchereDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    voucherTable.DeleteQuery((int)(VouchereDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UpdateDataGrid()
        {
            VouchereDataGrid.ItemsSource = voucherTable.GetData();
        }

        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(VoucherName.Text) || EmployeeID.SelectedItem == null || CityID.SelectedItem == null || CountryID.SelectedItem == null || CarrierID.SelectedItem == null 
                || HotelID.SelectedItem == null || string.IsNullOrEmpty(VoucherPrice.Text) || string.IsNullOrEmpty(DateBegin.Text) || string.IsNullOrEmpty(DateEnd.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ServiceID_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ServiceID.SelectedIndex = -1;
        }

        private void Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Здесь нельзя писать! Выберите дату, нажав на иконку календаря!");
        }

        private void VoucherPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("Разрешены только цифры!");
            }
        }

        private void VoucherName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("Разрешены только буквы!");
            }
        }
    }
}
