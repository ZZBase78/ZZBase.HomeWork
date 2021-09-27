using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08.TrueFalseGame
{
    public partial class EndGameForm : Form
    {

        public string text;
        public bool victory;

        public EndGameForm()
        {
            InitializeComponent();

        }

        public void UpdateVisible()
        {
            label_Text.Text = text;
            if (victory) label_Text.ForeColor = Color.Red;
        }

        private void EndGameForm_Load(object sender, EventArgs e)
        {
            if (victory)
            {
                if (File.Exists("TrueFalseGame\\Victory.wav"))
                {
                    SoundPlayer simpleSound = new SoundPlayer("TrueFalseGame\\Victory.wav");
                    simpleSound.Play();
                }
            }
            else
            {
                if (File.Exists("TrueFalseGame\\EndGame.wav"))
                {
                    SoundPlayer simpleSound = new SoundPlayer("TrueFalseGame\\EndGame.wav");
                    simpleSound.Play();
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
