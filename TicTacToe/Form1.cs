namespace TicTacToe
{
    // <summary>
    // Form class that handles user clicks and CPU move
    // </summary>
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int cpuWinCount = 0;
        List<Button>? buttons;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        // <summary>
        // Checks which buttons are still available and randomly chooses one
        // Also checks if game has been won
        // </summary>
        private void CPUMove(object sender, EventArgs e)
        {
            if (buttons?.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();
            }
        }

        // <summary>
        // Gets the button user clicked and updates.
        // Also checks if game has been won
        // </summary>
        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons?.Remove(button);
            CheckGame();
            CPUTimer.Start();
        }

        // <summary>
        // Reset game via reset button from form
        // </summary>
        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        // <summary>
        // Checks to see if player or cpu has won the game.
        // Updates Player and CPU scores accordingly
        // </summary>
        private void CheckGame() 
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                ) 
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins!");
                playerWinCount++;
                playerLabel.Text = "Player Wins: " + playerWinCount;
                RestartGame();
            } 
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU Wins!");
                cpuWinCount++;
                cpuLabel.Text = "CPU Wins: " + cpuWinCount;
                RestartGame();
            }
        }

        // <summary>
        // Restarts game by reseting the text and making them enabled again
        // </summary>
        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4,
                button5, button6, button7, button8, button9 };
            
            foreach(Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
