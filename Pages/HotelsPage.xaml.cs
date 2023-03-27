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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        HotelsTableAdapter hotelsTable = new HotelsTableAdapter();
        public HotelsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            HotelsDataGrid.ItemsSource = hotelsTable.GetData();
            HotelNameBox.Text = "";
            HotelLevel.Value = 0;
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
                    if (HotelsDataGrid.SelectedItem != null)
                    {
                        int hotelID = (int)(HotelsDataGrid.SelectedItem as DataRowView).Row[0];
                        hotelsTable.UpdateQuery(HotelNameBox.Text, (int)HotelLevel.Value, hotelID);
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
                    hotelsTable.InsertQuery(HotelNameBox.Text, (int)HotelLevel.Value);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HotelsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (HotelsDataGrid.SelectedItem != null)
                {
                    HotelNameBox.Text = (HotelsDataGrid.SelectedItem as DataRowView).Row[1].ToString();
                    HotelLevel.Value = (int)(HotelsDataGrid.SelectedItem as DataRowView).Row[2];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HotelsDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    hotelsTable.DeleteQuery((int)(HotelsDataGrid.SelectedItem as DataRowView).Row[0]);
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
            if (string.IsNullOrEmpty(HotelNameBox.Text) || HotelLevel.Value == 0)
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
            HotelsDataGrid.ItemsSource = hotelsTable.GetData();
        }

        private void HotelNameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
    }
}
