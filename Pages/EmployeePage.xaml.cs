using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TravelApp.DataSet1TableAdapters;

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeTableAdapter employeeTable = new EmployeeTableAdapter();
        RolesTableAdapter rolesTable= new RolesTableAdapter();
        public EmployeePage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.ItemsSource = employeeTable.GetData();
            RolesBox.ItemsSource = rolesTable.GetData();
            RolesBox.DisplayMemberPath = "role_name";
            RolesBox.SelectedValuePath = "role_id";
            EmployeeSurname.Text = "";
            EmployeeName.Text = "";
            EmployeeMiddleName.Text = "";
            EmployeePassNum.Text = "";
            EmployeePassSer.Text = "";
            EmployeeAge.Text = "";
        }

        private void EmployeeDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    employeeTable.DeleteQuery((int)(EmployeeDataGrid.SelectedItem as DataRowView).Row[0]);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    if (EmployeeDataGrid.SelectedItem != null)
                    {
                        int roleID = (int)RolesBox.SelectedValue;
                        int employeeID = (int)(EmployeeDataGrid.SelectedItem as DataRowView).Row[0];
                        employeeTable.UpdateQuery(EmployeeSurname.Text, EmployeeName.Text, EmployeeMiddleName.Text, EmployeePassNum.Text, EmployeePassSer.Text, Convert.ToInt32(EmployeeAge.Text), roleID, employeeID);
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
                    employeeTable.InsertQuery(EmployeeSurname.Text, EmployeeName.Text, EmployeeMiddleName.Text, EmployeePassNum.Text, EmployeePassSer.Text, Convert.ToInt32(EmployeeAge.Text), (int)RolesBox.SelectedValue);
                    UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView employeeRowView = EmployeeDataGrid.SelectedItem as DataRowView;
                if (EmployeeDataGrid.SelectedItem != null)
                {
                    EmployeeSurname.Text = (string)employeeRowView.Row[1];
                    EmployeeName.Text = (string)employeeRowView.Row[2];
                    if (employeeRowView.Row[3] == DBNull.Value)
                    {
                        EmployeeMiddleName.Text = "";
                    }
                    else
                    {
                        EmployeeMiddleName.Text = (string)(EmployeeDataGrid.SelectedItem as DataRowView).Row[3];
                    }
                    EmployeePassNum.Text = (string)employeeRowView.Row[4];
                    EmployeePassSer.Text = (string)employeeRowView.Row[5];
                    EmployeeAge.Text = employeeRowView.Row[6].ToString();
                    RolesBox.SelectedIndex = (int)employeeRowView.Row[7];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Employee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void UpdateDataGrid()
        {
            EmployeeDataGrid.ItemsSource = employeeTable.GetData();
        }

        private bool IsFieldsEmpty()
        {
            if (string.IsNullOrEmpty(EmployeeSurname.Text) || string.IsNullOrEmpty(EmployeeName.Text) || string.IsNullOrEmpty(EmployeePassNum.Text) || string.IsNullOrEmpty(EmployeePassSer.Text) || string.IsNullOrEmpty(EmployeeAge.Text) || RolesBox.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EmployeeName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

    }
}
