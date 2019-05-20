using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperSpaceCheeseBattles
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int numberOfPlayers = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            numberOfPlayers = 2;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numberOfPlayers = 3;
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numberOfPlayers = 4;
            panel1.Visible = true;
        }

        public string player1Name = string.Empty;
        public string player2Name = string.Empty;
        public string player3Name = string.Empty;
        public string player4Name = string.Empty;
        private int count = 0;
        private bool CloseForm = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter in a name");
            }
            else
            {
                if (count == 0)
                {
                    player1Name = textBox1.Text;
                    label2.Text = "Please enter in th\nsecond player's name:";
                    textBox1.Text = string.Empty;
                    count++;
                    if (count == numberOfPlayers)
                        CloseForm = true;
                }
                else if (count == 1)
                {
                    player2Name = textBox1.Text;
                    label2.Text = "Please enter in th\nthird player's name:";
                    textBox1.Text = string.Empty;
                    count++;
                    if (count == numberOfPlayers)
                        CloseForm = true;
                }
                else if (count == 2)
                {
                    player3Name = textBox1.Text;
                    label2.Text = "Please enter in th\nfourth player's name:";
                    textBox1.Text = string.Empty;
                    count++;
                    if (count == numberOfPlayers)
                        CloseForm = true;
                }
                else if (count == 3)
                {
                    player4Name = textBox1.Text;
                    count++;
                    CloseForm = true;
                }
                
                if (CloseForm)
                {
                    this.Close();
                }
            }
        }
    }
}
