using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Configuration;

namespace ParkSS
{


    public class ParkSS
    {

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            //string connString = ConfigurationManager.ConnectionStrings["ParkSS.Properties.Connection.connStr"].ConnectionString;
            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'D:\T1819\IS\Practica\Campus Park\campusPark\BOT-SpotSensor\ParkSS\ParkingSpots.mdf'; Integrated Security = True";
            string message = Encoding.UTF8.GetString(e.Message);

            Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);

            switch (e.Topic)
                {
                    case "parkingSpots":
                        InsertParkingSpot(connString, message);
                        break;

                    case "parkingLots":
                        InsertParkingLot(connString, message);
                        break;
                }
        }

        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient("127.0.0.1");
            string[] mStrTopicsInfo = { "parkingSpots", "parkingLots" };
            mClient.Connect(Guid.NewGuid().ToString());

            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }

            //Specify events we are interest on//New Msg Arrived
            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            //Subscribe to topics
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};

            //QoS–depends on the topics number
            mClient.Subscribe(mStrTopicsInfo, qosLevels);
            Console.ReadKey();

            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(mStrTopicsInfo);
                //Put this in a button to see notif!
                mClient.Disconnect();
                //Free process and process's resources
            }
        }


        private static void InsertParkingSpot(string connString, string data)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNode parkingSpot = doc.SelectSingleNode("//parkingSpot");
            DateTime lastUpdated = DateTime.Parse(parkingSpot["status"]["timestamp"].InnerText);
            int lines = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand {
                    CommandText = "SELECT COUNT(*) FROM ParkingSpotsInfo ps JOIN ParkingLots pl ON pl.Id = ps.ParkingLotId WHERE UPPER(ps.Name) = UPPER(@name) " +
                    "AND UPPER(pl.Name) = UPPER(@parkingLot)",
                    CommandType = System.Data.CommandType.Text,
                    Connection = conn
                };
                cmd.Parameters.AddWithValue("@name", parkingSpot["name"].InnerText);
                cmd.Parameters.AddWithValue("@parkingLot", parkingSpot["id"].InnerText);

                try
                {
                    Int32 spotExists = (Int32)cmd.ExecuteScalar();

                    if (spotExists == 0)
                    {
                        cmd = new SqlCommand {
                            CommandText = "INSERT INTO ParkingSpotsInfo (Name, ParkingLotId, Location, Status, LastUpdated, BatteryStatus) " +
                            "VALUES (@name, (SELECT Id FROM ParkingLots WHERE UPPER(Name) = UPPER(@parkingLot)), @location, @status, @lastUpdated, @batteryStatus)",
                            CommandType = System.Data.CommandType.Text,
                            Connection = conn
                        };

                        cmd.Parameters.AddWithValue("@name", parkingSpot["name"].InnerText);
                        cmd.Parameters.AddWithValue("@parkingLot", parkingSpot["id"].InnerText);
                        cmd.Parameters.AddWithValue("@location", parkingSpot["location"].InnerText);
                        cmd.Parameters.AddWithValue("@status", parkingSpot["status"]["value"].InnerText);
                        cmd.Parameters.AddWithValue("@lastUpdated", lastUpdated);
                        cmd.Parameters.AddWithValue("@batteryStatus", int.Parse(parkingSpot["batteryStatus"].InnerText));

                        lines = cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted" + lines.ToString() + "into ParkingSpotsInfo");
                    }
                    else
                    {
                        cmd = new SqlCommand
                        {
                            CommandText = "UPDATE ParkingSpotsInfo SET Status = @status, LastUpdated = @lastUpdated,  BatteryStatus = @batteryStatus " +
                            "WHERE UPPER(Name) = UPPER(@name) AND ParkingLotId = (SELECT Id FROM ParkingLots WHERE UPPER(Name) = UPPER(@parkingLot))",
                            CommandType = System.Data.CommandType.Text,
                            Connection = conn
                        };
                        cmd.Parameters.AddWithValue("@name", parkingSpot["name"].InnerText);
                        cmd.Parameters.AddWithValue("@parkingLot", parkingSpot["id"].InnerText);
                        cmd.Parameters.AddWithValue("@status", parkingSpot["status"]["value"].InnerText);
                        cmd.Parameters.AddWithValue("@lastUpdated", lastUpdated);
                        cmd.Parameters.AddWithValue("@batteryStatus", int.Parse(parkingSpot["batteryStatus"].InnerText));

                        lines = cmd.ExecuteNonQuery();
                        Console.WriteLine("Updated" + lines.ToString() + "into ParkingSpotsInfo");
                    }

                    cmd = new SqlCommand
                    {
                        CommandText = "INSERT INTO SpotsHistory (Date, ParkingSpotId, SpotStatus, BatteryStatus) " +
                        "VALUES (@date, (SELECT Id FROM ParkingSpotsInfo WHERE UPPER(@name) = UPPER(Name)), @status, @batteryStatus)",
                        CommandType = System.Data.CommandType.Text,
                        Connection = conn
                    };

                    cmd.Parameters.AddWithValue("@name", parkingSpot["name"].InnerText);
                    cmd.Parameters.AddWithValue("@status", parkingSpot["status"]["value"].InnerText);
                    cmd.Parameters.AddWithValue("@date", lastUpdated);
                    cmd.Parameters.AddWithValue("@batteryStatus", int.Parse(parkingSpot["batteryStatus"].InnerText));

                    lines = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted" + lines.ToString() + "into SpotsHistory");
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public static void InsertParkingLot(string connString, string data)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNodeList parkingLotsXml = doc.SelectNodes("//parkingLot");

            List<string> parkingLots = new List<string>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT Name FROM ParkingLots",
                    CommandType = System.Data.CommandType.Text,
                    Connection = conn
                };

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            parkingLots.Add(reader.GetString(0));
                        }

                    reader.Close();

                        foreach (XmlNode n in parkingLotsXml)
                        {
                            if (!parkingLots.Contains(n["id"].InnerText))
                            {
                            cmd = new SqlCommand
                            {
                                CommandText = "INSERT INTO ParkingLots (Name, Description, NumberOfSpots, OpeningHours, NumberOfSpecialSpots) " +
                                "VALUES (@name, @description, @numberOfSpots, @openingHours, @numberOfSpecialSpots)",
                                CommandType = System.Data.CommandType.Text,
                                Connection = conn
                        };

                                cmd.Parameters.AddWithValue("@name", n["id"].InnerText);
                                cmd.Parameters.AddWithValue("@description", n["description"].InnerText);
                                cmd.Parameters.AddWithValue("@numberOfSpots", int.Parse(n["numberOfSpots"].InnerText));
                                cmd.Parameters.AddWithValue("@openingHours", n["operatingHours"].InnerText);
                                cmd.Parameters.AddWithValue("@numberOfSpecialSpots", int.Parse(n["numberOfSpecialSpots"].InnerText));
                             
                                int lines = cmd.ExecuteNonQuery();
                            Console.WriteLine("Inserted" + lines.ToString() + "into ParkingLots");
                        }
                        }
                    Console.WriteLine("ParkingLot table is up to date.");
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
    }
}


