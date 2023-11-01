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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fleet_Tracking
{
    /// <summary>
    /// Interaction logic for TimeSheetPage.xaml
    /// </summary>
    public partial class TimeSheetPage : Page
    {
        public TimeSheetPage()
        {
            InitializeComponent();
        }

        private void BtnRecordHours_Click(object sender, RoutedEventArgs e)
        {
            record_mechanic_grid.Visibility = Visibility.Visible;
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
