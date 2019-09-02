namespace OthelloLogic
{
    internal class Board
    {
        private readonly BoardCell[,] r_GameBoard;

        internal BoardCell[,] GameBoard
        {
            get { return r_GameBoard; }
        }

        internal Board(int i_Size)
        {
            r_GameBoard = new BoardCell[i_Size, i_Size];
            InitializeBoard();
        }

        internal void InitializeBoard()
        {           
            int size = r_GameBoard.GetLength(0);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++) 
                {
                    r_GameBoard[row, col] = new BoardCell();
                }
            }           
        }

        internal int CalcOptions(BoardSigns.eBoardSigns i_PlayerSign)
        {
            int numOfOption = 0;

            for (int row = 0; row < r_GameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < r_GameBoard.GetLength(0); col++)
                {
                    if (!IsFullCell(row, col))
                    {
                        if (findOpositeSignInSquareAroundMe(row, col, BoardSigns.GetOpositeSign(i_PlayerSign)))
                        {
                            r_GameBoard[row, col].CellSign = BoardSigns.eBoardSigns.Option;
                            numOfOption++;
                        }
                        else
                        {
                            r_GameBoard[row, col].CellSign = BoardSigns.eBoardSigns.Empty;
                        }
                    }
                }
            }

            return numOfOption;
        }

        internal bool IsFullCell(int i_Row, int i_Col)
        {
            return r_GameBoard[i_Row, i_Col].CellSign == BoardSigns.eBoardSigns.Player1Sign || r_GameBoard[i_Row, i_Col].CellSign == BoardSigns.eBoardSigns.Player2Sign;
        }

        internal bool IsInBounds(int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < r_GameBoard.GetLength(0) && i_Col >= 0 && i_Col < r_GameBoard.GetLength(1);
        }
       
        internal void FillCell(int i_RowNumber, int i_ColNumber, BoardSigns.eBoardSigns i_Sign)
        {
            r_GameBoard[i_RowNumber, i_ColNumber].CellSign = i_Sign;
            findOpositeSignInSquareAroundMe(i_RowNumber, i_ColNumber, BoardSigns.GetOpositeSign(i_Sign));
        }

        private bool findOpositeSignInSquareAroundMe(int i_RowNumber, int i_ColNumber, BoardSigns.eBoardSigns i_OpositeSignToFind)
        {
            bool anyOptionFound = false;

            for (int rowDir = -1; rowDir < 2; rowDir++)
            {
                for (int colDir = -1; colDir < 2; colDir++)
                {
                    if (IsInBounds(i_RowNumber + rowDir, i_ColNumber + colDir) && r_GameBoard[i_RowNumber + rowDir, i_ColNumber + colDir].CellSign == i_OpositeSignToFind)
                    {
                        anyOptionFound |= findSignInDir(i_RowNumber, i_ColNumber, BoardSigns.GetOpositeSign(i_OpositeSignToFind), rowDir, colDir);
                    }
                }
            }

            return anyOptionFound;
        }

        private bool findSignInDir(int i_RowNumber, int i_ColNumber, BoardSigns.eBoardSigns i_SignToFind, int i_RowDir, int i_ColDir)
        {
            bool fullCell = IsFullCell(i_RowNumber, i_ColNumber);
            bool foundSign = false;

            i_RowNumber += i_RowDir;
            i_ColNumber += i_ColDir;

            while (IsInBounds(i_RowNumber, i_ColNumber))
            {
                if (r_GameBoard[i_RowNumber, i_ColNumber].CellSign == i_SignToFind)
                {
                    foundSign = true;
                    break;
                }
                else if (!IsFullCell(i_RowNumber, i_ColNumber))
                {
                    break;
                }

                i_RowNumber += i_RowDir;
                i_ColNumber += i_ColDir;
            }

            if (fullCell && foundSign)
            {
                flipSignsInDir(i_RowNumber - i_RowDir, i_ColNumber - i_ColDir, i_SignToFind, -i_RowDir, -i_ColDir);
            }

            return foundSign;
        }

        private void flipSignsInDir(int i_Row, int i_Col, BoardSigns.eBoardSigns i_SignToFlip, int i_RowDir, int i_ColDir)
        {
            while (r_GameBoard[i_Row, i_Col].CellSign != i_SignToFlip)
            {
                r_GameBoard[i_Row, i_Col].CellSign = i_SignToFlip;
                i_Row += i_RowDir;
                i_Col += i_ColDir;
            }
        }
              
        internal bool IsOptionalCell(BoardSigns.eBoardSigns i_SignOfCell)
        {
            return i_SignOfCell == BoardSigns.eBoardSigns.Option;
        }

        internal void ResetBoard()
        {
            int size = r_GameBoard.GetLength(0);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    r_GameBoard[row, col].CellSign = BoardSigns.eBoardSigns.Empty;
                }
            }

            r_GameBoard[(size / 2) - 1, (size / 2) - 1].CellSign = BoardSigns.eBoardSigns.Player2Sign;
            r_GameBoard[(size / 2) - 1, size / 2].CellSign = BoardSigns.eBoardSigns.Player1Sign;
            r_GameBoard[size / 2, (size / 2) - 1].CellSign = BoardSigns.eBoardSigns.Player1Sign;
            r_GameBoard[size / 2, size / 2].CellSign = BoardSigns.eBoardSigns.Player2Sign;
            CalcOptions(BoardSigns.eBoardSigns.Player1Sign);
        }
    }
}
