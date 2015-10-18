using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using Newtonsoft.Json;

namespace SpotifyAPI
{
    class SpotifyHelper
    {
        public static string buildTopTracksEndpoint(string artistID)
        {
            StringBuilder endPoint = new StringBuilder(string.Format("https://api.spotify.com/v1/artists/{0}/top-tracks", artistID));
            endPoint.Append("?country=US");
            return endPoint.ToString();

        }
        public static string buildArtistSearchEndpoint(string artist)
        {
            StringBuilder endPoint = new StringBuilder("https://api.spotify.com/v1/search");
            endPoint.Append("?q=");
            endPoint.Append(artist.Replace(" ", "%20"));//replace spaces with %20
            endPoint.Append("&type=artist");

            return endPoint.ToString();
        }
        public static string getInformation(string endPoint, bool authRequired = false)
        {
            try
            {
                WebRequest request = WebRequest.Create(endPoint);
                if (authRequired)
                {
                    request.Headers.Add("Authorization", string.Format("Bearer {0}", GetAccessToken()));
                }
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                string response = getResponse(request);

                return response;

            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string GetAccessToken()
        {
            SpotifyToken token = new SpotifyToken();

            string postString = string.Format("grant_type=client_credentials");
            byte[] byteArray = Encoding.UTF8.GetBytes(postString);

            string url = "https://accounts.spotify.com/api/token";

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("Authorization", "Basic NDQxODA1ZDE4MDAyNDNlZGI2MjVjOGRkMzE0M2MzMjc6NjQ0MDMzZThlMGFkNDY0YmI3MGJmOWExN2Y2MjJiYmE=");
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            string response = getResponse(request);

            try
            {
                token = JsonConvert.DeserializeObject<SpotifyToken>(response);
                return token.access_token;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string getResponse(WebRequest request)
        {
            try
            {
                Stream objStream = request.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);

                string sLine = "";
                string response = "";
                int i = 0;

                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        response += sLine;
                    }
                }
                return response;
            }
            catch (WebException)
            {
                return "";
            }
        }

        public static void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url)
                    .GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            //System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }
    }
    public class SpotifyToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        public override string ToString()
        {
            string returnString = "";
            returnString += "access_token " + access_token + "\n";
            returnString += "token_type " + token_type + "\n";
            returnString += "expires_in " + expires_in + "\n";

            return returnString;
        }
    }
}
