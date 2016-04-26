namespace SparX
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewVideo = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDwlds = new System.Windows.Forms.ListView();
            this.titleCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTotalDuration = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblCurrentAudio = new AltoControls.AltoSlidingLabel();
            this.searchTxtBox = new AltoControls.AltoTextBox();
            this.spinningCircles1 = new AltoControls.SpinningCircles();
            this.btnPath = new AltoControls.AltoButton();
            this.btnNewQueue = new AltoControls.AltoButton();
            this.btnStartQueue = new AltoControls.AltoButton();
            this.btnPauseQueue = new AltoControls.AltoButton();
            this.btnAddQueue = new AltoControls.AltoButton();
            this.btnSearch = new AltoControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewVideo
            // 
            this.listViewVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.listViewVideo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.listViewVideo.FullRowSelect = true;
            this.listViewVideo.GridLines = true;
            this.listViewVideo.Location = new System.Drawing.Point(4, 60);
            this.listViewVideo.Name = "listViewVideo";
            this.listViewVideo.Size = new System.Drawing.Size(314, 278);
            this.listViewVideo.TabIndex = 0;
            this.listViewVideo.UseCompatibleStateImageBehavior = false;
            this.listViewVideo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Id";
            this.columnHeader2.Width = 28;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Video Title";
            this.columnHeader1.Width = 196;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Duration";
            this.columnHeader3.Width = 52;
            // 
            // listViewDwlds
            // 
            this.listViewDwlds.BackColor = System.Drawing.Color.Wheat;
            this.listViewDwlds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleCol,
            this.progCol,
            this.pathCol});
            this.listViewDwlds.FullRowSelect = true;
            this.listViewDwlds.GridLines = true;
            this.listViewDwlds.Location = new System.Drawing.Point(329, 182);
            this.listViewDwlds.Name = "listViewDwlds";
            this.listViewDwlds.Size = new System.Drawing.Size(314, 155);
            this.listViewDwlds.TabIndex = 5;
            this.listViewDwlds.UseCompatibleStateImageBehavior = false;
            this.listViewDwlds.View = System.Windows.Forms.View.Details;
            // 
            // titleCol
            // 
            this.titleCol.Text = "Title";
            this.titleCol.Width = 102;
            // 
            // progCol
            // 
            this.progCol.Text = "Progress";
            this.progCol.Width = 52;
            // 
            // pathCol
            // 
            this.pathCol.Text = "Target Folder";
            this.pathCol.Width = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(332, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Save Folder:";
            // 
            // lblTotalDuration
            // 
            this.lblTotalDuration.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalDuration.Location = new System.Drawing.Point(542, 89);
            this.lblTotalDuration.Name = "lblTotalDuration";
            this.lblTotalDuration.Size = new System.Drawing.Size(79, 13);
            this.lblTotalDuration.TabIndex = 25;
            this.lblTotalDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(330, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Currently playing:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(329, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "Download List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "Search Results";
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(329, 77);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(311, 45);
            this.mediaPlayer.TabIndex = 24;
            // 
            // lblCurrentAudio
            // 
            this.lblCurrentAudio.Enabled = false;
            this.lblCurrentAudio.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentAudio.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCurrentAudio.Location = new System.Drawing.Point(452, 53);
            this.lblCurrentAudio.Name = "lblCurrentAudio";
            this.lblCurrentAudio.Size = new System.Drawing.Size(188, 20);
            this.lblCurrentAudio.Slide = false;
            this.lblCurrentAudio.TabIndex = 39;
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.BackColor = System.Drawing.Color.Transparent;
            this.searchTxtBox.Br = System.Drawing.Color.White;
            this.searchTxtBox.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.searchTxtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchTxtBox.Location = new System.Drawing.Point(4, 5);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(262, 30);
            this.searchTxtBox.TabIndex = 38;
            this.searchTxtBox.Text = "Cold Play";
            // 
            // spinningCircles1
            // 
            this.spinningCircles1.BackColor = System.Drawing.Color.Transparent;
            this.spinningCircles1.FullTransparent = true;
            this.spinningCircles1.Increment = 1F;
            this.spinningCircles1.Location = new System.Drawing.Point(272, 139);
            this.spinningCircles1.N = 8;
            this.spinningCircles1.Name = "spinningCircles1";
            this.spinningCircles1.Radius = 2.5F;
            this.spinningCircles1.Size = new System.Drawing.Size(90, 99);
            this.spinningCircles1.TabIndex = 37;
            this.spinningCircles1.Text = "spinningCircles1";
            this.spinningCircles1.Visible = false;
            // 
            // btnPath
            // 
            this.btnPath.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPath.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPath.BackColor = System.Drawing.Color.Transparent;
            this.btnPath.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPath.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPath.ForeColor = System.Drawing.Color.DimGray;
            this.btnPath.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPath.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPath.Location = new System.Drawing.Point(423, 5);
            this.btnPath.Name = "btnPath";
            this.btnPath.Radius = 4;
            this.btnPath.Size = new System.Drawing.Size(215, 30);
            this.btnPath.Stroke = 0F;
            this.btnPath.StrokeColor = System.Drawing.Color.Black;
            this.btnPath.TabIndex = 36;
            this.btnPath.Transparency = false;
            // 
            // btnNewQueue
            // 
            this.btnNewQueue.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnNewQueue.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnNewQueue.BackColor = System.Drawing.Color.Transparent;
            this.btnNewQueue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewQueue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNewQueue.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnNewQueue.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnNewQueue.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnNewQueue.Location = new System.Drawing.Point(563, 128);
            this.btnNewQueue.Name = "btnNewQueue";
            this.btnNewQueue.Radius = 15;
            this.btnNewQueue.Size = new System.Drawing.Size(75, 35);
            this.btnNewQueue.Stroke = 0F;
            this.btnNewQueue.StrokeColor = System.Drawing.Color.Black;
            this.btnNewQueue.TabIndex = 35;
            this.btnNewQueue.Text = "New Queue";
            this.btnNewQueue.Transparency = false;
            // 
            // btnStartQueue
            // 
            this.btnStartQueue.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnStartQueue.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnStartQueue.BackColor = System.Drawing.Color.Transparent;
            this.btnStartQueue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStartQueue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStartQueue.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnStartQueue.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnStartQueue.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnStartQueue.Location = new System.Drawing.Point(485, 128);
            this.btnStartQueue.Name = "btnStartQueue";
            this.btnStartQueue.Radius = 15;
            this.btnStartQueue.Size = new System.Drawing.Size(75, 35);
            this.btnStartQueue.Stroke = 0F;
            this.btnStartQueue.StrokeColor = System.Drawing.Color.Black;
            this.btnStartQueue.TabIndex = 34;
            this.btnStartQueue.Text = "Start Queue";
            this.btnStartQueue.Transparency = false;
            // 
            // btnPauseQueue
            // 
            this.btnPauseQueue.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnPauseQueue.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnPauseQueue.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseQueue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPauseQueue.Enabled = false;
            this.btnPauseQueue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPauseQueue.ForeColor = System.Drawing.Color.White;
            this.btnPauseQueue.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnPauseQueue.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnPauseQueue.Location = new System.Drawing.Point(407, 128);
            this.btnPauseQueue.Name = "btnPauseQueue";
            this.btnPauseQueue.Radius = 15;
            this.btnPauseQueue.Size = new System.Drawing.Size(75, 35);
            this.btnPauseQueue.Stroke = 0F;
            this.btnPauseQueue.StrokeColor = System.Drawing.Color.Black;
            this.btnPauseQueue.TabIndex = 33;
            this.btnPauseQueue.Text = "Pause";
            this.btnPauseQueue.Transparency = false;
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnAddQueue.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnAddQueue.BackColor = System.Drawing.Color.Transparent;
            this.btnAddQueue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddQueue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddQueue.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnAddQueue.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnAddQueue.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnAddQueue.Location = new System.Drawing.Point(329, 128);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Radius = 15;
            this.btnAddQueue.Size = new System.Drawing.Size(75, 35);
            this.btnAddQueue.Stroke = 0F;
            this.btnAddQueue.StrokeColor = System.Drawing.Color.Black;
            this.btnAddQueue.TabIndex = 32;
            this.btnAddQueue.Text = "Add to Queue";
            this.btnAddQueue.Transparency = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSearch.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSearch.Location = new System.Drawing.Point(272, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Radius = 10;
            this.btnSearch.Size = new System.Drawing.Size(54, 30);
            this.btnSearch.Stroke = 0F;
            this.btnSearch.StrokeColor = System.Drawing.Color.Black;
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Search";
            this.btnSearch.Transparency = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 345);
            this.Controls.Add(this.lblCurrentAudio);
            this.Controls.Add(this.searchTxtBox);
            this.Controls.Add(this.spinningCircles1);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.btnNewQueue);
            this.Controls.Add(this.btnStartQueue);
            this.Controls.Add(this.btnPauseQueue);
            this.Controls.Add(this.btnAddQueue);
            this.Controls.Add(this.lblTotalDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewVideo);
            this.Controls.Add(this.listViewDwlds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SparX";
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewVideo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listViewDwlds;
        private System.Windows.Forms.ColumnHeader titleCol;
        private System.Windows.Forms.ColumnHeader progCol;
        private System.Windows.Forms.ColumnHeader pathCol;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Label lblTotalDuration;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private AltoControls.AltoButton btnSearch;
        private AltoControls.AltoButton btnAddQueue;
        private AltoControls.AltoButton btnPauseQueue;
        private AltoControls.AltoButton btnStartQueue;
        private AltoControls.AltoButton btnNewQueue;
        private AltoControls.AltoButton btnPath;
        private AltoControls.SpinningCircles spinningCircles1;
        private AltoControls.AltoTextBox searchTxtBox;
        private AltoControls.AltoSlidingLabel lblCurrentAudio;
    }
}

