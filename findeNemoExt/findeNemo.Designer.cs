namespace findeNemo
{
    partial class findeNemo
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
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.lblPunkte = new System.Windows.Forms.Label();
            this.txbPunkte = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.pnlBlocks = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.progressSpeed = new System.Windows.Forms.ProgressBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 20;
            this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            // 
            // lblPunkte
            // 
            this.lblPunkte.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblPunkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunkte.Location = new System.Drawing.Point(503, 156);
            this.lblPunkte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPunkte.Name = "lblPunkte";
            this.lblPunkte.Size = new System.Drawing.Size(71, 31);
            this.lblPunkte.TabIndex = 2;
            this.lblPunkte.Text = "Punkte:";
            // 
            // txbPunkte
            // 
            this.txbPunkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPunkte.Location = new System.Drawing.Point(503, 197);
            this.txbPunkte.Margin = new System.Windows.Forms.Padding(2);
            this.txbPunkte.Name = "txbPunkte";
            this.txbPunkte.Size = new System.Drawing.Size(72, 29);
            this.txbPunkte.TabIndex = 3;
            this.txbPunkte.Text = "0";
            this.txbPunkte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(503, 260);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(71, 32);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(503, 297);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(71, 32);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(503, 334);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(71, 32);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "Neu starten";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(41, 649);
            this.lblMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 13);
            this.lblMin.TabIndex = 8;
            this.lblMin.Text = "Min";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(218, 649);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(85, 13);
            this.lblMsg.TabIndex = 9;
            this.lblMsg.Text = "Geschwindigkeit";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(426, 649);
            this.lblMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(27, 13);
            this.lblMax.TabIndex = 10;
            this.lblMax.Text = "Max";
            // 
            // pnlBlocks
            // 
            this.pnlBlocks.Location = new System.Drawing.Point(41, 125);
            this.pnlBlocks.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBlocks.Name = "pnlBlocks";
            this.pnlBlocks.Size = new System.Drawing.Size(419, 509);
            this.pnlBlocks.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblInfo.Location = new System.Drawing.Point(11, 9);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(570, 102);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Klick auf Start\r\ndas ist die 1. Spielrunde";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressSpeed
            // 
            this.progressSpeed.Location = new System.Drawing.Point(41, 669);
            this.progressSpeed.Name = "progressSpeed";
            this.progressSpeed.Size = new System.Drawing.Size(419, 36);
            this.progressSpeed.TabIndex = 11;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(243, 677);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(19, 20);
            this.lblSpeed.TabIndex = 12;
            this.lblSpeed.Text = "2";
            // 
            // findeNemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 713);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.progressSpeed);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txbPunkte);
            this.Controls.Add(this.lblPunkte);
            this.Controls.Add(this.pnlBlocks);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(608, 752);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(608, 752);
            this.Name = "findeNemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finde Nemo";
            this.Load += new System.EventHandler(this.findeNemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.Label lblPunkte;
        private System.Windows.Forms.TextBox txbPunkte;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Panel pnlBlocks;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ProgressBar progressSpeed;
        private System.Windows.Forms.Label lblSpeed;
    }
}

