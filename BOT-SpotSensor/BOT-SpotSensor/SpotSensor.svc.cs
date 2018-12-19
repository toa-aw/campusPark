using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;

namespace BOT_SpotSensor
{
    public class BotService : IBotService
    {
        private XmlDocument doc = new XmlDocument();
        private string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "APP_Data", "ParkinglotB.xml");
        private Random random = new Random();
        private DateTime date;
        private XmlNodeList xmlParkingSpotList;
        private XmlNode nodeParkingSpot;
        private XmlNode nodeParkingSpotStatus;
        private XmlNode nodeBatteryStatus;

        public ParkingSpot GetSpotData()
        {
            SetUp();

            Status status = new Status(nodeParkingSpotStatus["value"].InnerText, date);
            string id = nodeParkingSpot["id"].InnerText;
            string type = nodeParkingSpot["type"].InnerText;
            string name = nodeParkingSpot["name"].InnerText;
            //Todo: .InnerText of something with no text or pass null
            string location = nodeParkingSpot["location"].InnerText;
            int batteryStatus = int.Parse(nodeParkingSpot["batteryStatus"].InnerText);

            ParkingSpot parkingSpotObject = new ParkingSpot(id, type, name, location, status, batteryStatus);

            return parkingSpotObject;
        }

        public string GetSpotString()
        {
            SetUp();
            return nodeParkingSpot.OuterXml;
        }

        public List<ParkingSpot> GetSpotsData()
        {

            doc.Load(path);
            List<ParkingSpot> listSpots = new List<ParkingSpot>();

            xmlParkingSpotList = doc.SelectNodes("/parkinglot/parkingSpot");

            foreach (XmlNode n in xmlParkingSpotList)
            {
                string id = n["id"].InnerText;
                string type = n["type"].InnerText;
                string name = n["name"].InnerText;
                string location = n["location"].InnerText;
                int batteryStatus = int.Parse(n["batteryStatus"].InnerText);
                Status status = new Status(n["status"]["value"].InnerText, DateTime.Parse(n["status"]["timestamp"].InnerText));


                ParkingSpot parkingSpot = new ParkingSpot(id, type, name, location, status, batteryStatus);
                listSpots.Add(parkingSpot);
            }
            return listSpots;
        }

        public string GetSpotsString()
        {
            //Todo: Just this?
            doc.Load(path);
            return doc.OuterXml;
        }

        private void SetUp()
        {
            doc.Load(path);
            xmlParkingSpotList = doc.SelectNodes("/parkinglot/parkingSpot");

            int nodePosition = random.Next(1, xmlParkingSpotList.Count);

            nodeParkingSpot = xmlParkingSpotList.Item(nodePosition);
            nodeParkingSpotStatus = nodeParkingSpot["status"];

            int isfree = nodeParkingSpotStatus["value"].InnerText.CompareTo("free");
            int isOccupied = nodeParkingSpotStatus["value"].InnerText.CompareTo("occupied");

            nodeBatteryStatus = nodeParkingSpot["batteryStatus"];
            int batteryStatus = int.Parse(nodeBatteryStatus.InnerText);

            if (batteryStatus == 0){
                if (isfree == 0)
                {
                    nodeParkingSpotStatus["value"].InnerText = "occupied";
                }
                else if (isOccupied == 0)
                {
                    nodeParkingSpotStatus["value"].InnerText = "free";
                }
            }

            if(random.Next(100) > 95)
            { 
                

                if(batteryStatus == 0)
                {
                    nodeBatteryStatus.InnerText = "1";

                }else if(batteryStatus == 1)
                {
                    nodeBatteryStatus.InnerText = "0";
                }

            }

            date = DateTime.Now;
            nodeParkingSpotStatus["timestamp"].InnerText = date.ToString("yyyy-MM-dd HH:mm:ss");

            doc.Save(path);
        }
    }
}
