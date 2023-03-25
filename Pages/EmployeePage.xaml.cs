﻿using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeTableAdapter employeeTable = new EmployeeTableAdapter();
        RolesTableAdapter rolesTable= new RolesTableAdapter();
        public EmployeePage()
        {
            InitializeComponent();
            EmployeeDataGrid.IsReadOnly = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.ItemsSource = employeeTable.GetData();
            RolesBox.ItemsSource = rolesTable.GetData();
            RolesBox.DisplayMemberPath = "role_name";
            RolesBox.SelectedValuePath = "id";
        }

        private void EmployeePassNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
