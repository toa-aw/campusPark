using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BOT_SpotSensor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBotService
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<ParkingSpot> GetSpotsData();

        [OperationContract]
        ParkingSpot GetSpotData();

        [OperationContract]
        String GetSpotString();

        [OperationContract]
        String GetSpotsString(); 
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ParkingSpot
    {
        [DataMember]
        public string id;

        [DataMember]
        public string type;

        [DataMember]
        public string name;

        [DataMember]
        public string locaction;

        [DataMember]
        public Status status;

        [DataMember]
        public int batteryStatus;

        public ParkingSpot()
        {
        }

        public ParkingSpot(string id, string type, string name, string locaction, Status status, int batteryStatus)
        {
            this.id = id;
            this.type = type;
            this.name = name;
            this.locaction = locaction;
            this.status = status;
            this.batteryStatus = batteryStatus;
        }

        [DataMember]
        public string StringId
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string StringType
        {
            get { return type; }
            set { type = value; }
        }

        [DataMember]
        public string StringName
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string StringLocation
        {
            get { return locaction; }
            set { locaction = value; }
        }

        [DataMember]
        public Status StatusStatus
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public int IntegerBatteryStatus
        {
            get { return batteryStatus; }
            set { batteryStatus = value; }
        }
    }

    [DataContract]
    public class Status
    {
        [DataMember]
        public string value;

        [DataMember]
        public DateTime timeStamp;

        public Status(string value, DateTime timeStamp)
        {
            this.value = value;
            this.timeStamp = timeStamp;
        }
    }
}
