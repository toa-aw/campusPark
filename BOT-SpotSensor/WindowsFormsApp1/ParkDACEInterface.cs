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

namespace WindowsFormsApp1
{
    public partial class ParkDACEInterface : Form
    {
        //private Timer timer1;
        private List<ParkingSpot> parkingSpotsList;
        private BackgroundWorker bw = new BackgroundWorker();
        private ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;
        private List<string> spotsDLL = new List<string>();

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            dll.Initialize(NewSensorValueFunction, 50);
        }


        public ParkDACEInterface()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(DoWork);

            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            bw.RunWorkerAsync();
        }

        public void NewSensorValueFunction(string str)
        {
            //To have access to the listbox that is in other thread (Form)
            this.BeginInvoke((MethodInvoker)delegate
            {
                txtBoxRecievedData.Text += str + Environment.NewLine;
                spotsDLL.Add(str);
                dll.Stop();
            });
        }

        public void readConfigFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(textBoxXmlFile.Text);

            XmlElement delayMs = doc.DocumentElement;

            txtBoxFormatedData.Text = delayMs.GetAttribute("refreshRate");

            XmlNodeList lst = doc.SelectNodes("//provider/connectionType");
            foreach (XmlNode node in lst)
            {
                switch (node.InnerText)
                {
                    case "DLL":
                        foreach (string item in spotsDLL)
                        {
                            string[] spot = item.Split(';');
                            //listBox1.Items.Add(spot[1]);
                        }
                        
                        break;
                    case "SOAP":
                        using (BotServiceClient service = new BotServiceClient())
                        {
                            //XmlDocument doc2 = new XmlDocument();
                            //string xml = service.GetSpotsString();
                            //doc.LoadXml(xml);
                            //XmlNodeList spots = doc.SelectNodes("/parkinglot/parkingSpot");
                            //foreach (XmlNode item in spots)
                            //{
                            //    listBox1.Items.Add(item["name"].InnerText);
                            //}
                            //List<ParkingSpot> parkingSpots = service.GetSpotsData().ToList();
                            //foreach (ParkingSpot spot in parkingSpots)
                            //{
                            //    listBox1.Items.Add(spot);
                            //}
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxXmlFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnFormatData_Click(object sender, EventArgs e)
        {
            readConfigFile();
        }
    }
}
