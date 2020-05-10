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
        /// Counter for button spacing
        /// </summary>
        int count = 0;

        /// <summary>
        /// button value counter
        /// </summary>
        int countBtns = 0;

        /// <summary>
        /// Game speed
        /// </summary>
        int gameSpeed = 0;

        /// <summary>
        /// Buttons movement
        /// </summary>
        int smoothness = 5;

        /// <summary>
        /// Genetrates a random number
        /// </summary>
        Random r = new Random();

        /// <summary>
        /// Generated button will be saved in here
        /// </summary>
        List <Button> buttons = new List<Button>();

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
            generateBlock();

            //disable buttons
            btnStop.Enabled = false;
            btnRestart.Enabled = false;
        }

        /// <summary>
        /// This method start the game and disables the following buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Start timer
            tmrGame.Start();

            //disable or enable buttons
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
            //reset all settings to 0
            points = 0;
            gameSpeed = 0;
            count = 0;
            countBtns = 0;

            //stop the timer
            tmrGame.Stop();

            //disable or enable buttons
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnRestart.Enabled = false;

            //clear the panel
            pnlBlocks.Controls.Clear();
            buttons.Clear();
            generateBlock();

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
            //Increment count
            count++;
            
            //this line create space between buttons
            if (count % smoothness == 0) generateBlock();
            
            //Buttons flowing downwards
            goDown();
        }

        /// <summary>
        /// This method checks if red button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redBtn_Click(object sender, EventArgs e)
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
            (sender as Button).BackColor = Color.Pink;
            
            //Disbale the button from preventing points boosting
            (sender as Button).Enabled = false;

            //Take pionts from the button
            points += Convert.ToInt32((sender as Button).Text);

            //Echo the points in textbox
            txbPunkte.Text = points.ToString();

            //Increment the speed
            controlSpeed();
        }

        /// <summary>
        /// This method checks if green button is pressed
        /// </summary>
        /// <param name="sender">Object button</param>
        /// <param name="e">Click event</param>
        private void greenBtn_Click(object sender, EventArgs e)
        {
            //Timer stop
            tmrGame.Stop();

            //Disables all the buttons in the panel
            disableBtn();

            //Disable the following buttons
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            //Echo message why?
            echoMessage("Du hast das falsche Feld geklickt - Die Spielrunde ist vorüber.\nDu hast " + points.ToString() + " Punkte und eine Geschwindigkeit von " + gameSpeed.ToString() + " erreicht");
        }

        /// <summary>
        /// This method will check if the button hits panel bottom, then game will stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBtn(object sender, EventArgs e)
        {
            //Checking if Red button touched the bottom of the panel
            if (Color.Red == (sender as Button).BackColor && (sender as Button).Top > pnlBlocks.Height)
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


        /// <summary>
        /// This method generates row of buttons in panel
        /// </summary>
        private void generateBlock()
        {
            //Generate the random button
            int randomBtn = r.Next(0, 4);

            //Generate button when the form is loaded
            if (countBtns == 0)
            {
                //Generate 4 buttons each row 
                for (int i = 0; i < 4; i++)
                {
                    //Increment countbtns 
                    countBtns++;

                    //Create random red button
                    bool redBtn = (i == randomBtn);

                    //Add button to the panel
                    Button btn = addBtn(i, redBtn, 0);
                    this.pnlBlocks.Controls.Add(btn);
                    buttons.Add(btn);
                }
            }

            //click on start or press the red button
            for (int i = 0; i < 4; i++)
            {
                //Increment countbtns 
                countBtns++;

                //Create random red button
                bool redBtn = (i == randomBtn);

                //Add button to the panel
                Button btn = addBtn(i, redBtn, -50);
                this.pnlBlocks.Controls.Add(btn);
                buttons.Add(btn);
            }
        }   

        /// <summary>
        /// This method generates a button
        /// </summary>
        /// <param name="i">This param is for button name</param>
        /// <param name="redBtn">This param is for the red button</param>
        /// <param name="btnY">This param defeines the Location Y of button</param>
        /// <returns>And returns the generated button</returns>
        private Button addBtn(int i, bool redBtn, int btnY)
        {
            //Button object
            Button btn = new Button();

            //Button settings
            btn.Name = "btn" + i.ToString();
            btn.Text = countBtns.ToString();
            btn.Width = pnlBlocks.Width / 4;
            btn.Height = 50;
            btn.Location = new Point(i * (pnlBlocks.Width / 4), btnY);
            btn.BackColor = redBtn ? Color.Red : Color.CadetBlue;            
            btn.Click += redBtn ? new EventHandler(this.redBtn_Click) : new EventHandler(this.greenBtn_Click);
            btn.LocationChanged += new EventHandler(this.checkBtn);

            //Returns the button
            return btn;
        }
        
        /// <summary>
        /// This method moves the button downwards by adding + 5 px
        /// </summary>
        private void goDown()
        {
            //Loop through all buttons
            foreach (var btn in buttons)
            {
                //Change Y location each button
                btn.Top = btn.Location.Y + 50 / smoothness;
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
            //Increment the speed
            gameSpeed++;

            //If speed is 100 or more and Timer tick value = 20, this is the max speed
            if (gameSpeed >= 100)
            {
                tmrGame.Interval = 20;
            }
            else 
            {
                tmrGame.Interval = 120 - gameSpeed;
            }

            //Hide speed label, if speed is 0
            if (gameSpeed == 0)
            {
                lblSpeed.Visible = false;
            }
            else
            {
                //show the label
                lblSpeed.Visible = true;

                //show the speed in panel speed
                lblSpeed.Width = pnlSpeed.Width / 100 * gameSpeed;
                //with speed counter
                lblSpeed.Text = gameSpeed.ToString();
            }
        }
    }
}
