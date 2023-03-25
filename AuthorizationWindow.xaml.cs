using MaterialDesignThemes.Wpf;
using System;
using System.Data;
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
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль!");
            }
        }
        private int FindUser(string login, string password)
        {
            DataTable authTable = authorizationAdapter.GetData();
            for (int i = 0; i < authTable.Rows.Count; i++)
            {
                if (login == (string)authTable.Rows[i][2])
                {
                    if (password == (string)authTable.Rows[i][3])
                    {
                        return Convert.ToInt32(authTable.Rows[i][1]);
                    }
                }

            }
            return -1;
        }
    }
}
