using System;

namespace OthelloLogic
{
    internal class PcPlayer
    {
        private int m_NumOfOptions;

        internal int OptionsCounter
        {
            get { return m_NumOfOptions; }
            set { m_NumOfOptions = value; }
        }

        internal PcPlayer()
        {
            m_NumOfOptions = 4;
        }

        internal void GetCellToFill(Board i_Board, out int o_RowNumber, out int o_ColNumber)
        {
            Random randnum = new Random();
            int optionNum = randnum.Next(1, OptionsCounter);
            o_RowNumber = -1;
            o_ColNumber = -1;
            for (int row = 0; row < i_Board.GameBoard.GetLength(0) && optionNum != 0; row++)
            {
                for (int col = 0; col < i_Board.GameBoard.GetLength(1) && optionNum != 0; col++)
                {
                    if (i_Board.IsOptionalCell(i_Board.GameBoard[row, col].CellSign))
                    {
                        if (optionNum == 1)
                        {
                            o_RowNumber = row;
                            o_ColNumber = col;                            
                        }

                        optionNum--;
                    }
                }
            }          
        }    
    }
}
