using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using RestSharp;
using System.Net;
using SmartPark.Models;

namespace ParkDashboard
{
    public partial class ParksForm : Form
    {

        string baseURI = @"http://localhost:49929/api/parks";

        public ParksForm()
        {
            InitializeComponent();
        }

        private void btnGetAllParks_Click(object sender, EventArgs e)
        {
            var client = new RestClient(baseURI);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            List<Park> lst = jser.Deserialize<List<Park>>(str);

            foreach (Park park in lst)
            {
                string strTemp = "" + park.Id + " " + park.Name;
                listBoxAllParks.Items.Add(strTemp);
            }
        }

        private void btnGetParkInfo_Click(object sender, EventArgs e)
        {
            if (listBoxAllParks.SelectedItem == null)
            {
                MessageBox.Show("Please select a park.");
                return;
            }

            string parkSelected = listBoxAllParks.GetItemText(listBoxAllParks.SelectedItem);
            string[] parkT = parkSelected.Split(' ');

            var client = new RestClient("http://localhost:49929/api/parks/" + parkT[0]);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            Park park = jser.Deserialize<Park>(str);

            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ").Append(park.Id).Append("\r\n");
            sb.Append("Name: ").Append(park.Name).Append("\r\n");
            sb.Append("Description: ").Append(park.Description).Append("\r\n");
            sb.Append("Number Of Spots: ").Append(park.NumberOfSpots).Append("\r\n");
            sb.Append("Operating Hours: ").Append(park.OperatingHours).Append("\r\n");
            sb.Append("Number Of Special Spots: ").Append(park.NumberOfSpecialSpots);
            
            textBoxParkInfo.Text = sb.ToString();

        }

        private void btnGetOccupancyRate_Click(object sender, EventArgs e)
        {
            if (listBoxAllParks.SelectedItem == null)
            {
                MessageBox.Show("Please select a park.");
                return;
            }

            string parkSelected = listBoxAllParks.GetItemText(listBoxAllParks.SelectedItem);
            string[] parkT = parkSelected.Split(' ');

            var client = new RestClient("http://localhost:49929/api/parks/" + parkT[0] + "/occupancy");
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            
            string occupancyRate = jser.Deserialize<string>(str);
            decimal rate = Convert.ToDecimal(occupancyRate);
            occupancyRate = rate.ToString("0.##");
            textBoxOccupancyRate.Text = occupancyRate + "%";
        }

        private void btnParkingSpots_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ParkingSpotsForm().ShowDialog();
            this.Show();           
        }
    }
}
