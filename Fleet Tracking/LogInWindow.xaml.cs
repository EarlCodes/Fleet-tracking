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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        Database database = new Database();
        MainWindow mainWindow = new MainWindow();
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Text != "" && txtEmployeeId.Text != null)
            {
                bool passwordCorrect = database.PasswordCorrect(txtEmployeeId.Text, txtPassword.Text);

                if (passwordCorrect)
                {
                    TimeSheetPage timeSheetPage = new TimeSheetPage();
                    mainWindow.mainFrame.Content = timeSheetPage;
                    this.Close();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Please Make sure password exist");
                }
            }
        }
    }
}
