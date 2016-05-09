using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Application.Model
{
    class Advertisement
    {
        public string Coordinates { get; set; }
        public string Owner { get; set; }
        public DateTime DateOfExpire { get; set; }
        public List<PSensor> PSensors { get; }

        public Advertisement(string coordinates)
        {
            PSensors = new List<PSensor>();
            Coordinates = coordinates;
        }

        public bool AddPSensor(PSensor psensor)
        {
            if (PSensors.Contains(psensor))
                return false;

            PSensors.Add(psensor);
            return true;
        }

        public bool RemovePSensor(PSensor psensor)
        {
            
        }
    }
}
