using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.SpotService;

namespace WindowsFormsApp1
{
    public partial class ParkDACEInterface : Form
    {
        //private Timer timer1;
        private List<ParkingSpot> parkingSpotsList;
        private BackgroundWorker bw = new BackgroundWorker();
        private ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            dll.Initialize(NewSensorValueFunction, 3000);
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
                
            });
        }
    }
}
