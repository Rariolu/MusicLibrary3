using Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace MusicLibrary3
{
    
    public delegate void UpdateChannelCall(Channel channel);
    public delegate void UpdateSecondsCall(double seconds);
    public delegate void UpdateTempoCall(int tempo);
    public delegate void UpdateNoteCall(string note);
    public delegate void UpdateProgressCall(double progress);
    /// <summary>
    /// A windows form used to play notes.
    /// </summary>
    public partial class NotePlayer : Form
    {
        public NotePlayer()
        {
            InitializeComponent();
        }
        double timeleft;
        /*private void UpdateChannel(Midi.Channel channel)
        {
            lblChannel.Text = channel.ToString();
        }
        private void UpdateSeconds(double seconds)
        {
            lblSecondsLeft.Text = seconds + " seconds left ^_^";
        }*/
        private void UpdateTempo(int tempo)
        {
            lblTempo.Text = tempo.ToString();
        }
        private void UpdateNote(string note)
        {
            lblNote.Text = note;
        }
        /*private void UpdateProgress(double progress)
        {
            lblProgress.Text = progress + "%";
        }
        private void play(Music song, bool flat)
        {
            #region redundant
            //lblChannel.Invoke(new UpdateChannelCall(this.UpdateChannel),song.Channel.OBJ());
            lblChannel.Text = song.Channel.ToString();
            Sound[] notes = song.Sounds;
            double seconds = 0;
            foreach (Sound sound in notes)
            {
                seconds += (double)sound.NoteType.GetDuration(sound.Tempo) / 1000;
            }
            timeleft = seconds;
            tmrMain.Enabled = true;
            lblSecondsLeft.Text = timeleft + "";
            //lblSecondsLeft.Invoke(new UpdateSecondsCall(UpdateSeconds), timeleft.OBJ());
            double length = notes.Length;
            double thing = (100 / length);
            double otherthing = Math.Round(thing);
            sounds = notes;
            double progress = 0;
            #endregion
            for (int i = 0; i < notes.Length; i++)
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
                seconds -= (double)sound.NoteType.GetDuration(sound.Tempo) / 1000;
                lblSecondsLeft.Text = seconds + " seconds left";
                //lblSecondsLeft.Invoke(new UpdateSecondsCall(UpdateSeconds), seconds.OBJ());
                Refresh();
                sound.PlaySound(song.Channel);
            }
        }*/
        public void Play(Sound note, Channel channel)
        {
            sounds = new Sound[] { note };
            Play(new Sound[] { note }, channel);
        }
        Thread playthread;
        public void Play(Music song, bool flat)
        {
            //play(song, tempo, flat);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender, e) =>
            {
                musicPlayControl1.play(song, flat);
            };
            musicPlayControl1.play(song, flat);
            //playthread = new Thread(() => musicPlayControl1.play(song, flat));
            //playthread.Start();
        }
        public void Play(Sound[] notes, Channel channel)
        {
            Play(new Music(notes, channel), false);
        }
        Sound[] sounds = new Sound[0];
        private void button1_Click(object sender, EventArgs e)
        {
            string notes = "";
            foreach (Sound sound in sounds)
            {
                notes += "Note: " + sound.Note + "; Type: " + sound.FullNoteType.NoteType + "; Dotted: " + sound.FullNoteType.Dotted + "; Pitch: " + sound.Pitch + "\n";
            }
            MessageBox.Show(notes);
            Clipboard.SetText(notes);
        }
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            //timeleft -= 0.001;
            //lblSecondsLeft.Text = timeleft+"";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            playthread.Abort();
        }

        private void NotePlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                musicPlayControl1.PLAY = false;
            }
        }
    }
    /// <summary>
    /// This is an extension of the "ProgressBar" class that has a property called "DoubleValue" that allows the user to set the value to a double.
    /// </summary>
    public class NewProgressBar : ProgressBar
    {
        private double doublevalue;
        public double DoubleValue
        {
            get
            {
                return doublevalue;
            }
            set
            {
                doublevalue = value;
                double newvalue = Math.Round(value);
                Value = newvalue.ObjectToIntegerParse();
            }
        }
    }
    /*public static class Temp
    {
        public static object[] OBJ(this object obj)
        {
            return new object[] { obj };
        }
    }*/
}