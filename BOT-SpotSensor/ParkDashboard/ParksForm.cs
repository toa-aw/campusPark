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

        string baseURI = @"http://localhost:50112/api/parks";

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
    }
}
