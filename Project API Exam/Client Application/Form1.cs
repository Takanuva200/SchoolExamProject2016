using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Application.Controller;
using Client_Application.Model;

namespace Client_Application
{
    public partial class Form1 : Form
    {
        AdvertisementController adController = new AdvertisementController();

        Advertisement currentSelectedAd;
        public Form1()
        { 
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Adds an advertisement to the Advertisement Catalog.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBoxOwner.Text))
                {
                    var owner = textBoxOwner.Text;
                    var coords = textBoxCoordinates.Text;
                    var newAd = new Advertisement(coords, owner);
                    adController.AddCreateAdvertisement(newAd);
                    updateList();
                }
            }
            catch (Exception eX)
            {

                MessageBox.Show(eX.Message);
            }
            
        }
        /// <summary>
        /// Adds a PSensor to the currently selected Advertisement.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                currentSelectedAd = listBoxAdvertisements.SelectedItem as Advertisement;
                if (!string.IsNullOrWhiteSpace(textBoxSACoordinates.Text) && !string.IsNullOrWhiteSpace(textBoxSBCoordinates.Text))
                {
                    var SACoords = textBoxSACoordinates.Text;
                    var SAIP = textBoxSAIPAddress.Text;
                    var SAPort = textBoxPortSA.Text;
                    var sensorA = new MovementSensor(adController.LatestAdID, SACoords,new List<Activations>(),new UdpClient(SAIP,int.Parse(SAPort)) );

                    var SBCoords = textBoxSBCoordinates.Text;
                    var SBIP = textBoxSBIPAddress.Text;
                    var SBPort = textBoxPortSB.Text;
                    var sensorB = new MovementSensor(adController.LatestAdID, SBCoords, new List<Activations>(), new UdpClient(SBIP, int.Parse(SBPort)));

                    if(currentSelectedAd == null)
                        throw new NullReferenceException("You need to select an advertisement in the list.");

                    PSensor psensor = new PSensor(currentSelectedAd.LatestPsId, textBoxSACoordinates.Text, sensorA, sensorB);
                    currentSelectedAd.AddPSensor(psensor);
                    updateList();
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
            
        }

        private string checkForNull(string content, string property)
        {
            string field = "property";

            switch (property)
            {
                case "Coordinates":
                    if (content == null)
                        field = "Coordinates";

                    break;
                case "IP":
                    if (content == null)
                        field = "IP";
                    break;
                case "Port":

                    break;
            }
            if (content == null)
            {
                return "You have made an error in field: " + field;
            }
            return null;
        }
        /// <summary>
        /// Call this when an update for the lists is necessary.
        /// </summary>
        private void updateList()
        {
            var currentCatalog = adController.AdvertisementCatalog;

            var source = new BindingSource(currentCatalog, null);
            listBoxAdvertisements.DataSource = source;
            listBoxAdvertisements.DisplayMember = "Owner";
            listBoxCoordinates.DataSource = source;
            listBoxCoordinates.DisplayMember = "Coordinates";
            listBoxNumberOfPSensors.DataSource = source;
            listBoxNumberOfPSensors.DisplayMember = "GetPSensorCount";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This is called when the selection is changed, so that every listBox has the right highlight.
        /// </summary>
        private void listBoxAdvertisements_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = (ListBox)sender;
            var indix = box.SelectedIndex;
            listBoxAdvertisements.SelectedIndex = indix;
            if (listBoxNumberOfPSensors.Items.Count > 0)
            {
                listBoxAdvertisements.SelectedIndex = indix;
                listBoxNumberOfPSensors.SelectedIndex = indix;
                listBoxCoordinates.SelectedIndex = indix;
            }
            currentSelectedAd = listBoxAdvertisements.SelectedItem as Advertisement;
        }
    }
}
