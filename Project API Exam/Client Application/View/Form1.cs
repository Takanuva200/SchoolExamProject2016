using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using Client_Application.Controller;
using Client_Application.Model;

namespace Client_Application.View
{
    public partial class Form1 : Form
    {
        AdvertisementController adController = new AdvertisementController();

        Advertisement currentSelectedAd;
        public Form1()
        {
            InitializeComponent();
            updateList();
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
                    var owner = textBoxOwner.Text;
                    var coords = textBoxCoordinates.Text;
                    if(string.IsNullOrWhiteSpace(owner))
                        throw new ArgumentException("The field Owner can't be empty.");
                    if(string.IsNullOrWhiteSpace(coords))
                        throw new ArgumentException("The field Coordinates can't be empty.");

                    adController.CreateAdvertisement(coords, owner, dateTimePickerOfExpiration.Value);
                    updateList();
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
                    Dictionary<string, string> dictionaryOfStrings = new Dictionary<string, string>();
                    var SACoords = textBoxSACoordinates.Text;
                    dictionaryOfStrings.Add("Coordinates",SACoords);
                    var SAIP = textBoxSAIPAddress.Text;
                    dictionaryOfStrings.Add("IP", SAIP);
                    var SAPort = textBoxPortSA.Text;
                    dictionaryOfStrings.Add("Port", SAPort);

                    var SBCoords = textBoxSBCoordinates.Text;
                    dictionaryOfStrings.Add("Coordinates",SBCoords);
                    var SBIP = textBoxSBIPAddress.Text;
                    dictionaryOfStrings.Add("IP", SBIP);
                    var SBPort = textBoxPortSB.Text;
                    dictionaryOfStrings.Add("Port", SBPort);
                    string errorString = "";
                    foreach (var item in dictionaryOfStrings)
                    {
                        errorString = checkForNull(item.Key, item.Value);                        
                    }
                    if(!string.IsNullOrWhiteSpace(errorString))
                        throw new ArgumentException(errorString);
                    if (currentSelectedAd == null)
                        throw new NullReferenceException("You need to select an advertisement in the list.");

                    adController.AddSensorsToAd(1, SACoords, new List<Activations>(), new UdpClient(SAIP, int.Parse(SAPort)),
                    2, SBCoords, new List<Activations>(), new UdpClient(SBIP, int.Parse(SBPort)), currentSelectedAd);
                    updateList();
                
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }

        }
        /// <summary>
        /// Checks the different fields and properties if they have an error in them.
        /// </summary>
        /// <param name="content">Is the content that is going to be checked</param>
        /// <param name="property">Is the property</param>
        /// <returns></returns>
        private string checkForNull(string content, string property)
        {
            string field = "property";
            string extra = "";
            if (string.IsNullOrWhiteSpace(content))
            {
                switch (property)
                {
                    case "Coordinates":
                        field = "Coordinates";
                        break;
                    case "IP":
                        field = "IP";
                        if (checkIP(content))
                            extra = "Your IP address can only be 12 numbers long";
                        break;
                    case "Port":
                        field = "Port";
                        if (content.Length <= 4)
                        {
                            extra = "\nThe port number can only be 4 numbers long";
                        }
                        break;
                }
                return "You have made an error in field: " + field + extra;

            }

            return null;
        }

        private bool checkIP(string content)
        {
            bool check = false;
            var splits = content.Split('.');
            foreach (var split in splits)
            {
                if (split.Length > 3)
                    check = true;
                else
                {
                    check = false;
                }
            }
            return check;
        }

        /// <summary>
        /// Call this when an update for the lists is necessary.
        /// </summary>
        private void updateList()
        {
            label_AdID.Text = "Current ID: " +adController.LatestAdID;
            label_IDSA.Text = "Current ID: 1";
            label_IDSB.Text = "Current ID: 2";
            var currentCatalog = adController.AdvertisementCatalog;

            var source = new BindingSource(currentCatalog, null);
            listBoxAdvertisements.DataSource = source;
            listBoxAdvertisements.DisplayMember = "Owner";
            listBoxCoordinates.DataSource = source;
            listBoxCoordinates.DisplayMember = "Coordinates";
            listBoxNumberOfPSensors.DataSource = source;
            listBoxNumberOfPSensors.DisplayMember = "GetPSensorCount";
            listBoxDateOfExpire.DataSource = source;
            listBoxDateOfExpire.DisplayMember = "DateOfExpire";
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
