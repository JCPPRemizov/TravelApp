using System;
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
using System.Windows.Shapes;
using TravelApp.Pages;

namespace TravelApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static AuthorizationWindow authorizationWindow;
        public AdminWindow()
        {
            InitializeComponent();
            Table1.Focus();
        }

        private void HideAppButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            authorizationWindow.Show();
        }

        private void Table1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminFrame.Content = new EmployeePage();
        }

        private void Table1_GotFocus(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new EmployeePage();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
