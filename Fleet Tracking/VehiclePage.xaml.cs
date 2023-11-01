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
using System.Data.SqlClient;

namespace Fleet_Tracking
{
    /// <summary>
    /// Interaction logic for VehiclePage.xaml
    /// </summary>
    public partial class VehiclePage : Page
    {
        Database database = new Database();
        RWindow rw = new RWindow();
        public VehiclePage()
        {
            InitializeComponent();
        }

        //Working with the capture vehicle grid
        private void BtnCaptureV_Click(object sender, RoutedEventArgs e)
        {
            //closing panel when the user selects a button that displays a panel

            //Closing and oppening the right grid when the user clicks
            delete_vehicle_grid.Visibility = Visibility.Hidden;
            update_vehicle_grid.Visibility = Visibility.Hidden;
            capture_vehicle_grid.Visibility = Visibility.Visible;
        }

        private void BtnCaptureDone_Click(object sender, RoutedEventArgs e)
        {
            //Statements to capture a new vehicle record
            //when user inputs data and clicks done
            try
            {
                int engineSize, currentOdo, nextOdoMeter = 0;

                engineSize = int.Parse(txtEngineSize.Text.ToString());
                currentOdo = int.Parse(txtCurrentOdo.Text.ToString());
                nextOdoMeter = int.Parse(txtNextOdo.Text.ToString());

                //Check if the user filled in all the required fields
                if (txtRegistrationNumber.Text != "" && txtManufacturer.Text != "" &&
                    comboVehicleType.SelectionBoxItem != null && txtEngineSize.Text != "" && txtCurrentOdo.Text != "" && txtNextOdo.Text != "")
                {
                    //Capturing a vehicle while text blocks are not empty
                    database.AddVehicle(txtRegistrationNumber.Text.ToUpper(), comboVehicleType.Text, txtManufacturer.Text.ToUpper(), engineSize, currentOdo, nextOdoMeter);
                    MessageBox.Show($"A {comboVehicleType.Text} with registration {txtRegistrationNumber.Text} was stored successfully!!!");
                }
                else
                {
                    MessageBox.Show("Error while attempting to save.Please make sure that all the required fields are not empty and try again ");
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please make sure you inserted all the required fields");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check that you have entered digits where necessary not a combination degits and letters.");
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message + f.StackTrace);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtRegistrationNumber.Text = "";
            txtManufacturer.Text = "";
            comboVehicleType.SelectedItem = null;
            txtEngineSize.Text = "";
            txtCurrentOdo.Text = "";
            txtNextOdo.Text = "";
        }
        
        
//working with the update grid
        private void BtnUpdateV_Click(object sender, RoutedEventArgs e)
        {
            //Assigning combo box with car registration number from database
            List<string> list = new List<string>();
            list = database.GetVehicleNumbers();
            ComboBoxItem item = new ComboBoxItem();

            int x = 0;
            while(x < list.Count)
            {
                comboVehicleOptions.Items.Add(list.ElementAt(x));
                x++;
            }
            //closing panel when the user selects a button that displays a panel

            //Closing and oppening the right grid when the user clicks
            delete_vehicle_grid.Visibility = Visibility.Hidden;
            capture_vehicle_grid.Visibility = Visibility.Hidden;
            update_vehicle_grid.Visibility = Visibility.Visible;
        }
           //getting the car details based on user selection on a combo box
        private void BtnComboSelect_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            if(comboVehicleOptions.SelectedItem != null)
            {
                car = database.GetCarDetails(comboVehicleOptions.Text);
            }
            if(car != null)
            {
                txtURegistrationNumber.Text = car.RegNumber;
                txtUManufacturer.Text = car.Manufacturer;
                txtUEngineSize.Text = car.EngineSize;
                txtUCurrentOdo.Text = car.CurrentOdometer;
                txtUNextOdo.Text = car.NextOdometer;

                List<string> list = new List<string>();
                list = database.GetVehicleNumbers();

                int x = 0;
                while (x < list.Count)
                {
                    comboUVehicleType.Items.Add(list.ElementAt(x));
                    x++;
                }

            }
        }
        private void BtnUDone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int engineSize, currentOdo, nextOdoMeter = 0;

                engineSize = int.Parse(txtUEngineSize.Text.ToString());
                currentOdo = int.Parse(txtUCurrentOdo.Text.ToString());
                nextOdoMeter = int.Parse(txtUNextOdo.Text.ToString());

                //Check if the user filled in all the required fields
                if (txtURegistrationNumber.Text != "" && txtUManufacturer.Text != "" &&
                    comboUVehicleType.SelectionBoxItem != null && txtUEngineSize.Text != "" && txtUCurrentOdo.Text != "" && txtUNextOdo.Text != "")
                {
                    //Capturing a vehicle while text blocks are not empty
                    database.UpdateVehicle(comboVehicleOptions.Text, comboVehicleType.Text, txtUManufacturer.Text.ToUpper(), engineSize, currentOdo, nextOdoMeter);
                    MessageBox.Show($"A Car with registration plate {txtURegistrationNumber.Text} was stored successfully!!!");
                }
                else
                {
                    MessageBox.Show("Error while attempting to save.Please make sure that all the required fields are not empty and try again ");
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please make sure you inserted all the required fields");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check that you have entered digits where necessary not a combination degits and letters.");
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message + f.StackTrace);
            }
        }

        private void BtnUClear_Click(object sender, RoutedEventArgs e)
        {

            txtURegistrationNumber.Text = "";
            txtUManufacturer.Text = "";
            comboUVehicleType.SelectedItem = null;
            txtUEngineSize.Text = "";
            txtUCurrentOdo.Text = "";
            txtUNextOdo.Text = "";
        }
        //working with the delete grid
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //closing panel when the user selects a button that displays a panel
            sidePanel.Width = 81;

            //Closing and oppening the right grid when the user clicks
            update_vehicle_grid.Visibility = Visibility.Hidden;
            capture_vehicle_grid.Visibility = Visibility.Hidden;
            delete_vehicle_grid.Visibility = Visibility.Hidden;
        }

        private void BtnDeleteV_Click(object sender, RoutedEventArgs e)
        {
            //Statements to delete a vehicle when the user have selected a car to delete
        }
        //Menu button configarations
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntroductionWindow intro = new IntroductionWindow();
            intro.Show();
        }

        //Code to generate car report when the report button on the side panel is clicked
        private void BtnVehicleReport_Click(object sender, RoutedEventArgs e)
        {

            
            VehicleReport report = new VehicleReport();

            FleetDataSet data = new FleetDataSet();
            data = VehicleData();
            report.SetDataSource(data);

           
            rw.crystalReportViewer.ViewerCore.ReportSource = report;
            rw.crystalReportViewer.ViewerCore.Owner = Window.GetWindow(this);
            rw.Show();
        }

        public FleetDataSet VehicleData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\Fleet Tracking\Fleet Tracking\FLEETTRACKING.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VEHICLE", con);
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;
            FleetDataSet data = new FleetDataSet();
            adapter.Fill(data,"VEHICLE");

            con.Close();
            return data;
        }

    }
}
