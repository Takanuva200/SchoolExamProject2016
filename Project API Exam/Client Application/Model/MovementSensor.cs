using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_Application.Model
{
    class MovementSensor
    {
        /// <summary>
        /// Gets the ID of the sensor. Private setter.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the address of a movement sensor
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// Gets or sets the number of time the movement sensor has been activated
        /// </summary>
        public int NumberOfActivations { get; set; }
        /// <summary>
        /// Gets or sets the UdpClient that is going to be used by the webservice
        /// </summary>
        public UdpClient SensorClient { get; set; }

        /// <summary>
        /// A class that represents 1 movement sensor
        /// </summary>
        /// <param name="id">Is the ID of sensor</param>
        /// <param name="coordinates">Is the address of the sensor</param>
        /// <param name="numberOfActiovations">Is the number of times the sensor has been activated</param>
        /// <param name="sensorClient">Is the UdpClient used for connecting to the sensor</param>
        public MovementSensor(int id,string coordinates, int numberOfActiovations, UdpClient sensorClient)
        {
            ID = id;
            Coordinates = coordinates;
            NumberOfActivations = numberOfActiovations;
            SensorClient = sensorClient;
        }
    }
}
