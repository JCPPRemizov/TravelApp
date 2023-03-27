using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private object countriesTable;

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

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog();
                string json = "";
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    json = File.ReadAllText(dialog.FileName);
                    List<Role> list = JsonConvert.DeserializeObject<List<Role>>(json);
                    foreach (var item in list)
                    {
                        rolesTable.InsertQuery(item.role_name);
                    }
                }
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nПроверьте, что Вы выбрали файл JSON!");
            }
        }

        private void RoleBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
    }
}
