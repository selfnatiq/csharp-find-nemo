using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace findeNemo
{
    public partial class findeNemo : Form
    {
        /// <summary>
        /// Counts every round of the game
        /// </summary>
        int round = 1;

        /// <summary>
        /// Counts score of the game
        /// </summary>
        int points = 0;

        /// <summary>
        /// Game speed
        /// </summary>
        int gameSpeed = 2;

        /// <summary>
        /// Makes button flowing smoother
        /// </summary>
        int smoothness = 2;

        /// <summary>
        /// Timer tuning, default value is 20
        /// </summary>
        int tmrInterval = 20;

        /// <summary>
        /// Genetrates a random number
        /// </summary>
        Random r = new Random();

        /// <summary>
        /// Generated button will be saved in here
        /// </summary>
        List <Button> buttons = new List<Button>();

        /// <summary>
        /// Array of nemo images
        /// </summary>
        Image[] nemo = new Image[] { 
            Properties.Resources.nemo1,
            Properties.Resources.nemo2,
            Properties.Resources.nemo3
        };

        /// <summary>
        /// Array of none nemo images
        /// </summary>
        Image[] o_nemo = new Image[]
        {
            Properties.Resources.o_nemo1,
            Properties.Resources.o_nemo2,
            Properties.Resources.o_nemo3,
            Properties.Resources.o_nemo4,
            Properties.Resources.o_nemo5,
            Properties.Resources.o_nemo6,
            Properties.Resources.o_nemo7,
            Properties.Resources.o_nemo8,
            Properties.Resources.o_nemo9,
            Properties.Resources.o_nemo10,
            Properties.Resources.o_nemo11,
            Properties.Resources.o_nemo12
        };

        public findeNemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method loads the game with row of buttons and disables the following buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findeNemo_Load(object sender, EventArgs e)
        {
            //Generate 4 blocks on load
            generateBtn();

            //timer tuning
            tmrGame.Interval = tmrInterval;

            //Hide label speed
            lblSpeed.Visible = false;

            //disable buttons
            btnStop.Enabled = false;
            btnRestart.Enabled = false;
        }

        /// <summary>
        /// This method starts the game and disables the following buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Start timer
            tmrGame.Start();

            //disable and enable buttons
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnRestart.Enabled = true;
        }

        /// <summary>
        /// This method stops the game and outputs a message in Info label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //Stop timer
            tmrGame.Stop();
            
            //disable button
            btnStop.Enabled = false;

            //Disable all buttons in the panel
            disableBtn();

            //Echo message why?
            echoMessage("Du hast das Spiel gestoppt - Die Spielrunde ist Vorüber\n Du hast " + points.ToString() + " Punkte und eine Geschwindigkeit von " + gameSpeed.ToString() + " erreicht");
        }

        /// <summary>
        /// This method reset all value and add 1 to var round 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            //Resets all vars to default
            resetSetting();

            //Create buttons in the panel
            generateBtn();

            //add 1 to rounds
            round++;

            //Echo message why?
            echoMessage("Klicke auf Start\nDas ist die " + round.ToString() + ". Spielrunde");
        }

        /// <summary>
        /// Game timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrGame_Tick(object sender, EventArgs e)
        {            
            //Buttons flowing down
            goDown();
        }

        /// <summary>
        /// This method checks if red button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redBtn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);

            if (btn.BackColor.Equals(Color.Red))
            {
                //If the player clicks on red button then the game should start without clicking on start button
                if (points == 0)
                {
                    //timer start
                    tmrGame.Start();

                    //disable or enables buttons
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    btnRestart.Enabled = true;
                }

                //Change button color to pink
                btn.BackColor = Color.Pink;

                //Change background image to richtig
                btn.BackgroundImage = Properties.Resources.richtig;

                //Disbale the button from preventing points boosting
                btn.Enabled = false;

                //Take points from the button and add them to points var 
                points += Convert.ToInt32(btn.Text);

                //Echo the points in textbox
                txbPunkte.Text = points.ToString();

                //Increment the speed                
                controlSpeed();

                //Remove those buttons which are not showing any more
                if (btn.Location.Y >= pnlBlocks.Height)
                {
                    pnlBlocks.Controls.Remove(btn);
                    btn.Dispose();
                }
            }
            else
            {
                //Timer stop
                tmrGame.Stop();

                //Disables all the buttons in the panel
                disableBtn();

                //Disable the following buttons
                btnStart.Enabled = false;
                btnStop.Enabled = false;
                btnRestart.Enabled = true;

                //Echo message why?
                echoMessage("Du hast das falsche Feld geklickt - Die Spielrunde ist vorüber.\nDu hast " + points.ToString() + " Punkte und eine Geschwindigkeit von " + gameSpeed.ToString() + " erreicht");
            }
        }

        /// <summary>
        /// This method generates buttons in the panel
        /// </summary>
        private void generateBtn()
        {
            //Generate the random button
            int randomBtn = r.Next(0, 4);

            //button properties
            int btnRow = 4;
            int btnCol = 6;
            int btnTotal = 250;
            int btnWidth = pnlBlocks.Width / btnRow;
            int btnHight = pnlBlocks.Height / btnCol;
            int btnNum = 0;
            int btnY = 0;

            for (int i = 0; btnNum <= btnTotal; i++)
            {
                btnNum++;
                Button btn = new Button();

                //button values
                btn.Name = "btnNum" + i.ToString();
                btn.Width = btnWidth;
                btn.Height = btnHight;
                btn.Text = btnNum.ToString();
                btn.BackColor = (i == randomBtn) ? Color.Red : Color.CadetBlue;
                btn.BackgroundImage = (i == randomBtn) ? nemo[r.Next(0, nemo.Length)] : o_nemo[r.Next(0, o_nemo.Length)];
                //strech the image to button size
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Click += new EventHandler(redBtn_Click);
                btn.Location = new Point(i * btnWidth, -btnY);            

                //Add button to buttons list
                buttons.Add(btn);                

                //This if block creates buttons, so they can spawn and flow downwards
                if (btn.Location.X == btnRow * btnWidth)
                {
                    i = 0;
                    randomBtn = r.Next(0, 3);
                    btnY += btnHight;
                    btn.Location = new Point(i * btnWidth, -btnY);
                    btn.BackColor = (i == randomBtn) ? Color.Red : Color.CadetBlue;
                    //strech the image to button size
                    btn.BackgroundImage = (i == randomBtn) ? nemo[r.Next(0, nemo.Length)] : o_nemo[r.Next(0, o_nemo.Length)];
                }

                //Add button to panel
                pnlBlocks.Controls.Add(btn);
            }          

        }
        
        /// <summary>
        /// This method moves the button downwards by adding gamespeed
        /// </summary>
        private void goDown()
        {
            //Loop through all buttons
            foreach (var btn in buttons)
            {               
                //Change Y location each button
                btn.Top += gameSpeed / smoothness;

                //Checking if Red button touched the bottom of the panel
                if (Color.Red.Equals(btn.BackColor) && btn.Top > pnlBlocks.Height)
                {
                    //if yes stop the timer
                    tmrGame.Stop();

                    //Disable the buttons from preventing to click and points adding
                    disableBtn();

                    //Disable or enables the buttons
                    btnStop.Enabled = false;
                    btnRestart.Enabled = true;

                    //Echo message why?
                    echoMessage("Du hast in der untersten Reihe nicht geklickt - Die Spielrunde ist vorüber.\nDu hast " + points.ToString() + " Punkte und eine Geschwindigkeit von " + gameSpeed.ToString() + " erreicht");
                }

            }
        }

        /// <summary>
        /// This methods disables buttons in the list
        /// </summary>
        private void disableBtn()
        {
            //Loop through all buttons
            foreach (var btn in buttons)
            {
                //Disable the button
                btn.Enabled = false;
            }
        }
        
        /// <summary>
        /// This method shows the given message in Info label
        /// </summary>
        /// <param name="message">Given message</param>
        private void echoMessage(string message)
        {
            //Show message in Label Info
            lblInfo.Text = message;
        }
        
        /// <summary>
        /// This method controls & shows game speed in progress bar
        /// </summary>
        private void controlSpeed()
        {
            gameSpeed += 2;
           
            //show the label
            lblSpeed.Visible = true;

            //show the speed in panel speed
            progressSpeed.Value = gameSpeed;

            //with speed counter
            lblSpeed.Text = gameSpeed.ToString();
        }

        private void resetSetting()
        {
            //reset all settings to 0
            points = 0;
            gameSpeed = 2;

            //stop the timer
            tmrGame.Stop();

            //disable or enable buttons
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnRestart.Enabled = false;

            //clear the panel
            pnlBlocks.Controls.Clear();
            buttons.Clear();

            //set progress speed value to 0
            progressSpeed.Value = 0;
            lblSpeed.Text = 0.ToString();
        }
    }
}
