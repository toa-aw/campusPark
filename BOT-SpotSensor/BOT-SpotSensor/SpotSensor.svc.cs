using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace BOT_SpotSensor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BotService : IBotService
    {
        public List<ParkingSpot> GetSpots()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("add path!");

            List<ParkingSpot> listSpots = new List<ParkingSpot>();

            XmlNodeList xmlSpotList = doc.SelectNodes("//parkingspots");

            foreach (XmlNode n in xmlSpotList)
            {
                string id = n["id"].InnerText;
                string type = n["type"].InnerText;
                string name = n["name"].InnerText;
                string location = n["location"].InnerText;
                int batteryStatus = int.Parse(n["batteryStatus"].InnerText);
                Status status = new Status(n["status"]["batteryStatus"].InnerText, DateTime.Parse(n["status"]["timestamp"].InnerText));


                ParkingSpot parkingSpot = new ParkingSpot(id, type, name, location, status, batteryStatus);
                listSpots.Add(parkingSpot);
            }
            return listSpots;
        }
    }
}
