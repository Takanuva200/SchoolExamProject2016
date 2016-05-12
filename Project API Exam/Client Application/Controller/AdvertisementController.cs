using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Client_Application.Model;

namespace Client_Application.Controller
{
    /// <summary>
    /// A class designed to control the available advertisements.
    /// </summary>
    class AdvertisementController
    {
        private List<Advertisement> advertisementCatalog;
        /// <summary>
        /// Gets the current advertisement catalog. Private set.
        /// </summary>
        public List<Advertisement> AdvertisementCatalog
        {
            get { return advertisementCatalog; }
            private set { advertisementCatalog = value; }
        }
        /// <summary>
        /// Creates an AdvertisementController. It will make a new or if available populate, advertisementCatalog
        /// </summary>
        public AdvertisementController()
        {
            if (advertisementCatalog == null)
            {
                try
                {
                    //TODO: Connect the client to the webservice.
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    advertisementCatalog = new List<Advertisement>();
                }
            }  
        }
        /// <summary>
        /// Call this to create and add an advertisement.
        /// </summary>
        /// <param name="coords">Is the coordinates of the advertisement</param>
        /// <param name="owner">Is the owner of the advertisement</param>
        /// <returns></returns>
        internal bool CreateAdvertisement(string coords, string owner, DateTime dateOfExpire)
        {
            var newAd = new Advertisement(coords, owner, dateOfExpire);
            if (advertisementCatalog.Contains(newAd))
                return false;

            advertisementCatalog.Add(newAd);
            return true;

        }

        /// <summary>
        /// Gets the latest ID for the Advertisement.
        /// </summary>
        public int LatestAdID => advertisementCatalog.Count + 1;

        /// <summary>
        /// Adds a PSensor to the current selected Advertisement.
        /// </summary>
        /// <param name="id1">Is Automatically set to 1</param>
        /// <param name="sACoords">Coordinates of SensorA</param>
        /// <param name="list1">A list contained the struct Activations</param>
        /// <param name="udpClient1">UdpClient for SensorA</param>
        /// <param name="id2">Is Automatically set to 2</param>
        /// <param name="sBCoords">Coordinates of SensorB</param>
        /// <param name="list2">A list contained the struct Activations</param>
        /// <param name="udpClient2">UdpClient for SensorB</param>
        /// <param name="currentSelectedAd">IS the current selected ad</param>
        internal void AddSensorsToAd(int id1, string sACoords, List<Activations> list1, UdpClient udpClient1, int id2, string sBCoords, List<Activations> list2, UdpClient udpClient2, Advertisement currentSelectedAd)
        {
            var sensorA = new MovementSensor(LatestAdID, sACoords, new List<Activations>(), udpClient1);
            var sensorB = new MovementSensor(LatestAdID, sBCoords, new List<Activations>(), udpClient2);
            var psensor = new PSensor(currentSelectedAd.LatestPsId, sACoords, sensorA, sensorB);
            currentSelectedAd.AddPSensor(psensor);
        }
    }
}
