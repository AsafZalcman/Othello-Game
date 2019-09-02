namespace OthelloLogic
{
    public class Game
    {
        private const int k_StartingScore = 2;
        private const int k_StartingNumOfOptions = 4;
        private readonly GameType.eGameType r_GameType;

        public enum eGameResultOptions
        {
            Tie,
            Sign1Wins,
            Sign2Wins,
        }

        private readonly Board r_Board;

        public BoardCell[,] GameBoard
        {
            get { return r_Board.GameBoard; }
        }

        private readonly PcPlayer r_PcPlayer = null;
        private int m_BlackScore;
        private int m_WhiteScore;

        public Game(int i_BoardSize, GameType.eGameType i_GameType)
        {
            r_Board = new Board(i_BoardSize);            
            m_BlackScore = k_StartingScore;
            m_WhiteScore = k_StartingScore;
            r_GameType = i_GameType;

            if (GameType.IsPlayerVsPc(r_GameType))
            {
                r_PcPlayer = new PcPlayer();
            }
        }

        public bool ThereAreMoves(BoardSigns.eBoardSigns i_PlayerSign)
        {
            int numberOfOptions = r_Board.CalcOptions(i_PlayerSign);

            if (PcTurn(i_PlayerSign))
            {
                r_PcPlayer.OptionsCounter = numberOfOptions;
            }

            return numberOfOptions != 0;
        }

        public void Play(BoardSigns.eBoardSigns io_CurrentTureSign, int i_RowNumber, int i_ColNumber)
        {
            r_Board.FillCell(i_RowNumber, i_ColNumber, io_CurrentTureSign);
            updateScore();
        }

        private void updateScore()
        {
            m_BlackScore = 0;
            m_WhiteScore = 0;

            foreach (BoardCell cell in r_Board.GameBoard)
            {
                if (cell.CellSign == BoardSigns.eBoardSigns.Player1Sign)
                {
                    m_BlackScore++;
                }
                else if (cell.CellSign == BoardSigns.eBoardSigns.Player2Sign)
                {
                    m_WhiteScore++;
                }
            }
        }

       public void StartNewGame()
        {
            r_Board.ResetBoard();          
            m_BlackScore = k_StartingScore;
            m_WhiteScore = k_StartingScore;           
        }
        
        public bool SecondPlayerTurn(BoardSigns.eBoardSigns i_CurrentTurnSign)
        {
            return i_CurrentTurnSign == BoardSigns.eBoardSigns.Player2Sign;
        }

        public bool PcTurn(BoardSigns.eBoardSigns i_CurrentTurnSign)
        {
            return SecondPlayerTurn(i_CurrentTurnSign) && GameType.IsPlayerVsPc(r_GameType);
        }
              
        private bool isPlayer1Won()
        {
            return m_BlackScore > m_WhiteScore;
        }

        private bool isPlayer2Won()
        {
            return m_BlackScore < m_WhiteScore;
        }

        public void GetPcCellChoice(out int o_RowNumber, out int o_ColNumber)
        {
            r_PcPlayer.GetCellToFill(r_Board, out o_RowNumber, out o_ColNumber);
        }

        public eGameResultOptions GetWinnerSign()
        {
            eGameResultOptions result;

            if(isPlayer1Won())
            {
                result = eGameResultOptions.Sign1Wins;
            }
            else if(isPlayer2Won())
            {
                result = eGameResultOptions.Sign2Wins;
            }
            else
            {
                result = eGameResultOptions.Tie;
            }

            return result;
        }

        public string GetScore()
        {           
            return string.Format("({0}\\{1})", m_BlackScore.ToString(), m_WhiteScore.ToString());
        }
    }
}
