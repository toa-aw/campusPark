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
        private Timer timer1;
        private List<ParkingSpot> parkingSpotsList;

        public ParkDACEInterface()
        {
            InitializeComponent();
            InitTimer();
        }

        
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (SpotService.BotServiceClient service = new SpotService.BotServiceClient())
            {
                parkingSpotsList = service.GetSpots().ToList();
                
            }
        }

    }
}
