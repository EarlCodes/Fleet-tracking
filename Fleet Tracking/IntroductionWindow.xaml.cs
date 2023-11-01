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

namespace Fleet_Tracking
{
    /// <summary>
    /// Interaction logic for IntroductionWindow.xaml
    /// </summary>
    public partial class IntroductionWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        public IntroductionWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerPage managerPage = new ManagerPage();

            mainWindow.mainFrame.Content = managerPage;
            this.Close();
            mainWindow.Show();

            //textBlock.Text = date.SelectedDate.Value.ToShortDateString();
            
        }

        //Configuring the vehicle buttton to display vehicle page 
        private void BtnVehicle_Click(object sender, RoutedEventArgs e)
        {
            //This is where the frames content is set 
            
            VehiclePage vehiclePage = new VehiclePage();

            mainWindow.mainFrame.Content = vehiclePage;
            this.Close();
            mainWindow.Show();
        }

        //Configuring the vehicle buttton to display Trip page 
        private void BtnTrip_Click(object sender, RoutedEventArgs e)
        {
            TripPage tripPage = new TripPage();
            mainWindow.mainFrame.Content = tripPage;
            this.Close();
            mainWindow.Show();
        }

        //Configuring the vehicle buttton to display service page 
        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            ServicePage servicePage = new ServicePage();
            mainWindow.mainFrame.Content = servicePage;
            this.Close();
            mainWindow.Show();
        }

        private void BtnTimesheet_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logInWindow = new LogInWindow();
            this.Close();
            logInWindow.Show();
            
        }
    }
}
