using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using NAudio.Wave;

namespace VestigeMusicPlayer
{
    public partial class Form1 : Form
    {
        private List<Playlist> _playlists = new List<Playlist>();
        private IWavePlayer waveOut; /* handles audio output */
        private AudioFileReader audioFileReader; /* reads and decodes MP3 */
        public Form1()
        {
            InitializeComponent();

            /* create playlist list */
            Playlist_List.DataSource = _playlists;
            Playlist_List.DisplayMember = "Name";

            /* subscribe to event (when playlist has been selected) */
            Playlist_List.SelectedIndexChanged += Playlist_List_SelectedIndexChanged;
            /* subscribe to event (when track has been selected) */
            Tracklist.SelectedIndexChanged += Tracklist_SelectedIndexChanged;

        }

        class Playlist
        {
            /* properties */
            public string Name { get; set; } = "New Playlist";
            private readonly List<string> _tracks = new();
            public List<string> Tracks => _tracks;

            private int _currentIndex = 0;
            private WaveOutEvent _output;
            private AudioFileReader _reader;
            private bool _isPaused = false; /* track if playback is paused */

            /* methods */
            public void LoadPlaylist(IEnumerable<string> files)
            {
                _tracks.Clear();
                _tracks.AddRange(files);
            }

            public void Play()
            {
                /* if paused, resume track */
                if (_output != null && _isPaused)
                {
                    _output.Play();
                    _isPaused = false;
                    return;
                }

                /* start new */
                PlayTrack(_currentIndex);
            }

            public void Pause()
            {
                if (_output != null)
                {
                    _output.Pause();
                    _isPaused = true;
                }
            }

            public void Stop()
            {
                if (_output != null)
                {
                    _output.PlaybackStopped -= OnPlaybackStopped;
                    _output.Stop();
                }

                _reader?.Dispose();
                _output?.Dispose();
                _reader = null;
                _output = null;
                _isPaused = false;
            }

            private void PlayTrack(int index)
            {
                _reader?.Dispose();
                _output?.Dispose();

                _reader = new AudioFileReader(_tracks[index]);
                _output = new WaveOutEvent();
                _output.Init(_reader);
                _output.Play();
                _output.PlaybackStopped += OnPlaybackStopped;
            }

            public void Next()
            {
                _currentIndex = (_currentIndex + 1) % _tracks.Count;
                PlayTrack(_currentIndex);
            }

            public void SetTrack(int index)
            {
                if (index >= 0 && index < _tracks.Count)
                {
                    _currentIndex = index;
                }
            }

            private void OnPlaybackStopped(object sender, StoppedEventArgs e)
            {
                Next();
            }

            public void MoveTrack(int oldIndex, int newIndex)
            {
                if (oldIndex >= 0 && oldIndex < _tracks.Count && newIndex >= 0 && newIndex < _tracks.Count)
                {
                    string track = _tracks[oldIndex];
                    _tracks.RemoveAt(oldIndex);
                    _tracks.Insert(newIndex, track);
                }
            }
        }

        private void Playlist_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* if a playlist is selected from the playlist list... */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                /* display the tracks for that playlist */
                // Tracklist.DataSource = null;
                if (selected.Tracks.Count == 0)
                {
                    Tracklist.DataSource = null;
                    lblTrackName.Text = "Playlist is empty";
                }
                else
                {
                    Tracklist.DataSource = selected.Tracks;
                    lblTrackName.Text = "Select a track";
                }
            }
        }

        private void Tracklist_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                int index = Tracklist.SelectedIndex;
                selected.SetTrack(index);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* 'Add Track' button */
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Audio Files|*.mp3;*.wav;*.flac*.aac;*.wma";
                ofd.Title = "Select a track";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    lblTrackName.Text = Path.GetFileName(filePath);

                    if (Playlist_List.SelectedItem is Playlist selected)
                    {
                        selected.Tracks.Add(filePath);
                        Tracklist.DataSource = null;
                        Tracklist.DataSource = selected.Tracks;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* '+ Create Playlist' button */

            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter playlist name:");

            if (string.IsNullOrWhiteSpace(name)) return;

            Playlist myPlaylist = new Playlist { Name = name };
            _playlists.Add(myPlaylist);

            Playlist_List.DataSource = null;
            Playlist_List.DataSource = _playlists;
            Playlist_List.DisplayMember = "Name";

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            /* 'Play' button */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                selected.Play();
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            /* 'Pause' button */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                selected.Pause();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /* 'Stop' button */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                selected.Stop();
            }
        }

        /* cleanup to prevent memory leaks */
        private void Cleanup()
        {
            audioFileReader?.Dispose();
            waveOut?.Dispose();
            audioFileReader = null;
            waveOut = null;
        }

        /* ensure cleanup */
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cleanup();
        }

        private void removeTrackButton_Click(object sender, EventArgs e)
        {
            /* remove selected track from playlist */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                selected.Tracks.RemoveAt(Tracklist.SelectedIndex);
                Tracklist.DataSource = null;
                Tracklist.DataSource = selected.Tracks;
                lblTrackName.Text = "Select a track";
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            /* move track up in the playlist */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                int index = Tracklist.SelectedIndex;
                if (index > 0)
                {
                    selected.MoveTrack(index, index - 1);
                    Tracklist.DataSource = null;
                    Tracklist.DataSource = selected.Tracks;
                    Tracklist.SelectedIndex = index - 1;
                }
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            /* move track down in the playlist */
            if (Playlist_List.SelectedItem is Playlist selected)
            {
                int index = Tracklist.SelectedIndex;
                if (index < selected.Tracks.Count - 1)
                {
                    selected.MoveTrack(index, index + 1);
                    Tracklist.DataSource = null;
                    Tracklist.DataSource = selected.Tracks;
                    Tracklist.SelectedIndex = index + 1;
                }
            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void btnClickThis_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

    }
}
