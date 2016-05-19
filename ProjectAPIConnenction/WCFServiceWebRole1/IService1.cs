using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //List<Location> GetAllLocations();

        [OperationContract]
        List<MovementSensor> GetAllMovementSensors();

        [OperationContract]
        List<Ads> GetAllAds();

        [OperationContract]
        List<MovementSensorToAds> GetAllMovementSensorToAds();

        //[OperationContract]
        //Location GetSpecificLocation(int id);

        [OperationContract]
        MovementSensor GetSpecificMovementSensor(int id);

        [OperationContract]
        Ads GetSpecificAd(int id);

        [OperationContract]
        MovementSensorToAds GetSpecficMovementSensorToAds(int id);

        [OperationContract]
        void DeleteSpecificAd(int id);

        [OperationContract]
        void DeleteSpecificSensor(int id);

        [OperationContract]
        void DeleteSpecificSensorToAd(int id);

        [OperationContract]
        Ads AddAdvertisment(Ads newAdd);

        [OperationContract]
        MovementSensor AddMovementSensor(MovementSensor newSensor);

        [OperationContract]
        MovementSensorToAds AddMovementSensorToAd(MovementSensorToAds newMStoAd);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

   // [DataContract]
    //public class Location
    //{
    //    [DataMember]
    //    public string Koordinates { get; set; }
        
    //}

    [DataContract]
    public class MovementSensor
    {
        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int Activity { get; set; }
    }

    [DataContract]
    public class Ads
    {
        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Owner { get; set; }

        [DataMember]
        public DateTime dateOfExpire { get; set; }

        //[DataMember]
        //public int locationID { get; set; }

        [DataMember]
        public List<MovementSensor> MovementSensor { get; set; }
    }

    [DataContract]
    public class MovementSensorToAds
    {
        public int MovementSensorID { get; set; }
        public int AdID { get; set; }
    }
}
