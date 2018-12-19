using RestSharp;
using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ParkDashboard
{
    public partial class ParkingSpotsForm : Form
    {
        string baseURI = @"http://localhost:49929/api/parkingSpots";

        public ParkingSpotsForm()
        {
            InitializeComponent();
        }

        private void btnGetAllSpotsForAMoment_Click(object sender, EventArgs e)
        {
            listBoxAllSpots.Items.Clear();
            string parkId = textBoxPark.Text;

            if (parkId.Length == 0)
            {
                MessageBox.Show("Please specify the id of the park.");
                return;
            }
            JavaScriptSerializer jser = new JavaScriptSerializer();

            string timePicker = dateTimePickerSpecificDate.Text;
            string[] dateParts = timePicker.Split(' ');
            string date = dateParts[0];
            string time = dateParts[1];

            string formatedTime = time.Replace(':', 't');

            var client = new RestClient(baseURI + "/park/" + parkId + "/" + date + "/" + formatedTime);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);

            string str = response.Content.ToString();

            List<ParkingSpot> lst = jser.Deserialize<List<ParkingSpot>>(str);

            if (lst.Count() == 0)
            {
                MessageBox.Show("This park does not has spots.");
                return;
            }

            foreach (ParkingSpot spot in lst)
            {
                string strTemp = "Id: " + spot.Id + " Name: " + spot.Name + " Status: " + spot.Status + " Date: " + spot.Timestamp;
                listBoxAllSpots.Items.Add(strTemp);
            }
        }

        private void btnGetSpotsStatusInAPeriod_Click(object sender, EventArgs e)
        {
            listBoxAllSpots.Items.Clear();
            string parkId = textBoxPark.Text;

            if (parkId.Length == 0)
            {
                MessageBox.Show("Please specify the id of the park.");
                return;
            }

            string timePicker = dateTimePickerStartDate.Text;

            string[] moment = timePicker.Split(' ');

            string date = moment[0];
            string time = moment[1];

            string formatTime = time.Replace(':', 't');

            string timePicker2 = dateTimePickerEndDate.Text;

            string[] moment2 = timePicker2.Split(' ');

            string date2 = moment2[0];
            string time2 = moment2[1];

            string formatTime2 = time2.Replace(':', 't');

            var client = new RestClient(baseURI + "/park/" + parkId + "/" + date + "/" + formatTime + "/" + date2 + "/" + formatTime2);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            List<ParkingSpot> lst = jser.Deserialize<List<ParkingSpot>>(str);

            if (lst.Count() == 0)
            {
                MessageBox.Show("This park does not has spots.");
                return;
            }

            foreach (ParkingSpot spot in lst)
            {
                string strTemp = "Id: " + spot.Id + " Name: " + spot.Name + " Status: " + spot.Status + " Date: " + spot.Timestamp;
                listBoxAllSpots.Items.Add(strTemp);
            }
        }

        private void btnGetFreeSpotsInAMoment_Click(object sender, EventArgs e)
        {
            listBoxAllSpots.Items.Clear();
            string parkId = textBoxPark.Text;

            if (parkId.Length == 0)
            {
                MessageBox.Show("Please specify the id of the park.");
                return;
            }

            string timePicker = dateTimePickerSpecificDate.Text;

            string[] moment = timePicker.Split(' ');

            string date = moment[0];
            string time = moment[1];

            string formatedTime = time.Replace(':', 't');

            var client = new RestClient(baseURI + "/park/" + parkId + "/free/" + date + "/" + formatedTime);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            List<ParkingSpot> lst = jser.Deserialize<List<ParkingSpot>>(str);

            if (lst.Count() == 0)
            {
                MessageBox.Show("This park does not has spots.");
                return;
            }

            foreach (ParkingSpot spot in lst)
            {
                string strTemp = "Id: " + spot.Id + " Name: " + spot.Name + " Status: " + spot.Status;
                listBoxAllSpots.Items.Add(strTemp);
            }
        }

        private void btnGetAllSpotsInAPark_Click(object sender, EventArgs e)
        {
            listBoxAllSpots.Items.Clear();
            string parkId = textBoxPark.Text;

            if (parkId.Length == 0)
            {
                MessageBox.Show("Please specify the id of the park.");
                return;
            }

            var client = new RestClient(baseURI + "/park/" + parkId);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            //if (response.ResponseStatus == ResponseStatus.Error)
            //{
            //    MessageBox.Show("Park does not exists.");
            //    return;
            //}

            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            List<ParkingSpot> lst = jser.Deserialize<List<ParkingSpot>>(str);

            if (lst.Count() == 0)
            {
                MessageBox.Show("This park does not has spots.");
                return;
            }

            foreach (ParkingSpot spot in lst)
            {
                string strTemp = "Id: " + spot.Id + " Name: " + spot.Name;
                listBoxAllSpots.Items.Add(strTemp);
            }
        }

        private void btnGetSpotInfo_Click(object sender, EventArgs e)
        {
            textBoxSpotData.Text = null;

            if (listBoxAllSpots.SelectedItem == null)
            {
                MessageBox.Show("Please select a Parking Spot from the list.");
                return;
            }

            string parkingSpot = listBoxAllSpots.SelectedItem.ToString();
            textBoxSpotData.Text = parkingSpot;
            string[] spotData = parkingSpot.Split(' ');

            string spotId = spotData[1];

            string timePicker = dateTimePickerSpecificDate.Text;

            string[] moment = timePicker.Split(' ');

            string date = moment[0];
            string time = moment[1];

            string formatedTime = time.Replace(':', 't');

            var client = new RestClient(baseURI + "/"+ spotId + "/" + date);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            ParkingSpot spot = jser.Deserialize<ParkingSpot>(str);


            string strTemp = "Id: " + spot.Id + "\r\n" + 
                             "Name: " + spot.Name + "\r\n" +
                             "Park Id: " + spot.ParkingLotId + "\r\n" +
                             "Status: " + spot.Status + "\r\n" +
                             "Location: " + spot.Location + "\r\n" +
                             "Last Updated: " + spot.Timestamp + "\r\n" +
                             "Battery Status: " + spot.BatteryStatus;

            textBoxSpotData.Text = strTemp;
        }

        private void btnGetSpotsToBeReplaced_Click(object sender, EventArgs e)
        {
            listBoxAllSpots.Items.Clear();
            var client = new RestClient(baseURI + "/replace");
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            List<ParkingSpot> lst = jser.Deserialize<List<ParkingSpot>>(str);

            if (lst.Count() == 0)
            {
                MessageBox.Show("No spots need to be replaced.");
                return;
            }

            foreach (ParkingSpot spot in lst)
            {
                string strTemp = "Id: " + spot.Id +
                                 " Name: " + spot.Name +
                                 " Location: " + spot.Location +
                                 " Battery Status: " + spot.BatteryStatus;
                listBoxAllSpots.Items.Add(strTemp);
            }
        }

        private void btnGetSpotsToBeReplacedInAPark_Click(object sender, EventArgs e)
        {
            listBoxAllSpots.Items.Clear();
            string parkId = textBoxPark.Text;

            if (parkId.Length == 0)
            {
                MessageBox.Show("Please specify the id of the park.");
                return;
            }

            var client = new RestClient(baseURI + "/park/" + parkId + "/replace");
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            string str = response.Content.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            List<ParkingSpot> lst = jser.Deserialize<List<ParkingSpot>>(str);

            if (lst.Count() == 0)
            {
                MessageBox.Show("No spots need to be replaced.");
                return;
            }

            foreach (ParkingSpot spot in lst)
            {
                string strTemp = "Id: " + spot.Id +
                                 " Name: " + spot.Name +
                                 " Location: " + spot.Location +
                                 " Battery Status: " + spot.BatteryStatus;
                listBoxAllSpots.Items.Add(strTemp);
            }
        }

        private void ParkingSpotsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
