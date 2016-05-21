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
        private const string myConnectionString =
            "Database=DAT_Adpoim;Data Source=eu-cdbr-azure-north-e.cloudapp.net;User Id=b98d5b0a7ddc13;Password=43d25694";

        // Get All Methods:
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
        public Ads GetSpecificAd(string address)
        {
            string realAddress = "";
            const string selectAllAddress = "select * from ADS";
            var result = new List<string>();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(selectAllAddress, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var hello = reader.GetString("Address");
                                result.Add(hello);
                            }
                        }
                    }
                }
            }
            foreach (var a in result)
            {
                if (a.Contains(address))
                {
                    realAddress = a;
                }
            }
            var selectAllAds = "select * from ADS where Address=@Address";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllAds, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Address", realAddress);
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
        public MovementSensor GetSpecificMovementSensor(string address)
        {
            string realAddress = "";
            const string selectAllAddress = "select * from ms";
            var result = new List<string>();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(selectAllAddress, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var hello = reader.GetString("Address");
                                result.Add(hello);
                            }
                        }
                    }
                }
            }
            foreach (var a in result)
            {
                if (a.Contains(address))
                {
                    realAddress = a;
                }
            }
            var selectAllMS = "select * from ms where Address=@Address";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd2 = new MySqlCommand(selectAllMS, sqlConnection))
                {
                    cmd2.Parameters.AddWithValue("@Address", realAddress);
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
        public MovementSensorToAds GetSpecficMovementSensorToAds(string address)
        {
            string realAddress = "";
            const string selectAllAddress = "select * from MSToAds";
            var result = new List<string>();
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(selectAllAddress, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var hello = reader.GetString("ADS_Address");
                                result.Add(hello);
                            }
                        }
                    }
                }
            }
            foreach (var a in result)
            {
                if (a.Contains(address))
                {
                    realAddress = a;
                }
            }
            var selectAllMSAd = "select * from MSToADS where ADS_Address=@ADS_Address";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(selectAllMSAd, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@ADS_Address", realAddress);
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
            var addSensorString = "insert into MSToADS(MS_Address, ADS_Address) value (@newMsAddress, @newAdAddress)";
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();

                using (var cmd = new MySqlCommand(addSensorString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@newMsAddress", newMStoAd.MovementSensorAddress);
                    cmd.Parameters.AddWithValue("@newAdAddress", newMStoAd.AdAddress);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newMStoAd;
        }

        // Update Methods:
        public Ads UpdateAdvertisment(string oldAddress, Ads newUpdatedAd)
        {
            var updateAd = "UPDATE ADS set  Address=@updatedAddress, owner=@updatedOwner, dateOfExpire = @updateddateOfExpire where Address=" + oldAddress;
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
        public MovementSensor UpdateMSensor(string oldAddress, MovementSensor newSensor)
        {
            var updateMs = "UPDATE MS set Address=@updatedAddress, Activity=@updatedActivity where Address=" + oldAddress;
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
        public MovementSensorToAds UpdateMsToAd(string oldAddress, MovementSensorToAds newMsAds)
        {
            var updateMsAd = "UPDATE MS set MS_Address=@updateMSdAddress, ADS_Address=@updatedADAddress where ADS_Address =" + oldAddress;
            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(updateMsAd, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@updateMSdAddress", newMsAds.MovementSensorAddress);
                    cmd.Parameters.AddWithValue("@updatedADAddress", newMsAds.AdAddress);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return newMsAds;
        }

        // Delete Methods:
        public void DeleteSpecificAd(string address)
        {
            var deleteAd = "DELETE from ADS where Address=" + address;
            var deleteAdToMS = "DELETE from MSToADS where ADS_Address=" + address;
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
        public void DeleteSpecificSensor(string address)
        {
            var deleteSensor = "DELETE from MS where Address=" + address;
            var deleteAdToMS = "DELETE from MSToADS where MS_Address=" + address;

            using (var sqlConnection = new MySqlConnection(myConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new MySqlCommand(deleteSensor, sqlConnection))
                {
                    var cmd2 = new MySqlCommand(deleteAdToMS, sqlConnection);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteSpecificSensorToAd(string address)
        {
            var deleteSensor = "DELETE from MSToADS where ADS_Address=" + address;
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
            var address = reader.GetString(0);
            var activity = reader.GetInt32(1);
            var movementSensor = new MovementSensor();
            {
                movementSensor.Address = address;
                movementSensor.Activity = activity;
            }
            return movementSensor;
        }
        private static Ads ReadAds(IDataReader reader)
        {
            var address = reader.GetString(0);
            var owner = reader.GetString(1);
            var dateOfExpire = reader.GetDateTime(2);
            var ads = new Ads();
            {
                
                ads.Address = address;
                ads.Owner = owner;
                ads.dateOfExpire = dateOfExpire;
            }
            return ads;
        }
        private static MovementSensorToAds ReadSensorToAds(IDataReader reader)
        {
            var msAddress = reader.GetString(1);
            var adAddress = reader.GetString(2);
            var movementSensorToAds = new MovementSensorToAds();
            {
                movementSensorToAds.MovementSensorAddress = msAddress;
                movementSensorToAds.AdAddress = adAddress;
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