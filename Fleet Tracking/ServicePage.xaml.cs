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
    /// Interaction logic for ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        Database database = new Database();
        public ServicePage()
        {
            InitializeComponent();
        }
        
 // working Appoinment scheduling grid
        private void BtnAppoinment_Click(object sender, RoutedEventArgs e)
        {
            //Setting the combo box to values from a database
              //Setting combobox for vehicles
            List<string> list = new List<string>();
            list = database.GetVehicleNumbers();

            int x = 0;
            while (x < list.Count)
            {
                comboVehicleNumber.Items.Add(list.ElementAt(x));
                x++;
            }

            //setting the combo box for available service code
            list = new List<string>();
            list = database.GetProcedureCodes();

            int w = 0;
            while (w < list.Count)
            {
                comboServiceId.Items.Add(list.ElementAt(w));
                w++;
            }

            //Opening the right grid when the user clicks side panel button
            procedure_grid.Visibility = Visibility.Hidden;
            daily_Job_sheet_grid.Visibility = Visibility.Hidden;
            appoinment_scheduled_grid.Visibility = Visibility.Visible;

        }
        private void BtnOkay_Click(object sender, RoutedEventArgs e)
        {
            if(comboVehicleNumber.SelectedItem != null && datePicker.SelectedDate != null && txtHour.Text !="" && txtMinute.Text !="")
            {
                try
                {
                    int hour = int.Parse(txtHour.Text);
                    int minutes = int.Parse(txtMinute.Text);

                    if (hour != 0 )
                    {
                        string time = hour + ":" + minutes;
                       
                        database.CaptureAppoinment(comboVehicleNumber.Text, datePicker.SelectedDate.Value.ToShortDateString(), comboServiceId.Text, time);
                        MessageBox.Show("Service Appoinment list has been captured .The appoinment number is :"+ database.GetLastAppoimentNumber()+" Use appoinment list for tracking");
                    }
                }
                catch(FormatException ex)
                {
                    MessageBox.Show("Expected a number instead ohter character were found.Please insert the hour and minute in numbers");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }

            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            comboVehicleNumber.SelectedItem = null;
            datePicker.SelectedDate = null;
            txtHour.Text = "";
            txtMinute.Text = "";
        }

//Daily job sheet grid
        private void BtnDailyJobSheet_Click(object sender, RoutedEventArgs e)
        {
            //Opening the right grid when the user clicks side panel button
            procedure_grid.Visibility = Visibility.Hidden;
            appoinment_scheduled_grid.Visibility = Visibility.Hidden;
            daily_Job_sheet_grid.Visibility = Visibility.Visible;
        }

        //Create service procedure grid 
        private void BtnProcedure_Click(object sender, RoutedEventArgs e)
        {
            //Opening the right grid when the user clicks side panel button
            appoinment_scheduled_grid.Visibility = Visibility.Hidden;
            daily_Job_sheet_grid.Visibility = Visibility.Hidden;
            procedure_grid.Visibility = Visibility.Visible;
        }

        private void BtnProcedureOkay_Click(object sender, RoutedEventArgs e)
        {
            if(txtProcedureCode.Text.Length < 5)
            {
                if(txtProcedureCode.Text !="" && txtDescription.Text !="" && txtServiceType.Text !="")
                {
                    database.CapturerServiceType(txtProcedureCode.Text, txtServiceType.Text, txtDescription.Text);
                    MessageBox.Show("Successfully captured service code "+ txtProcedureCode.Text);
                }
                else
                {
                    MessageBox.Show("some Field are empty.Please make sure that all fields are inserted");
                }
            }
            else
            {
                MessageBox.Show("Please make sure that the procedure code consist of 5 characters not more and try again ");
            }
        }
        private void BtnProcedureClear_Click(object sender, RoutedEventArgs e)
        {
            txtProcedureCode.Text = "";
            txtDescription.Text = "";
            txtServiceType.Text = "";
        }

    }
}
