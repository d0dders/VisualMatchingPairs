using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualMatchingPairs
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        int revealedIconCount = 0;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!",
            "N","N",
            ",",",",
            "k","k",
            "b","b",
            "v","v",
            "w","w",
            "z","z"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }


        }

        private void Label_click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }

            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if(clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.Black;
                }
                else
                {
                    secondClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.Black;
                    if (firstClicked.Text == secondClicked.Text)
                    {
                        revealedIconCount += 2;
                        firstClicked = null;
                        secondClicked = null;
                        CheckForWin();
                        return;
                    }

                    timer1.Start();

                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWin()
        {
            if(revealedIconCount == 16)
            {
                MessageBox.Show("You matched all the icons, well done!", "Congratulations!");
                Close();
            }
        }
    }
}
