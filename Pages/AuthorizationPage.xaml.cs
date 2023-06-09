﻿using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TravelApp.DataSet1TableAdapters;

namespace TravelApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        AuthorizationTableAdapter authorizationTable = new AuthorizationTableAdapter(); 
        EmployeeTableAdapter employeeTable = new EmployeeTableAdapter();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AuthDataGrid.ItemsSource = authorizationTable.GetData();
            UserIdBox.ItemsSource = employeeTable.GetData();
            UserIdBox.DisplayMemberPath = "employee_surname";
            UserIdBox.SelectedValuePath = "employee_id";
            LoginTextBox.Text = "";
            PassTextBox.Text = "";
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
                    string passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,40}$";
                    string loginPattern = "^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\\d.-]{4,40}$";
                    if (Regex.IsMatch(PassTextBox.Text, passPattern) && Regex.IsMatch(LoginTextBox.Text, loginPattern))  
                    {
                        authorizationTable.InsertQuery((int)UserIdBox.SelectedValue, LoginTextBox.Text, PassTextBox.Text);
                        UpdateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Логин должен начинаться с буквы и не быть больше 40 символов; " +
                            "\nПароль должен иметь как минимум одну заглавную букву, одну цифру и один специальный знак. Минимальная длина - 8, максимальная - 40");
                    }
                }
            }
            catch (Exception ex)
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
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    if (AuthDataGrid.SelectedItem != null)
                    {
                        int authID = (int)(AuthDataGrid.SelectedItem as DataRowView).Row[0];
                        var passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,40}$";
                        string loginPattern = "^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\\d.-]{4,40}$";
                        if (Regex.IsMatch(PassTextBox.Text, passPattern) && Regex.IsMatch(LoginTextBox.Text, loginPattern))
                        {
                            authorizationTable.UpdateQuery((int)UserIdBox.SelectedValue, LoginTextBox.Text, PassTextBox.Text, authID);
                            UpdateDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Логин должен начинаться с буквы и не быть больше 40 символов; " +
                                "\nПароль должен иметь как минимум одну заглавную букву, одну цифру и один специальный знак. Минимальная длина - 8, максимальная - 40");
                        }
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

        private void AuthDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView authDataRow = AuthDataGrid.SelectedItem as DataRowView;
                if (AuthDataGrid.SelectedItem != null)
                {
                    LoginTextBox.Text = (string)authDataRow.Row[2];
                    PassTextBox.Text = (string)authDataRow.Row[3];
                    UserIdBox.SelectedValue = (int)authDataRow.Row[1];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("Разрешены только буквы и цифры!");
            }
        }

        private void AuthDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    authorizationTable.DeleteQuery((int)(AuthDataGrid.SelectedItem as DataRowView).Row[0]);
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
            if (string.IsNullOrEmpty(LoginTextBox.Text) || string.IsNullOrEmpty(PassTextBox.Text) || UserIdBox.SelectedItem == null)
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
           AuthDataGrid.ItemsSource = authorizationTable.GetData();
        }
    }
}
