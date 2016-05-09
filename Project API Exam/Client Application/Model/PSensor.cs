using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Application.Model
{
    class PSensor
    {
        /// <summary>
        /// Gets the ID of the PSensor. Private setter.
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Gets or sets the coordinates of the PSensor
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// Gets or sets the Sensor1 in the PSensor
        /// </summary>
        public MovementSensor SensorA { get; set; }
        /// <summary>
        /// Gets or sets the Sensor2 in the PSensor
        /// </summary>
        public MovementSensor SensorB { get; set; }

        /// <summary>
        /// A class representing a pair of Movement Sensors
        /// </summary>
        /// <param name="id">Is the ID of the PSensor</param>
        /// <param name="coordinate">Is the address of the PSensor</param>
        /// <param name="sensorA">Is the movement sensor Arrival</param>
        /// <param name="sensorB">Is the movement sensor Bye</param>
        public PSensor(int id ,string coordinate, MovementSensor sensorA, MovementSensor sensorB)
        {
            Coordinates = coordinate;
            SensorA = sensorA;
            SensorB = sensorB;
            ID = id;
        }
    }
}
