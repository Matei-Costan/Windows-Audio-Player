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
    abstract class Playlist
    {
        protected List<Audio> _audios;
        public List<Audio> Audios
        {
            get
            {
                return _audios;
            }
        }

        protected Playlist(string[] fileName)
        {
            _audios = new List<Audio>();
            foreach(string file in fileName)
                _audios.Add(CreateAudio(file));
        }

        abstract protected Audio CreateAudio(string fileName);
    }
}

