    using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CountriesPage.xaml
    /// </summary>
    public partial class CountriesPage : Page
    {
        CountriesTableAdapter countriesTable = new CountriesTableAdapter();
        public CountriesPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CountriesDataGrid.ItemsSource = countriesTable.GetData();
            CountryNameBox.Text = "";
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
                    if (CountriesDataGrid.SelectedItem != null)
                    {
                        int countryID = (int)(CountriesDataGrid.SelectedItem as DataRowView).Row[0];
                        countriesTable.UpdateQuery(CountryNameBox.Text, countryID);
                        UpdateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Веберите поле для редактирования!");
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
                    countriesTable.InsertQuery(CountryNameBox.Text);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CountriesDataGrid.SelectedItem != null)
                {
                    CountryNameBox.Text = (string)(CountriesDataGrid.SelectedItem as DataRowView).Row[1];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountriesDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    countriesTable.DeleteQuery((int)(CountriesDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(CountryNameBox.Text))
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
            CountriesDataGrid.ItemsSource = countriesTable.GetData();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog();
                string json = "";
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    json = File.ReadAllText(dialog.FileName);
                    if (json.Length < 1)
                    {
                        MessageBox.Show("Файл пустой!");
                        return;
                    }
                    List<Country> list = JsonConvert.DeserializeObject<List<Country>>(json);
                    foreach (var item in list)
                    {
                        countriesTable.InsertQuery(item.country_name);
                    }
                }
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nПроверьте, что Вы выбрали файл JSON!");
            }
        }

        private void CountryNameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("Разрешены только буквы!");
            }
        }
    }
}
