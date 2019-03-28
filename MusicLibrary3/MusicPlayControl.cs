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
    public partial class MusicPlayControl : UserControl
    {
        public MusicPlayControl()
        {
            InitializeComponent();
        }
        double timeleft;
        public bool PLAY = true;
        public void play(Music song, bool flat)
        {
            #region redundant
            //lblChannel.Invoke(new UpdateChannelCall(this.UpdateChannel),song.Channel.OBJ());
            lblChannel.Text = song.Channel.ToString();
            Sound[] notes = song.Sounds;
            double seconds = 0;
            foreach (Sound sound in notes)
            {
                seconds += (double)sound.FullNoteType.GetDuration(sound.Tempo) / 1000;
            }
            timeleft = seconds;
            tmrMain.Enabled = true;
            lblSecondsLeft.Text = timeleft + "";
            //lblSecondsLeft.Invoke(new UpdateSecondsCall(UpdateSeconds), timeleft.OBJ());
            double length = notes.Length;
            double thing = (100 / length);
            double otherthing = Math.Round(thing);
            double progress = 0;
            #endregion
            for (int i = 0; i < notes.Length && PLAY; i++)
            {
                #region redundant2
                Sound sound = notes[i];
                //lblTempo.Invoke(new UpdateTempoCall(UpdateTempo), tempo.OBJ());
                lblTempo.Text = sound.Tempo.ToString();
                Refresh();
                string note = sound.Note.ToString();
                if (flat)
                {
                    try
                    {
                        note = sound.Note.GetFlat();
                    }
                    catch { }
                }
                #endregion
                //lblNote.Invoke(new UpdateNoteCall(UpdateNote), note.OBJ());
                lblNote.Text = note;
                progress += thing;
                //lblProgress.Invoke(new UpdateProgressCall(UpdateProgress), progress.OBJ());
                lblProgress.Text = progress + "%";
                seconds -= (double)sound.FullNoteType.GetDuration(sound.Tempo) / 1000;
                lblSecondsLeft.Text = seconds + " seconds left";
                //lblSecondsLeft.Invoke(new UpdateSecondsCall(UpdateSeconds), seconds.OBJ());
                Refresh();
                sound.PlaySound(song.Channel);
            }
        }

        private void MusicPlayControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                PLAY = false;
                MessageBox.Show("frfrhfurhfruihruifh");
            }
        }
    }
}