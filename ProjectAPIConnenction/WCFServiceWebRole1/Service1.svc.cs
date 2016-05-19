using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private const string myConnectionString =
            "Database=DAT_Adpoim;Data Source=eu-cdbr-azure-north-e.cloudapp.net;User Id=b98d5b0a7ddc13;Password=43d25694";

        // Get All Methods:
        public List<Ads> GetAllAds()
        {
            const string selectAllAds = "select * from ADS";
            var result = new List<Ads>();
            var MovementSensorsToAds = GetAllMovementSensorToAds();

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
                                foreach (
                                    var PS in MovementSensorsToAds.FindAll(x => x.AdID == reader.GetInt32(0)))
                                {
                                    ads.MovementSensor.Add(GetSpecificMovementSensor(PS.MovementSensorID));
                                }

                                result.Add(ads);
                            }
                        }
                    }
                }
            }
            return result;
        }
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
        public Ads GetSpecificAd(int id)
        {
            var selectAllLocations = "select * from ADS where ADS_ID=" + id;
            var MovementSensorsToAds = GetAllMovementSensorToAds();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllLocations, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@ADS_ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var ads = ReadAds(reader);
                            foreach (var PS in MovementSensorsToAds.FindAll(x => x.AdID == reader.GetInt32(0)))
                            {
                                ads.MovementSensor.Add(GetSpecificMovementSensor(PS.MovementSensorID));
                            }
                            return ads;
                        }
                    }
                }
            }
            return null;
        }
        public MovementSensor GetSpecificMovementSensor(int id)
        {
            var selectAllLocations = "select * from MS where MS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllLocations, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@MS_ID", id);
                    using (var reader = cmd.ExecuteReader())
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
        public MovementSensorToAds GetSpecficMovementSensorToAds(int id)
        {
            var selectAllLocations = "select * from MSToADS where MSToADS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllLocations, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@MSToADS_ID", id);
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
        public Ads AddAdvertisment(Ads newAdd)
        {
            var addAdvertismentString =
                "insert into ADS(address, owner, dateOfExpire) value (@newAddress, @newOwner, @newDateOfExpire)";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(addAdvertismentString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@newAddress", newAdd.Address);
                    cmd.Parameters.AddWithValue("@newOwner", newAdd.Owner);
                    cmd.Parameters.AddWithValue("@newDateOfExpire", newAdd.dateOfExpire);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newAdd;
        }
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

        // Delete Methods:
        public void DeleteSpecificAd(int id)
        {
            var deleteAd = "DELETE from ADS where ADS_ID=" + id;
            var deleteAdToMS = "DELETE from MSToADS where ADS_ID=" + id;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(deleteAd, sqlConnection))
                {
                    var cmd2 = new MySqlCommand(deleteAdToMS, sqlConnection);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
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
        public void DeleteSpecificSensorToAd(int id)
        {
            var deleteSensor = "DELETE from MSToADS where MSToADS_ID=" + id;
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
                ads.MovementSensor = new List<MovementSensor>();
            }
            return ads;
        }
        private static MovementSensorToAds ReadSensorToAds(IDataReader reader)
        {
            var msID = reader.GetInt32(1);
            var adID = reader.GetInt32(2);
            var movementSensorToAds = new MovementSensorToAds();
            {
                movementSensorToAds.MovementSensorID = msID;
                movementSensorToAds.AdID = adID;
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
    }
}