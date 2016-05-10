using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Application.Model
{
    /// <summary>
    /// A class representing a pair of Movement Sensors.
    /// </summary>
    class PSensor
    {
        /// <summary>
        /// Gets the ID of the PSensor. Private setter..
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Gets or sets the coordinates of the PSensor
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// Gets or sets the Sensor Arrival in the PSensor
        /// </summary>
        public MovementSensor SensorA { get; set; }
        /// <summary>
        /// Gets or sets the Sensor Bye in the PSensor.
        /// </summary>
        public MovementSensor SensorB { get; set; }

        /// <summary>
        /// Creates a PSensor The sensors should be assigned so the SensorA is activated and then afterwards SensorB for the correct count.
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
