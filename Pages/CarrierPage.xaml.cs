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

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarrierPage.xaml
    /// </summary>
    public partial class CarrierPage : Page
    {
        CarrierTableAdapter carrierTable = new CarrierTableAdapter();
        public CarrierPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CarriersDataGrid.ItemsSource = carrierTable.GetData();
            CarrierlNameBox.Text = "";
            CarrierInnBox.Text = "";
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
                    if (CarriersDataGrid.SelectedItem != null)
                    {
                        int carrierID = (int)(CarriersDataGrid.SelectedItem as DataRowView).Row[0];
                        carrierTable.UpdateQuery(CarrierlNameBox.Text, Convert.ToInt32(CarrierInnBox.Text), carrierID);
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
                    carrierTable.InsertQuery(CarrierlNameBox.Text, Convert.ToInt32(CarrierInnBox.Text));
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarriersDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    carrierTable.DeleteQuery((int)(CarriersDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarriersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CarriersDataGrid.SelectedItem != null)
                {
                    CarrierlNameBox.Text = (CarriersDataGrid.SelectedItem as DataRowView).Row[1].ToString();
                    CarrierInnBox.Text = (CarriersDataGrid.SelectedItem as DataRowView).Row[2].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(CarrierlNameBox.Text) || string.IsNullOrEmpty(CarrierInnBox.Text))
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
            CarriersDataGrid.ItemsSource = carrierTable.GetData();
        }

        private void CarrierInnBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
