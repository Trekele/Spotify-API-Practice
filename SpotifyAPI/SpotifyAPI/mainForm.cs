using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using Newtonsoft.Json;
using SpotifyAPI;

namespace SpotifyAPI
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// search button click function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string response = "";

            //Make sure there is text in the text box
            if (txtArtist.Text != string.Empty)
            {
                response = SpotifyHelper.getInformation(SpotifyHelper.buildArtistSearchEndpoint(txtArtist.Text));
                if (response != "")
                {
                    try
                    {
                        //deserialize the response and get the very first image url for the artist
                        dynamic artists = JsonConvert.DeserializeObject(response);
                        string imageURL = artists.artists.items[0].images[0].url;
                        pbArtist.WaitOnLoad = true;
                        pbArtist.Load(imageURL);
                        string artistID = artists.artists.items[0].id;
                        //get the top tracks from the artist searched.
                        response = SpotifyHelper.getInformation(SpotifyHelper.buildTopTracksEndpoint(artistID));
                        dynamic tracks = JsonConvert.DeserializeObject(response);
                        string temp = tracks.tracks[0].preview_url;
                        //play the first one
                        SpotifyHelper.PlayMp3FromUrl(temp);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("No Image Found for " + txtArtist.Text, "No Images For " + txtArtist.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Artist not found :(", "Invalid Artist");
                }
            }
            else
            {
                MessageBox.Show("Please enter an artist", "Error");
            }
        }
    }
}
