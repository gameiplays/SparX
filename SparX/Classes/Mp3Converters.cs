using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SparX
{
    public class YTMp3OrgConverter
    {
        const string siteUrl = "www.youtube-mp3.org";
        WebBrowser webBrowser;
        Stopwatch stpWathcher;
        bool docCompleted;
        /// <summary>
        /// Enables the user to convert YouTube videos to mp3 using youtube-mp3.org
        /// </summary>
        public YTMp3OrgConverter()
        {
            stpWathcher = new Stopwatch();
            this.webBrowser = new WebBrowser();
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            docCompleted = false;
            webBrowser.ScriptErrorsSuppressed = true;
            GetReady();
        }
        public void GetReady()
        {
            webBrowser.Navigate(siteUrl);
        }
        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            docCompleted = true;
        }
        /// <summary>
        /// Converts youtube video to mp3 and returns download link as string
        /// </summary>
        /// <param name="youtubeLink">YouTube video link to be converted</param>
        /// <returns></returns>
        public string ConvertYTVideoToMp3(string youtubeLink)
        {
            if (!YTMp3OrgConverter.IsYoutubeUrl(youtubeLink)) throw new Exception("Url düzgün bir YouTube video adresi değil");
            stpWathcher.Start();
            if (!docCompleted)
            {
                webBrowser.Navigate(siteUrl);
                while (!docCompleted)
                {
                    Application.DoEvents();
                    if (stpWathcher.Elapsed.TotalSeconds > 4)
                    {
                        stpWathcher.Reset();
                        return "";
                    }
                }
            }
            stpWathcher.Reset();
            string videoId = Regex.Split(youtubeLink, @"watch\?v=")[1];
            if (webBrowser.Document.GetElementById("youtube-url") == null)
            {
                webBrowser.Navigate(siteUrl);
                while (!docCompleted)
                {
                    Application.DoEvents();
                    if (stpWathcher.Elapsed.TotalSeconds > 4)
                    {
                        stpWathcher.Reset();
                        return "";
                    }
                }
            }
            webBrowser.Document.GetElementById("youtube-url").SetAttribute("value", youtubeLink);
            webBrowser.Document.GetElementById("submit").InvokeMember("click");
            stpWathcher.Start();
            while (webBrowser.Document.GetElementById("dl_link") == null ||
                   webBrowser.Document.GetElementById("dl_link").GetElementsByTagName("a").Count == 0 ||
                  !webBrowser.Document.GetElementById("dl_link").GetElementsByTagName("a")[0].GetAttribute("href").Contains(videoId))
            {
                if (!string.IsNullOrEmpty(webBrowser.Document.GetElementById("error_text").InnerText))
                    return "";

                Application.DoEvents();
            }
            stpWathcher.Reset();
            HtmlElementCollection elCol = webBrowser.Document.GetElementById("dl_link").GetElementsByTagName("a");

            string downloadLink = "";
            foreach (HtmlElement item in elCol)
            {
                if (item.GetAttribute("href").Contains("create"))
                    downloadLink = item.GetAttribute("href");
            }
            return downloadLink;
        }
        public static bool IsYoutubeUrl(string link)
        {
            string youtubeUrlPattern = @"^(https://|http://)?(www\.)?youtube\.com/watch\?v=.{11}$";
            return Regex.IsMatch(link, youtubeUrlPattern);
        }

        
    }
    public class YT2Mp3Converter
    {
        Stopwatch stp;
        string rawAddress = "youtube2mp3.cc/api/#{0}|mp3";
        WebBrowser browser;
        bool cancel;
        /// <summary>
        /// Enables the user to convert YouTube videos to mp3 using youtube2mp3.cc API
        /// </summary>
        public YT2Mp3Converter()
        {
            browser = new WebBrowser();
            stp = new Stopwatch();
        }
        /// <summary>
        /// Converts YouTube video to mp3 and returns the mp3 download link as string.
        /// </summary>
        /// <param name="youtubeLink">YouTube video link to be converted</param>
        /// <returns></returns>
       
        public string ConvertYTVideoToMp3(string youtubeLink)
        {
            cancel = false;
            if (!YTMp3OrgConverter.IsYoutubeUrl(youtubeLink)) return null;
            string id = Regex.Split(youtubeLink, @"watch\?v=")[1];
            string address = string.Format(rawAddress, id);
            browser = new WebBrowser();
            browser.Navigate(address);
            stp.Start();
            while (browser.Document == null || 
                   browser.Document.GetElementById("download") == null || 
                  !browser.Document.GetElementById("download").GetAttribute("href").Contains("downloader"))
            {
                if (cancel) return null;
                if (stp.Elapsed.TotalSeconds > 4)
                    return null;
                Application.DoEvents();
            }
            stp.Reset();
            string linkt = browser.Document.GetElementById("download").GetAttribute("href");
            return linkt;
        }
        public void CancelProcess()
        {
            cancel = true;
        }
    }
}
