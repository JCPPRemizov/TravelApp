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
    /// Логика взаимодействия для CitiesPage.xaml
    /// </summary>
    public partial class CitiesPage : Page
    {
        CitiesTableAdapter citiesTable = new CitiesTableAdapter();
        CountriesTableAdapter countriesTable = new CountriesTableAdapter();
        public CitiesPage()
        {
            InitializeComponent();
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
                    if (CitiesDataGrid.SelectedItem != null)
                    {
                        int countryID = (int)(CountryComboBox.SelectedItem as DataRowView).Row[0];
                        int cityID = (int)(CitiesDataGrid.SelectedItem as DataRowView).Row[0];
                        citiesTable.UpdateQuery(CityNameBox.Text, countryID, cityID);
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
                    citiesTable.InsertQuery(CityNameBox.Text, (int)CountryComboBox.SelectedValue);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CitiesDataGrid.ItemsSource = citiesTable.GetData();
            CountryComboBox.ItemsSource = countriesTable.GetData();
            CountryComboBox.DisplayMemberPath = "country_name";
            CountryComboBox.SelectedValuePath = "country_id";
            CityNameBox.Text = "";
        }

        private void CitiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView citiesRowView = CitiesDataGrid.SelectedItem as DataRowView;
                if (CitiesDataGrid.SelectedItem != null)
                {
                    CityNameBox.Text = citiesRowView.Row[1].ToString();
                    CountryComboBox.SelectedValue = (int)citiesRowView.Row[2];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CitiesDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    citiesTable.DeleteQuery((int)(CitiesDataGrid.SelectedItem as DataRowView).Row[0]);
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
            CitiesDataGrid.ItemsSource = citiesTable.GetData();
        }
        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(CityNameBox.Text) || CountryComboBox.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
