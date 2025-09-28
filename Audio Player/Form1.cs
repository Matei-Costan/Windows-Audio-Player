using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using WMPLib;

namespace IP_Proiect
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer wplayer;

        public Form1()
        {
            InitializeComponent();
            openFileDialog.Filter = "Music (*.mp3)|*.mp3|Music (.wav)|*wav";
            wplayer = new WindowsMediaPlayer();
        }

        private void incarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            IWMPPlaylistCollection playlistColl;
            IWMPPlaylist playlist = wplayer.newPlaylist("Playlist", "");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    playlistColl = wplayer.playlistCollection;
                    playlist = playlistColl.newPlaylist("Playlist");
                    foreach (string f in openFileDialog.FileNames)
                    {
                        IWMPMedia media = wplayer.newMedia(f);
                        playlist.appendItem(media);
                        songListBox.Items.Add(f);
                    }
                    wplayer.currentPlaylist = playlist;
                    wplayer.controls.stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception" + ex);
                }
            }
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proiect IP");
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            wplayer.URL = songListBox.SelectedItem.ToString();
            wplayer.controls.play();
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (wplayer.playState == WMPPlayState.wmppsPlaying)
            {
                wplayer.controls.pause();
            }
            else
            {
                wplayer.controls.play();
            }
        }

        private void timerMelodie_Tick(object sender, EventArgs e)
        {
            if (wplayer.playState == WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)wplayer.controls.currentItem.duration;
                progressBar1.Value = (int)wplayer.controls.currentPosition;
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (songListBox.SelectedIndex > 0)
            {
                songListBox.SelectedIndex = songListBox.SelectedIndex - 1;
                wplayer.URL = songListBox.SelectedItem.ToString();
                wplayer.controls.play();
            }
            else
            {
                songListBox.SelectedIndex = songListBox.Items.Count - 1;
                wplayer.URL = songListBox.SelectedItem.ToString();
                wplayer.controls.play();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (songListBox.SelectedIndex < songListBox.Items.Count - 1)
            {
                songListBox.SelectedIndex = songListBox.SelectedIndex + 1;
                wplayer.URL = songListBox.SelectedItem.ToString();
                wplayer.controls.play();
            }
            else
            {
                songListBox.SelectedIndex = 0;
                wplayer.URL = songListBox.SelectedItem.ToString();
                wplayer.controls.play();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            wplayer.settings.volume = trackBar1.Value;
        }
    }
}
