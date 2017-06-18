using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace GeneralProjectLibrary
{
    /// <summary>
    /// Functions concerning Web-Connectivity
    /// </summary>
    public static class InternetFunctions
    {
        /// <summary>
        /// Method that pings "google.com" to check if the 
        /// person is connected to the Internet
        /// Taken from the stack overflow answer: 
        /// http://stackoverflow.com/a/2031834 
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectedToTheInternet()
        {
            try
            {
                using (Ping myPing = new Ping())
                {
                    string host = "google.com";
                    byte[] buffer = new byte[32];
                    int timeout = 1000;
                    PingOptions pingOptions = new PingOptions();
                    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                    return (reply.Status == IPStatus.Success);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that returns the entire Content of the specific Website.
        /// Only returns the HTML-Syntax,
        /// </summary>
        /// <param name="sURL"></param>
        /// <returns></returns>
        public static string GetHTMLCode(string sURL)
        {
            //try to get the request
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(sURL);
            wr.Proxy = new WebProxy();
            string sTotal = "", sLine;

            //Set the Methods
            wr.Method = "GET";
            wr.Accept = "text/html";
            wr.UserAgent = "Not Firefox";

            //read in the answer
            using (WebResponse wrep = wr.GetResponse())
            {
                using (StreamReader sr = new StreamReader(wrep.GetResponseStream()))
                {
                    while ((sLine = sr.ReadLine()) != null)
                        sTotal += sLine;
                }
            }

            return sTotal;
        }

    }
}
