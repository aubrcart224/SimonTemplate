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

        //  guess and number varibales 
        int guess = 0;
        int  number = 0;

        //sound players 
        SoundPlayer redPlayer = new SoundPlayer(Properties.Resources.red);
        SoundPlayer greenPlayer = new SoundPlayer(Properties.Resources.green);
        SoundPlayer bluePlayer = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer yellowPlayer = new SoundPlayer(Properties.Resources.yellow);


        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //change button shape


            GraphicsPath outerPath = new GraphicsPath();
            outerPath.AddEllipse(5, 5, 220, 220); //5 pixels in because later 5 pixels will be taken off each edge

            //create a region out of the full circle
            Region buttonRegion = new Region(outerPath);

            buttonRegion.Exclude(new Rectangle(0, 0, 110, 5));   //remove top line
            buttonRegion.Exclude(new Rectangle(0, 105, 110, 5)); //remove bottom line
            buttonRegion.Exclude(new Rectangle(0, 0, 5, 110));   //remove left line
            buttonRegion.Exclude(new Rectangle(105, 0, 5, 110)); //remove right line

            //remove inner circle from button
            GraphicsPath innerPath = new GraphicsPath();
            innerPath.AddEllipse(70, 70, 90, 90);
            buttonRegion.Exclude(innerPath);

            //apply region to red button
            greenButton.Region = buttonRegion;

            //rotate the orientation of the screen by 90 degrees
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(90, new PointF(55, 55));

            //apply rotation to button region and apply region to red button    
            buttonRegion.Transform(transformMatrix);
            redButton.Region = buttonRegion;

            //apply rotation to button region and apply region to blue button 
            buttonRegion.Transform(transformMatrix);
            blueButton.Region = buttonRegion;

            //apply rotation to button region and apply region to yellow button 
            buttonRegion.Transform(transformMatrix);
            yellowButton.Region = buttonRegion;



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
            Form1.pattern.Add(number);
   

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.pattern.Count(); i++)
            {
                if (Form1.pattern[i] == 0)
                {
                    greenButton.BackColor= Color.White;
                    greenPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(500);


                }
                else if (Form1.pattern[i] == 1)
                {
                    blueButton.BackColor = Color.White;
                    bluePlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.pattern[i] == 2)
                {
                    redButton.BackColor = Color.White;
                    redPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor =Color.DarkRed;
                    Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.pattern[i] == 3)
                {
                    yellowButton.BackColor= Color.White;
                    yellowPlayer.Play();
                    Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(500);
                }
                

            }

            //TODO: get guess index value back to 0
            guess = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            SoundPlayer mistakePlayer = new SoundPlayer(Properties.Resources.mistake);
            mistakePlayer.Play();

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

            if (Form1.pattern[guess]==0)
            {
                greenButton.BackColor = Color.White;
                greenPlayer.Play();
                Refresh();
                Thread.Sleep(200);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                Thread.Sleep(500);

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
            if (Form1.pattern[guess]==2)
            {
                redButton.BackColor = Color.White;
                redPlayer.Play();
                Refresh();
                Thread.Sleep(200);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(500);

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

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess]==1)
            {
                blueButton.BackColor = Color.White;
                bluePlayer.Play();
                Refresh();
                Thread.Sleep(200);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(500);

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

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess]==3)
            {
                yellowButton.BackColor = Color.White;
                yellowPlayer.Play();    
                Refresh();
                Thread.Sleep(200);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(500);

                guess ++;
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
    }
}
