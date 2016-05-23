using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAPIWebservice" in both code and config file together.
    [ServiceContract]
    public interface IAPIWebservice
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "allmovementssensors/")]

        List<MovementSensor> GetAllMovementSensors();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "allads/")]

        List<Ads> GetAllAds();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "allmovementstoads/")]

        List<MovementSensorToAds> GetAllMovementSensorToAds();

        //[OperationContract]
        //Location GetSpecificLocation(int id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "allsensors/{id}/")]

        MovementSensor GetSpecificMovementSensor(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "ads/{id}/")]

        Ads GetSpecificAd(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "movementsensorstoads/{id}/")]

        MovementSensorToAds GetSpecficMovementSensorToAds(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "ads/{id}/")]

        void DeleteSpecificAd(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "sensors/{id}")]

        void DeleteSpecificSensor(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "sensorstoad/{id}/")]

        void DeleteSpecificSensorToAd(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "addads/{addressOwner}/")]

        string AddAdvertisment(string addressOwner);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "addsensor/")]

        MovementSensor AddMovementSensor(MovementSensor newSensor);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "sensortoads/")]

        MovementSensorToAds AddMovementSensorToAd(MovementSensorToAds newMStoAd);

        //[OperationContract]
        //List<int> GetAdID();

        //[OperationContract]
        //List<int> GetMovementID();

        //[OperationContract]
        //List<int> GetMovementToAdID();

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "ads/{id}/")]

        Ads UpdateAdvertisment(string id, Ads updatedAd);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "sensor/{id}/")]

        MovementSensor UpdateMSensor(string id, MovementSensor newSensor);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "updatetoad/{id}/")]

        MovementSensorToAds UpdateMsToAd(string id, MovementSensorToAds newMsAds);








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
        //[DataMember]
        //public int ID { get;}

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int Activity { get; set; }
    }

    [DataContract]
    public class Ads
    {
        //[DataMember]
        //public int ID { get;}

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Owner { get; set; }

        [DataMember]
        public DateTime dateOfExpire { get; set; }



        //[DataMember]
        //public int locationID { get; set; }

    }

    [DataContract]
    public class MovementSensorToAds
    {
        //[DataMember]
        //public int ID { get; set; }

        [DataMember]
        public string MovementSensorID { get; set; }

        [DataMember]
        public string AdID { get; set; }
    }
}
