using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandMine
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        bool[,] Mines = new bool[8, 8];
        Button[,] Buttons = new Button[8, 8];
        int tempX;
        int tempY;
        int numAdjacent;
        int cleared;
        int marked;
        int seconds;

        public Form1()
        {
            InitializeComponent();
            newGame();

        }

        // either a left or right click on a button
        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            
           for (int x = 0; x < 8; x++)
           {
                for (int y = 0; y < 8; y++)
                {
                    if (sender == Buttons[x, y])
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            if (Buttons[x, y].Text == String.Empty && Buttons[x, y].Enabled == true && marked > 0)
                            {
                                Buttons[x, y].Text = "X";
                                Buttons[x, y].ForeColor = Color.Black;
                                marked--;
                            }
                            else if (Buttons[x, y].Text == "X")
                            {
                                Buttons[x, y].Text = String.Empty;
                                marked++;
                            }
                            lblFlags.Text = marked.ToString(); // update how many marks the player has
                        }
                        else if (e.Button == MouseButtons.Left && Buttons[x, y].Text == String.Empty)
                            checkButton(x, y);
                    }
                }
            }
        }

        // reveals what is hidden in a button
        private void checkButton(int x, int y)
        {
            timer1.Start();

            if (Mines[x, y] == true) // if its a mine
            {
                timer1.Stop();

                revealMines();
                if (MessageBox.Show("Game Over\nPlay again?", "Land Mine", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newGame();
                }
                else
                {
                    Application.Exit();
                }
            }
            else // tally the adjacent mines
            {
                if (x > 0 && y > 0 && Mines[x - 1, y - 1] == true) // upper left
                {
                    numAdjacent++;
                }
                if (y > 0 && Mines[x, y - 1] == true) // upper center
                {
                    numAdjacent++;
                }
                if (x < 7 && y > 0 && Mines[x + 1, y - 1] == true) // upper right
                {
                    numAdjacent++;
                }
                if (x > 0 && Mines[x - 1, y] == true) // middle left
                {
                    numAdjacent++;
                }
                if (x < 7 && Mines[x + 1, y] == true) // middle right
                {
                    numAdjacent++;
                }
                if (x > 0 && y < 7 && Mines[x - 1, y + 1] == true) // lower left
                {
                    numAdjacent++;
                }
                if (y < 7 && Mines[x, y + 1] == true) // lower center
                {
                    numAdjacent++;
                }
                if (x < 7 && y < 7 && Mines[x + 1, y + 1] == true) // lower right
                {
                    numAdjacent++;
                }
                
                // incrament clicked non-mine buttones
                cleared++;

                switch (numAdjacent)
                {
                    case 1:
                        Buttons[x, y].ForeColor = Color.Blue;
                        break;
                    case 2:
                        Buttons[x, y].ForeColor = Color.Green;
                        break;
                    case 3:
                        Buttons[x, y].ForeColor = Color.Red;
                        break;
                    case 4:
                        Buttons[x, y].ForeColor = Color.DarkBlue;
                        break;
                    case 5:
                        Buttons[x, y].ForeColor = Color.DarkRed;
                        break;
                    case 6:
                        Buttons[x, y].ForeColor = Color.DarkCyan;
                        break;
                    case 7:
                        Buttons[x, y].ForeColor = Color.Black;
                        break;
                    case 8:
                        Buttons[x, y].ForeColor = Color.Gray;
                        break;
                }

                if (numAdjacent == 0)
                    checkSuroundingButtons(x, y);
                else
                    Buttons[x, y].Text = numAdjacent.ToString();

                // reset for next click
                numAdjacent = 0;

                // if the player clicks on all the non-mine buttons
                if (cleared == 54)
                {
                    if (MessageBox.Show("You Win!\nPlay again?", "Land Mine", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        newGame();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                
                // rest for next click
                numAdjacent = 0;
            }
        }

        // clicks on surrounding buttons
        private void checkSuroundingButtons(int x, int y)
        {
            Buttons[x, y].Enabled = false;

            if (y > 0 && Buttons[x, y - 1].Text == String.Empty && Buttons[x, y - 1].Enabled == true) // button above
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x, y - 1].PerformClick();
                checkButton(x, y - 1);
            }
            if (x > 0 && Buttons[x - 1, y].Text == String.Empty && Buttons[x - 1, y].Enabled == true) // button to the left
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x - 1, y].PerformClick();
                checkButton(x - 1, y);
            }
            if (x < 7 && Buttons[x + 1, y].Text == String.Empty && Buttons[x + 1, y].Enabled == true) // button to the right
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x + 1, y].PerformClick();
                checkButton(x + 1, y);
            }
            if (y < 7 && Buttons[x, y + 1].Text == String.Empty && Buttons[x, y + 1].Enabled == true) // button below
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x, y + 1].PerformClick();
                checkButton(x, y + 1);
            }
            if (x > 0 && y > 0 && Buttons[x - 1, y - 1].Text == String.Empty && Buttons[x - 1, y - 1].Enabled == true) // button above and to the left
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x - 1, y - 1].PerformClick();
                checkButton(x - 1, y - 1);
            }
            if (x > 0 && y < 7 && Buttons[x - 1, y + 1].Text == String.Empty && Buttons[x - 1, y + 1].Enabled == true) // button above and to the right
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x - 1, y + 1].PerformClick();
                checkButton(x - 1, y + 1);
            }
            if (x < 7 && y > 0 && Buttons[x + 1, y - 1].Text == String.Empty && Buttons[x + 1, y - 1].Enabled == true) // button below and to the left
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x + 1, y - 1].PerformClick();
                checkButton(x + 1, y - 1);
            }
            if (x < 7 && y < 7 && Buttons[x + 1, y + 1].Text == String.Empty && Buttons[x + 1, y + 1].Enabled == true) // button below and to the right
            {
                //Buttons[x, y].Enabled = false;
                //Buttons[x + 1, y + 1].PerformClick();
                checkButton(x + 1, y + 1);
            }
        }

        // sets up everything for a new game
        private void newGame()
        {
            lblDebug.Text = String.Empty;
            cleared = 0;
            marked = 10;
            seconds = 0;
            lblFlags.Text = marked.ToString();
            lblTimer.Text = "0:00";

            // assings the buttons ot the buttons array
            initalizeButtons();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Mines[x, y] = false;
                    Buttons[x, y].Text = String.Empty;
                }
            }

            // assigns the mine locations
            for (int i = 0; i < 10; i++)
            {
                do // so there's no more than one mine per button
                {
                    tempX = rand.Next(7);
                    tempY = rand.Next(7);
                }
                while (Mines[tempX, tempY] == true);
                Mines[tempX, tempY] = true;

                // debug to list mine locations
                //lblDebug.Text += '\n' + "[" + tempX + " , " + tempY + "]";
                //Buttons[tempX, tempY].Text = "*";
            }
        }

        // shows all mines
        private void revealMines()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (Mines[x, y] == true)
                    {
                        Buttons[x, y].Text = "*";
                        Buttons[x, y].ForeColor = Color.Black;
                    }
                }
            }
        }

        private void initalizeButtons()
        {
            Buttons[0, 0] = button0;
            Buttons[1, 0] = button1;
            Buttons[2, 0] = button2;
            Buttons[3, 0] = button3;
            Buttons[4, 0] = button4;
            Buttons[5, 0] = button5;
            Buttons[6, 0] = button6;
            Buttons[7, 0] = button7;
            Buttons[0, 1] = button8;
            Buttons[1, 1] = button9;
            Buttons[2, 1] = button10;
            Buttons[3, 1] = button11;
            Buttons[4, 1] = button12;
            Buttons[5, 1] = button13;
            Buttons[6, 1] = button14;
            Buttons[7, 1] = button15;
            Buttons[0, 2] = button16;
            Buttons[1, 2] = button17;
            Buttons[2, 2] = button18;
            Buttons[3, 2] = button19;
            Buttons[4, 2] = button20;
            Buttons[5, 2] = button21;
            Buttons[6, 2] = button22;
            Buttons[7, 2] = button23;
            Buttons[0, 3] = button24;
            Buttons[1, 3] = button25;
            Buttons[2, 3] = button26;
            Buttons[3, 3] = button27;
            Buttons[4, 3] = button28;
            Buttons[5, 3] = button29;
            Buttons[6, 3] = button30;
            Buttons[7, 3] = button31;
            Buttons[0, 4] = button32;
            Buttons[1, 4] = button33;
            Buttons[2, 4] = button34;
            Buttons[3, 4] = button35;
            Buttons[4, 4] = button36;
            Buttons[5, 4] = button37;
            Buttons[6, 4] = button38;
            Buttons[7, 4] = button39;
            Buttons[0, 5] = button40;
            Buttons[1, 5] = button41;
            Buttons[2, 5] = button42;
            Buttons[3, 5] = button43;
            Buttons[4, 5] = button44;
            Buttons[5, 5] = button45;
            Buttons[6, 5] = button46;
            Buttons[7, 5] = button47;
            Buttons[0, 6] = button48;
            Buttons[1, 6] = button49;
            Buttons[2, 6] = button50;
            Buttons[3, 6] = button51;
            Buttons[4, 6] = button52;
            Buttons[5, 6] = button53;
            Buttons[6, 6] = button54;
            Buttons[7, 6] = button55;
            Buttons[0, 7] = button56;
            Buttons[1, 7] = button57;
            Buttons[2, 7] = button58;
            Buttons[3, 7] = button59;
            Buttons[4, 7] = button60;
            Buttons[5, 7] = button61;
            Buttons[6, 7] = button62;
            Buttons[7, 7] = button63;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Buttons[x, y].Enabled = true;
                }
            }
        }

        // resets the game
        private void btnRest_Click(object sender, EventArgs e)
        {
            if (cleared < 1)
                newGame();
            else if (MessageBox.Show("Are you sure you want to restart?", "LandMine", MessageBoxButtons.YesNo) == DialogResult.Yes)
                newGame();
        }

        // incraments the timer every second
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds % 60 < 10)
                lblTimer.Text = seconds / 60 + ":0" + seconds % 60;
            else
                lblTimer.Text = seconds / 60 + ":" + seconds % 60;
        }
    }
}
