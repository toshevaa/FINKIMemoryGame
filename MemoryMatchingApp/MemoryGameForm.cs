using MemoryMatchingApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;


namespace MemoryMatchingApp
{
    public partial class MemoryGameForm : Form
    {
        private int totalScore = 0;
        private int currentRows = 2;
        private int currentCols = 1;
        private int successfullyRevealedPairs = 0;
        private int startingPosX;
        private int startingPosY;
        private int iconSize;
        private int levelCounter = 1;
        PictureBox FirstOpenedImage;
        PictureBox SecondOpenedImage;
        WindowsMediaPlayer cardFlip = new WindowsMediaPlayer();
        WindowsMediaPlayer bgMusic = new WindowsMediaPlayer();
        private List<PictureBox> pictures = new List<PictureBox>();
        private List<int> tags = new List<int>();
        List<bool> oldEnabledValues = new List<bool>();


        private void InitializeGame(int rows = 2, int cols = 3)
        {

            if (bgMusic.playState != WMPPlayState.wmppsPlaying)
            {
                bgMusic.URL = "quizCountdown.mp3";
                bgMusic.settings.setMode("loop", true);
                bgMusic.controls.play();
            }

            cardFlip.URL = "cardFlip.mp3";

            this.currentRows = rows;
            this.currentCols = cols;

            AdjustIconSizeAndPosition(rows, cols);
            generateShuffledTags();

            int tagIndex = 0;
            int totalWidth = currentCols * (iconSize + 10) - 10;
            int totalHeight = currentRows * (iconSize + 10) - 10;
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = splitContainer1.Bottom + ((this.ClientSize.Height - splitContainer1.Height - totalHeight) / 2);

            for (int i = 0; i < this.currentRows; i++)
            {
                for (int j = 0; j < this.currentCols; j++)
                {
                    PictureBox p = new PictureBox();
                    ((ISupportInitialize)(p)).BeginInit();
                    p.Tag = tags[tagIndex++];
                    Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(p.Tag.ToString());
                    p.Image = bmp;
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Location = new Point(startX + j * (iconSize + 10), startY + i * (iconSize + 10));
                    p.Name = "pictureBox" + i.ToString() + j.ToString();
                    p.Size = new Size(iconSize, iconSize);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.TabStop = false;
                    p.BackColor = Color.Transparent;
                    p.Parent = this;
        
                    p.Click += new EventHandler((sender, e) => this.cardReveal(sender, e, p));
                    this.pictures.Add(p);
                    this.Controls.Add(p);
                    ((ISupportInitialize)(p)).EndInit();
                }
            }
            previewCardsTimer.Start();
            this.ResumeLayout();
        }

        private void AdjustIconSizeAndPosition(int rows, int cols)
        {
            int baseIconSize = 100;
            int baseSpacing = 10;

            if (rows * cols <= 6)
            {
                this.iconSize = baseIconSize;
            }
            else if (rows * cols <= 12)
            {
                this.iconSize = baseIconSize - 10;
            }
            else if (rows * cols <= 20)
            {
                this.iconSize = baseIconSize - 20;
            }
            else
            {
                this.iconSize = baseIconSize - 30;
            }
        }

      
        private void generateShuffledTags()
        {
            int totalCards = this.currentCols * this.currentRows;

            for (int i = 1; i <= totalCards / 2; i++)
            {
                this.tags.Add(i);
                this.tags.Add(i);
            }

            Random rng = new Random();
            int n = this.tags.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = this.tags[k];
                this.tags[k] = this.tags[n];
                this.tags[n] = value;
            }
        }

