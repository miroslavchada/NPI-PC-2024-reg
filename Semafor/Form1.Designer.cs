namespace Semafor {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            pbSLRed = new PictureBox();
            pbSLYellow = new PictureBox();
            pbSLGreen = new PictureBox();
            lbCountdown = new Label();
            btSwitch = new Button();
            timerNormal = new System.Windows.Forms.Timer(components);
            timerStandby = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbSLRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSLYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSLGreen).BeginInit();
            SuspendLayout();
            // 
            // pbSLRed
            // 
            pbSLRed.BackColor = Color.Transparent;
            pbSLRed.BackgroundImage = Properties.Resources.SLRedOff;
            pbSLRed.Location = new Point(67, 78);
            pbSLRed.Name = "pbSLRed";
            pbSLRed.Size = new Size(100, 100);
            pbSLRed.TabIndex = 0;
            pbSLRed.TabStop = false;
            // 
            // pbSLYellow
            // 
            pbSLYellow.BackColor = Color.Transparent;
            pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOff;
            pbSLYellow.Location = new Point(67, 184);
            pbSLYellow.Name = "pbSLYellow";
            pbSLYellow.Size = new Size(100, 100);
            pbSLYellow.TabIndex = 1;
            pbSLYellow.TabStop = false;
            // 
            // pbSLGreen
            // 
            pbSLGreen.BackColor = Color.Transparent;
            pbSLGreen.BackgroundImage = Properties.Resources.SLGreenOff;
            pbSLGreen.Location = new Point(67, 290);
            pbSLGreen.Name = "pbSLGreen";
            pbSLGreen.Size = new Size(100, 100);
            pbSLGreen.TabIndex = 2;
            pbSLGreen.TabStop = false;
            // 
            // lbCountdown
            // 
            lbCountdown.AutoSize = true;
            lbCountdown.Font = new Font("Segoe UI Semibold", 72F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbCountdown.Location = new Point(196, 168);
            lbCountdown.Name = "lbCountdown";
            lbCountdown.Size = new Size(0, 128);
            lbCountdown.TabIndex = 3;
            lbCountdown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btSwitch
            // 
            btSwitch.Font = new Font("Segoe UI", 13F);
            btSwitch.ForeColor = Color.Black;
            btSwitch.Location = new Point(393, 197);
            btSwitch.Name = "btSwitch";
            btSwitch.Size = new Size(139, 87);
            btSwitch.TabIndex = 4;
            btSwitch.Text = "Vypnout";
            btSwitch.UseVisualStyleBackColor = true;
            btSwitch.Click += btSwitch_Click;
            // 
            // timerNormal
            // 
            timerNormal.Enabled = true;
            timerNormal.Interval = 1000;
            timerNormal.Tick += timerNormal_Tick;
            // 
            // timerStandby
            // 
            timerStandby.Interval = 2000;
            timerStandby.Tick += timerStandby_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(605, 513);
            Controls.Add(btSwitch);
            Controls.Add(lbCountdown);
            Controls.Add(pbSLGreen);
            Controls.Add(pbSLYellow);
            Controls.Add(pbSLRed);
            ForeColor = Color.FromArgb(0, 192, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Chada - Semafor";
            ((System.ComponentModel.ISupportInitialize)pbSLRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSLYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSLGreen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSLRed;
        private PictureBox pbSLYellow;
        private PictureBox pbSLGreen;
        private Label lbCountdown;
        private Button btSwitch;
        private System.Windows.Forms.Timer timerNormal;
        private System.Windows.Forms.Timer timerStandby;
    }
}
