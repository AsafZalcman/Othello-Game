using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OthelloLogic;

namespace WindowUi
{
    public partial class GameForm : Form
    {
        private const int k_FirstButtonPosition = 12;
        private const string k_FormName = "Othello - ";
        private const string k_NewGameMessege = "Would you like another round?";
        private readonly GameSettingsForm r_GameSettingForm;        
        private readonly Game r_OtheloLogicGame;
        private readonly OthelloBoardButton[,] r_BoardButtons;
        private readonly Player r_Player1, r_Player2;
        private BoardSigns.eBoardSigns m_CurrentTurnSign;
              
        public GameForm()
        {
            r_GameSettingForm = new GameSettingsForm();

            if (r_GameSettingForm.ShowDialog() == DialogResult.OK) 
            {
                r_Player1 = new Player("Red");
                r_Player2 = new Player("Yellow");
                r_OtheloLogicGame = new Game(r_GameSettingForm.BoardSize, r_GameSettingForm.GameType);
                r_BoardButtons = new OthelloBoardButton[r_GameSettingForm.BoardSize, r_GameSettingForm.BoardSize];
                InitializeComponent();
                createBoardButtons();
                ShowDialog();
            }
        }

        private void Board_Load(object sender, EventArgs e)
        {
            m_CurrentTurnSign = BoardSigns.eBoardSigns.Player1Sign;
            r_OtheloLogicGame.StartNewGame();
            Text = string.Format("{0} {1} Turn", k_FormName, r_Player1.Name);
            int clientSize = (r_BoardButtons.GetLength(0) * OthelloBoardButton.sr_ButtonSize) + (k_FirstButtonPosition * 2);
            ClientSize = new Size(clientSize, clientSize);                       
        }

        private void createBoardButtons()
        {
            int buttonXPosition;
            int boardSize = r_BoardButtons.GetLength(0);                       
            int buttonYPosition = k_FirstButtonPosition;      
          
            for (int row = 0; row < boardSize; row++) 
            {
                buttonXPosition = k_FirstButtonPosition;
                
                for (int col = 0; col < boardSize; col++)
                {
                    r_BoardButtons[row, col] = new OthelloBoardButton(row, col, buttonXPosition, buttonYPosition);              
                    r_OtheloLogicGame.GameBoard[row, col].m_ReportSignChangedDelegate += r_BoardButtons[row, col].ChangeButtonStatus;
                    Controls.Add(r_BoardButtons[row, col]);
                    r_BoardButtons[row, col].Click += BoardButton_Click;
                    buttonXPosition += OthelloBoardButton.sr_ButtonSize;                   
                }

                buttonYPosition += OthelloBoardButton.sr_ButtonSize;
            }
        }

        private void BoardButton_Click(object sender, EventArgs e)
        {
            OthelloBoardButton othelloBoardButton = sender as OthelloBoardButton;            
            r_OtheloLogicGame.Play(m_CurrentTurnSign, othelloBoardButton.RowIndex, othelloBoardButton.ColIndex);
            Refresh();
            Thread.Sleep(200);
            prepareNextUserTurn();     
        }

        private void prepareNextUserTurn()
        {       
            if (noMovesForPlayer(BoardSigns.GetOpositeSign(m_CurrentTurnSign)))
            {               
                if (noMovesForPlayer(m_CurrentTurnSign))
                {                   
                    askForNewGame();
                }                          
            }
            else
            {
                m_CurrentTurnSign = BoardSigns.GetOpositeSign(m_CurrentTurnSign);
                Text = string.Format("{0}{1} Turn", k_FormName, getCurrentPlayerName());

                if (r_OtheloLogicGame.PcTurn(m_CurrentTurnSign))
                {
                   r_OtheloLogicGame.GetPcCellChoice(out int row, out int col);                   
                   BoardButton_Click(r_BoardButtons[row, col], EventArgs.Empty);
                }
            }                      
        }
      
        private bool noMovesForPlayer(BoardSigns.eBoardSigns i_Sign)
        {
            return !r_OtheloLogicGame.ThereAreMoves(i_Sign);
        }

        private void askForNewGame()
        {
            string WinnerMsg = getWinnerMsg();
            string gameScore = r_OtheloLogicGame.GetScore();

            DialogResult answer = MessageBox.Show(
                string.Format(
@"{0} {1} ({2}\{3})
{4}",
                WinnerMsg,
                gameScore,
                r_Player1.Score.ToString(),
                r_Player2.Score.ToString(),
                k_NewGameMessege),
                "Othello",
                MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {
                r_OtheloLogicGame.StartNewGame();
                m_CurrentTurnSign = BoardSigns.eBoardSigns.Player1Sign;
            }
            else
            {
                Close();              
            }
        }
                 
        private string getWinnerMsg()
        {
            string winnerMsg;
            Game.eGameResultOptions result = r_OtheloLogicGame.GetWinnerSign();

            if (result == Game.eGameResultOptions.Sign1Wins) 
            {
                winnerMsg = r_Player1.Name + " Won!!";
                r_Player1.Score += 1;              
            }
            else if (result == Game.eGameResultOptions.Sign2Wins)
            {
                winnerMsg = r_Player2.Name + " Won!!";
                r_Player2.Score += 1;
            }
            else
            {
                winnerMsg = "Its a tie!!";
            }

            return winnerMsg;
        }

        private string getCurrentPlayerName()
        {
            string playerName;

            if (m_CurrentTurnSign == BoardSigns.eBoardSigns.Player1Sign) 
            {
                playerName = r_Player1.Name;
            }
            else
            {
                playerName = r_Player2.Name;
            }

            return playerName;
        }
    }
}
