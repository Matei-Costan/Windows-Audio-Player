using IP_Proiect.Music.AudioTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Proiect.Playlist
{
    class SongPlaylist:Playlist
    {
       
        public SongPlaylist(string[] fileName) : base(fileName) { }

        protected override Audio CreateAudio(string fileName)
        {
            Audio audio = null;
            if (Path.GetExtension(fileName) == ".mp3")
            {
                MessageBox.Show(Path.GetExtension(fileName));
                audio = new Mp3(fileName);
            }
            else if (Path.GetExtension(fileName) == ".flac")
            {
                audio = new Flac(fileName);
                //MessageBox.Show(Path.GetExtension(fileName));
            }
            else if (Path.GetExtension(fileName) == ".wav")
            {
                audio = new Wav(fileName);
                //MessageBox.Show(Path.GetExtension(fileName));
            }
            else if (Path.GetExtension(fileName) == "")
                throw new ArgumentNullException();
            else
                throw new ArgumentException();
            return audio;
        }
    }
}

