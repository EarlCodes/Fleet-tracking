using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Fleet_Tracking
{
    class Database
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\Fleet Tracking\Fleet Tracking\FLEETTRACKING.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;

        //general methood to open the the database
        public void OpenDatabase()
        {
            try
            {
                con.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        //a method that closes the database 
        public void CloseDatabase()
        {
            try
            { 
            con.Close();
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        //MEthod for storing vehicle
        public void AddVehicle(string vehicleNumber,string vehicleType,string manufacturer,int engineSize,int currentOdo,int nextOdo)
        {
            OpenDatabase();
            try
            {
                cmd = new SqlCommand("SP_CAPTURE_CAR", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("vehicle_number", vehicleNumber);
                cmd.Parameters.AddWithValue("vehicle_type", vehicleType);
                cmd.Parameters.AddWithValue("manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("engine_size", engineSize);
                cmd.Parameters.AddWithValue("current_odometer", currentOdo);
                cmd.Parameters.AddWithValue("next_Odometer", nextOdo);

                cmd.ExecuteNonQuery();
                
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            
            CloseDatabase();
        }


        //Get vehicle plates from database and assign it to a list
        public List<string> GetVehicleNumbers()
        {
            List<string> list = new List<string>();
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_GET_VEHICLE_NUMBER",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    list.Add(data[0].ToString());
                }
                data.Close();
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.StackTrace + e.Message);
            }

            CloseDatabase();
            return list;
        }

        //method to capture service type to database
        public void CapturerServiceType(string procedureCode,string serviceType,string description)
        {
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_CREATE_SERVICE_TYPE", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("procedure_code", procedureCode);
                cmd.Parameters.AddWithValue("service_type", serviceType);
                cmd.Parameters.AddWithValue("description", description);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e) 
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
        }

        //method to create trip 
        public void CreateTrip(string vehicle,string destination,string kilometer,string date)
        {
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_CREATE_TRIP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("vehicle_number", vehicle);
                cmd.Parameters.AddWithValue("destination", destination);
                cmd.Parameters.AddWithValue("number_kilo", kilometer);
                cmd.Parameters.AddWithValue("trip_date", date);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
        }

        //method to get trip numbers
        public List<string> GetTripNumbers()
        {
            List<string> list = new List<string>();
            
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_GET_TRIP_NUMBERS", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader data = cmd.ExecuteReader();
                while(data.Read())
                {
                    list.Add(data[0].ToString());
                }
                data.Close();
            }
            catch (SqlException e) 
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
            return list;
        }

        //METHOD TO GET THE LAST TRIP ID 
        public string GetTripId()
        {
            String tripId = "";
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("GET_LAST_TRIP_ID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader data = cmd.ExecuteReader();
                while(data.Read())
                {
                    tripId = data[0].ToString();
                }
                data.Close();
            }
            catch (SqlException x)
            {

                MessageBox.Show(x.Message + x.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
            return tripId;
        }

        //method to add service appoinment to the appoinment list
        public void CaptureAppoinment(string vehicleNumber  ,string date ,string serviceId,string time)
        {
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("CREATE_SERVICE_APPOINMENT", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("vehicle_number", vehicleNumber);
                cmd.Parameters.AddWithValue("appoinment_date", date);
                cmd.Parameters.AddWithValue("service_id", serviceId);
                cmd.Parameters.AddWithValue("appoinment_time", time);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message + e.StackTrace);
            }
            CloseDatabase();
        }
       
        //Method to handle get car details 
        //returns Car
        public Car GetCarDetails( string carReg)
        {
            Car car = new Car();

            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_GET_VEHICLE_DETAILS", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Vehicle", carReg);

                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    car.RegNumber = data[0].ToString();
                    car.Type = data[1].ToString();
                    car.Manufacturer = data[2].ToString();
                    car.EngineSize = data[3].ToString();
                    car.CurrentOdometer = data[4].ToString();
                    car.NextOdometer = data[5].ToString();
                }
                data.Close();
            }
            catch (SqlException w)
            {

                MessageBox.Show(w.Message + w.StackTrace);
            }
            finally
            {              
                CloseDatabase();
            }

            CloseDatabase();
            return car;
        }

        //method to handle update vehicles
        public void UpdateVehicle(string vehicleNumber, string vehicleType, string manufacturer, int engineSize, int currentOdo, int nextOdo)
        {
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_UPDATE_VEHICLE", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("VEHICLE_NUMBER", vehicleNumber);
                cmd.Parameters.AddWithValue("VEHICLE_TYPE", vehicleType);
                cmd.Parameters.AddWithValue("MANUFACTURER", manufacturer);
                cmd.Parameters.AddWithValue("ENGINE_SIZE", engineSize);
                cmd.Parameters.AddWithValue("CURRENT_ODOMETER", currentOdo);
                cmd.Parameters.AddWithValue("NEXTSERVICE_ODOMETER", nextOdo);

                cmd.ExecuteNonQuery();
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            CloseDatabase();
        }

        //Method to handle getting the procedure codes
        public List<string> GetProcedureCodes()
        {
            List<string> list = new List<string>();
            try
            {
                OpenDatabase();

                cmd = new SqlCommand("SP_GET_PROCEDURE_CODES",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader data = cmd.ExecuteReader();

                while(data.Read())
                {
                    list.Add(data[0].ToString());
                }

                data.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
            return list;
        }
        public String GetLastAppoimentNumber()
        {
            string appoinment_number = "";
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_GET_LAST_APPOINMENT_NUMBER", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader data = cmd.ExecuteReader();

                while(data.Read())
                {
                    appoinment_number = data[0].ToString();
                }
                data.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
            return appoinment_number;
        }

        //capturing fuel usage
        public void TripIncident(String tripId,string incident)
        {
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_RECORD_TRIP_INCIDENT", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("trip_number", tripId);
                cmd.Parameters.AddWithValue("incident", incident);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
        }

        //fuel usage 
        public void FuelUsage(String tripId, string fuelUsage)
        {
            try
            {
                OpenDatabase();
                cmd = new SqlCommand("SP_ADD_FUELUSAGE", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("trip_number", tripId);
                cmd.Parameters.AddWithValue("fuel_usage", fuelUsage);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
        }

        //Completed trips
        public void CaptureCompletedTrip(string regNumber,string completedDate,string driverId)
        {
            try
            {
                OpenDatabase();
                cmd = new  SqlCommand("SP_CAPTURER_COMPLETED_TRIP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("trip_number", regNumber);
                cmd.Parameters.AddWithValue("completed_date", completedDate);
                cmd.Parameters.AddWithValue("driver_id", driverId);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            { 
               CloseDatabase();
            }
            CloseDatabase();
        }

        //check password
        public bool PasswordCorrect(string empId,string password)
        {
            bool passwordCorrect = false;
            try
            {
                string localPassword = "";
                OpenDatabase();
                cmd = new SqlCommand("GET_PASSWORD", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("employee_id", empId);

                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    localPassword = data[0].ToString();
                }
                if(localPassword.Equals(""))
                {
                    passwordCorrect = false;
                }
                if(localPassword.Equals(password))
                {
                    passwordCorrect = true;
                }
                data.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message + e.StackTrace);
            }
            finally
            {
                CloseDatabase();
            }
            CloseDatabase();
            return passwordCorrect;
        }
    }
}
