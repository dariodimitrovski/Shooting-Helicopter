namespace Shooting_Helicopter
{
    partial class Form1
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
            this.pillar1 = new System.Windows.Forms.PictureBox();
            this.pillar2 = new System.Windows.Forms.PictureBox();
            this.helicopter = new System.Windows.Forms.PictureBox();
            this.ufo = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pillar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pillar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helicopter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufo)).BeginInit();
            this.SuspendLayout();
            // 
            // pillar1
            // 
            this.pillar1.Image = global::Shooting_Helicopter.Properties.Resources.pillar;
            this.pillar1.Location = new System.Drawing.Point(691, 0);
            this.pillar1.Margin = new System.Windows.Forms.Padding(4);
            this.pillar1.Name = "pillar1";
            this.pillar1.Size = new System.Drawing.Size(79, 212);
            this.pillar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pillar1.TabIndex = 0;
            this.pillar1.TabStop = false;
            this.pillar1.Tag = "pillar";
            // 
            // pillar2
            // 
            this.pillar2.Image = global::Shooting_Helicopter.Properties.Resources.pillar;
            this.pillar2.Location = new System.Drawing.Point(337, 295);
            this.pillar2.Margin = new System.Windows.Forms.Padding(4);
            this.pillar2.Name = "pillar2";
            this.pillar2.Size = new System.Drawing.Size(80, 260);
            this.pillar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pillar2.TabIndex = 1;
            this.pillar2.TabStop = false;
            this.pillar2.Tag = "pillar";
            // 
            // helicopter
            // 
            this.helicopter.Image = global::Shooting_Helicopter.Properties.Resources.Halicopter;
            this.helicopter.ImageLocation = "";
            this.helicopter.InitialImage = null;
            this.helicopter.Location = new System.Drawing.Point(83, 128);
            this.helicopter.Margin = new System.Windows.Forms.Padding(4);
            this.helicopter.Name = "helicopter";
            this.helicopter.Size = new System.Drawing.Size(133, 66);
            this.helicopter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.helicopter.TabIndex = 2;
            this.helicopter.TabStop = false;
            this.helicopter.Tag = "helicopter";
            // 
            // ufo
            // 
            this.ufo.Image = global::Shooting_Helicopter.Properties.Resources.alien1;
            this.ufo.Location = new System.Drawing.Point(940, 244);
            this.ufo.Margin = new System.Windows.Forms.Padding(4);
            this.ufo.Name = "ufo";
            this.ufo.Size = new System.Drawing.Size(68, 72);
            this.ufo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ufo.TabIndex = 3;
            this.ufo.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(16, 11);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(110, 29);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Score: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.ufo);
            this.Controls.Add(this.helicopter);
            this.Controls.Add(this.pillar2);
            this.Controls.Add(this.pillar1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Helicopter Shooting Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pillar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pillar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helicopter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pillar1;
        private System.Windows.Forms.PictureBox pillar2;
        private System.Windows.Forms.PictureBox helicopter;
        private System.Windows.Forms.PictureBox ufo;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label txtScore;
    }
}
