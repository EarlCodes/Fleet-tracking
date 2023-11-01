using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Tracking
{
    class Car
    {
        string regNumber,type,manufacturer,engineSize,currentOdometer,nextOmeter = "";
        public Car()
        {
            
        }

         

        public String RegNumber
        {
            get { return regNumber; }
            set {  regNumber = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public String Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public String EngineSize
        {
            get { return engineSize; }
            set { engineSize = value; }
        }

        public String CurrentOdometer
        {
            get { return currentOdometer; }
            set { currentOdometer = value; }
        }

        public String NextOdometer
        {
            get { return nextOmeter; }
            set { nextOmeter = value; }
        }
    }
}
