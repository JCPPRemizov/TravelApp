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
    /// Логика взаимодействия для TouristPage.xaml
    /// </summary>
    public partial class TouristPage : Page
    {
        TouristTableAdapter touristTable = new TouristTableAdapter(); 
        public TouristPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TouristDataGrid.ItemsSource = touristTable.GetData();
            TouristSurname.Text = "";
            TouristName.Text = "";
            TouristMiddleName.Text = "";
            TouristPassNum.Text = "";
            TouristPassSer.Text = "";
            TouristAge.Text = "";
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
                    if (TouristDataGrid.SelectedItem != null)
                    {
                        int touristID = (int)(TouristDataGrid.SelectedItem as DataRowView).Row[0];
                        touristTable.UpdateQuery(TouristSurname.Text, TouristName.Text, TouristMiddleName.Text, TouristPassNum.Text, TouristPassSer.Text, Convert.ToInt32(TouristAge.Text), touristID);
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
                    touristTable.InsertQuery(TouristSurname.Text, TouristName.Text, TouristMiddleName.Text, TouristPassNum.Text, TouristPassSer.Text, Convert.ToInt32(TouristAge.Text));
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TouristDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TouristSurname.Text = (string)(TouristDataGrid.SelectedItem as DataRowView).Row[1];
                TouristName.Text = (string)(TouristDataGrid.SelectedItem as DataRowView).Row[2];
                if ((TouristDataGrid.SelectedItem as DataRowView).Row[3] == DBNull.Value)
                {
                    TouristMiddleName.Text = "";
                }
                else
                {
                    TouristMiddleName.Text = (string)(TouristDataGrid.SelectedItem as DataRowView).Row[3];
                }
                TouristPassNum.Text = (string)(TouristDataGrid.SelectedItem as DataRowView).Row[4];
                TouristPassSer.Text = (string)(TouristDataGrid.SelectedItem as DataRowView).Row[5];
                TouristAge.Text = (TouristDataGrid.SelectedItem as DataRowView).Row[6].ToString();
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TouristDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    touristTable.DeleteQuery((int)(TouristDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tourist_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void UpdateDataGrid()
        {
            TouristDataGrid.ItemsSource = touristTable.GetData();
        }

        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(TouristSurname.Text) || string.IsNullOrEmpty(TouristName.Text) || string.IsNullOrEmpty(TouristPassNum.Text) || string.IsNullOrEmpty(TouristPassSer.Text) || string.IsNullOrEmpty(TouristAge.Text))
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
