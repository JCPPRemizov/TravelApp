using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TravelApp.DataSet1TableAdapters;

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        RolesTableAdapter rolesTable = new RolesTableAdapter();
        public RolesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RolesDataGrid.ItemsSource = rolesTable.GetData();
            RoleBox.Text = "";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsFieldsEmpty())
                {
                    MessageBox.Show("Заполните поле \"Название роли\"");
                }
                else
                {
                    if (RolesDataGrid.SelectedItem != null)
                    {
                        int roleID = (int)(RolesDataGrid.SelectedItem as DataRowView).Row[0];
                        rolesTable.UpdateQuery(RoleBox.Text, roleID);
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
                    MessageBox.Show("Заполните поле \"Название роли\"");
                }
                else
                {
                    rolesTable.InsertQuery(RoleBox.Text);
                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RolesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem != null)
            {
                RoleBox.Text = (string)(RolesDataGrid.SelectedItem as DataRowView).Row[1];
            }

        }

        private void RolesDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    rolesTable.DeleteQuery((int)(RolesDataGrid.SelectedItem as DataRowView).Row[0]);
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
            if (string.IsNullOrEmpty(RoleBox.Text))
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
            RolesDataGrid.ItemsSource = rolesTable.GetData();
        }
    }
}
