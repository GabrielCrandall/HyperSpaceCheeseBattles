using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//cheese powers
//moving animation
//simplify code lots
//choose number of players
//"ai" option?



namespace HyperSpaceCheeseBattles
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            Form2 otherForm = new Form2();
            otherForm.ShowDialog();
            playerNumbers = otherForm.numberOfPlayers;
            InitializeComponent();
            ResetBoard();
            player1.Name = otherForm.player1Name;
            player2.Name = otherForm.player2Name;
            player3.Name = otherForm.player3Name;
            player4.Name = otherForm.player4Name;
            if (player1.Name != string.Empty)
                label5.Text = player1.Name;
            if (player2.Name != string.Empty)
                label7.Text = player2.Name;
            if (player3.Name != string.Empty)
                label8.Text = player3.Name;
            if (player4.Name != string.Empty)
                label10.Text = player4.Name;
        }
        public static int playerNumbers = 0;
        public static bool reroll = false;
        public static void ResetBoard()
        {
            displayArray = new int[8, 8]
            {
                {0, 1, 1, 2, 0, 1, 1, 2},
                {0, 4, 1, 3, 2, 0, 5, 3},
                {3, 2, 0, 1, 3, 2, 0, 1},
                {1, 3, 2, 0, 1, 3, 2, 2},
                {0, 1, 3, 2, 0, 1, 3, 2},
                {0, 0, 1, 3, 2, 0, 1, 3},
                {3, 6, 0, 1, 3, 2, 5, 1},
                {3, 3, 2, 0, 3, 3, 2, 8}
            };


            player1.xCoord = 0;
            player1.yCoord = 0;
            displayArray[player1.xCoord, player1.yCoord] = 9;

            player2.xCoord = 1;
            player2.yCoord = 0;
            displayArray[player2.xCoord, player2.yCoord] = 10;

            if (playerNumbers >= 3)
            {
                player3.xCoord = 2;
                player3.yCoord = 0;
                displayArray[player3.xCoord, player3.yCoord] = 11;
            }
            else
            {
                player3.xCoord = -1;
                player3.yCoord = -1;
            }

            if (playerNumbers == 4)
            {
                player4.xCoord = 3;
                player4.yCoord = 0;
                displayArray[player4.xCoord, player4.yCoord] = 12;
            }
            else
            {
                player4.xCoord = -1;
                player4.yCoord = -2;
            }

            playerTurn = 0;

            ChangePic();
        }

        public static Rocket player1 = new Rocket();
        public static Rocket player2 = new Rocket();
        public static Rocket player3 = new Rocket();
        public static Rocket player4 = new Rocket();

        public static int[,] boardArray = new int[8, 8]
        {
            {0, 1, 1, 2, 0, 1, 1, 2},
            {0, 4, 1, 3, 2, 0, 5, 3},
            {3, 2, 0, 1, 3, 2, 0, 1},
            {1, 3, 2, 0, 1, 3, 2, 2},
            {0, 1, 3, 2, 0, 1, 3, 2},
            {0, 0, 1, 3, 2, 0, 1, 3},
            {3, 6, 0, 1, 3, 2, 5, 1},
            {3, 3, 2, 0, 3, 3, 2, 8}
        };

        public static int[,] displayArray = new int[8, 8]
        {
            {0, 1, 1, 2, 0, 1, 1, 2},
            {0, 4, 1, 3, 2, 0, 5, 3},
            {3, 2, 0, 1, 3, 2, 0, 1},
            {1, 3, 2, 0, 1, 3, 2, 2},
            {0, 1, 3, 2, 0, 1, 3, 2},
            {0, 0, 1, 3, 2, 0, 1, 3},
            {3, 6, 0, 1, 3, 2, 5, 1},
            {3, 3, 2, 0, 3, 3, 2, 8}
        };

        public class Rocket
        {
            public int xCoord = 0;
            public int yCoord = 0;
            private int playerPic = -1;
            public string Name = string.Empty;
            public bool changeArrow = true;

            public void Move(int num)
            {
                switch (playerTurn)
                {
                    case 0:
                        playerPic = 9;
                        break;
                    case 1:
                        playerPic = 10;
                        break;
                    case 2:
                        playerPic = 11;
                        break;
                    case 3:
                        playerPic = 12;
                        break;
                    default:
                        //this shouldn't happen
                        break;
                }

                switch (boardArray[xCoord, yCoord])
                {
                    case 0:
                    case 4:
                        //up
                        if (changeArrow)
                            displayArray[xCoord, yCoord] = boardArray[xCoord, yCoord];
                        if (yCoord + num > 7)
                        {
                            yCoord = 7;
                        }
                        else
                        {
                            yCoord += num;
                        }

                        break;
                    case 1:
                    case 5:
                        //right
                        if (changeArrow)
                            displayArray[xCoord, yCoord] = boardArray[xCoord, yCoord];
                        if (xCoord + num > 7)
                        {
                            xCoord = 7;
                        }
                        else
                        {
                            xCoord += num;
                        }
                        break;
                    case 2:
                    case 6:
                        //down
                        if (changeArrow)
                            displayArray[xCoord, yCoord] = boardArray[xCoord, yCoord];
                        if (yCoord - num < 0)
                        {
                            yCoord = 0;
                        }
                        else
                        {
                            yCoord -= num;
                        }
                        break;
                    case 3:
                    case 7:
                        //left
                        if (changeArrow)
                            displayArray[xCoord, yCoord] = boardArray[xCoord, yCoord];
                        if (xCoord - num < 0)
                        {
                            xCoord = 0;
                        }
                        else
                        {
                            xCoord -= num;
                        }
                        break;
                }

                if (CollisionCheck(xCoord, yCoord))
                {
                    changeArrow = false;
                    Move(1);
                }
                else
                {
                    changeArrow = true;
                    displayArray[xCoord, yCoord] = playerPic;
                    if (CheeseCheck(xCoord, yCoord))
                    {
                        CheesePower();
                    }
                }

                if ((xCoord == 7) && (yCoord == 7))
                {
                    MessageBox.Show("WINNNER!", (playerTurn >= 2) ? ((playerTurn == 2) ? "Player: " + player3.Name : "Player: " + player4.Name) : ((playerTurn == 0) ? "Player: " + player1.Name : "Player: " + player2.Name));
                    DialogResult dialogResult = MessageBox.Show("Do you want to play again?", "Play Again?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ResetBoard();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }

            }

            private bool CheeseCheck(int x, int y)
            {
                if (boardArray[x, y] == 4 || boardArray[x, y] == 5 || boardArray[x, y] == 6 || boardArray[x, y] == 7)
                {
                    return true;
                }
                return false;
            }

            private bool CollisionCheck(int x, int y)
            {
                int p1x = player1.xCoord;
                int p1y = player1.yCoord;

                int p2x = player2.xCoord;
                int p2y = player2.yCoord;

                int p3x = player3.xCoord;
                int p3y = player3.yCoord;

                int p4x = player4.xCoord;
                int p4y = player4.yCoord;
                switch (playerTurn)
                {
                    case 0:
                        if ((p1x == p2x) && (p1y == p2y))
                        {
                            return true;
                        }
                        else if ((p1x == p3x) && (p1y == p3y))
                        {
                            return true;
                        }
                        else if ((p1x == p4x) && (p1y == p4y))
                        {
                            return true;
                        }
                        return false;
                    case 1:
                        if ((p2x == p1x) && (p2y == p1y))
                        {
                            return true;
                        }
                        else if ((p2x == p3x) && (p2y == p3y))
                        {
                            return true;
                        }
                        else if ((p2x == p4x) && (p2y == p4y))
                        {
                            return true;
                        }
                        return false;
                    case 2:
                        if ((p3x == p1x) && (p3y == p1y))
                        {
                            return true;
                        }
                        else if ((p3x == p2x) && (p3y == p2y))
                        {
                            return true;
                        }
                        else if ((p3x == p4x) && (p3y == p4y))
                        {
                            return true;
                        }
                        return false;
                    case 3:
                        if ((p4x == p1x) && (p4y == p1y))
                        {
                            return true;
                        }
                        else if ((p4x == p2x) && (p4y == p2y))
                        {
                            return true;
                        }
                        else if ((p4x == p3x) && (p4y == p3y))
                        {
                            return true;
                        }
                        return false;
                }
                return false;
            }
            private void CheesePower()
            {
                panel2.Visible = true;
            }
        }

        public class Dice
        {
            public int Roll()
            {
                int rand = RandomNumber(1, 7);
                return rand;
            }
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
        }
        private static void ChangePic()
        {
            pictureBox1.Image = PictureAssign(displayArray[0, 7]);
            pictureBox2.Image = PictureAssign(displayArray[1, 7]);
            pictureBox3.Image = PictureAssign(displayArray[2, 7]);
            pictureBox4.Image = PictureAssign(displayArray[3, 7]);
            pictureBox5.Image = PictureAssign(displayArray[4, 7]);
            pictureBox6.Image = PictureAssign(displayArray[5, 7]);
            pictureBox7.Image = PictureAssign(displayArray[6, 7]);
            pictureBox8.Image = PictureAssign(displayArray[7, 7]);
            pictureBox9.Image = PictureAssign(displayArray[0, 6]);
            pictureBox10.Image = PictureAssign(displayArray[1, 6]);
            pictureBox11.Image = PictureAssign(displayArray[2, 6]);
            pictureBox12.Image = PictureAssign(displayArray[3, 6]);
            pictureBox13.Image = PictureAssign(displayArray[4, 6]);
            pictureBox14.Image = PictureAssign(displayArray[5, 6]);
            pictureBox15.Image = PictureAssign(displayArray[6, 6]);
            pictureBox16.Image = PictureAssign(displayArray[7, 6]);
            pictureBox17.Image = PictureAssign(displayArray[0, 5]);
            pictureBox18.Image = PictureAssign(displayArray[1, 5]);
            pictureBox19.Image = PictureAssign(displayArray[2, 5]);
            pictureBox20.Image = PictureAssign(displayArray[3, 5]);
            pictureBox21.Image = PictureAssign(displayArray[4, 5]);
            pictureBox22.Image = PictureAssign(displayArray[5, 5]);
            pictureBox23.Image = PictureAssign(displayArray[6, 5]);
            pictureBox24.Image = PictureAssign(displayArray[7, 5]);
            pictureBox25.Image = PictureAssign(displayArray[0, 4]);
            pictureBox26.Image = PictureAssign(displayArray[1, 4]);
            pictureBox27.Image = PictureAssign(displayArray[2, 4]);
            pictureBox28.Image = PictureAssign(displayArray[3, 4]);
            pictureBox29.Image = PictureAssign(displayArray[4, 4]);
            pictureBox30.Image = PictureAssign(displayArray[5, 4]);
            pictureBox31.Image = PictureAssign(displayArray[6, 4]);
            pictureBox32.Image = PictureAssign(displayArray[7, 4]);
            pictureBox33.Image = PictureAssign(displayArray[0, 3]);
            pictureBox34.Image = PictureAssign(displayArray[1, 3]);
            pictureBox35.Image = PictureAssign(displayArray[2, 3]);
            pictureBox36.Image = PictureAssign(displayArray[3, 3]);
            pictureBox37.Image = PictureAssign(displayArray[4, 3]);
            pictureBox38.Image = PictureAssign(displayArray[5, 3]);
            pictureBox39.Image = PictureAssign(displayArray[6, 3]);
            pictureBox40.Image = PictureAssign(displayArray[7, 3]);
            pictureBox41.Image = PictureAssign(displayArray[0, 2]);
            pictureBox42.Image = PictureAssign(displayArray[1, 2]);
            pictureBox43.Image = PictureAssign(displayArray[2, 2]);
            pictureBox44.Image = PictureAssign(displayArray[3, 2]);
            pictureBox45.Image = PictureAssign(displayArray[4, 2]);
            pictureBox46.Image = PictureAssign(displayArray[5, 2]);
            pictureBox47.Image = PictureAssign(displayArray[6, 2]);
            pictureBox48.Image = PictureAssign(displayArray[7, 2]);
            pictureBox49.Image = PictureAssign(displayArray[0, 1]);
            pictureBox50.Image = PictureAssign(displayArray[1, 1]);
            pictureBox51.Image = PictureAssign(displayArray[2, 1]);
            pictureBox52.Image = PictureAssign(displayArray[3, 1]);
            pictureBox53.Image = PictureAssign(displayArray[4, 1]);
            pictureBox54.Image = PictureAssign(displayArray[5, 1]);
            pictureBox55.Image = PictureAssign(displayArray[6, 1]);
            pictureBox56.Image = PictureAssign(displayArray[7, 1]);
            pictureBox57.Image = PictureAssign(displayArray[0, 0]);
            pictureBox58.Image = PictureAssign(displayArray[1, 0]);
            pictureBox59.Image = PictureAssign(displayArray[2, 0]);
            pictureBox60.Image = PictureAssign(displayArray[3, 0]);
            pictureBox61.Image = PictureAssign(displayArray[4, 0]);
            pictureBox62.Image = PictureAssign(displayArray[5, 0]);
            pictureBox63.Image = PictureAssign(displayArray[6, 0]);
            pictureBox64.Image = PictureAssign(displayArray[7, 0]);
        }

        private static Image PictureAssign(int num)
        {
            switch (num)
            {
                case 0:
                    //up arrow
                    return Properties.Resources.upArrow;//image goes here
                case 1:
                    //right arrow
                    return Properties.Resources.rightArrow;//image goes here
                case 2:
                    //down arrow
                    return Properties.Resources.downArrow;//image goes here
                case 3:
                    //left arrow
                    return Properties.Resources.leftArrow;//image goes here
                case 4:
                    //cheese up arrow
                    return Properties.Resources.upArrowCheese;//image goes here
                case 5:
                    //cheese right arrow
                    return Properties.Resources.rightArrowCheese;//image goes here
                case 6:
                    //cheese down arrow
                    return Properties.Resources.downArrowCheese;//image goes here
                case 7:
                    //cheese left arrow
                    return Properties.Resources.leftArrowCheese;//image goes here
                case 8:
                    //win square
                    return Properties.Resources.Win;//image goes here
                case 9:
                    //Player1 Rocket
                    return Properties.Resources.rocket1;
                case 10:
                    //Player2 Rocket
                    return Properties.Resources.rocket2;
                case 11:
                    //Player3 Rocket
                    return Properties.Resources.rocket3;
                case 12:
                    //Player 4 Rocket
                    return Properties.Resources.rocket4;
                default:
                    //rocket
                    return Properties.Resources.rocket;//image goes here
            }

        }

        private static int playerTurn = 0;
        private bool doIt = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if ((panel2.Visible == true) || (panel1.Visible == true) || (panel3.Visible == true))
            {
                MessageBox.Show("Please choose a cheese option.");
            }
            else
            {
                if (doIt)
                {
                    if (playerTurn == playerNumbers - 1)
                        playerTurn = 0;
                    else
                        playerTurn++;
                    doIt = false;
                }
                Dice blah = new Dice();
                switch (playerTurn)
                {
                    case 0:
                        player1.Move(blah.Roll());
                        if (panel2.Visible == false)
                            playerTurn++;
                        break;
                    case 1:
                        player2.Move(blah.Roll());
                        if (panel2.Visible == false)
                        {
                            if (playerNumbers == 2)
                            {
                                playerTurn = 0;
                            }
                            else
                            {
                                playerTurn++;
                            }
                        }
                        break;
                    case 2:
                        player3.Move(blah.Roll());
                        if (panel2.Visible == false)
                        {
                            if (playerNumbers == 3)
                            {
                                playerTurn = 0;
                            }
                            else
                            {
                                playerTurn++;
                            }
                        }
                        break;
                    case 3:
                        player4.Move(blah.Roll());
                        if (panel2.Visible == false)
                            playerTurn = 0;
                        break;
                    default:
                        playerTurn = 0;
                        break;
                }

                ChangePic();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reroll
            panel2.Visible = false;
            Dice blah = new Dice();
            switch (playerTurn)
            {
                case 0:
                    player1.Move(blah.Roll());
                    if (panel2.Visible == false)
                        playerTurn++;
                    break;
                case 1:
                    player2.Move(blah.Roll());
                    if (panel2.Visible == false)
                    {
                        if (playerNumbers == 2)
                        {
                            playerTurn = 0;
                        }
                        else
                        {
                            playerTurn++;
                        }
                    }
                    break;
                case 2:
                    player3.Move(blah.Roll());
                    if (panel2.Visible == false)
                    {
                        if (playerNumbers == 3)
                        {
                            playerTurn = 0;
                        }
                        else
                        {
                            playerTurn++;
                        }
                    }
                    break;
                case 3:
                    player4.Move(blah.Roll());
                    if (panel2.Visible == false)
                        playerTurn = 0;
                    break;
            }
            ChangePic();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //attack player
            doIt = true;
            panel2.Visible = false;
            panel1.Visible = true;
            switch (playerTurn)
            {
                case 0:
                    pictureBox65.Image = PictureAssign(10);
                    if (playerNumbers >= 3)
                        pictureBox66.Image = PictureAssign(11);
                    if (playerNumbers == 4)
                        pictureBox67.Image = PictureAssign(12);
                    //player1 attacks
                    break;
                case 1:
                    pictureBox65.Image = PictureAssign(9);
                    if (playerNumbers >= 3)
                        pictureBox66.Image = PictureAssign(11);
                    if (playerNumbers == 4)
                        pictureBox67.Image = PictureAssign(12);
                    //player2 attacks
                    break;
                case 2:
                    pictureBox65.Image = PictureAssign(10);
                    pictureBox66.Image = PictureAssign(9);
                    if (playerNumbers == 4)
                        pictureBox67.Image = PictureAssign(12);
                    //player3 attacks
                    break;
                case 3:
                    pictureBox65.Image = PictureAssign(10);
                    pictureBox66.Image = PictureAssign(11);
                    pictureBox67.Image = PictureAssign(9);
                    //player4 attacks
                    break;
            }
        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
            switch (playerTurn)
            {
                case 0:
                case 1:
                case 2:

                    //player4 chooses square
                    if (playerNumbers == 4)
                        bam = 3;
                    break;
                case 3:
                    //player 1 chooses square
                    bam = 0;
                    break;
            }
            if (bam != -1)
            {
                panel1.Visible = false;
                panel3.Visible = true;
                canMove = true;
            }
        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {
            switch (playerTurn)
            {
                case 0:
                case 1:
                case 3:
                    //player3 chooses square
                    if (playerNumbers >= 3)
                        bam = 2;
                    break;
                case 2:
                    //player1 chooses square
                    bam = 0;
                    break;
            }
            if (bam != -1)
            {
                panel1.Visible = false;
                panel3.Visible = true;
                canMove = true;
            }
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {
            switch (playerTurn)
            {
                case 0:
                case 3:
                case 2:
                    //player2 chooses
                    bam = 1;
                    break;
                case 1:
                    //player 1 chooses square
                    bam = 0;
                    break;
            }
            if (bam != -1)
            {
                panel1.Visible = false;
                panel3.Visible = true;
                canMove = true;
            }
        }

        //choosing pics on bottom row
        private int bam = -1;
        private bool canMove = false;

        private void lop(int square)
        {
            if (canMove)
            {
                if ((displayArray[square, 0] != 9) && (displayArray[square, 0] != 10) && (displayArray[square, 0] != 11) && (displayArray[square, 0] != 12))
                {
                    panel3.Visible = false;
                    switch (bam)
                    {
                        case 0:
                            displayArray[player1.xCoord, player1.yCoord] = boardArray[player1.xCoord, player1.yCoord];
                            player1.yCoord = 0;
                            player1.xCoord = square;
                            displayArray[player1.xCoord, player1.yCoord] = 9;
                            break;
                        case 1:
                            displayArray[player2.xCoord, player2.yCoord] = boardArray[player2.xCoord, player2.yCoord];
                            player2.yCoord = 0;
                            player2.xCoord = square;
                            displayArray[player2.xCoord, player2.yCoord] = 10;
                            break;
                        case 2:
                            displayArray[player3.xCoord, player3.yCoord] = boardArray[player3.xCoord, player3.yCoord];
                            player3.yCoord = 0;
                            player3.xCoord = square;
                            displayArray[player3.xCoord, player3.yCoord] = 11;
                            break;
                        case 3:
                            displayArray[player4.xCoord, player4.yCoord] = boardArray[player4.xCoord, player4.yCoord];
                            player4.yCoord = 0;
                            player4.xCoord = square;
                            displayArray[player4.xCoord, player4.yCoord] = 12;
                            break;
                    }
                    ChangePic();
                    canMove = false;
                }
                else
                {
                    MessageBox.Show("A player is on that square. Please choose somehwere else.");
                }
            }
        }
        private void pictureBox57_Click(object sender, EventArgs e)
        {
            lop(0);
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            lop(1);
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            lop(2);
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            lop(3);
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            lop(4);
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            lop(5);
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            lop(6);
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            lop(7);
        }
    }
}