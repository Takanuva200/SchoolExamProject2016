using System;
using System.Collections.Generic;
using System.Linq;
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
            GetAdvertisementCatalog();
        }

        /// <summary>
        /// Sets the AdvertisementCatalog.
        /// </summary>
        private void GetAdvertisementCatalog()
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
        /// Gets the latest ID for the Advertisement.
        /// </summary>
        public int LatestAdID => advertisementCatalog.Count+1;

        /// <summary>
        /// Call this method to add an advertisement to the catalog.
        /// </summary>
        /// <param name="newAd">The new advertisement that is going to be added</param>
        /// <returns> A bool based on the success. True if it succeeded, false if the catalog already contains an identical advertisement</returns>
        public bool AddCreateAdvertisement(Advertisement newAd)
        {
            if (advertisementCatalog.Contains(newAd))
                return false;
            advertisementCatalog.Add(newAd);
            return true;
        }

    }
}
