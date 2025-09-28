using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Proiect.Music.AudioTypes
{
    abstract class Audio
    {
        public Control _content;
        public string _name;

        public string getName()
        {
            return this._name;
        }

        public String getContent()
        {
            return this._content.Text;
        }

        protected void playAudio(string fileName)
        {
            SoundPlayer simpleSound = new SoundPlayer(fileName);
            simpleSound.Play();
        }
    }
}
