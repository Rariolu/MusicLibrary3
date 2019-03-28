namespace MusicLibrary3
{
    partial class MusicPlayControl
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
            //base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblSecondsLeft = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.lblChannel = new System.Windows.Forms.Label();
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
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 104);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(21, 13);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "0%";
            // 
            // lblSecondsLeft
            // 
            this.lblSecondsLeft.AutoSize = true;
            this.lblSecondsLeft.Location = new System.Drawing.Point(12, 137);
            this.lblSecondsLeft.Name = "lblSecondsLeft";
            this.lblSecondsLeft.Size = new System.Drawing.Size(13, 13);
            this.lblSecondsLeft.TabIndex = 4;
            this.lblSecondsLeft.Text = "0";
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
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(218, 35);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(51, 13);
            this.lblChannel.TabIndex = 6;
            this.lblChannel.Text = "[channel]";
            // 
            // MusicPlayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.lblSecondsLeft);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblNote);
            this.Name = "MusicPlayControl";
            this.Size = new System.Drawing.Size(369, 216);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MusicPlayControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblSecondsLeft;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lblChannel;
    }
}