        public MemoryGameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);// ako prava problem nesto tajmero so sveto crveno najverojatno e od tuka problemo - 3te linii kod
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
            startNextLevel();
        }
        private void startNextLevel()
        {
            showNextLevelText();
            nextLevelCountdownTimer.Start();
        }

        private void cardReveal(object sender, EventArgs e, PictureBox p)
        {
            cardFlip.controls.stop();
            Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(p.Tag.ToString());
            p.Image = bmp;
            if (FirstOpenedImage != null && SecondOpenedImage != null)
            {
                return;
            }
            if (FirstOpenedImage == null)
            {
                cardFlip.controls.play();
                FirstOpenedImage = p;
            }
            else if (FirstOpenedImage != null && SecondOpenedImage == null && FirstOpenedImage != p)
            {
                cardFlip.controls.play();
                SecondOpenedImage = p;
            }
            if (FirstOpenedImage != null && SecondOpenedImage != null)
            {
                if (FirstOpenedImage.Tag.Equals(SecondOpenedImage.Tag))
                {
                    FirstOpenedImage.Enabled = false;
                    SecondOpenedImage.Enabled = false;
                    FirstOpenedImage = null;
                    SecondOpenedImage = null;

                    successfullyRevealedPairs += 1;
                    totalScore += 15;
                    increaseCounterBy(2);
                }
                else
                {
                    totalScore -= 5;
                    for (int i = 0; i < pictures.Count; i++)
                    {
                        oldEnabledValues.Add(pictures[i].Enabled);
                    }

                    for (int i = 0; i < pictures.Count; i++)
                    {
                        pictures[i].Enabled = false;
                    }
                    incorrectPairTimer.Start();
                }

                if (successfullyRevealedPairs == (currentCols * currentRows) / 2)
                {

                    goToNextLevel();
                }
            }
            lblScore.Text = totalScore.ToString();
        }

        private void goToNextLevel()
        {
            levelCounter++;
            lblLevelCounter.Text = levelCounter.ToString();
            increaseCounterBy(levelCounter*10);
            this.successfullyRevealedPairs = 0;
            this.tags.Clear();
            foreach (var pair in pictures)
            {
                this.Controls.Remove(pair);
            }
            this.pictures.Clear();
            oldEnabledValues.Clear();
            startNextLevel();

        }

        private void gameOver()
        {
            foreach (var pair in pictures)
            {
                this.Controls.Remove(pair);
            }
            this.pictures.Clear();
            oldEnabledValues.Clear();
        }

        private void increaseCounterBy(int count)
        {
            int timer = Convert.ToInt32(lblSeconds.Text);
            this.lblSeconds.Text = (timer + count).ToString();
        }

        private void incorrectPairTimer_Tick(object sender, EventArgs e)
        {
            incorrectPairTimer.Stop();
            FirstOpenedImage.Image = Properties.Resources.CardBack;
            SecondOpenedImage.Image = Properties.Resources.CardBack;
            FirstOpenedImage = null;
            SecondOpenedImage = null;
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Enabled = oldEnabledValues[i];
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(lblSeconds.Text);
            timer = timer - 1;
            lblSeconds.Text = timer.ToString();

            if (timer <= 5)
            {
                lblSeconds.ForeColor = Color.Red;
                lblMinutes.ForeColor = Color.Red;
            }
            else
            {
                lblSeconds.ForeColor = Color.White;
                lblMinutes.ForeColor = Color.White;
            }

            if (timer == 0)
            {
                gameTimer.Stop();
                gameOver();
                this.Hide();
                bgMusic.controls.pause();
                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.ShowDialog();
                this.Close();
            }
        }

        private void previewCardsTimer_Tick(object sender, EventArgs e)
        {
            foreach (var p in pictures)
            {
                p.Enabled = false;
            }
            previewCardsTimer.Stop();
            foreach (var p in pictures)
            {
                p.Enabled = true;
                p.Image = Resources.CardBack;
                p.Cursor = Cursors.Hand;
            }
            gameTimer.Start();
        }


        private void nextLevelCountdownTimer_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(nextLevelCountdownLabel.Text);
            timer = timer - 1;
            nextLevelCountdownLabel.Text = timer.ToString();

            if (timer == 0)
            {
                nextLevelCountdownTimer.Stop();
                hideNextLevelText();
                gameTimer.Start();
                if(levelCounter < 6)
                {
                InitializeGame(this.currentRows + 1, this.currentCols + 1);
                }
                else
                {
                    InitializeGame(this.currentRows, this.currentCols + 2);
                }
               
            }

        }
        private void hideNextLevelText()
        {
            nextLevelCountdownLabel.Visible = false;
            nextLevelLabel.Visible = false;
            levelNstartsInLabel.Visible = false;
            nextLevelCountdownLabel.Text = "5";
            int currLevel = Convert.ToInt32(nextLevelLabel.Text);
            nextLevelLabel.Text = (currLevel + 1).ToString();
        }
        private void showNextLevelText()
        {
            nextLevelCountdownLabel.Visible = true;
            nextLevelLabel.Visible = true;
            levelNstartsInLabel.Visible = true;
            gameTimer.Stop();
        }

        private void lblLevelCounter_Click(object sender, EventArgs e)
        {

        }

        private void MemoryGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}