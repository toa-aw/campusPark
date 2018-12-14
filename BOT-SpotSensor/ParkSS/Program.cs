using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkSS
{
    class Program
    {

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) {
             Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
        }

        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient(IPAddress.Parse("192.168.237.155")); string[] mStrTopicsInfo = { "news", "complaints" }; mClient.Connect(Guid.NewGuid().ToString()); if (!mClient.IsConnected) { Console.WriteLine("Error connecting to message broker..."); return; }//Specify events we are interest on//New Msg ArrivedmClient.MqttMsgPublishReceived+= client_MqttMsgPublishReceived;//Subscribe to topicsbyte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};//QoS–depends on the topics numbermClient.Subscribe(mStrTopicsInfo, qosLevels);Console.ReadKey();if (mClient.IsConnected){mClient.Unsubscribe(mStrTopicsInfo); //Put this in a button to see notif!mClient.Disconnect(); //Free process and process's resources}}}}

        }
}
