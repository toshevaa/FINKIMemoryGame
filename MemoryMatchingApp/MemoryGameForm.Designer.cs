namespace MemoryMatchingApp
{
    partial class MemoryGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryGameForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLevelCounter = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevelText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.incorrectPairTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.previewCardsTimer = new System.Windows.Forms.Timer(this.components);
            this.FlipTimer = new System.Windows.Forms.Timer(this.components);
            this.levelNstartsInLabel = new System.Windows.Forms.Label();
            this.nextLevelLabel = new System.Windows.Forms.Label();
            this.nextLevelCountdownLabel = new System.Windows.Forms.Label();
            this.nextLevelCountdownTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackColor = System.Drawing.Color.Chocolate;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lblLevelCounter);
            this.splitContainer1.Panel1.Controls.Add(this.lblScore);
            this.splitContainer1.Panel1.Controls.Add(this.lblLevelText);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblSeconds);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblMinutes);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Name = "label4";
            // 
            // lblLevelCounter
            // 
            resources.ApplyResources(this.lblLevelCounter, "lblLevelCounter");
            this.lblLevelCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblLevelCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLevelCounter.ForeColor = System.Drawing.Color.Snow;
            this.lblLevelCounter.Name = "lblLevelCounter";
            this.lblLevelCounter.Click += new System.EventHandler(this.lblLevelCounter_Click);
            // 
            // lblScore
            // 
            resources.ApplyResources(this.lblScore, "lblScore");
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.ForeColor = System.Drawing.Color.Snow;
            this.lblScore.Name = "lblScore";
            // 
            // lblLevelText
            // 
            resources.ApplyResources(this.lblLevelText, "lblLevelText");
            this.lblLevelText.BackColor = System.Drawing.Color.Transparent;
            this.lblLevelText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLevelText.ForeColor = System.Drawing.Color.Snow;
            this.lblLevelText.Name = "lblLevelText";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblSeconds
            // 
            resources.ApplyResources(this.lblSeconds, "lblSeconds");
            this.lblSeconds.BackColor = System.Drawing.Color.Transparent;
            this.lblSeconds.ForeColor = System.Drawing.Color.Snow;
            this.lblSeconds.Name = "lblSeconds";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MemoryMatchingApp.Properties.Resources.timer_clock;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lblMinutes
            // 
            resources.ApplyResources(this.lblMinutes, "lblMinutes");
            this.lblMinutes.BackColor = System.Drawing.Color.Transparent;
            this.lblMinutes.ForeColor = System.Drawing.Color.Snow;
            this.lblMinutes.Name = "lblMinutes";
            // 
            // incorrectPairTimer
            // 
            this.incorrectPairTimer.Interval = 500;
            this.incorrectPairTimer.Tick += new System.EventHandler(this.incorrectPairTimer_Tick);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // previewCardsTimer
            // 
            this.previewCardsTimer.Interval = 3000;
            this.previewCardsTimer.Tick += new System.EventHandler(this.previewCardsTimer_Tick);
            // 
            // levelNstartsInLabel
            // 
            resources.ApplyResources(this.levelNstartsInLabel, "levelNstartsInLabel");
            this.levelNstartsInLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelNstartsInLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelNstartsInLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.levelNstartsInLabel.Name = "levelNstartsInLabel";
            // 
            // nextLevelLabel
            // 
            resources.ApplyResources(this.nextLevelLabel, "nextLevelLabel");
            this.nextLevelLabel.BackColor = System.Drawing.Color.Transparent;
            this.nextLevelLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextLevelLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nextLevelLabel.Name = "nextLevelLabel";
            // 
            // nextLevelCountdownLabel
            // 
            resources.ApplyResources(this.nextLevelCountdownLabel, "nextLevelCountdownLabel");
            this.nextLevelCountdownLabel.BackColor = System.Drawing.Color.Transparent;
            this.nextLevelCountdownLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextLevelCountdownLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nextLevelCountdownLabel.Name = "nextLevelCountdownLabel";
            // 
            // nextLevelCountdownTimer
            // 
            this.nextLevelCountdownTimer.Interval = 1000;
            this.nextLevelCountdownTimer.Tick += new System.EventHandler(this.nextLevelCountdownTimer_Tick);
            // 
            // MemoryGameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.nextLevelCountdownLabel);
            this.Controls.Add(this.nextLevelLabel);
            this.Controls.Add(this.levelNstartsInLabel);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MemoryGameForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MemoryGameForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer incorrectPairTimer;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer previewCardsTimer;
        private System.Windows.Forms.Timer FlipTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLevelCounter;
        private System.Windows.Forms.Label lblLevelText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label levelNstartsInLabel;
        private System.Windows.Forms.Label nextLevelLabel;
        private System.Windows.Forms.Label nextLevelCountdownLabel;
        private System.Windows.Forms.Timer nextLevelCountdownTimer;
    }
}

