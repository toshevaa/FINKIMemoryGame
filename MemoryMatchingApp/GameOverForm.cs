using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MemoryMatchingApp
{
    public partial class GameOverForm : Form
    {
       
        
        public GameOverForm()
        {
            WindowsMediaPlayer gameOver = new WindowsMediaPlayer();
            gameOver.URL = "gameOver.mp3";
            gameOver.controls.play();
            InitializeComponent();
        }

        private void GameOverForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            MemoryGameForm memoryGameForm = new MemoryGameForm();

            if(memoryGameForm.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                memoryGameForm.ShowDialog();
                this.Close();
            }
            else
            {
                this.Close();
            }
           
        }

        private void btnPlayAgain_Enter(object sender, EventArgs e)
        {
            btnPlayAgain.Cursor = Cursors.Hand;
        }

        private void btnExit_Enter(object sender, EventArgs e)
        {
            btnExit.Cursor = Cursors.Hand;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.Cursor = Cursors.Hand;
        }
    }
}
