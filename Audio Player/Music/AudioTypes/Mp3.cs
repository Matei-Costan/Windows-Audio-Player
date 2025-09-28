using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Proiect.Music.AudioTypes
{
    class Mp3 : Audio
    {
        public Mp3(string fileName):base()
        {
            TextBox text = new TextBox();
            _name = Path.GetFileNameWithoutExtension(fileName);
            text.Text = fileName;
            text.Name = _name;
            _content = text;
        }
    }
}
