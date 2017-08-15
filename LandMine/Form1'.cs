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
        bool[,] Mines = new bool[10, 10];
        Button[,] Buttons = new Button[8, 8];
        int tempX;
        int tempY;

        public Form1()
        {
            InitializeComponent();
            newGame();

        }

        private void button_click (object sender, RoutedEventArgs args)
        {
            ;//
        }

        private void newGame()
        {
            // sets assings the buttons ot the buttons array
            initalizeButtons();

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
                lblDebug.Text += '\n' + "[" + tempX + " , " + tempY + "]";
                Buttons[tempX, tempY].Text = "*";
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
        }

        private void button0_Click(object sender, EventArgs e)
        {

        }
    }
}
