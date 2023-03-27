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
        private static readonly Page[] pages = new Page[]
        {
            new RolesPage(),
            new AuthorizationPage(),
            new EmployeePage(),
            new TouristPage(),
            new VoucherPage(),
            new AdditionalServicePage(),
            new CountriesPage(),
            new CitiesPage(),
            new HotelsPage(),
            new CarrierPage(),
            new ReceiptPage()
        };
        public AdminWindow()
        {
            InitializeComponent();
            WindowComboBox.SelectedIndex = 0;
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


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void WindowComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdminFrame.Content = pages[WindowComboBox.SelectedIndex];
        }
    }
}
