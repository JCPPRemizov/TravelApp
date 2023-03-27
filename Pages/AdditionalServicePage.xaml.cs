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
    /// Логика взаимодействия для AdditionalServicePage.xaml
    /// </summary>
    public partial class AdditionalServicePage : Page
    {
        Additional_servicesTableAdapter servicesTableAdapter = new Additional_servicesTableAdapter();
        public AdditionalServicePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ServicesDataGrid.ItemsSource = servicesTableAdapter.GetData();
            ServiceNameBox.Text = "";
            ServicePriceBox.Text = "";
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
                    if (ServicesDataGrid.SelectedItem != null)
                    {
                        int serviceID = (int)(ServicesDataGrid.SelectedItem as DataRowView).Row[0];
                        servicesTableAdapter.UpdateQuery(ServiceNameBox.Text, Convert.ToInt32(ServicePriceBox.Text), serviceID);
                        UpdateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Веберите поле для редактирования!");
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
                    servicesTableAdapter.InsertQuery(ServiceNameBox.Text, Convert.ToInt32(ServicePriceBox.Text));
                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ServicesDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    servicesTableAdapter.DeleteQuery((int)(ServicesDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ServicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ServicesDataGrid.SelectedItem != null)
                {
                    ServiceNameBox.Text = (ServicesDataGrid.SelectedItem as DataRowView).Row[1].ToString();
                    ServicePriceBox.Text = (ServicesDataGrid.SelectedItem as DataRowView).Row[2].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDataGrid()
        {
            ServicesDataGrid.ItemsSource = servicesTableAdapter.GetData();
        }

        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(ServiceNameBox.Text) || string.IsNullOrEmpty(ServicePriceBox.Text))
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
