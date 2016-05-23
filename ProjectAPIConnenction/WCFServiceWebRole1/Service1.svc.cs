using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /// <summary>
        /// A string that connects the program to the database
        /// </summary>
        private const string myConnectionString =
            "Database=DAT_Adpoim;Data Source=eu-cdbr-azure-north-e.cloudapp.net;User Id=b98d5b0a7ddc13;Password=43d25694";

        // Get All Methods:

        /// <summary>
        /// Gets all ads from the database
        /// </summary>
        /// <returns>Returns a list of all the ads</returns>
        public List<Ads> GetAllAds()
        {
            const string selectAllAds = "select * from ADS";
            var result = new List<Ads>();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(selectAllAds, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var ads = ReadAds(reader);
                                result.Add(ads);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all movement sensors from the database
        /// </summary>
        /// <returns>Returns a list of all the movement sensors</returns>
        public List<MovementSensor> GetAllMovementSensors()
        {
            const string selectAllMovementSensors = "select * from MS";
            var result = new List<MovementSensor>();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(selectAllMovementSensors, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var movementSensor = ReadSensor(reader);
                                result.Add(movementSensor);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all connected ads and movement sensors from the database
        /// </summary>
        /// <returns>Returns a list of all the connected ads and movement sensors</returns>
        public List<MovementSensorToAds> GetAllMovementSensorToAds()
        {
            const string selectMovementSensorToAds = "select * from MSToADS";
            var result = new List<MovementSensorToAds>();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(selectMovementSensorToAds, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var MovementSensorToAds = ReadSensorToAds(reader);
                                result.Add(MovementSensorToAds);
                            }
                        }
                    }
                }
            }
            return result;
        }

        // Get Specific Methods:

        /// <summary>
        /// Gets a specific ad from the database
        /// </summary>
        /// <param name="id">Uses parameter id to look in the database for the id with the same value</param>
        /// <returns>Returns the ad with the same address as the parameter</returns>
        public Ads GetSpecificAd(int id)
        {
            //string realAddress = "";
            //const string selectAllAddress = "select * from ADS";
            //var result = new List<string>();
            //using (var sqlConnection = new MySqlConnection(myConnectionString))
            //{
            //    sqlConnection.Open();
            //    using (var cmd = new MySqlCommand(selectAllAddress, sqlConnection))
            //    {
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.HasRows)
            //            {
            //                while (reader.Read())
            //                {
            //                    var hello = reader.GetString("Address");
            //                    result.Add(hello);
            //                }
            //            }
            //        }
            //    }
            //}
            //foreach (var a in result)
            //{
            //    if (a.Contains(address))
            //    {
            //        realAddress = a;
            //    }
            //}
            var selectAllAds = "select * from ADS where ADS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllAds, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var ads = ReadAds(reader);
                            return ads;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a specific movement sensor from the database
        /// </summary>
        /// <param name="id">Uses parameter id to look in the database for the id with the same value</param>
        /// <returns>Returns the movement sensor with the same address as the parameter</returns>
        public MovementSensor GetSpecificMovementSensor(int id)
        {
            //string realAddress = "";
            //const string selectAllAddress = "select * from ms";
            //var result = new List<string>();
            //using (var sqlConnection = new MySqlConnection(myConnectionString))
            //{
            //    sqlConnection.Open();
            //    using (var cmd = new MySqlCommand(selectAllAddress, sqlConnection))
            //    {
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.HasRows)
            //            {
            //                while (reader.Read())
            //                {
            //                    var hello = reader.GetString("Address");
            //                    result.Add(hello);
            //                }
            //            }
            //        }
            //    }
            //}
            //foreach (var a in result)
            //{
            //    if (a.Contains(address))
            //    {
            //        realAddress = a;
            //    }
            //}
            var selectAllMS = "select * from ms where MS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd2 = new MySqlCommand(selectAllMS, sqlConnection))
                {
                    using (var reader = cmd2.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var MovementSensor = ReadSensor(reader);
                            return MovementSensor;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a specific connected ads and movement sensors from the database
        /// </summary>
        /// <param name="id">Uses parameter id to look in the database for the id with the same value</param>
        /// <returns>Returns the connected ads and movement sensors with the same address as the parameter</returns>
        public MovementSensorToAds GetSpecficMovementSensorToAds(int id)
        {
            //string realAddress = "";
            //const string selectAllAddress = "select * from MSToAds";
            //var result = new List<string>();
            //using (var sqlConnection = new MySqlConnection(myConnectionString))
            //{
            //    sqlConnection.Open();
            //    using (var cmd = new MySqlCommand(selectAllAddress, sqlConnection))
            //    {
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.HasRows)
            //            {
            //                while (reader.Read())
            //                {
            //                    var hello = reader.GetString("ADS_Address");
            //                    result.Add(hello);
            //                }
            //            }
            //        }
            //    }
            //}
            //foreach (var a in result)
            //{
            //    if (a.Contains(address))
            //    {
            //        realAddress = a;
            //    }
            //}
            var selectAllMSAd = "select * from MSToADS where MSToAds_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllMSAd, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var MovementSensorToAds = ReadSensorToAds(reader);
                            return MovementSensorToAds;
                        }
                    }
                }
            }
            return null;
        }

        // Add Methods: 

        /// <summary>
        /// Adds an advertisment to the database
        /// </summary>
        /// <param name="addressOwner">The parameter is the input (advertisment) added to the database</param>
        /// <returns>Returns the added advertisment to make sure it is added</returns>
        public string AddAdvertisment(string addressOwner)
        {
            var splits = addressOwner.Split('.');
            var addAdvertismentString =
                "insert into ADS(address, owner, dateOfExpire) value (@newAddress, @newOwner, @newDateOfExpire)";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(addAdvertismentString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@newAddress", splits[0]);
                    cmd.Parameters.AddWithValue("@newOwner", splits[1]);
                    cmd.Parameters.AddWithValue("@newDateOfExpire", DateTime.Now);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return splits[0] + " " + splits[1];
        }

        /// <summary>
        /// Adds a movement sensor to the database
        /// </summary>
        /// <param name="newSensor">The parameter is the input (movement sensor) added to the database</param>
        /// <returns>Returns the added movement sensor to make sure it is added</returns>
        public MovementSensor AddMovementSensor(MovementSensor newSensor)
        {
            var addSensorString = "insert into MS(address, Activity) value (@newAddress, @newActivity)";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(addSensorString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@newAddress", newSensor.Address);
                    cmd.Parameters.AddWithValue("@newActivity", newSensor.Activity);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newSensor;
        }

        /// <summary>
        /// Adds a connection between ads and movement sensors to the database
        /// </summary>
        /// <param name="newMStoAd">The parameter is the input (connected ads and movement sensor) added to the database</param>
        /// <returns>Returns the added connected ads and movement sensor to make sure it is added</returns>
        public MovementSensorToAds AddMovementSensorToAd(MovementSensorToAds newMStoAd)
        {
            var addSensorString = "insert into MSToADS(MS_ID, ADS_ID) value (@newMsID, @newAdID)";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(addSensorString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@newMsID", newMStoAd.MovementSensorID);
                    cmd.Parameters.AddWithValue("@newAdID", newMStoAd.AdID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newMStoAd;
        }

        // Update Methods:

        /// <summary>
        /// Updates an advertisment in the database
        /// </summary>
        /// <param name="id">Is used to find the advertisment that needs to be updated</param>
        /// <param name="newUpdatedAd">Is the new information you would like to change in the ad</param>
        /// <returns>Returns the advertisment to make sure it is updated</returns>
        public Ads UpdateAdvertisment(int id, Ads newUpdatedAd)
        {
            var updateAd = "UPDATE ADS set Address=@updatedAddress, owner=@updatedOwner, dateOfExpire = @updateddateOfExpire where ADS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(updateAd, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@updatedAddress", newUpdatedAd.Address);
                    cmd.Parameters.AddWithValue("@updatedOwner", newUpdatedAd.Owner);
                    cmd.Parameters.AddWithValue("@updateddateOfExpire", newUpdatedAd.dateOfExpire.Date);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newUpdatedAd;
        }

        /// <summary>
        /// Updates a movement sensor in the database
        /// </summary>
        /// <param name="id">Is used to find the movement sensor that needs to be updated</param>
        /// <param name="newSensor">Is the new information you would like to change in the sensor</param>
        /// <returns>Returns the movement sensor to make sure it is updated</returns>
        public MovementSensor UpdateMSensor(int id, MovementSensor newSensor)
        {
            var updateMs = "UPDATE MS set Address=@updatedAddress, Activity=@updatedActivity where MS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(updateMs, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@updatedAddress", newSensor.Address);
                    cmd.Parameters.AddWithValue("@updatedActivity", newSensor.Activity);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newSensor;
        }

        /// <summary>
        /// Updates a connected movement sensor and advertisment in the database
        /// </summary>
        /// <param name="id">Is used to find the connected movement sensor and advertisment that needs to be updated</param>
        /// <param name="newMsAds">Is the new information you would like to change in the connected movement sensor and advertisment</param>
        /// <returns>Returns the connected movement sensor and advertisment to make sure it is updated</returns>
        public MovementSensorToAds UpdateMsToAd(int id, MovementSensorToAds newMsAds)
        {
            var updateMsAd = "UPDATE MS set MS_ID=@updateMSID, ADS_ID=@updatedADID where MSToAds_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(updateMsAd, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@updateMSID", newMsAds.MovementSensorID);
                    cmd.Parameters.AddWithValue("@updatedADID", newMsAds.AdID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newMsAds;
        }

        // Delete Methods:

        /// <summary>
        /// Deletes a specific advertisment
        /// </summary>
        /// <param name="id">Is used to find the advertisment that needs to be deleted</param>
        public void DeleteSpecificAd(int id)
        {
            var deleteAd = "DELETE from ADS where ADS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(deleteAd, sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a specific movement sensor
        /// </summary>
        /// <param name="id">Is used to find the movement sensor that needs to be deleted</param>
        public void DeleteSpecificSensor(int id)
        {
            var deleteSensor = "DELETE from MS where MS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(deleteSensor, sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a specific connected movement sensor and advertisment
        /// </summary>
        /// <param name="id">Is used to find the connected movement sensor and advertisment that needs to be deleted</param>
        public void DeleteSpecificSensorToAd(int id)
        {
            var deleteSensor = "DELETE from MSToADS where MSToAds_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(deleteSensor, sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Reades data from database

        /// <summary>
        /// Reads the movement sensor data from the database and set it to the right MovementSensor class values
        /// </summary>
        /// <param name="reader">Reads the collumbs in the database</param>
        /// <returns>Returns the movement sensor object with the values of the database MS table</returns>
        private static MovementSensor ReadSensor(IDataRecord reader)
        {
            var address = reader.GetString(1);
            var activity = reader.GetInt32(2);
            var movementSensor = new MovementSensor();
            {
                movementSensor.Address = address;
                movementSensor.Activity = activity;
            }
            return movementSensor;
        }

        /// <summary>
        /// Reads the advertisment data from the database and set it to the right Ads class values
        /// </summary>
        /// <param name="reader">Reads the collumbs in the database</param>
        /// <returns>Returns the advertisment object with the values of the database ADS table</returns>
        private static Ads ReadAds(IDataReader reader)
        {
            var address = reader.GetString(1);
            var owner = reader.GetString(2);
            var dateOfExpire = reader.GetDateTime(3);
            var ads = new Ads();
            {
                
                ads.Address = address;
                ads.Owner = owner;
                ads.dateOfExpire = dateOfExpire;
            }
            return ads;
        }

        /// <summary>
        /// Reads the connected movement sensor and advertisment data from the database and set it to the right MovementSensorToAds class values
        /// </summary>
        /// <param name="reader">Reads the collumbs in the database</param>
        /// <returns>Returns the connected movement sensor and advertisment object with the values of the database MSToAds table</returns>
        private static MovementSensorToAds ReadSensorToAds(IDataReader reader)
        {
            var msId = reader.GetString(1);
            var adId = reader.GetString(2);
            var movementSensorToAds = new MovementSensorToAds();
            {
                movementSensorToAds.MovementSensorID = msId;
                movementSensorToAds.AdID = adId;
            }
            return movementSensorToAds;
        }




        // Potential ekstra below:


        //public List<Location> GetAllLocations()
        //{
        //    const string selectAllLocations = "select * from LOC";
        //    var result = new List<Location>();
        //    using (var sqlConnection = new MySqlConnection(myConnectionString))
        //    {
        //        sqlConnection.Open();

        //        using (var cmd = new MySqlCommand(selectAllLocations, sqlConnection))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var location = ReadLocation(reader);
        //                        result.Add(location);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        //public Location GetSpecificLocation(int id)
        //{
        //    var selectAllLocations = "select * from LOC where LOC_ID=" + id;
        //    using (var sqlConnection = new MySqlConnection(myConnectionString))
        //    {
        //        sqlConnection.Open();
        //        using (var cmd = new MySqlCommand(selectAllLocations, sqlConnection))
        //        {
        //            cmd.Parameters.AddWithValue("@LOC_ID", id);
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    reader.Read();
        //                    var location = ReadLocation(reader);
        //                    return location;
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}
        //private static Location ReadLocation(IDataRecord reader)
        //{
        //    var koordinate = reader.GetString(1);
        //    var location = new Location();
        //    {
        //        location.Koordinates = koordinate;
        //    }

        //    return location;
        //}

        // Get All ID: 
        //public List<int> GetAdID()
        //{
        //    const string selectAllAds = "select * from ADS";
        //    var result = new List<int>();
        //    using (var sqlConnection = new MySqlConnection(myConnectionString))
        //    {
        //        sqlConnection.Open();
        //        using (var cmd = new MySqlCommand(selectAllAds, sqlConnection))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var hello = reader.GetInt32("ADS_ID");
        //                        result.Add(hello);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        //public List<int> GetMovementID()
        //{
        //    const string selectAllMS = "select * from MS";
        //    var result = new List<int>();

        //    using (var sqlConnection = new MySqlConnection(myConnectionString))
        //    {
        //        sqlConnection.Open();
        //        using (var cmd = new MySqlCommand(selectAllMS, sqlConnection))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var hello = reader.GetInt32("MS_ID");
        //                        result.Add(hello);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        //public List<int> GetMovementToAdID()
        //{
        //    const string selectAllMSAD = "select * from MSToADS";
        //    var result = new List<int>();
        //    using (var sqlConnection = new MySqlConnection(myConnectionString))
        //    {
        //        sqlConnection.Open();
        //        using (var cmd = new MySqlCommand(selectAllMSAD, sqlConnection))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var hello = reader.GetInt32("MSToADS_ID");
        //                        result.Add(hello);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

    }
}