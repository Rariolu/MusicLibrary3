using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicLibrary3
{
    public partial class KeyboardControl : UserControl
    {
        public KeyboardControl()
        {
            InitializeComponent();
        }
        private int pitch = 3;
        public int Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
                kbbC.Pitch = kbbCsharp.Pitch = kbbD.Pitch = kbbDsharp.Pitch = kbbE.Pitch = kbbF.Pitch = kbbFsharp.Pitch = kbbG.Pitch = kbbGsharp.Pitch = kbbA.Pitch = kbbAsharp.Pitch = kbbB.Pitch = value;
            }
        }
    }
    public enum KeyType
    {
        Normal, FlatSharp
    }
    public class KeyboardButton : Button
    {
        private int keyindex;
        public int KeyIndex
        {
            get
            {
                return keyindex;
            }
            set
            {
                keyindex = value;
            }
        }
        private KeyType keytype;
        public KeyType KeyType
        {
            get
            {
                return keytype;
            }
            set
            {
                keytype = value;
                if (value == KeyType.Normal)
                {
                    Size = new Size(40, 80);
                    BackColor = Color.White;
                    SendToBack();
                }
                else
                {
                    Size = new Size(20, 40);
                    BackColor = Color.Black;
                    BringToFront();
                }
            }
        }
        private int pitch = 3;
        public int Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {

            }
        }
        public KeyboardButton()
        {
            KeyType = KeyType.Normal;
            keyindex = 1;
            Text = "";
            Click += new EventHandler(KeyboardButton_Click);
        }
        private void KeyboardButton_Click(object sender, EventArgs e)
        {
            Note note = (keyindex - 1).GetNoteFromIndex();
            Fncs.PlayNote(note, new FullNoteType(NoteType.SemiQuaver), Pitch, 60, Midi.Channel.Channel1);
        }

    }
}
