using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SparX
{
    public partial class MainForm : Form
    {
        #region Variables
        int lastSelectedIndex = 0;
        bool queueProcessing = true;
        string selectedTitle, selectedLink;
        string targetDirectory;
        string currentAudioFileName;
        public List<string> IDs = new List<string>();
        public List<string> titles = new List<string>();
        public List<string> durations = new List<string>();
        ContextMenuStrip menu;
        DownloadQueue dldQueue;
        Stopwatch stpWathcher = new Stopwatch();
        YTMp3OrgConverter mp3Orgconverter;
        YT2Mp3Converter mp3ccConverter;
        ListViewItem item;
        #endregion

        #region Constructor + Load
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            mp3Orgconverter = new YTMp3OrgConverter();
            mp3ccConverter = new YT2Mp3Converter();
            dldQueue = new DownloadQueue();
            dldQueue.QueueCompleted += dldQueue_QueueCompleted;
            dldQueue.QueueProgressChanged += dldQueue_QueueProgressChanged;
            dldQueue.QueueElementCompleted += dldQueue_QueueElementCompleted;
            dldQueue.QueueElementStartedDownloading += dldQueue_QueueElementStartedDownloading;
            listViewDwlds.MouseDown += listViewDwlds_MouseDown;
            listViewVideo.MouseDoubleClick += listViewVideo_MouseDoubleClick;
            btnStartQueue.Click += btnStartQueue_Click;
            btnAddQueue.Click += btnAddQueue_Click;
            btnNewQueue.Click += btnNewQueue_Click;
            btnPauseQueue.Click += btnPauseQueue_Click;
            btnPath.Click += btnPath_Click;
            btnSearch.Click += btnSearch_Click;
            searchTxtBox.MouseDoubleClick += searchTxtBox_MouseDoubleClick;
            timer.Tick += timer_Tick;
            mediaPlayer.PlayStateChange += mediaPlayer_PlayStateChange;
            this.AcceptButton = btnSearch;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dldQueue.Cancel();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            queueProcessing = true;
            SetDoubleBuffering(listViewDwlds, true);
            btnPauseQueue.Enabled = false;
            createMenu();
            listViewDwlds.ContextMenuStrip = menu;
            targetDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            btnPath.Text = targetDirectory;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            searchTxtBox.Text = "Michael Jackson";
        }
        bool mediaEnded;
        int counter = 0;
        void mediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {

                timer.Start();
                lblCurrentAudio.Text = currentAudioFileName;
            }
            else
                timer.Stop();
            if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                
                lblTotalDuration.Text = string.Empty;
                lblCurrentAudio.Text = string.Empty;
                if (mediaEnded)
                {
                    if (counter == 0)
                    {
                        counter = 0;
                        timer.Stop();
                        lblCurrentAudio.Text = "";
                        listViewVideo.SelectedItems[0].Selected = false;
                        lastSelectedIndex++;
                        if (lastSelectedIndex >= listViewVideo.Items.Count) return;
                        listViewVideo.Items[lastSelectedIndex].Selected = true;
                        ListViewItem item = listViewVideo.SelectedItems[0];
                        item.EnsureVisible();
                        string downloadLink = getDownloadLink(item);
                        if (string.IsNullOrEmpty(downloadLink)) return;
                        mediaPlayer.URL = downloadLink;
                        currentAudioFileName = selectedTitle;
                        lblTotalDuration.Text = "Buffering...";
                        timer.Start();
                        counter++;
                    }
                    else if (counter == 1)
                    {
                        mediaPlayer.Ctlcontrols.play();
                        counter = 0;
                        mediaEnded = false;
                    }
                }
            }
            if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsBuffering)
            {
                lblTotalDuration.Text = "Buffering...";
            }
            if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                mediaEnded = true;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) return;
            lblTotalDuration.Text = mediaPlayer.Ctlcontrols.currentPositionString+"/"+ mediaPlayer.Ctlcontrols.currentItem.durationString;
        }

        void searchTxtBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            searchTxtBox.SelectAll();
        }
        void listViewDwlds_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            item = listViewDwlds.GetItemAt(e.Location.X, e.Location.Y);
        }


        #endregion

        #region Click Events

        void listViewVideo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            timer.Stop();
            lblCurrentAudio.Text = "";
            ListViewItem item = listViewVideo.SelectedItems[0];
            lastSelectedIndex = item.Index;
            string downloadLink = getDownloadLink(item);
            if (string.IsNullOrEmpty(downloadLink))
            {
                mp3Orgconverter = new YTMp3OrgConverter();
                return;
            }
            mediaPlayer.URL = downloadLink;
            currentAudioFileName = selectedTitle;
            lblTotalDuration.Text = "Buffering...";
            timer.Start();
        }
        void btnPauseQueue_Click(object sender, EventArgs e)
        {
            if (queueProcessing)
            {
                dldQueue.Pause();
                btnPauseQueue.Text = "Resume";
                queueProcessing = false;
            }
            else
            {
                dldQueue.ResumeAsync();
                btnPauseQueue.Text = "Pause";
                queueProcessing = true;
            }
        }


        void btnNewQueue_Click(object sender, EventArgs e)
        {
            dldQueue.Clear();
            listViewDwlds.Items.Clear();
            btnAddQueue.Enabled = true;
            btnStartQueue.Enabled = true;
            btnPauseQueue.Enabled = false;
            btnPauseQueue.Text = "Duraklat";
        }


        void btnStartQueue_Click(object sender, EventArgs e)
        {
            if (dldQueue.QueueLength <= 0) return;
            btnStartQueue.Enabled = false;
            btnPauseQueue.Enabled = true;
            dldQueue.StartAsync();
        }
        void btnAddQueue_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewVideo.SelectedItems)
            {
                string downloadLink = getDownloadLink(item);

                if (string.IsNullOrEmpty(downloadLink))
                {
                    mp3Orgconverter = new YTMp3OrgConverter();
                    return;
                }
                listViewDwlds.Items.Add(selectedTitle).SubItems.Add("");
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    selectedTitle = selectedTitle.Replace(c.ToString(), "_");
                }
                string path = Path.Combine(targetDirectory, selectedTitle + ".mp3");

                listViewDwlds.Items[listViewDwlds.Items.Count - 1].SubItems.Add(path);
                listViewDwlds.Items[listViewDwlds.Items.Count - 1].SubItems.Add("");
                dldQueue.Add(downloadLink, path);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            Stopwatch stp = new Stopwatch();
            bool comp = false;
            stp.Start();
            Task.Run(() =>
            {
                while (stp.Elapsed.TotalSeconds <= 5)
                {
                    if (comp) break;
                }
                stp.Reset();
                waitingPanel(false);
            });

            Task.Run(() =>
            {
                waitingPanel(true);
                SearchByKeyword(searchTxtBox.Text);
                this.Invoke((MethodInvoker)delegate
                {
                    listViewVideo.Items.Clear();
                    for (int i = 0; i < durations.Count; i++)
                    {
                        listViewVideo.Items.Add((i + 1).ToString() + ".)").SubItems.Add(titles[i]);
                        listViewVideo.Items[i].SubItems.Add(durations[i]);
                    }
                    if (listViewVideo.Items.Count > 0)
                        listViewVideo.Items[0].Selected = true;
                    waitingPanel(false);
                });
                comp = true;
            });

        }
        private void deleteItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewDwlds.SelectedItems)
            {
                dldQueue.Delete(item.Index);
                listViewDwlds.Items.RemoveAt(item.Index);
            }
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = item.SubItems[2].Text;
            if (!File.Exists(info.FileName)) 
            {
                MessageBox.Show("Dosya yerinde bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            info.Verb = "open";
            Process pr = new Process();
            pr.StartInfo = info;
            pr.Start();
        }
        void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                targetDirectory = folderBrowserDialog.SelectedPath;
                btnPath.Text = targetDirectory;
            }
        }
        #endregion

        #region Other Events
        void dldQueue_QueueElementStartedDownloading(object sender, EventArgs e)
        {
            btnPauseQueue.Enabled = dldQueue.CurrentAcceptRange;
        }
        void dldQueue_QueueElementCompleted(object sender, QueueElementCompletedEventArgs e)
        {
            listViewDwlds.Items[e.Index].SubItems[1].Text = "Tamamlandı";
            btnPauseQueue.Enabled = false;
        }
        void dldQueue_QueueCompleted(object sender, EventArgs e)
        {
            btnPauseQueue.Enabled = false;
            btnStartQueue.Enabled = true;
        }

        void dldQueue_QueueProgressChanged(object sender, EventArgs e)
        {
            listViewDwlds.Items[dldQueue.CurrentIndex].SubItems[1].Text = "%" + dldQueue.CurrentProgress;
            listViewDwlds.Items[dldQueue.CurrentIndex].EnsureVisible();
        }


        #endregion

        #region Methods
        void waitingPanel(bool enable)
        {
            this.Invoke((MethodInvoker)delegate
            {
                spinningCircles1.Visible = enable;
            });
        }
        void createMenu()
        {
            menu = new System.Windows.Forms.ContextMenuStrip();
            ToolStripMenuItem openItem = new ToolStripMenuItem("Aç");
            openItem.Click += openItem_Click;
            ToolStripMenuItem folderItem = new ToolStripMenuItem("Klasörü Aç");
            folderItem.Click += folderItem_Click;
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Sil");
            deleteItem.Click += deleteItem_Click;
            menu.Items.Add(openItem);
            menu.Items.Add(folderItem);
            menu.Items.Add(deleteItem);
        }

        void folderItem_Click(object sender, EventArgs e)
        {
            string argument = @"/select, " + listViewDwlds.SelectedItems[0].SubItems[2].Text;

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            controlProperty.SetValue(control, value, null);
        }

        string getDownloadLink(ListViewItem item)
        {
            if (item == null) return string.Empty;
            btnAddQueue.Enabled = false;
            selectedTitle = item.SubItems[1].Text;
            selectedLink = "https://www.youtube.com/watch?v=" + IDs[item.Index];
            waitingPanel(true);
            string downloadLink = mp3Orgconverter.ConvertYTVideoToMp3(selectedLink);
            if (string.IsNullOrEmpty(downloadLink)) downloadLink = mp3ccConverter.ConvertYTVideoToMp3(selectedLink);
            waitingPanel(false);
            btnAddQueue.Enabled = true;
            return downloadLink;
        }
        private void SearchByKeyword(string keyword)
        {
            titles.Clear();
            IDs.Clear();
            durations.Clear();
            if (keyword == "") return;
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyABcJNv5pYNK0Qo_pxqMK0I13hSwipf6bk",
                ApplicationName = this.GetType().ToString()
            });
            var searchListRequest = youtubeService.Search.List("snippet");
            var videoListRequest = youtubeService.Videos.List("contentDetails");
            searchListRequest.Q = keyword;
            searchListRequest.MaxResults = 50;
            searchListRequest.VideoCategoryId = "10";
            searchListRequest.Type = "video";
            
            Google.Apis.YouTube.v3.Data.SearchListResponse searchListResponse = null;
            try
            {
                searchListResponse = searchListRequest.Execute();
            }
            catch
            {
                waitingPanel(false);
                return;
            }
            
            if (searchListResponse.Items.Count <= 0) return;
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        titles.Add(searchResult.Snippet.Title);
                        IDs.Add(searchResult.Id.VideoId);
                        videoListRequest.Id += searchResult.Id.VideoId + ",";
                        break;
                }
            }

            videoListRequest.Id = videoListRequest.Id.Remove(videoListRequest.Id.Length - 1);
            var videoListResponse = videoListRequest.Execute();
            
            foreach (var item in videoListResponse.Items)
            {
                TimeSpan time = convertTimeFormat(item.ContentDetails.Duration);

                if (time.TotalMinutes > 10)
                {
                    titles.RemoveAt(IDs.IndexOf(item.Id));
                    IDs.Remove(item.Id);
                    continue;
                }
                durations.Add(time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00"));
            }
        }

        TimeSpan convertTimeFormat(string isoFormat)
        {
            return XmlConvert.ToTimeSpan(isoFormat);

        }
        #endregion
        
    }
}
