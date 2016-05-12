using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Application.Model
{
    /// <summary>
    /// A Class representing an Advertisement.
    /// </summary>
    class Advertisement
    {
        /// <summary>
        /// Gets or sets the coordinates of the advertisement.
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// Gets or sets the owner of the advertisement.
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// Gets or set the expiration date of the advertisement
        /// </summary>
        public DateTime DateOfExpire { get; set; }
        /// <summary>
        /// Gets or sets the list of PSensors the advertisement has or have.
        /// </summary>
        public List<PSensor> PSensors { get; }

        /// <summary>
        /// Creates an Advertisement
        /// </summary>
        /// <param name="coordinates">Is the coordinates of the advertisement</param>
        /// <param name="owner">Is the owner of the advertisement</param>
        public Advertisement(string coordinates, string owner, DateTime dateOfExpire)
        {
            PSensors = new List<PSensor>();
            Coordinates = coordinates;
            Owner = owner;
            DateOfExpire = dateOfExpire;
        }
        /// <summary>
        /// Gets the current number of PSensors the advertisement has.
        /// </summary>
        public int GetPSensorCount => PSensors.Count;
        /// <summary>
        /// Gets the current ID when making a new PSensor.
        /// </summary>
        public int LatestPsId => PSensors.Count + 1;
        /// <summary>
        /// Call this to add a PSensor to the advertisement.
        /// </summary>
        /// <param name="psensor">Is the PSensor that is going to be added</param>
        /// <returns>A bool on wether or not the operation completed. If true it was a success, false the PSensor already exist</returns>
        public bool AddPSensor(PSensor psensor)
        {
            if (PSensors.Contains(psensor))
                return false;

            PSensors.Add(psensor);
            return true;
        }
    }
}
