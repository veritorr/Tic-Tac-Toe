using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool player = true; //2 types of players: true - X is the player -- false - O is the player
        int moveCnt = 0; // num of moves up to 9 max

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enhanced by Tom D'Alleva", "Game About TTT");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (player)
                b.Text = "X";
            else
                b.Text = "O";
            b.Enabled = false; 
            moveCnt++;
            winCheck();
            player = !player;

        }

        private void winCheck()
        {
            bool isWinner = false;
            
            // row checking
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                isWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                isWinner = true;
            // column checking
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                isWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                isWinner = true;
            // diag checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                isWinner = true;
            
            if (isWinner)
            {
                String theWinner = "";
                if (player) //determine which player won
                    theWinner = "X";
                else
                    theWinner = "O";
   
                MessageBox.Show(theWinner + " is the Winner!!!\n Click OK, then use File/New Game to start a  new game.");
                Thread.Sleep(2000);
               
            }
        
            // If there is no winner see if there is a draw.
            if (moveCnt >= 9)
            {
                disableBtns();
                MessageBox.Show("Unfortunately this game is a draw.");
            }



        }//end winCheck()

        private void disableBtns()
        {
            try // exception handler
            {

                foreach (Control c in Controls) // for each button on our form
                {
                    Button b = (Button)c; // turn each control into a button in order to disable it
                    b.Enabled = false; // disable to button
                }
            }
                catch {}
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveCnt = 0;
            player = true; // start with X again

            try // exception handler
            {

                foreach (Control c in Controls) // for each button on our form
                {
                    Button b = (Button)c; // turn each control into a button in order to disable it
                    b.Enabled = true; // disable to button
                    b.Text = "";
                }
            }
            catch { }

        } // end disableBtns

    }
}
