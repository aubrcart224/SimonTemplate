using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at

        //randoom number gen 
        //public static Random randNum = new Random();
        //int number = randNum.Next(0, 5);
        int guess = 0;
        int number = 0;
        
        


        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.pattern.Clear();
            Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            Random randNum = new Random();
            number = randNum.Next(0, 4);
            //Form1.pattern.Add(number);
            Form1.pattern.Add(1);

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i <= Form1.pattern.Count(); i++)
            {
                if (Form1.pattern[i] == 0)
                {
                    greenButton.BackColor= Color.White;
                    Thread.Sleep(1000);
                    Refresh();
                    greenButton.BackColor = Color.ForestGreen;


                }
                else if (Form1.pattern[i] == 1)
                {
                    blueButton.BackColor = Color.White;
                    Thread.Sleep(1000);
                    Refresh();
                    blueButton.BackColor = Color.DarkBlue;
                }
                else if (Form1.pattern[i] == 2)
                {
                    redButton.BackColor= Color.White;
                    Thread.Sleep(1000);
                    Refresh();
                    redButton.BackColor =Color.DarkRed;
                }
                else if (Form1.pattern[i] == 3)
                {
                    yellowButton.BackColor= Color.White;
                    Thread.Sleep(1000);
                    Refresh();
                    yellowButton.BackColor = Color.Goldenrod;
                }
                

            }

            //TODO: get guess index value back to 0
            guess = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
            // light up button, play sound, and pause
            // set button colour back to original
            // add one to the guess index
            // check to see if we are at the end of the pattern. If so:
            // call ComputerTurn() method
            // else call GameOver method
           
            if (Form1.pattern.Contains(guess))
            {
                greenButton.BackColor = Color.White;
                Refresh();
                Thread.Sleep(1000);
                greenButton.BackColor = Color.ForestGreen;

                guess++;
                if (guess == Form1.pattern.Count())
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }



        }

        private void redButton_Click(object sender, EventArgs e)
        {

        }

        private void blueButton_Click(object sender, EventArgs e)
        {

        }

        private void yellowButton_Click(object sender, EventArgs e)
        {

        }
    }
}
