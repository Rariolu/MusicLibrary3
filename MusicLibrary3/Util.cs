using Midi;
using NAudio;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace MusicLibrary3
{
    //tempp
    #region UsefulSubroutines
    /// <summary>
    /// A static class full of useful properties and subroutines regarding music simulation and analysis.
    /// </summary>
    public static class Fncs
    {
        #region Properties
        public static Dictionary<int, Pattern[]> AvailablePatterns = new Dictionary<int, Pattern[]>();
        public static bool ControlPressed
        {
            get
            {
                return System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl);
            }
        }
        public static OutputDevice device = OutputDevice.InstalledDevices[0];
        public static Note[] Flats = new Note[]
        {
            Note.Asharp,
            Note.Dsharp,
            Note.Gsharp,
            Note.Csharp,
            Note.Fsharp,
            Note.B
        };
        public static Midi.Instrument[] Instruments = new Midi.Instrument[]
        {
            Midi.Instrument.Accordion,
            Midi.Instrument.AcousticBass,
            Midi.Instrument.AcousticGrandPiano,
            Midi.Instrument.AcousticGuitarNylon,
            Midi.Instrument.AcousticGuitarSteel,
            Midi.Instrument.Agogo,
            Midi.Instrument.AltoSax,
            Midi.Instrument.Applause,
            Midi.Instrument.Bagpipe,
            Midi.Instrument.Banjo,
            Midi.Instrument.BaritoneSax,
            Midi.Instrument.Bassoon,
            Midi.Instrument.BirdTweet,
            Midi.Instrument.BlownBottle,
            Midi.Instrument.BrassSection,
            Midi.Instrument.BreathNoise,
            Midi.Instrument.BrightAcousticPiano,
            Midi.Instrument.Celesta,
            Midi.Instrument.Cello,
            Midi.Instrument.ChoirAahs,
            Midi.Instrument.ChurchOrgan,
            Midi.Instrument.Clarinet,
            Midi.Instrument.Clavinet,
            Midi.Instrument.Contrabass,
            Midi.Instrument.DistortionGuitar,
            Midi.Instrument.DrawbarOrgan,
            Midi.Instrument.Dulcimer,
            Midi.Instrument.ElectricBassFinger,
            Midi.Instrument.ElectricBassPick,
            Midi.Instrument.ElectricGrandPiano,
            Midi.Instrument.ElectricGuitarClean,
            Midi.Instrument.ElectricGuitarJazz,
            Midi.Instrument.ElectricGuitarMuted,
            Midi.Instrument.ElectricPiano1,
            Midi.Instrument.ElectricPiano2,
            Midi.Instrument.EnglishHorn,
            Midi.Instrument.Fiddle,
            Midi.Instrument.Flute,
            Midi.Instrument.FrenchHorn,
            Midi.Instrument.FretlessBass,
            Midi.Instrument.FX1Rain,
            Midi.Instrument.FX2Soundtrack,
            Midi.Instrument.FX3Crystal,
            Midi.Instrument.FX4Atmosphere,
            Midi.Instrument.FX5Brightness,
            Midi.Instrument.FX6Goblins,
            Midi.Instrument.FX7Echoes,
            Midi.Instrument.FX8SciFi,
            Midi.Instrument.Glockenspiel,
            Midi.Instrument.GuitarFretNoise,
            Midi.Instrument.GuitarHarmonics,
            Midi.Instrument.Gunshot,
            Midi.Instrument.Harmonica,
            Midi.Instrument.Harpsichord,
            Midi.Instrument.Helicopter,
            Midi.Instrument.HonkyTonkPiano,
            Midi.Instrument.Kalimba,
            Midi.Instrument.Koto,
            Midi.Instrument.Lead1Square,
            Midi.Instrument.Lead2Sawtooth,
            Midi.Instrument.Lead3Calliope,
            Midi.Instrument.Lead4Chiff,
            Midi.Instrument.Lead5Charang,
            Midi.Instrument.Lead6Voice,
            Midi.Instrument.Lead7Fifths,
            Midi.Instrument.Lead8BassPlusLead,
            Midi.Instrument.Marimba,
            Midi.Instrument.MelodicTom,
            Midi.Instrument.MusicBox,
            Midi.Instrument.MutedTrumpet,
            Midi.Instrument.Oboe,
            Midi.Instrument.Ocarina,
            Midi.Instrument.OrchestraHit,
            Midi.Instrument.OrchestralHarp,
            Midi.Instrument.OverdrivenGuitar,
            Midi.Instrument.Pad1NewAge,
            Midi.Instrument.Pad2Warm,
            Midi.Instrument.Pad3Polysynth,
            Midi.Instrument.Pad4Choir,
            Midi.Instrument.Pad5Bowed,
            Midi.Instrument.Pad6Metallic,
            Midi.Instrument.Pad7Halo,
            Midi.Instrument.Pad8Sweep,
            Midi.Instrument.PanFlute,
            Midi.Instrument.PercussiveOrgan,
            Midi.Instrument.Piccolo,
            Midi.Instrument.PizzicatoStrings,
            Midi.Instrument.Recorder,
            Midi.Instrument.ReedOrgan,
            Midi.Instrument.ReverseCymbal,
            Midi.Instrument.RockOrgan,
            Midi.Instrument.Seashore,
            Midi.Instrument.Shakuhachi,
            Midi.Instrument.Shamisen,
            Midi.Instrument.Shanai,
            Midi.Instrument.Sitar,
            Midi.Instrument.SlapBass1,
            Midi.Instrument.SlapBass2,
            Midi.Instrument.SopranoSax,
            Midi.Instrument.SteelDrums,
            Midi.Instrument.StringEnsemble1,
            Midi.Instrument.StringEnsemble2,
            Midi.Instrument.SynthBass1,
            Midi.Instrument.SynthBass2,
            Midi.Instrument.SynthBrass1,
            Midi.Instrument.SynthBrass2,
            Midi.Instrument.SynthDrum,
            Midi.Instrument.SynthStrings1,
            Midi.Instrument.SynthStrings2,
            Midi.Instrument.SynthVoice,
            Midi.Instrument.TaikoDrum,
            Midi.Instrument.TangoAccordion,
            Midi.Instrument.TelephoneRing,
            Midi.Instrument.TenorSax,
            Midi.Instrument.Timpani,
            Midi.Instrument.TinkleBell,
            Midi.Instrument.TremoloStrings,
            Midi.Instrument.Trombone,
            Midi.Instrument.Trumpet,
            Midi.Instrument.Tuba,
            Midi.Instrument.TubularBells,
            Midi.Instrument.Vibraphone,
            Midi.Instrument.Viola,
            Midi.Instrument.Violin,
            Midi.Instrument.VoiceOohs,
            Midi.Instrument.Whistle,
            Midi.Instrument.Woodblock,
            Midi.Instrument.Xylophone
        };
        public static int Interval
        {
            get
            {
                return rand.Next(-2, 3);
            }
        }
        public static string[] majorflats = new string[] { "C", "F", "B♭", "E♭", "A♭", "D♭", "G♭" };
        public static string[] majorsharps = new string[] { "C", "G", "D", "A", "E", "B", "F#" };
        public static string[] minorflats = new string[] { "A", "D", "G", "C", "F", "B♭", "E♭" };
        public static string[] minorsharps = new string[] { "A", "E", "B", "F#", "C#", "G#", "D#" };
        public static Note[] Naturals
        {
            get
            {
                List<Note> notes = new List<Note>();
                foreach (Note note in Notes)
                {
                    if (!note.ToString().Contains("sharp"))
                    {
                        notes.Add(note);
                    }
                }
                return notes.ToArray();
            }
        }
        public static Note[] Notes = new Note[]
        {
            Note.C,
            Note.Csharp,
            Note.D,
            Note.Dsharp,
            Note.E,
            Note.F,
            Note.Fsharp,
            Note.G,
            Note.Gsharp,
            Note.A,
            Note.Asharp,
            Note.B
        };
        public static NoteType[] NoteTypes = new NoteType[]
        {
            NoteType.SemiQuaver,
            NoteType.Quaver,
            NoteType.Crotchet,
            NoteType.Minim,
            NoteType.SemiBreve
        };
        public static Random rand = new Random();
        #region Pitches
        public static Pitch[] Pitches = new Pitch[]
        {
            //Negative 1
            Pitch.ANeg1,
            Pitch.ASharpNeg1,
            Pitch.BNeg1,
            Pitch.CNeg1,
            Pitch.CSharpNeg1,
            Pitch.DNeg1,
            Pitch.DSharpNeg1,
            Pitch.ENeg1,
            Pitch.FNeg1,
            Pitch.FSharpNeg1,
            Pitch.GNeg1,
            Pitch.GSharpNeg1,
            //0
            Pitch.A0,
            Pitch.ASharp0,
            Pitch.B0,
            Pitch.C0,
            Pitch.CSharp0,
            Pitch.D0,
            Pitch.DSharp0,
            Pitch.E0,
            Pitch.F0,
            Pitch.FSharp0,
            Pitch.G0,
            Pitch.GSharp0,
            //1
            Pitch.A1,
            Pitch.ASharp1,
            Pitch.B1,
            Pitch.C1,
            Pitch.CSharp1,
            Pitch.D1,
            Pitch.DSharp1,
            Pitch.E1,
            Pitch.F1,
            Pitch.FSharp1,
            Pitch.G1,
            Pitch.GSharp1,
            //2
            Pitch.A2,
            Pitch.ASharp2,
            Pitch.B2,
            Pitch.C2,
            Pitch.CSharp2,
            Pitch.D2,
            Pitch.DSharp2,
            Pitch.E2,
            Pitch.F2,
            Pitch.FSharp2,
            Pitch.G2,
            Pitch.GSharp2,
            //3
            Pitch.A3,
            Pitch.ASharp3,
            Pitch.B3,
            Pitch.C3,
            Pitch.CSharp3,
            Pitch.D3,
            Pitch.DSharp3,
            Pitch.E3,
            Pitch.F3,
            Pitch.FSharp3,
            Pitch.G3,
            Pitch.GSharp3,
            //4
            Pitch.A4,
            Pitch.ASharp4,
            Pitch.B4,
            Pitch.C4,
            Pitch.CSharp4,
            Pitch.D4,
            Pitch.DSharp4,
            Pitch.E4,
            Pitch.F4,
            Pitch.FSharp4,
            Pitch.G4,
            Pitch.GSharp4,
            //5
            Pitch.A5,
            Pitch.ASharp5,
            Pitch.B5,
            Pitch.C5,
            Pitch.CSharp5,
            Pitch.D5,
            Pitch.DSharp5,
            Pitch.E5,
            Pitch.F5,
            Pitch.FSharp5,
            Pitch.G5,
            Pitch.GSharp5,
            //6
            Pitch.A6,
            Pitch.ASharp6,
            Pitch.B6,
            Pitch.C6,
            Pitch.CSharp6,
            Pitch.D6,
            Pitch.DSharp6,
            Pitch.E6,
            Pitch.F6,
            Pitch.FSharp6,
            Pitch.G6,
            Pitch.GSharp6,
            //7
            Pitch.A7,
            Pitch.ASharp7,
            Pitch.B7,
            Pitch.C7,
            Pitch.CSharp7,
            Pitch.D7,
            Pitch.DSharp7,
            Pitch.E7,
            Pitch.F7,
            Pitch.FSharp7,
            Pitch.G7,
            Pitch.GSharp7,
            //8
            Pitch.A8,
            Pitch.ASharp8,
            Pitch.B8,
            Pitch.C8,
            Pitch.CSharp8,
            Pitch.D8,
            Pitch.DSharp8,
            Pitch.E8,
            Pitch.F8,
            Pitch.FSharp8,
            Pitch.G8,
            Pitch.GSharp8,
            //9
            Pitch.C9,
            Pitch.CSharp9,
            Pitch.D9,
            Pitch.DSharp9,
            Pitch.E9,
            Pitch.F9,
            Pitch.FSharp9,
            Pitch.G9,
        };
        #endregion
        public static Note[] Sharps = new Note[]
        {
            Note.Fsharp,
            Note.Csharp,
            Note.Gsharp,
            Note.Dsharp,
            Note.Asharp,
            Note.F
        };
        public static bool ShiftPressed
        {
            get
            {
                return System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift);
            }
        }
        public const float SmallestNoteValue = 0.25f;
        #endregion
        #region As
        public static void Add(ref List<FullNoteType> patterns, FullNoteType typetoadd, int times)
        {
            for (int i = 0; i < times; i++)
            {
                patterns.Add(typetoadd);
            }
        }
        public static void AddIfNotAtEnd(ref string mainstring, string value)
        {
            if (!mainstring.EndsWith(value))
            {
                mainstring += value;
            }
        }
        #endregion
        #region Cs
        public static void ChangeInstrument(Channel channel, Instrument instrument)
        {
            if (!device.IsOpen)
            {
                device.Open();
            }
            device.SendProgramChange(channel, instrument);
        }
        public static Music CombineMusic(Music[] songs)
        {
            List<Sound> sounds = new List<Sound>();
            foreach (Music song in songs)
            {
                sounds.AddRange(song.Sounds);
            }
            Music music = new Music(sounds.ToArray(), songs[0].Channel);
            music.FlatNSharps = songs[0].FlatNSharps;
            int length = songs[0].Sounds.Length;
            music.TimeSignature = songs[0].TimeSignature;
            return music;
        }
        #endregion
        #region Ds
        #endregion
        #region Fs
        public static double Frequency(int key)
        {
            double num = key - 49;
            double num2 = num / 12;
            double num3 = Math.Pow(2, num2);
            double num4 = num3 * 440;
            num4 = Math.Round(num4);
            return num4;
        }
        public static double Frequency(decimal key)
        {
            return Frequency(int.Parse(key.ToString()));
        }
        #endregion
        #region Gs
        public static int[] GetAllDurations(int tempo)
        {
            List<int> durations = new List<int>();
            foreach (FullNoteType nt in GetAllNoteTypes())
            {
                durations.Add(nt.GetDuration(tempo));
            }
            return durations.ToArray();
        }
        public static FullNoteType[] GetAllNoteTypes()
        {
            List<FullNoteType> notetypes = new List<FullNoteType>();
            for (int i = 0; i < Fncs.NoteTypes.Length; i++)
            {
                NoteType nt = Fncs.NoteTypes[i];
                notetypes.Add(new FullNoteType(false, false, nt));
                notetypes.Add(new FullNoteType(false, true, nt));
                notetypes.Add(new FullNoteType(true, false, nt));
                notetypes.Add(new FullNoteType(true, true, nt));
            }
            return notetypes.ToArray();
        }
        public static float GetBeatIndex(this FullNoteType note)
        {
            float beatindex = SmallestNoteValue * Math.Pow(2, note.NoteType.GetNoteTypeIndex()).ObjectToFloatParse();
            if (note.Third)
            {
                beatindex *= 2f / 3f;
            }
            if (note.Dotted)
            {
                if (note.NoteType != NoteType.SemiQuaver)
                {
                    FullNoteType temp = new FullNoteType(false, note.Third, NoteTypes[note.NoteType.GetNoteTypeIndex() - 1]);
                    beatindex += temp.GetBeatIndex();
                }
            }
            return beatindex;
        }
        public static float GetBeatIndex(this Pattern pattern)
        {
            float returner = 0;
            foreach (FullNoteType notetype in pattern.NoteTypes)
            {
                returner += notetype.GetBeatIndex();
            }
            return returner;
        }
        /// <summary>
        /// Get the total duration of a an array of "Sound" instances.
        /// </summary>
        /// <param name="sounds"></param>
        /// <returns></returns>
        public static int GetDuration(this Sound[] sounds)
        {
            int duration = 0;
            foreach (Sound sound in sounds)
            {
                duration += sound.FullNoteType.GetDuration(sound.Tempo);
            }
            return duration;
        }
        /// <summary>
        /// Get the duration of a single "FullNoteType" instance.
        /// </summary>
        /// <param name="notetype">The type of note.</param>
        /// <param name="tempo">The tempo that it would be played at.</param>
        /// <returns></returns>
        public static int GetDuration(this FullNoteType notetype, int tempo)
        {
            return notetype.NoteType.GetDuration(notetype.Dotted, notetype.Third, tempo);
        }
        public static int GetDuration(this NoteType notetype, bool dotted, bool third, int tempo)
        {
            int notelength = 60000 / tempo;
            if (notetype == NoteType.SemiQuaver)
            {
                notelength /= 4;
            }
            if (notetype == NoteType.Quaver)
            {
                notelength /= 2;
            }
            if (notetype == NoteType.Minim)
            {
                notelength *= 2;
            }
            if (notetype == NoteType.SemiBreve)
            {
                notelength *= 4;
            }
            //float nt = (int)notetype.ObjectToFloatParse();
            //notelength = (notelength *nt/16).ObjectToIntegerParse();
            if (dotted)
            {
                notelength += notelength / 2;
            }
            if (third)
            {
                notelength = notelength * 2 / 3;
            }
            return notelength;
        }
        /// <summary>
        /// Gets an enumeration value from the given object and enumeration type.
        /// </summary>
        /// <typeparam name="T">The enumeration type that will be returned.</typeparam>
        /// <param name="obj">The text or other object that is compared to all possible enum values.</param>
        /// <returns></returns>
        public static T GetEnumValue<T>(this object obj)
        {
            string text = obj.ToString();
            Array enumarray;
            try
            {
                enumarray = Enum.GetValues(typeof(T));
            }
            catch
            {
                throw new Exception("Type is not an enumeration.");
            }
            foreach (T value in enumarray)
            {
                if (value.ToString().ToLower() == text.ToLower())
                {
                    return value;
                }
            }
            throw new Exception("Unknown value :/");
        }
        public static string GetFlat(this Note note)
        {
            if (!note.ToString().Contains("sharp"))
            {
                throw new Exception("Go fuck yourself!");
            }
            Note nextnote = note.TransposeBy(1);
            return nextnote + "flat";
        }
        public static FlatsNSharps GetFlatsNSharps(FlatSharp flatorsharp, MajorOrMinor majororminor, string name)
        {
            int index;
            FlatSharp flatsharp;
            if (flatorsharp == FlatSharp.Flat)
            {
                if (majororminor == MajorOrMinor.Major)
                {
                    index = majorflats.ToList().IndexOf(name);
                }
                else
                {
                    index = minorflats.ToList().IndexOf(name);
                }
                flatsharp = FlatSharp.Flat;
            }
            else if (flatorsharp == FlatSharp.Natural)
            {
                if (majororminor == MajorOrMinor.Major)
                {
                    if (majorflats.Contains(name))
                    {
                        index = majorflats.ToList().IndexOf(name);
                        flatsharp = FlatSharp.Flat;
                    }
                    else
                    {
                        index = majorsharps.ToList().IndexOf(name);
                        flatsharp = FlatSharp.Sharp;
                    }
                }
                else
                {
                    if (minorflats.Contains(name))
                    {
                        index = minorflats.ToList().IndexOf(name);
                        flatsharp = FlatSharp.Flat;
                    }
                    else
                    {
                        index = minorsharps.ToList().IndexOf(name);
                        flatsharp = FlatSharp.Sharp;
                    }
                }
            }
            else
            {
                if (majororminor == MajorOrMinor.Major)
                {
                    index = majorsharps.ToList().IndexOf(name);
                }
                else
                {
                    index = minorsharps.ToList().IndexOf(name);
                }
                flatsharp = FlatSharp.Sharp;
            }
            return new FlatsNSharps(flatsharp, index);
        }
        public static string GetKeySignature(this FlatsNSharps fns)
        {
            return GetKeySignature(fns.FlatOrSharp, fns.Quantity);
        }
        public static string GetKeySignature(FlatSharp flatsharp, int quantity)
        {
            return GetKeySignature(flatsharp, quantity, MajorOrMinor.Major) + " or " + GetKeySignature(flatsharp, quantity, MajorOrMinor.Minor);
        }
        public static string GetKeySignature(FlatSharp flatsharp, int quantity, MajorOrMinor majororminor)
        {

            if (flatsharp == FlatSharp.Flat)
            {
                if (majororminor == MajorOrMinor.Major)
                {
                    return Fncs.majorflats[quantity] + " major";
                }
                else
                {
                    return Fncs.minorflats[quantity] + " minor";
                }
            }
            else if (flatsharp == FlatSharp.Sharp)
            {
                if (majororminor == MajorOrMinor.Major)
                {
                    return Fncs.majorsharps[quantity] + " major";
                }
                else
                {
                    return Fncs.minorsharps[quantity] + " minor";
                }
            }
            else
            {
                if (majororminor == MajorOrMinor.Major)
                {
                    return "C major";
                }
                else
                {
                    return "A minor";
                }
            }
        }
        public static int GetMidoIndex(this Sound sound)
        {
            return sound.NoteIndex + sound.Pitch * 12;
        }
        public static Music GetMusicFromMidiFile(string filepath, int channel)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception("File doesn't exist you faggot");
            }
            MidiFile midifile = new MidiFile(filepath);
            MidiEventCollection events = new MidiEventCollection(midifile.FileFormat, midifile.DeltaTicksPerQuarterNote);
            List<Sound> sounds = new List<Sound>();
            int tempo = 0;
            foreach (IList<MidiEvent> midi in midifile.Events)
            {
                foreach (MidiEvent me in midi)
                {
                    if (me is TempoEvent)
                    {
                        tempo = (me as TempoEvent).Tempo.ObjectToIntegerParse();
                        break;
                    }
                }
                if (tempo != 0)
                {
                    break;
                }
            }
            int errors = 0;
            foreach (IList<MidiEvent> midi in midifile.Events)
            {
                for (int i = 0; i < midi.Count; i++)
                {
                    try
                    {
                        MidiEvent me = midi[i];
                        if (me.Channel == channel)
                        {
                            if (me.CommandCode == MidiCommandCode.NoteOn)
                            {
                                NoteEvent ne = (NoteEvent)me;
                                string notename = ne.NoteName.Replace("#", "Sharp");
                                int pitch = notename.Substring(notename.Length - 1).ObjectToIntegerParse();
                                Note note = notename.Substring(0, notename.Length - 1).GetEnumValue<Note>();
                                int duration = 0;
                                if (i < midi.Count - 1)
                                {
                                    duration = (midi[i + 1].AbsoluteTime - midi[i].AbsoluteTime).ObjectToIntegerParse();
                                }
                                FullNoteType nt = GetNoteType(duration, tempo);
                                sounds.Add(new Sound(note, nt, pitch,tempo));
                            }
                            if (me is TempoEvent)
                            {
                                tempo = ((TempoEvent)me).Tempo.ObjectToIntegerParse();
                            }
                        }
                    }
                    catch
                    {
                        errors++;
                    }
                }
            }
            return new Music(sounds.ToArray(), ("Channel" + channel).GetEnumValue<Channel>());
        }
        public static Note GetNoteFromIndex(this int index)
        {
            return index.GetNoteFromIndex(Notes);
        }
        public static Note GetNoteFromIndex(this int index, Note[] availablenotes)
        {
            while (index >= availablenotes.Length)
            {
                index -= availablenotes.Length;
            }
            while (index < 0)
            {
                index += availablenotes.Length;
            }
            return availablenotes[index];
        }
        public static int GetNoteIndex(this Note note)
        {
            return note.GetNoteIndex(Notes);
        }
        public static int GetNoteIndex(this Note note, Note[] availablenotes)
        {
            for (int i = 0; i < availablenotes.Length; i++)
            {
                if (note == availablenotes[i])
                {
                    return i;
                }
            }
            return 1;
            //throw new Exception("Unknown note: " + note.ToString());
        }
        public static FullNoteType GetNoteType(int duration, int tempo)
        {
            List<int> durations = GetAllDurations(tempo).ToList();
            int closestduration = durations.Aggregate((x, y) => Math.Abs(x - duration) < Math.Abs(y - duration) ? x : y);
            for (int i = 0; i < GetAllNoteTypes().Length; i++)
            {
                if (GetAllDurations(tempo)[i] == closestduration)
                {
                    return GetAllNoteTypes()[i];
                }
            }
            return null;
        }
        public static int GetNoteTypeIndex(this NoteType notetype)
        {
            for (int i = 0; i < NoteTypes.Length; i++)
            {
                if (notetype == NoteTypes[i])
                {
                    return i;
                }
            }
            throw new Exception("Unknown note type");
        }
        public static Music GetSong(this Genre genre, FormType form, Channel channel)
        {
            Music A = genre.GenerateSong(channel);
            Music B = genre.GenerateSong(A.FlatNSharps, channel);
            Music C = genre.GenerateSong(A.FlatNSharps, channel);
            if (form == FormType.Binary)
            {
                return CombineMusic(new Music[] { A, B });
            }
            else if (form == FormType.Ternary)
            {
                return CombineMusic(new Music[] { A, B, A });
            }
            else if (form == FormType.Rondo)
            {
                return CombineMusic(new Music[] { A, B, A, C, A });
            }
            else if (form == FormType.Sonata_Rondo)
            {
                return CombineMusic(new Music[] { A, B, A, C, A, B, A });
            }
            else //if (form == FormType.Arch)
            {
                return CombineMusic(new Music[] { A, B, C, B, A });
            }
        }
        public static Music GetSong(this Pattern[] patterns, int tempo, Channel channel)
        {
            Note previousnote = Fncs.RandomNote(patterns[0].AvailableNotes);
            List<Sound> notes = new List<Sound>();
            int pitch = 3;
            foreach (Pattern pattern in patterns)
            {
                for (int i = 0; i < pattern.DifferenceFromStart.Length; i++)
                {
                    if (pattern.DifferenceFromStart[i].PlayType == PlayType.Note)
                    {
                        if (previousnote.GetNoteIndex() > previousnote.TransposeBy(pattern.DifferenceFromStart[i].NoteInterval, pattern.AvailableNotes).GetNoteIndex())
                        {
                            if (pitch < 5)
                            {
                                pitch++;
                            }
                        }
                        if (previousnote.GetNoteIndex() - pattern.DifferenceFromStart[i].NoteInterval < 0)
                        {
                            if (pitch > 3)
                            {
                                pitch--;
                            }
                        }
                        notes.Add(new Sound(previousnote.TransposeBy(pattern.DifferenceFromStart[i].NoteInterval, pattern.AvailableNotes), pattern.NoteTypes[i], pitch));
                        previousnote = previousnote.TransposeBy(pattern.DifferenceFromStart[i].NoteInterval, pattern.AvailableNotes);
                    }
                    else
                    {
                        notes.Add(new Sound(Note.Rest,pattern .NoteTypes[i], pitch));
                    }
                }
            }
            return new Music(notes.ToArray(), channel);
        }
        #endregion
        #region Is
        #endregion
        #region Ls
        /// <summary>
        /// Create an instance of the "Music" class from given text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Music LoadTextAsMusic(string text)
        {
            try
            {
                string[] lines = text.Split("\n".ToCharArray());
                string firstline = lines[0];
                string flatsharp = FortogamarBlast.Fncs.TextBetween_String_List("FlatOrSharp: ", ";", firstline)[0];
                FlatSharp FlatSharp = flatsharp.GetEnumValue<FlatSharp>();
                int quantity = int.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Quantity: ", ";", firstline)[0]);
                int tempo = int.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Tempo: ", ";", firstline)[0]);
                FlatsNSharps flatsnsharps = new FlatsNSharps(FlatSharp, quantity);
                List<Sound> sounds = new List<Sound>();
                for (int i = 1; i < lines.Length; i++)
                {
                    Note note = FortogamarBlast.Fncs.TextBetween_String_List("Note: ", ";", lines[i])[0].GetEnumValue<Note>();
                    NoteType notetype = FortogamarBlast.Fncs.TextBetween_String_List("NoteType: ", ";", lines[i])[0].GetEnumValue<NoteType>();
                    bool dotted = bool.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Dotted: ", ";", lines[i])[0]);
                    bool triplet = bool.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Triplet: ", ";", lines[i])[0]);
                    int pitch = int.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Pitch: ", ";", lines[i])[0]);
                    sounds.Add(new Sound(note, new FullNoteType(dotted, triplet, notetype), pitch));
                }
                return new Music(sounds.ToArray(), Midi.Channel.Channel5);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        #endregion
        #region Ns
        /// <summary>
        /// Create a new pattern from another that will have the same rhythm as the previous one but the notes will be changed.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Pattern NewPatternFromSeed(this Pattern pattern)
        {
            List<FullNoteType> notetypes = new List<FullNoteType>();
            List<Interval> intervals = new List<Interval>();
            for (int i = 0; i < pattern.NoteTypes.Length; i++)
            {
                notetypes.Add(pattern.NoteTypes[i]);
                intervals.Add(RandomInterval());
            }
            return new Pattern(intervals.ToArray(), notetypes.ToArray(), pattern.FlatsNSharps);
        }
        public static string Normalise(this Note note, FlatSharp flatorsharp)
        {
            string returner = note.ToString();
            if (returner.Contains("sharp"))
            {
                if (flatorsharp == FlatSharp.Sharp)
                {
                    returner = returner.Replace("sharp", "#");
                }
                else if (flatorsharp == FlatSharp.Flat)
                {
                    returner = note.GetFlat();
                    returner = returner.Replace("flat", "♭");
                }
            }
            return returner;
        }
        public static Note[] NotesFromKey(this FlatsNSharps flatsnsharps)
        {
            List<Note> notes = new List<Note>();
            if (flatsnsharps.FlatOrSharp == FlatSharp.Flat)
            {
                List<Note> flats = new List<Note>();
                for (int i = 0; i < flatsnsharps.Quantity; i++)
                {
                    flats.Add(Flats[i]);
                }
                foreach (Note note in Naturals)
                {
                    if (flats.Contains(note.TransposeBy(-1)))
                    {
                        notes.Add(note.TransposeBy(-1));
                    }
                    else
                    {
                        notes.Add(note);
                    }
                }
            }
            else if (flatsnsharps.FlatOrSharp == FlatSharp.Natural)
            {
                notes = Naturals.ToList();
            }
            else
            {
                List<Note> sharps = new List<Note>();
                for (int i = 0; i < flatsnsharps.Quantity; i++)
                {
                    sharps.Add(Sharps[i]);
                }
                foreach (Note note in Naturals)
                {
                    if (sharps.Contains(note.TransposeBy(1)))
                    {
                        notes.Add(note.TransposeBy(1));
                    }
                    else
                    {
                        notes.Add(note);
                    }
                }
            }
            //notes.Add(Note.Rest);
            return notes.ToArray();
        }
        #endregion
        #region Os
        /// <summary>
        /// Returns a float depending on the value of "number".ToString(), if this value is invalid then an exception is thrown.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float ObjectToFloatParse(this object number)
        {
            try
            {
                return float.Parse(number.ToString());
            }
            catch
            {
                throw new Exception("This is not a fucking float!");
            }
        }
        public static int ObjectToIntegerParse(this object number)
        {
            try
            {
                return int.Parse(number.ToString());
            }
            catch
            {
                throw new Exception("That's not a fucking integer you bitch!");
            }
        }
        public static Music OpenMusic(AudioFileType aft,string filepath)
        {
            if (aft == AudioFileType.WAV)
            {
                throw new Exception("Can't open this type");
            }
            if (!File.Exists(filepath))
            {
                throw new Exception("File doesn't exist you faggot");
            }
            if (aft == AudioFileType.Midi)
            {
                return GetMusicFromMidiFile(filepath, 1);
            }
            else
            {
                return LoadTextAsMusic(File.ReadAllText(filepath));
            }
        }
        
        #endregion
        #region Ps
        public static void PlayNote(Note note)
        {
            PlayNote(note, new FullNoteType(NoteType.Crotchet), 4, 120, Channel.Channel1);
        }
        public static void PlayNote(Note note, int duration, int pitch, int tempo, Channel channel)
        {
            try
            {
                if (note != Note.Rest)
                {
                    if (!device.IsOpen)
                    {
                        device.Open();
                    }
                    Pitch pitchie = (note + "" + pitch).GetEnumValue<Pitch>();
                    device.SendNoteOn(channel, pitchie, 100);
                    Thread.Sleep(duration);
                    device.SendNoteOff(channel, pitchie, 100);
                    /*int noteindex = note.GetNoteIndex();
                    double value = Fncs.Frequency((noteindex + 4) + (pitch * 12));
                    Console.Beep(value.Round().ObjectToIntegerParse(), duration);*/
                }
                else
                {
                    Thread.Sleep(duration);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public static void PlayNote(Note note, FullNoteType notetype, int pitch, int tempo, Channel channel)
        {
            PlayNote(note, notetype.NoteType, notetype.Dotted, notetype.Third, pitch, tempo, channel);
        }
        public static void PlayNote(Note note, NoteType type, bool dotted, bool third, int pitch, int tempo, Channel channel)
        {
            int duration = type.GetDuration(dotted, third, tempo);
            PlayNote(note, duration, pitch, tempo, channel);
        }
        public static void PlayNoteAsBeep(Note note,int duration,int pitch,Channel channel)
        {
            try
            {
                if (note != Note.Rest)
                {
                    if (!device.IsOpen)
                    {
                        device.Open();
                    }
                    int noteindex = note.GetNoteIndex();
                    double value = Fncs.Frequency((noteindex + 4) + (pitch * 12));
                    Console.Beep(value.Round().ObjectToIntegerParse(), duration);
                }
                else
                {
                    Thread.Sleep(duration);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public static void PlaySound(this Sound sound, Channel channel)
        {
            try
            {
                PlayNote(sound.Note, sound.FullNoteType, sound.Pitch, sound.Tempo, channel);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
        #region Rs
        public static bool RandomBool()
        {
            int num = rand.Next(2);
            if (num < 1)
            {
                return false;
            }
            return true;
        }
        public static FlatSharp RandomFlatSharp()
        {
            int index = rand.Next(3);
            if (index == 0)
            {
                return FlatSharp.Flat;
            }
            else if (index == 1)
            {
                return FlatSharp.Natural;
            }
            else
            {
                return FlatSharp.Sharp;
            }
        }
        public static FlatsNSharps RandomFlatsNSharps()
        {
            return RandomFlatsNSharps(6);
        }
        public static FlatsNSharps RandomFlatsNSharps(int maxnumber)
        {
            FlatSharp flatsharp = RandomFlatSharp();
            int number = 0;
            if (flatsharp != FlatSharp.Natural)
            {
                number = rand.Next(1, maxnumber + 1);
            }
            return new FlatsNSharps(flatsharp, number);
        }
        public static FullNoteType RandomFullNoteType()
        {
            return RandomFullNoteType(4);
        }
        public static FullNoteType RandomFullNoteType(float beatindex)
        {
            return RandomFullNoteType(beatindex, false, false);
        }
        public static FullNoteType RandomFullNoteType(float beatindex, bool potentiallydotted, bool potentialltriplet)
        {
            List<FullNoteType> types = new List<FullNoteType>();
            foreach (NoteType type in NoteTypes)
            {
                FullNoteType tempnodotnothird = new FullNoteType(false, false, type);
                FullNoteType tempdotnothird = new FullNoteType(true, false, type);
                FullNoteType tempnodotthird = new FullNoteType(false, true, type);
                if (tempdotnothird.GetBeatIndex() <= beatindex)
                {
                    if (type != NoteType.SemiQuaver)
                    {
                        if (potentiallydotted)
                        {
                            types.Add(tempdotnothird);
                        }
                    }
                    if (potentialltriplet)
                    {
                        types.Add(tempnodotthird);
                    }
                    types.Add(tempnodotnothird);
                }
                else if (tempnodotnothird.GetBeatIndex() <= beatindex)
                {
                    types.Add(tempnodotnothird);
                    if (potentialltriplet)
                    {
                        types.Add(tempnodotthird);
                    }
                }
                else if (tempnodotthird.GetBeatIndex() <= beatindex)
                {
                    if (potentialltriplet)
                    {
                        types.Add(tempnodotthird);
                    }
                }
            }
            int index = rand.Next(types.Count);
            return types[index];
        }
        public static Interval RandomInterval()
        {
            int index = rand.Next(14);
            if (index < 13)
            {
                return new Interval(PlayType.Note, Fncs.Interval);
            }
            else
            {
                return new Interval(PlayType.Rest);
            }
        }
        public static Note RandomNote()
        {
            return RandomNote(Notes);
        }
        public static Note RandomNote(Note[] notes)
        {
            int index = rand.Next(notes.Length);
            return notes[index];
        }
        public static NoteType RandomNoteType()
        {
            int index = rand.Next(NoteTypes.Length);
            return NoteTypes[index];
        }
        public static int RandomNumber(int startrange, int endrange, int multipleof)
        {
            int number = rand.Next(startrange, endrange);
            while (number % multipleof != 0)
            {
                number = rand.Next(startrange, endrange);
            }
            return number;
        }
        public static Pattern RandomPattern(float beats)
        {
            FlatsNSharps fns = RandomFlatsNSharps();
            return RandomPattern(beats, fns);
        }
        public static Pattern RandomPattern(float beats, FlatsNSharps flatsnsharps)
        {
            List<FullNoteType> notetypes = new List<FullNoteType>();
            float tempbeats = 0f;
            float remaining = beats;
            while (tempbeats < beats)
            {
                notetypes.Add(Fncs.RandomFullNoteType(remaining));
                tempbeats += notetypes[notetypes.Count - 1].GetBeatIndex();
                remaining = beats - tempbeats;
            }
            List<Interval> notedifferences = new List<Interval>();
            for (int i = 0; i < notetypes.Count; i++)
            {
                notedifferences.Add(RandomInterval());
            }
            return new Pattern(notedifferences.ToArray(), notetypes.ToArray(), flatsnsharps);
        }
        public static Sound RandomSound()
        {
            return RandomSound(Notes, 4);
        }
        public static Sound RandomSound(Note[] notes, float beatindex)
        {
            Note note = RandomNote(notes);
            FullNoteType type = RandomFullNoteType(beatindex);
            int pitch = rand.Next(2, 6);
            return new Sound(note, type, pitch);
        }
        public static Sound RandomSound(float beatindex)
        {
            Note note = RandomNote();
            FullNoteType type = RandomFullNoteType(beatindex);
            int pitch = rand.Next(2, 6);
            return new Sound(note, type, pitch);
        }
        public static string Round(this double num)
        {
            double returner = Math.Round(num);
            return returner.ToString();
        }
        #endregion
        #region Ss
        public static void Save(AudioFileType filetype, string filepath, Music music)
        {
            if (filetype == AudioFileType.Midi)
            {
                MidiEventCollection midievents = new MidiEventCollection(2, 960);
                long time = 0;
                IList<MidiEvent> track = new List<MidiEvent>();
                foreach (Sound sound in music.Sounds)
                {
                    int velocity = 127;
                    int notenumber;
                    if (sound.Note == MusicLibrary3.Note.Rest)
                    {
                        velocity = 0;
                        notenumber = 0;
                    }
                    else
                    {
                        notenumber = (sound.Pitch * 12) + (sound.NoteIndex + 4);
                    }
                    track.Add(new NoteEvent(time, 1, MidiCommandCode.NoteOn, notenumber, velocity));
                    track.Add(new NoteEvent(time + sound.FullNoteType.GetDuration(sound.Tempo), 1, MidiCommandCode.NoteOff, notenumber, 100));
                    time += sound.FullNoteType.GetDuration(sound.Tempo);
                }
                long absolutetime = track[track.Count - 1].AbsoluteTime;
                midievents.AddTrack(track);
                midievents.AddEvent(new MetaEvent(MetaEventType.EndTrack, 0, absolutetime), 0);
                AddIfNotAtEnd(ref filepath, ".mid");
                MidiFile.Export(filepath, midievents);
                MessageBox.Show("Done");
            }
            if (filetype == AudioFileType.TextRepresentation)
            {
                string textie = "Key signature: " + music.FlatNSharps.GetKeySignature() + "; FlatOrSharp: " + music.FlatNSharps.FlatOrSharp + "; Quantity: " + music.FlatNSharps.Quantity + ";";
                foreach (Sound sound in music.Sounds)
                {
                    textie += "\tNote: " + sound.Note + "; NoteType: " + sound.FullNoteType.NoteType + "; Pitch: " + sound.Pitch + "; Triplet: " + sound.FullNoteType.Third + "; Dotted: " + sound.FullNoteType.Dotted + "; Tempo: "+sound.Tempo;
                }
                AddIfNotAtEnd(ref filepath, ".txt");
                File.WriteAllText(filepath, textie);
            }
            if (filetype == AudioFileType.WAV)
            {
                WaveGenerator wg = new WaveGenerator(music);
                AddIfNotAtEnd(ref filepath, ".wav");
                wg.Save(filepath);
            }
            
            /*if (filetype == AudioFileType.MP3)
            {

            }*/
        }
        #endregion
        #region Ts
        public static List<StaveItem> ToStave(this List<Sound> sounds)
        {
            List<StaveItem> stave = new List<StaveItem>();
            foreach (Sound sound in sounds)
            {
                stave.Add(new StaveItem(stave.Count, sound));
            }
            return stave;
        }
        public static List<StaveItem> ToStave(this Sound[] sounds)
        {
            return sounds.ToList().ToStave();
        }
        public static Note TransposeBy(this Note note, int semitones)
        {
            return note.TransposeBy(semitones, Notes);
        }
        public static Note TransposeBy(this Note note, int semitones, Note[] availablenotes)
        {
            int index = note.GetNoteIndex(availablenotes) + semitones;
            return index.GetNoteFromIndex(availablenotes);
        }
        #endregion
    }
    #endregion
    #region Enumerations
    /// <summary>
    /// Used to represent a type of audio/midi file in the event of manipulating such files.
    /// </summary>
    public enum AudioFileType
    {
        Midi ,TextRepresentation,/*MP3,*/ WAV
    }
    /// <summary>
    /// An enumeration to represent the different volumes at which notes are played.
    /// </summary>
    public enum Dynamics
    {
        piano_pianissimo, pianissimo, piano, mezzo_piano, mezzo_forte, forte, fortissimo, forte_fortissimo
    }
    /// <summary>
    /// An enumeration to represent whether a note (or name of a key signature) is flat, sharp, or natural.
    /// </summary>
    public enum FlatSharp
    {
        Flat, Natural, Sharp
    }
    /// <summary>
    /// This represents different form structures that a song can take.
    /// </summary>
    public enum FormType
    {
        Arch, Binary, Ternary, Rondo, Sonata_Rondo, None
    }
    /// <summary>
    /// An enumeration to show whether a key signature or chord is major or minor
    /// </summary>
    public enum MajorOrMinor
    {
        Major, Minor
    }
    /// <summary>
    /// An enumeration to represent a musical note
    /// </summary>
    public enum Note
    {
        C, Csharp, D, Dsharp, E, F, Fsharp, G, Gsharp, A, Asharp, B, Rest
    }
    public enum NoteType
    {
        SemiQuaver=1, Quaver=2, Crotchet=4, Minim=8, SemiBreve=16
    }
    public enum PlayType
    {
        Note, Rest
    }
    public enum WaveExampleType
    {
        ExampleSineWave = 0
    }
    #endregion
    #region UsefulObjects
    public class Bar
    {
        public int Duration
        {
            get
            {
                return thissounds.ToArray().GetDuration();
            }
        }
        public float MaxDuration
        {
            get
            {
                return 60000 / Tempo * ((float)thistimesignature.Numerator / (float)thistimesignature.Denominator);
            }
        }
        private List<Sound> thissounds = new List<Sound>();
        public Sound[] Sounds
        {
            get
            {
                return thissounds.ToArray();
            }
        }
        public StaveItem[] SoundsAsStaveItems
        {
            get
            {
                StaveItem[] si = new StaveItem[thissounds.Count];
                for (int i = 0; i < thissounds.Count; i++)
                {
                    si[i] = new StaveItem(i + 1, thissounds[i]);
                }
                return si.ToArray();
            }
        }
        public int Tempo = 120;
        private TimeSignature thistimesignature;
        public TimeSignature TimeSignature
        {
            get
            {
                return thistimesignature;
            }
        }
        public void AddSound(Sound newsound)
        {
            List<Sound> temp = thissounds.ToArray().ToList();
            temp.Add(newsound);
            if (temp.ToArray().GetDuration() > MaxDuration)
            {
                throw new Exception("This can't be added because it makes the total duration surpass the maximum duration limit, put in place by the Time Signature.");
            }
            thissounds.Add(newsound);
        }
        public Bar(TimeSignature timesignature)
        {
            thistimesignature = timesignature;
        }
        public Bar(TimeSignature timesignature, Sound[] sounds):this(timesignature)
        {
            if (sounds.GetDuration() > MaxDuration)
            {
                throw new Exception("Collectively, these notes are too long for a bar of this Time Signature.");
            }
            int tempo = sounds[0].Tempo;
            foreach (Sound sound in sounds)
            {
                if (sound.Tempo != tempo)
                {
                    throw new Exception("Tempo within a bar should remain the same.");
                }
            }
            thissounds.AddRange(sounds);
        }
        public void ClearAllSounds()
        {
            thissounds.Clear();
        }
    }
    public class FlatsNSharps
    {
        private FlatSharp fos;
        public FlatSharp FlatOrSharp
        {
            get
            {
                return fos;
            }
        }
        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
        }
        public FlatsNSharps(FlatSharp flatorsharp, int number)
        {
            fos = flatorsharp;
            quantity = number;
        }
    }
    public class FullNoteType
    {
        private bool dotted;
        public bool Dotted
        {
            get
            {
                return dotted;
            }
        }
        private bool third;
        public bool Third
        {
            get
            {
                return third;
            }
        }
        private NoteType notetype;
        public NoteType NoteType
        {
            get
            {
                return notetype;
            }
        }
        public FullNoteType(NoteType notetype)
            : this(false, false, notetype)
        {

        }
        public FullNoteType(bool dotted, bool third, NoteType notetype)
        {
            this.dotted = dotted;
            if (dotted)
            {
                this.third = false;
            }
            else
            {
                this.third = third;
            }
            this.notetype = notetype;
        }
        public static FullNoteType GetFromString(string text)
        {
            try
            {
                text = text.Replace(" ", "").Replace("\t","").Replace("\n","");
                int index = text.IndexOf("<FullNoteType>") + 14;
                int endindex = text.IndexOf("</FullNoteType>", index) - index;
                string substring = text.Substring(index, endindex);
                bool dotted = false;
                bool third = false;
                if (substring.Contains("Dotted"))
                {
                    dotted = bool.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Dotted=\"", "\";", substring)[0]);
                }
                if (substring.Contains("Third"))
                {
                    third = bool.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Third=\"", "\";", substring)[0]);
                }
                NoteType notetype = FortogamarBlast.Fncs.TextBetween_String_List("NoteType=\"", "\";", substring)[0].GetEnumValue<NoteType>();
                return new FullNoteType(dotted, third, notetype);
            }
            catch
            {
                return null;
            }
        }
        public override string ToString()
        {
            if (Dotted || Third)
            {
                return "<FullNoteType>Dotted=\"" + Dotted + "\";Third=\"" + Third + "\";NoteType=\"" + NoteType + "\";</FullNoteType>";
            }
            else
            {
                return "<FullNoteType>NoteType=\"" + NoteType + "\";</FullNoteType>";
            }
        }
    }
    public class Genre
    {
        #region Properties
        private int barmultiple;
        public int BarMultiple
        {
            get
            {
                return barmultiple;
            }
        }
        private FlatsNSharps[] keysignatures;
        public FlatsNSharps[] KeySignatures
        {
            get
            {
                return keysignatures;
            }
        }
        private int maxbarquantity;
        public int MaxBarQuantity
        {
            get
            {
                return maxbarquantity;
            }
        }
        private int maxtempo;
        public int MaxTempo
        {
            get
            {
                return maxtempo;
            }
        }
        private int minbarquantity;
        public int MinimumBarQuantity
        {
            get
            {
                return minbarquantity;
            }
        }
        private int mintempo;
        public int MinTempo
        {
            get
            {
                return mintempo;
            }
        }
        private TimeSignature[] possibletimesignatures;
        public TimeSignature[] PossibleTimeSignature
        {
            get
            {
                return possibletimesignatures;
            }
        }
        #endregion
        public static Genre Medieval
        {
            get
            {
                List<FlatsNSharps> fnses = new List<FlatsNSharps>();
                fnses.Add(new FlatsNSharps(FlatSharp.Natural, 0));
                for (int i = 1; i <= 3; i++)
                {
                    fnses.Add(new FlatsNSharps(FlatSharp.Flat, i));
                    fnses.Add(new FlatsNSharps(FlatSharp.Sharp, i));
                }
                Fncs.ChangeInstrument(Channel.Channel1, Instrument.AcousticGuitarNylon);
                return new Genre(60, 75, fnses.ToArray(), new TimeSignature[] { TimeSignature.Four_Four, TimeSignature.Six_Eight }, 4, 16, 4);
            }
        }
        public static Genre Baroque
        {
            get
            {
                List<FlatsNSharps> fnses = new List<FlatsNSharps>();
                fnses.Add(new FlatsNSharps(FlatSharp.Natural, 0));
                for (int i = 1; i <= 3; i++)
                {
                    fnses.Add(new FlatsNSharps(FlatSharp.Flat, i));
                    fnses.Add(new FlatsNSharps(FlatSharp.Sharp, i));
                    fnses.Add(fnses[0]);
                }
                Fncs.ChangeInstrument(Channel.Channel1, Instrument.Harpsichord);
                return new Genre(80, 120, fnses.ToArray(), new TimeSignature[] { TimeSignature.Four_Four, TimeSignature.Six_Eight }, 16, 48, 4);
            }
        }
        public Music GenerateSong(Channel channel)
        {
            return GenerateSong(keysignatures[Fncs.rand.Next(keysignatures.Length)], channel);
        }
        public Music GenerateSong(FlatsNSharps fns, Channel channel)
        {
            int tempo = Fncs.rand.Next(mintempo, maxtempo + 1);
            int bars = Fncs.RandomNumber(minbarquantity, maxbarquantity, barmultiple);
            TimeSignature ts;
            float beats;
            int number = Fncs.rand.Next(2);
            if (number == 0)
            {
                ts = TimeSignature.Six_Eight;
                beats = 1.5f;
            }
            else
            {
                ts = TimeSignature.Four_Four;
                beats = 1f;
            }
            List<Pattern> patterns = new List<Pattern>();
            for (int i = 0; i < ts.Numerator; i++)
            {
                patterns.Add(Fncs.RandomPattern(beats/2,fns));
            }
            Pattern[] temp = patterns.ToArray();
            while (patterns.Count < bars * ts.Numerator)
            {
                foreach(Pattern pattern in temp)
                {
                    patterns.Add(pattern.NewPatternFromSeed());
                }
            }
            Music music = patterns.ToArray().GetSong(tempo, channel);
            music.FlatNSharps = fns;
            music.TimeSignature = ts;
            return music;
        }
        public Genre(int minimumtempo, int maximumtempo, FlatsNSharps[] availablekeysignatures, TimeSignature[] useabletimesignatures, int minbar, int maxbar, int barmultiple)
        {
            this.barmultiple = barmultiple;
            maxbarquantity = maxbar;
            minbarquantity = minbar;
            keysignatures = availablekeysignatures;
            possibletimesignatures = useabletimesignatures;
            mintempo = minimumtempo;
            maxtempo = maximumtempo;
        }
    }
    public class InstrumentComboBox : ComboBox
    {
        public InstrumentComboBox()
        {
            Text = "AcousticGrandPiano";
            foreach (Midi.Instrument instrument in Fncs.Instruments)
            {
                Items.Add(instrument);
            }
        }
        public Midi.Instrument Instrument
        {
            get
            {
                return Text.GetEnumValue<Midi.Instrument>();
            }
        }
    }
    public class Interval
    {
        private PlayType thisplaytype;
        public PlayType PlayType
        {
            get
            {
                return thisplaytype;
            }
        }
        private int thisnoteinterval;
        public int NoteInterval
        {
            get
            {
                if (thisplaytype == PlayType.Note)
                {
                    return thisnoteinterval;
                }
                else
                {
                    throw new Exception("This note is a rest therefore there is no note interval biatch!");
                }
            }
        }
        public Interval(PlayType playtype)
        {
            thisplaytype = playtype;
            if (playtype == PlayType.Note)
            {
                thisnoteinterval = 0;
            }
        }
        public Interval(PlayType playtype, int noteinterval)
            : this(playtype)
        {
            thisnoteinterval = noteinterval;
        }
    }
    public class Music
    {
        private Sound[] sounds;
        public Sound[] Sounds
        {
            get
            {
                return sounds;
            }
        }
        private TimeSignature ts;
        public TimeSignature TimeSignature
        {
            get
            {
                return ts;
            }
            set
            {
                ts = value;
            }
        }
        private FlatsNSharps flatNSharps = null;
        public FlatsNSharps FlatNSharps
        {
            get
            {
                if (flatNSharps != null)
                {
                    return flatNSharps;
                }
                else
                {
                    throw new Exception("No key provided");
                }
            }
            set
            {
                flatNSharps = value;
            }
        }
        private Channel channel;
        public Channel Channel
        {
            get
            {
                return channel;
            }
        }
        public Music(Sound[] notes, Channel channel)
        {
            this.channel = channel;
            sounds = notes;
        }
        public Music(Sound[] notes, Channel channel, FlatsNSharps key)
            : this(notes, channel)
        {
            flatNSharps = key;
        }
        public void PlayMusic(bool noteplayer)
        {
            if (noteplayer)
            {
                NotePlayer np = new NotePlayer();
                np.Show();
                np.Play(sounds, Channel);
                np.Close();
            }
            else
            {
                foreach (Sound sound in sounds)
                {
                    sound.PlaySound(channel);
                }
            }
        }
        public void PlayMusicAsync(bool noteplayer, Channel channel)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender, e) =>
            {
                PlayMusic(noteplayer);
            };
            bw.RunWorkerAsync();
            bw.Dispose();
        }
        public static Music GetFromText(string text)
        {
            return GetFromText(text, Channel.Channel1);
        }
        public static Music GetFromText(string text,Channel channel)
        {
            List<string> sounds = FortogamarBlast.Fncs.TextBetween_String_List("<Sound>", "</Sound>", text);
            List<Sound> soundobjects = new List<Sound>();
            foreach (string sound in sounds)
            {
                string temp = "<Sound>" + sound + "</Sound>";
                Sound soundobject = Sound.GetFromString(temp);
                if (soundobject != null)
                {
                    soundobjects.Add(soundobject);
                }
            }
            return new Music(soundobjects.ToArray(), channel);
        }
    }
    public class NoteTextBox : ComboBox
    {
        public NoteTextBox()
        {
            foreach (Note note in Fncs.Notes)
            {
                Items.Add(note);
            }
            Text = "C";
            TextChanged += new EventHandler(NoteTextBox_TextChanged);
        }
        string norm = "C";
        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Text.GetEnumValue<Note>();
                norm = Text;
            }
            catch
            {
                Text = norm;
            }
        }
        public Note Note
        {
            get
            {
                return Text.GetEnumValue<Note>();
            }
        }
    }
    public class NoteTypeTextBox : ComboBox
    {
        string norm = "Crotchet";
        public NoteTypeTextBox()
        {
            Text = "Crotchet";
            Items.AddRange(new object[] { NoteType.Crotchet, NoteType.Minim, NoteType.Quaver, NoteType.SemiBreve, NoteType.SemiQuaver });
            TextChanged += new EventHandler(NoteTypeTextBox_TextChanged);
        }
        private void NoteTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Text.GetEnumValue<NoteType>();
                norm = Text;
            }
            catch
            {
                Text = norm;
            }
        }
        public NoteType NoteType
        {
            get
            {
                return Text.GetEnumValue<NoteType>();
            }
        }
    }
    public class Pattern
    {
        public Note[] AvailableNotes
        {
            get
            {
                return flatsnsharps.NotesFromKey();
            }
        }
        private Interval[] differencefromstart;
        public Interval[] DifferenceFromStart
        {
            get
            {
                return differencefromstart;
            }
        }
        private FlatsNSharps flatsnsharps;
        public FlatsNSharps FlatsNSharps
        {
            get
            {
                return flatsnsharps;
            }
        }
        private FullNoteType[] notetypes;
        public FullNoteType[] NoteTypes
        {
            get
            {
                return notetypes;
            }
        }
        private int startpitch = 3;
        public int StartPitch
        {
            get
            {
                return startpitch;
            }
        }
        public Pattern(Interval[] notesdifferences, FullNoteType[] types, FlatsNSharps flatsandsharps)
        {
            differencefromstart = notesdifferences;
            notetypes = types;
            flatsnsharps = flatsandsharps;
            if (notesdifferences.Length != types.Length)
            {
                throw new Exception("The note differences and the note types have to have the same array length you fucking prick!");
            }
        }

        public void Play(int tempo, Channel channel)
        {
            Play(tempo, false, channel);
        }
        public void Play(int tempo, bool flat, Channel channel)
        {
            Note start = Fncs.RandomNote(AvailableNotes);
            Play(start, tempo, flat, channel);
        }
        public void Play(Note startnote, int tempo, bool flat, Channel channel)
        {
            List<Sound> sounds = new List<Sound>();
            int pitchchangeindex = 0;
            while (startnote.TransposeBy(pitchchangeindex).GetNoteIndex() != 0)
            {
                pitchchangeindex++;
            }
            for (int i = 0; i < differencefromstart.Length; i++)
            {
                Note note;
                int pitch = 3;
                if (differencefromstart[i].PlayType == PlayType.Note)
                {
                    int difference = differencefromstart[i].NoteInterval;
                    int temp = difference;

                    while (temp >= pitchchangeindex)
                    {
                        pitch++;
                        temp -= AvailableNotes.Length;
                    }
                    while (temp < 0)
                    {
                        pitch--;
                        temp += AvailableNotes.Length;
                    }
                    note = startnote.TransposeBy(difference, AvailableNotes);
                }
                else
                {
                    note = Note.Rest;
                }
                FullNoteType type = notetypes[i];
                Sound sound = new Sound(note, type, pitch);
                sounds.Add(sound);
            }
            NotePlayer np = new NotePlayer();
            np.Show();
            Music song = new Music(sounds.ToArray(), channel);
            np.Play(song, flat);
            np.Close();
        }
    }
    public class Sound
    {
        public static Sound GetFromString(string text)
        {
            try
            {
                text = text.Replace(" ", "").Replace("\t", "").Replace("\n", "");
                int index = text.IndexOf("<Sound>") + 7;
                int endindex = text.IndexOf("</Sound>", index) - index;
                string substring = text.Substring(index, endindex);
                Dynamics dynamic = Dynamics.mezzo_forte;
                if (substring.Contains("Dynamic=\""))
                {
                    dynamic = FortogamarBlast.Fncs.TextBetween_String_List("Dynamic=\"", "\";", substring)[0].GetEnumValue<Dynamics>();
                }
                Note note = FortogamarBlast.Fncs.TextBetween_String_List("Note=\"", "\";", substring)[0].GetEnumValue<Note>();
                FullNoteType fullnotetype = new FullNoteType(NoteType.Crotchet);
                if (substring.Contains("FullNoteType=\""))
                {
                    string fullnotetext = FortogamarBlast.Fncs.TextBetween_String_List("FullNoteType=\"", "</FullNoteType>", substring)[0] + "</FullNoteType>";
                    MessageBox.Show("URGH");
                    fullnotetype = FullNoteType.GetFromString(fullnotetext);
                }
                int pitch = 4;
                if (substring.Contains("Pitch=\""))
                {
                    pitch = int.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Pitch=\"", "\";", substring)[0]);
                }
                if (substring.Contains("Tempo=\""))
                {
                    int tempo = int.Parse(FortogamarBlast.Fncs.TextBetween_String_List("Tempo=\"", "\";", substring)[0]);
                    return new Sound(note, fullnotetype, pitch, tempo);
                }
                else
                {
                    return new Sound(note, fullnotetype, pitch);
                }
            }
            catch
            {
                return null;
            }
        }
        private Dynamics dynamic;
        public Dynamics Dynamic
        {
            get
            {
                return dynamic;
            }
        }
        /// <summary>
        /// Return a double value that represents the frequency which is dependent on the "Note" and "Pitch" properties.
        /// </summary>
        public double Frequency
        {
            get
            {
                if (Note != Note.Rest)
                {
                    return Fncs.Frequency((pitch * 12) + NoteIndex);
                }
                else
                {
                    return 0;
                }
            }
        }
        private Note note;
        public Note Note
        {
            get
            {
                return note;
            }
        }
        public int NoteIndex
        {
            get
            {
                return note.GetNoteIndex();
            }
        }
        private FullNoteType notetype;
        public FullNoteType FullNoteType
        {
            get
            {
                return notetype;
            }
        }
        private int pitch;
        public int Pitch
        {
            get
            {
                return pitch;
            }
        }
        private int tempo=120;
        public int Tempo
        {
            get
            {
                return tempo;
            }
        }
        public Sound(Note note, FullNoteType notetype, int pitch)
        {
            this.note = note;
            this.notetype = notetype;
            this.pitch = pitch;
        }
        public Sound(Note note, FullNoteType notetype, int pitch, int tempo):this(note,notetype,pitch)
        {
            this.tempo = tempo;
        }
        public override string ToString()
        {
            return "<Sound>Dynamic=\"" + Dynamic + "\";Note=\"" +Note+ "\";FullNoteType=\"" + FullNoteType + "\";Pitch=\"" + Pitch + "\";Tempo=\"" + Tempo + "\";</Sound>";
        }
    }
    public class StavePanel : Panel
    {
        private int beats=4;
        public int BeatsPerBar
        {
            get
            {
                return beats;
            }
        }
        public List<StaveItem> Sounds = new List<StaveItem>();
        public StavePanel()
        {
            AutoScroll = true;
            VerticalScroll.Enabled = true;
            VerticalScroll.Visible = true;
            Paint += new PaintEventHandler(StavePanel_Paint);
            beats = 4;
            MouseClick += new MouseEventHandler(StavePanel_MouseClick);
        }
        private void StavePanel_MouseClick(object sender, MouseEventArgs e)
        {
            int newY = e.Y % 200 + AutoScrollPosition.Y;
            int fifthie = 20;
            int checker = (e.Y / (fifthie / 2)) * (fifthie / 2);
            checker += fifthie * 2;
            checker -= 200;
            checker /= fifthie / 2;
            int noteindex = -(checker - 1);
            Note note = noteindex.GetNoteFromIndex(notes);
        }
        public StavePanel(int beatsperbar) : this()
        {
            beats = beatsperbar;
        }
        Note[] notes
        {
            get
            {
                List<Note> temp = new List<Note>();
                temp.Add(Note.C);
                temp.Add(Note.D);
                temp.Add(Note.E);
                temp.Add(Note.F);
                temp.Add(Note.G);
                temp.Add(Note.A);
                temp.Add(Note.B);
                return temp.ToArray();
            }
        }
        int noteindex(Sound soundee)
        {
            if (notes.Contains(soundee.Note))
            {
                return soundee.Note.GetNoteIndex(notes) + (soundee.Pitch - 3) * notes.Length;
            }
            else
            {
                foreach (Note notee in notes)
                {
                    if (notee == soundee.Note.TransposeBy(-1))
                    {
                        return notee.GetNoteIndex(notes) + (soundee.Pitch - 3) * notes.Length;
                    }
                }
                throw new Exception("urgh");
            }
        }
        public int NoteCount
        {
            get
            {
                return Sounds.Count;
            }
        }
        public int Bars
        {
            get
            {
                return ((NoteCount - 1) / BeatsPerBar) + 1;
            }
        }
        int lines
        {
            get
            {
                return Bars / 4;
            }
        }
        public TimeSignature TimeSignature = new TimeSignature(4, 4);
        private void StavePanel_Paint(object sender, PaintEventArgs e)
        {
            CreateGraphics().Clear(Color.White);
            AutoScrollMinSize = new Size(0, 200 * (lines + 1));
            Bitmap bmp = new Bitmap(1600, 200);
            int fifthie = 20;
            int lineY = 0;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int soundindex = 0;
                for (int j = 0; j <= lines; j++)
                {
                    if (TimeSignature != null)
                    {
                        Font font = new Font("Times New Roman", 50);
                        int topy = 200 - (8 * fifthie);
                        int bottomy = 200 - (5 * fifthie);
                        g.DrawString(TimeSignature.Numerator.ToString(), font, new Pen(Color.Black, 20).Brush, new PointF(5, topy));
                        g.DrawString(TimeSignature.Denominator.ToString(), font, new Pen(Color.Black, 20).Brush, new PointF(5, bottomy));
                    }
                    if (soundindex >= Sounds.Count && soundindex > 0)
                    {
                        break;
                    }
                    int extraX = 0;
                    for (int i = 1; i <= 5; i++)
                    {
                        int y = 200 - (i + 2) * (fifthie);
                        g.DrawLine(new Pen(Color.Black, 4), new Point(0, y), new Point(bmp.Width, y));
                    }
                    float donee = 0;
                    for (int i = 0; i < 16; i++)
                    {
                        if (donee < BeatsPerBar)
                        {
                            if (soundindex >= Sounds.Count)
                            {
                                break;
                            }
                            
                            StaveItem sound = Sounds[soundindex];
                            if ((sound as Sound).Note == Note.Rest)
                            {
                                int y = bmp.Height - (fifthie / 2 * (noteindex(sound) + 1)) - fifthie * 2;
                                int x = (i + extraX) * (fifthie + 50) + 30;
                                Point top = new Point(x + fifthie + 50, y - (fifthie * 4));
                                Point bottom = new Point(x + 50, y + (fifthie * 5));
                            if (y <= 30)
                            {
                                int topline = 200 - (7 * fifthie);
                                int tempy = topline - fifthie;
                                while (tempy >= y + fifthie / 2)
                                {
                                    g.DrawLine(new Pen(Color.Black, 4), new Point(top.X - 30, tempy), new Point(top.X + 20, tempy));
                                    tempy -= fifthie;
                                }
                            }
                            if (y >= 150)
                            {

                                int bottomline = 200 - (3 * fifthie);
                                int tempy = bottomline - fifthie;
                                while (tempy <= y + fifthie / 2)
                                {
                                    g.DrawLine(new Pen(Color.Black, 4), new Point(bottom.X - 15, tempy), new Point(bottom.X + 35, tempy));
                                    tempy += fifthie;
                                }
                                //g.DrawLine(new Pen(Color.Black, 5), new Point(bottom.X - 30, y - fifthie / 2), new Point(bottom.X + 30, y - fifthie / 2));
                            }
                            //MessageBox.Show(y.ToString());
                            if (sound.FullNoteType.NoteType != NoteType.SemiBreve)
                            {
                                if (y >= 90)
                                {
                                    g.DrawLine(new Pen(Color.Black, 5), new Point(x + fifthie + 50, y + fifthie), top);
                                }
                                else
                                {
                                    g.DrawLine(new Pen(Color.Black, 5), new Point(x + 50, y), bottom);
                                }
                            }
                            Rectangle rect = new Rectangle(new Point(x + 50, y), new Size(fifthie, fifthie));
                            g.DrawEllipse(new Pen(Color.Black, 5), rect);
                            if (sound.FullNoteType.NoteType == NoteType.Crotchet || sound.FullNoteType.NoteType == NoteType.Quaver || sound.FullNoteType.NoteType == NoteType.SemiQuaver)
                            {
                                g.FillEllipse(new Pen(Color.Black).Brush, rect);
                            }
                            if ((sound.FullNoteType.NoteType == NoteType.Quaver || sound.FullNoteType.NoteType == NoteType.SemiQuaver) && !sound.LinkedQuaver)
                            {
                                try
                                {
                                    Sound nextsound = Sounds[soundindex + 1];
                                    int y2 = bmp.Height - (fifthie / 2 * (noteindex(nextsound) + 1)) - fifthie * 2;
                                    bool bothbelow = y >= 90 && y2 >= 90;
                                    bool bothabove = y < 90 && y2 < 90;
                                    bool same = bothabove || bothbelow;
                                    if (nextsound.FullNoteType.NoteType != NoteType.SemiQuaver && nextsound.FullNoteType.NoteType != NoteType.Quaver && !same)
                                    {
                                        throw new Exception("Fuckin' biatch!");
                                    }
                                    int x2 = (i + 1) * (fifthie + 50);
                                    Point top2 = new Point(x2 + fifthie + 50, y2 - (fifthie * 4));
                                    Point bottom2 = new Point(x2 + 50, y2 + (fifthie * 5));
                                    Sounds[soundindex + 1].LinkedQuaver = true;
                                    if (bothbelow)
                                    {
                                        g.DrawLine(new Pen(Color.Black, 8), top, top2);
                                    }
                                    else if (bothabove)
                                    {
                                        g.DrawLine(new Pen(Color.Black, 8), bottom, bottom2);
                                    }
                                    else
                                    {
                                        throw new Exception("urgh");
                                    }
                                }
                                catch
                                {
                                    if (y >= 90)
                                    {
                                        Point newdest = new Point(top.X + 20, top.Y + 50);
                                        g.DrawLine(new Pen(Color.Black, 8), top, newdest);
                                    }
                                    else
                                    {
                                        Point newdest = new Point(bottom.X - 20, bottom.Y - 50);
                                        g.DrawLine(new Pen(Color.Black, 8), bottom, newdest);
                                    }
                                }
                            }
                            if (sound.FullNoteType.NoteType == NoteType.SemiQuaver && !sound.LinkedSemiquaver)
                            {
                                try
                                {
                                    Sound nextsound = Sounds[soundindex + 1];
                                    int y2 = bmp.Height - (fifthie / 2 * (noteindex(nextsound) + 1)) - fifthie * 2;
                                    bool bothbelow = y >= 90 && y2 >= 90;
                                    bool bothabove = y < 90 && y2 < 90;
                                    bool same = bothabove || bothbelow;
                                    if (nextsound.FullNoteType.NoteType != NoteType.SemiQuaver || !same)
                                    {
                                        throw new Exception("Fuckin' biatch!");
                                    }
                                    else
                                    {
                                        int x2 = (i + 1) * (fifthie + 50);
                                        Point top2 = new Point(x2 + fifthie + 50, y2 - (fifthie * 4));
                                        Point bottom2 = new Point(x2 + 50, y2 + (fifthie * 5));
                                        Sounds[soundindex + 1].LinkedSemiquaver = true;
                                        if (bothbelow)
                                        {
                                            g.DrawLine(new Pen(Color.Black, 8), new Point(top.X, top.Y + 10), new Point(top2.X, top2.Y + 10));
                                        }
                                        else if (bothabove)
                                        {
                                            g.DrawLine(new Pen(Color.Black, 8), new Point(bottom.X, bottom.Y - 10), new Point(bottom2.X, bottom2.Y - 10));
                                        }
                                        else
                                        {
                                            throw new Exception("urgh");
                                        }
                                    }

                                }
                                catch
                                {
                                    if (y >= 90)
                                    {
                                        Point newtop = new Point(top.X, top.Y + 30);
                                        Point newdest = new Point(newtop.X + 20, newtop.Y + 50);
                                        g.DrawLine(new Pen(Color.Black, 8), newtop, newdest);
                                    }
                                    else
                                    {
                                        Point newbottom = new Point(bottom.X, bottom.Y - 30);
                                        Point newdest = new Point(newbottom.X - 20, newbottom.Y - 50);
                                        g.DrawLine(new Pen(Color.Black, 8), newbottom, newdest);
                                    }
                                }
                            }
                        }
                            soundindex++;
                        }
                        else
                        {
                        }
                    }
                    for (int i = 1; i <= Bars; i++)
                    {
                        int x = i * (fifthie + 50) * BeatsPerBar + 25;
                        g.DrawLine(new Pen(Color.Blue), new Point(x, 0), new Point(x, bmp.Height));
                    }
                    CreateGraphics().DrawImage(bmp, new Point(0, lineY + AutoScrollPosition.Y));
                    g.Clear(Color.White);
                    lineY += 200;
                }

            }
            CreateGraphics().TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
        }
    }
    public class StaveItem : Sound
    {
        private int indx;
        public int Index
        {
            get
            {
                return indx;
            }
        }
        public StaveItem(int index, Sound sound)
            : base(sound.Note, sound.FullNoteType, sound.Pitch)
        {
            indx = index;
            
        }
        public bool LinkedQuaver = false;
        public bool LinkedSemiquaver = false;
    }
    public class TimeSignature
    {
        private int numerator;
        public int Numerator
        {
            get
            {
                return numerator;
            }
        }
        private int denominator;
        public int Denominator
        {
            get
            {
                return denominator;
            }
        }
        public TimeSignature(int num, int denom)
        {
            numerator = num;
            denominator = denom;
        }
        public static TimeSignature Four_Four
        {
            get
            {
                return new TimeSignature(4, 4);
            }
        }
        public static TimeSignature Six_Eight
        {
            get
            {
                return new TimeSignature(6, 8);
            }
        }
    }
    #region WaveClasses
    public class WaveDataChunk
    {
        public string sChunkID;     // "data"
        public uint dwChunkSize;    // Length of header in bytes
        public short[] shortArray;  // 8-bit audio

        /// <summary>
        /// Initializes a new data chunk with default values.
        /// </summary>
        public WaveDataChunk()
        {
            shortArray = new short[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }
    public class WaveFormatChunk
    {
        public string sChunkID;         // Four bytes: "fmt "
        public uint dwChunkSize;        // Length of header in bytes
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public uint dwAvgBytesPerSec;   // for estimating RAM allocation
        public ushort wBlockAlign;      // sample frame size, in bytes
        public ushort wBitsPerSample;    // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Stereo
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }
    public class WaveGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header = new WaveHeader();
        WaveFormatChunk format = new WaveFormatChunk();
        WaveDataChunk data = new WaveDataChunk();
        public WaveGenerator(WaveExampleType type)
        {
            // Fill the data array with sample data
            switch (type)
            {
                case WaveExampleType.ExampleSineWave:

                    // Number of samples = sample rate * channels * bytes per sample
                    uint numSamples = format.dwSamplesPerSec * format.wChannels;

                    // Initialize the 16-bit array
                    data.shortArray = new short[numSamples];

                    int amplitude = 32760;  // Max amplitude for 16-bit audio
                    double freq = 440.0f;   // Concert A: 440Hz

                    // The "angle" used in the function, adjusted for the number of channels and sample rate.
                    // This value is like the period of the wave.
                    double t = (Math.PI * 2 * freq) / (format.dwSamplesPerSec * format.wChannels);

                    for (uint i = 0; i < numSamples - 1; i++)
                    {
                        // Fill with a simple sine wave at max amplitude
                        for (int channel = 0; channel < format.wChannels; channel++)
                        {
                            data.shortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));
                        }
                    }
                    // Calculate data chunk size in bytes
                    data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
                    break;
            }
        }
        public WaveGenerator(Music music)
        {
            uint numSamples = format.dwSamplesPerSec * format.wChannels;
            List<short> shortlist = new List<short>();
            long thingy = (numSamples * music.Sounds.Length * 2);
            int amplitude = 32760;
            int index = 0;
            foreach (Sound sound in music.Sounds)
            {
                double frequency = sound.Frequency;
                double t = (Math.PI * 2 * frequency) / (format.dwSamplesPerSec * format.wChannels);
                double frameno = numSamples / 1000 * sound.FullNoteType.GetDuration(sound.Tempo) / 2;
                for (uint i = 0; i < frameno - 1; i++)
                {
                    // Fill with a simple sine wave at max amplitude
                    for (int channel = 0; channel < format.wChannels; channel++)
                    {
                        shortlist.Add(Convert.ToInt16(amplitude * Math.Sin(t * i)));
                    }
                }
                index += frameno.ObjectToIntegerParse();
            }
            data.shortArray = shortlist.ToArray();
            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
        }
        public void Save(string filePath)
        {
            // Create a file (it always overwrites)
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            BinaryWriter writer = new BinaryWriter(fileStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();
        }
    }
    public class WaveHeader
    {
        public string sGroupID; // RIFF
        public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
        public string sRiffType; // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }
    #endregion
    #endregion
}