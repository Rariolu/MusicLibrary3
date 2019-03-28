namespace MusicLibrary3
{
    partial class NotePlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotePlayer));
            this.lblNote = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.musicPlayControl1 = new MusicLibrary3.MusicPlayControl();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(0, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(0, 73);
            this.lblNote.TabIndex = 0;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(218, 104);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(0, 13);
            this.lblTempo.TabIndex = 5;
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // musicPlayControl1
            // 
            this.musicPlayControl1.Location = new System.Drawing.Point(12, 12);
            this.musicPlayControl1.Name = "musicPlayControl1";
            this.musicPlayControl1.Size = new System.Drawing.Size(369, 216);
            this.musicPlayControl1.TabIndex = 8;
            // 
            // NotePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 247);
            this.Controls.Add(this.musicPlayControl1);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.lblNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotePlayer";
            this.Text = "NotePlayer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotePlayer_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        private NewProgressBar npbProgress;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Timer tmrMain;
        private MusicPlayControl musicPlayControl1;
    }
}