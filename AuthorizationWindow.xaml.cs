using MaterialDesignThemes.Wpf;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TravelApp.DataSet1TableAdapters;
using TravelApp.Windows;

namespace TravelApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        AuthorizationTableAdapter authorizationAdapter = new AuthorizationTableAdapter();
        EmployeeTableAdapter employeeTableAdapter = new EmployeeTableAdapter();
        AdminWindow adminWindow = new AdminWindow();
        CashierWindow cashierWindow = new CashierWindow();
        public AuthorizationWindow()
        {
            InitializeComponent();

        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HideAppButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text) && !string.IsNullOrEmpty(PassTextBox.Password))
            {
                var passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$";
                string loginPattern = "^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\\d.-]{4,40}$";
                if (Regex.IsMatch(PassTextBox.Password, passPattern) && Regex.IsMatch(LoginTextBox.Text, loginPattern))
                {


                    switch (FindUser(LoginTextBox.Text, PassTextBox.Password))
                    {
                        case -1:
                            {
                                MessageBox.Show("Запись не найдена!");
                                break;
                            }
                        case 1:
                            {
                                this.Hide();
                                AdminWindow.authorizationWindow = this;
                                adminWindow.Show();
                                break;
                            }
                        case 2:
                            {
                                this.Hide();
                                CashierWindow.authorizationWindow = this;
                                cashierWindow.Show();
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Логин должен начинаться с буквы и не быть больше 40 символов; " +
                        "\nПароль должен иметь как минимум одну заглавную букву, одну цифру и один специальный знак. Минимальная длина - 8, максимальная - 40");
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль!");
            }
        }
        private int FindUser(string login, string password)
        {
            int userID = 0;
            DataTable authTable = authorizationAdapter.GetData();
            for (int i = 0; i < authTable.Rows.Count; i++)
            {
                if (login == (string)authTable.Rows[i][2])
                {
                    if (password == (string)authTable.Rows[i][3])
                    {
                        userID = Convert.ToInt32(authTable.Rows[i][1]);
                        return (int)employeeTableAdapter.GetData().FindByemployee_id(userID)[7];
                    }
                }

            }
            return -1;
            
            
        }

        private void AufWindow_Activated(object sender, EventArgs e)
        {
            LoginTextBox.Text = "";
            PassTextBox.Password = "";
        }
    }
}
