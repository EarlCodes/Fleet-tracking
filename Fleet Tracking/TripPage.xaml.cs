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
    /// Interaction logic for TripPage.xaml
    /// </summary>
    public partial class TripPage : Page
    {
        Database database = new Database();
        public TripPage()
        {
            InitializeComponent();
        }

        //Working with the create trip grid
        private void BtnCreateTrip_Click(object sender, RoutedEventArgs e)
        {
            //Adding values to a combo box
            List<string> list = new List<string>();
            list = database.GetVehicleNumbers();
            ComboBoxItem item = new ComboBoxItem();

            int x = 0;
            while (x < list.Count)
            {
                comboCarReg.Items.Add(list.ElementAt(x));
                x++;
            }


            //Configuring the right grids to disable
            //when a user clicks on the side panel button
            fuel_usage_grid.Visibility = Visibility.Hidden;
            trip_incident_grid.Visibility = Visibility.Hidden;
            trip_completed_grid.Visibility = Visibility.Hidden;
            create_trip_grid.Visibility = Visibility.Visible;
        }
        private void BtnOkay_Click(object sender, RoutedEventArgs e)
        {
            if(comboCarReg.SelectedItem != null && txtDestination.Text != "" && txtDate.SelectedDate != null && txtNoKilo.Text !="")
            {
                database.CreateTrip(comboCarReg.Text, txtDestination.Text, txtNoKilo.Text, txtDate.Text);
                MessageBox.Show("Sucessfully created trip.Trip number is "+database.GetTripId() +" Use trip number to track trip");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            comboCarReg.SelectedItem = null;
            txtDestination.Text = "";
            txtDate.SelectedDate = null;
            txtNoKilo.Text = "";
        }

        //Working with the completed trips grid
        private void BtnCompletedTrips_Click(object sender, RoutedEventArgs e)
        {
            //inserting into combo box trip id 
            List<string> list = new List<string>();
            list = database.GetTripNumbers();

            int x = 0;
            while (x < list.Count)
            {
                comboAppNumber.Items.Add(list.ElementAt(x));
                x++;
            }

            //Inserting into combox 



            //Configuring the right grids to disable
            //when a user clicks on the side panel button
            create_trip_grid.Visibility = Visibility.Hidden;
            fuel_usage_grid.Visibility = Visibility.Hidden;
            trip_incident_grid.Visibility = Visibility.Hidden;
            trip_completed_grid.Visibility = Visibility.Visible;

        }

        private void BtnCTOkay_Click(object sender, RoutedEventArgs e)
        {
            if(comboAppNumber.SelectedItem != null && txtCTrips.SelectedDate != null && txtDriverId.Text !="")
            {
                database.CaptureCompletedTrip(comboAppNumber.Text, txtCTrips.SelectedDate.Value.ToShortDateString(), txtDriverId.Text);
                MessageBox.Show("Successfully Stored a Completed trip.");
            }
            else
            {
                MessageBox.Show("Please make sure that alll fields are not empty");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            comboAppNumber.SelectedItem = null;
            txtCTrips.SelectedDate = null;
            txtDriverId.Text = "";
        }

        //Working with the fuel usage grid 
        private void BtnFuelUsage_Click(object sender, RoutedEventArgs e)
        {
            //configuring the combo button to have values that already exist
            List<string> list = new List<string>();
            list = database.GetTripNumbers();

            int x = 0;
            while (x < list.Count)
            {
                comboFuelTripId.Items.Add(list.ElementAt(x));
                x++;
            }


            //Configuring the right grids to disable
            //when a user clicks on the side panel button
            create_trip_grid.Visibility = Visibility.Hidden;
            trip_incident_grid.Visibility = Visibility.Hidden;
            trip_completed_grid.Visibility = Visibility.Hidden;
            fuel_usage_grid.Visibility = Visibility.Visible;

        }

        private void BtnTOkay_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int fuel = int.Parse(txtFuelUsage.Text);
                if (comboFuelTripId != null && txtFuelUsage.Text !="")
                {
                    database.FuelUsage(comboFuelTripId.Text, fuel.ToString());
                    MessageBox.Show("Added Fuel Usage to the Trip");
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Please make sure that you have inserted only digits");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            comboFuelTripId = null;
            txtFuelUsage.Text = "";
        }

        //Working with the trip incindent grid
        private void BtnTripIncidents_Click(object sender, RoutedEventArgs e)
        {
            //configuring the combo box to display trips that are already in the database
                //configuring the combo button to have values that already exist
                List<string> list = new List<string>();
                list = database.GetTripNumbers();

                int x = 0;
                while (x < list.Count)
                {
                    comboITripId.Items.Add(list.ElementAt(x));
                    x++;
                }


                //Configuring the right grids to disable
                //when a user clicks on the side panel button
                create_trip_grid.Visibility = Visibility.Hidden;           
            trip_completed_grid.Visibility = Visibility.Hidden;
            fuel_usage_grid.Visibility = Visibility.Hidden;
            trip_incident_grid.Visibility = Visibility.Visible;

        }

        //Menu button configurations
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sidePanel.Width == 80)
            {
                sidePanel.Width = 200;
            }

            else if (sidePanel.Width == 200)
            {
                sidePanel.Width = 80;
            }
        }

        private void BtnIncidentOkay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboITripId.SelectedItem != null && txtIncident.Text != "")
                {
                    database.TripIncident(comboITripId.Text, txtIncident.Text);
                    MessageBox.Show("Captured Trip incident for trip id "+comboITripId.Text);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please make sure that you have inserted only digits");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnIncidentClear_Click(object sender, RoutedEventArgs e)
        {
            comboITripId.SelectedItem = null;
            txtIncident.Text = "";
        }
    }
}
