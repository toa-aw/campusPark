using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceRefParkingSpotBot;
using System.Xml;
using System.Xml.Schema;
using BOT_SpotSensor;
using System.IO;
using System.Collections;
using uPLibrary.Networking.M2Mqtt;
using System.Threading;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class ParkDACEInterface : Form
    {
        private System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();

        const String STR_CHANNEL_NAME = "parkingSpots";

        //MqttClient m_cClient = new MqttClient(IPAddress.Parse("192.168.237.155"));
        MqttClient m_cClient;
        string[] m_strTopicsInfo = { STR_CHANNEL_NAME };


        XmlDocument parkingSpotsDoc = new XmlDocument();
        private BackgroundWorker bw = new BackgroundWorker();
        private ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;

        private bool makeResquest = true;

        Hashtable spotsLocations = new Hashtable();

        public ParkDACEInterface()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, EventArgs e)
        {
            runSoapBot();
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            readConfigFile();
        }

        public void NewSensorValueFunction(string str)
        {
            //To have access to the listbox that is in other thread (Form)
            this.BeginInvoke((MethodInvoker)delegate
            {
                XmlElement newspot = null;
                string[] spotData = str.Split(';');
                for (int i = 0; i < spotData.Length; i++)
                {
                    txtBoxRecievedData.Text += spotData[i] + Environment.NewLine;
                }

                switch (spotData[3])
                {
                    case "0":
                        newspot = createParkingSpot(parkingSpotsDoc, spotData[0], "ParkingSpot", spotData[1], spotsLocations[spotData[1]].ToString(), "free", spotData[2], spotData[4]);
                        sendSpotData(newspot);
                        break;
                    case "1":
                        newspot = createParkingSpot(parkingSpotsDoc, spotData[0], "ParkingSpot", spotData[1], spotsLocations[spotData[1]].ToString(), "occupied", spotData[2], spotData[4]);
                        sendSpotData(newspot);
                        break;
                    default:
                        break;
                }

                listBox1.Items.Add(newspot.OuterXml);
            });
        }

        public void readConfigFile()
        {
            XmlDocument configDoc = new XmlDocument();
            string path = "ParkingNodesConfig.xml";
            configDoc.Load(path);

            XmlElement configRootElem = configDoc.DocumentElement;

            string unit = configRootElem.GetAttribute("units");
            string delay = configRootElem.GetAttribute("refreshRate");

            XmlNode lst = configDoc.SelectSingleNode("//provider[connectionType='DLL']");

            XmlElement connectionType = lst["connectionType"];
            XmlElement parkInfo = lst["parkInfo"];
            int numberOfSpots = 0;

            numberOfSpots = int.Parse(parkInfo["numberOfSpots"].InnerText);
            loadExcelData(parkInfo["geoLocationFile"].InnerText, numberOfSpots);

            switch (unit)
            {
                case "seconds":
                    int delaysec = int.Parse(delay) * 1000;
                    dll.Initialize(NewSensorValueFunction, delaysec);
                    break;
                case "minutes":
                    int delaymin = int.Parse(delay) * 60000;
                    dll.Initialize(NewSensorValueFunction, delaymin);
                    break;
                default:
                    break;
            }
        }

        public void runSoapBot()
        {
            XmlDocument configDoc = new XmlDocument();
            string path = "ParkingNodesConfig.xml";
            configDoc.Load(path);

            XmlElement configRootElem = configDoc.DocumentElement;

            string unit = configRootElem.GetAttribute("units");
            string delay = configRootElem.GetAttribute("refreshRate");

            XmlNode lst = configDoc.SelectSingleNode("//provider[connectionType='SOAP']");

            XmlElement connectionType = lst["connectionType"];
            XmlElement parkInfo = lst["parkInfo"];
            int numberOfSpots = 0;

            using (BotServiceClient service = new BotServiceClient())
            {
                
                numberOfSpots = int.Parse(parkInfo["numberOfSpots"].InnerText);
                loadExcelData(parkInfo["geoLocationFile"].InnerText, numberOfSpots);

                XmlDocument botParkingSpotsDoc = new XmlDocument();
                string xml = service.GetSpotString();
                botParkingSpotsDoc.LoadXml(xml);

                XmlNode spotBot = botParkingSpotsDoc.SelectSingleNode("/parkingSpot");

                XmlNode status = spotBot["status"];
                string location = spotsLocations[spotBot["name"].InnerText].ToString();

                XmlElement spot = createParkingSpot(parkingSpotsDoc, spotBot["id"].InnerText, spotBot["type"].InnerText, spotBot["name"].InnerText, location, status["value"].InnerText, status["timestamp"].InnerText, spotBot["batteryStatus"].InnerText);
                sendSpotData(spot);
                listBox2.BeginInvoke((MethodInvoker)delegate
                {
                    listBox2.Items.Add(spot.OuterXml);
                });

            }
        }

        public void loadExcelData(string filename, int linesToRead)
        {
            int i = 0;
            int range = linesToRead + 5;
            List<string> parkIds = ExcelLib.ExcelHandler.ReadNxMCells(filename, "A6", "A" + range);
            List<string> spotLocations = ExcelLib.ExcelHandler.ReadNxMCells(filename, "B6", "B" + range);

            foreach (string key in parkIds)
            {
                if (!spotsLocations.Contains(key))
                {
                    spotsLocations.Add(key, spotLocations[i]);
                    i++;
                }
            }

        }

        public void sendSpotData(XmlElement pakingSpot)
        {
            m_cClient = new MqttClient("127.0.0.1");
            m_cClient.Connect(Guid.NewGuid().ToString());
            if (!m_cClient.IsConnected)
            {
                MessageBox.Show("Error connecting to message broker...");
                return;
            }
            m_cClient.Publish(STR_CHANNEL_NAME, Encoding.UTF8.GetBytes(pakingSpot.OuterXml));
        }

        private void btnFormatData_Click(object sender, EventArgs e)
        {
            //SetTimer();
            //dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            //bw.RunWorkerAsync();
        }

        public XmlElement createParkingSpot(XmlDocument doc, string parkid, string spotType, string spotname, string spotlocation, string spotstatusvalue, string spotTimestamp, string spotbatterystatus)
        {
            XmlElement parkingSpot = doc.CreateElement("parkingSpot");

            XmlElement id = doc.CreateElement("id");
            id.InnerText = parkid;
            XmlElement type = doc.CreateElement("type");
            type.InnerText = spotType;
            XmlElement name = doc.CreateElement("name");
            name.InnerText = spotname;
            XmlElement location = doc.CreateElement("location");
            location.InnerText = spotlocation;
            XmlElement status = doc.CreateElement("status");
            XmlElement value = doc.CreateElement("value");
            value.InnerText = spotstatusvalue;
            XmlElement timestamp = doc.CreateElement("timestamp");
            timestamp.InnerText = spotTimestamp;
            status.AppendChild(value);
            status.AppendChild(timestamp);
            XmlElement batteryStatus = doc.CreateElement("batteryStatus");
            batteryStatus.InnerText = spotbatterystatus;

            parkingSpot.AppendChild(id);
            parkingSpot.AppendChild(type);
            parkingSpot.AppendChild(name);
            parkingSpot.AppendChild(location);
            parkingSpot.AppendChild(status);
            parkingSpot.AppendChild(batteryStatus);

            return parkingSpot;
        }

        private void Form1_FormLoad(object sender, EventArgs e)
        {
            aTimer.Start();
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            bw.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dll.Stop();
            aTimer.Stop();
            aTimer.Dispose();
            makeResquest = false;
            if (m_cClient.IsConnected)
            {
                m_cClient.Unsubscribe(m_strTopicsInfo); //Put this in a button to see notif!
                m_cClient.Disconnect(); //Free process and process's resources
            }
        }
    }
}
