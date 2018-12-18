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

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) {
            XmlDocument doc = new XmlDocument();
            string connString = ConfigurationManager.ConnectionStrings["ParkSS.Properties.Connection.connStr"].ConnectionString;
            string message = Encoding.UTF8.GetString(e.Message);
            
            

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();

                switch (e.Topic)
                {
                    case "parkingSpots":
                        doc.LoadXml(message);
                        XmlNode node = doc.SelectSingleNode("/parkingSpot");
                        break;
                    case "parkingLots":
                        cmd.CommandText = "SELECT count(*) AS parkings FROM ParkingLots";
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = conn;

                        try
                        {
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                               if((int) reader["parkings"] == 0)
                                {
                                    doc.LoadXml(message);
                                    XmlNodeList parkingLots = doc.SelectNodes("//*");

                                    foreach (XmlNode n in parkingLots)
                                    {

                                    }

                                    cmd.CommandText = "INSERT INTO ParkingLots";
                                    cmd.CommandType = System.Data.CommandType.Text;
                                    cmd.Connection = conn;
                                }
                                reader.Close();       
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break;  
                }

            }


            Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
        }

        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient("127.0.0.1");
            string[] mStrTopicsInfo = { "parkingSpots", "parkingLots" };
            mClient.Connect(Guid.NewGuid().ToString());

            if (!mClient.IsConnected) {
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
    
            if (mClient.IsConnected){
                mClient.Unsubscribe(mStrTopicsInfo);
                //Put this in a button to see notif!
                mClient.Disconnect();
                //Free process and process's resources
            }
        }
    }
}


