namespace VestigeMusicPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip2 = new MenuStrip();
            Playlist_List = new ListBox();
            Tracklist = new ListBox();
            addTrackButton = new Button();
            createPlaylistButton = new Button();
            removeTrackButton = new Button();
            lblTrackName = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            stopButton = new Button();
            pauseButton = new Button();
            playButton = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(32, 32);
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1808, 24);
            menuStrip2.TabIndex = 5;
            menuStrip2.Text = "menuStrip2";
            // 
            // Playlist_List
            // 
            Playlist_List.BackColor = SystemColors.ControlLight;
            Playlist_List.ForeColor = SystemColors.MenuText;
            Playlist_List.FormattingEnabled = true;
            Playlist_List.Location = new Point(55, 156);
            Playlist_List.Name = "Playlist_List";
            Playlist_List.Size = new Size(1032, 676);
            Playlist_List.TabIndex = 6;
            // 
            // Tracklist
            // 
            Tracklist.BackColor = SystemColors.ControlLight;
            Tracklist.FormattingEnabled = true;
            Tracklist.Location = new Point(1127, 220);
            Tracklist.Name = "Tracklist";
            Tracklist.Size = new Size(628, 548);
            Tracklist.TabIndex = 7;
            Tracklist.SelectedIndexChanged += Playlist_List_SelectedIndexChanged;
            // 
            // addTrackButton
            // 
            addTrackButton.Location = new Point(1127, 900);
            addTrackButton.Name = "addTrackButton";
            addTrackButton.Size = new Size(198, 66);
            addTrackButton.TabIndex = 8;
            addTrackButton.Text = "Add Track";
            addTrackButton.UseVisualStyleBackColor = true;
            addTrackButton.Click += button1_Click;
            // 
            // createPlaylistButton
            // 
            createPlaylistButton.Location = new Point(1127, 156);
            createPlaylistButton.Name = "createPlaylistButton";
            createPlaylistButton.Size = new Size(628, 48);
            createPlaylistButton.TabIndex = 9;
            createPlaylistButton.Text = "+ Create Playlist";
            createPlaylistButton.UseVisualStyleBackColor = true;
            createPlaylistButton.Click += button2_Click;
            // 
            // removeTrackButton
            // 
            removeTrackButton.Location = new Point(1347, 900);
            removeTrackButton.Name = "removeTrackButton";
            removeTrackButton.Size = new Size(198, 66);
            removeTrackButton.TabIndex = 10;
            removeTrackButton.Text = "Remove Track";
            removeTrackButton.UseVisualStyleBackColor = true;
            // 
            // lblTrackName
            // 
            lblTrackName.AutoSize = true;
            lblTrackName.Location = new Point(1125, 671);
            lblTrackName.Name = "lblTrackName";
            lblTrackName.Size = new Size(78, 32);
            lblTrackName.TabIndex = 11;
            lblTrackName.Text = "label1";
            lblTrackName.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblTrackName);
            panel1.Location = new Point(0, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(1808, 756);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(stopButton);
            panel2.Controls.Add(pauseButton);
            panel2.Controls.Add(playButton);
            panel2.Location = new Point(0, 868);
            panel2.Name = "panel2";
            panel2.Size = new Size(1808, 212);
            panel2.TabIndex = 13;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(525, 30);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(198, 66);
            stopButton.TabIndex = 11;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += button2_Click_1;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(303, 30);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(198, 66);
            pauseButton.TabIndex = 10;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // playButton
            // 
            playButton.Location = new Point(85, 30);
            playButton.Name = "playButton";
            playButton.Size = new Size(198, 66);
            playButton.TabIndex = 9;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_2_5_2026_214859_cdn_wallpapersafari_com;
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1808, 1142);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1808, 1152);
            Controls.Add(removeTrackButton);
            Controls.Add(createPlaylistButton);
            Controls.Add(addTrackButton);
            Controls.Add(Tracklist);
            Controls.Add(menuStrip2);
            Controls.Add(panel2);
            Controls.Add(Playlist_List);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip2;
        private ListBox Playlist_List;
        private ListBox Tracklist;
        private Button addTrackButton;
        private Button createPlaylistButton;
        private Button removeTrackButton;
        private Label lblTrackName;
        private Panel panel1;
        private Panel panel2;
        private Button playButton;
        private Button stopButton;
        private Button pauseButton;
        private PictureBox pictureBox1;
    }
}
