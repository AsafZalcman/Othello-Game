using System;
using System.Collections.Generic;
using System.Text;

namespace OthelloLogic
{   
    public class BoardCell
    {
        private BoardSigns.eBoardSigns m_CellSign;

        internal BoardSigns.eBoardSigns CellSign
        {
            get { return m_CellSign; }
            set
            {
                m_CellSign = value;
                m_ReportSignChangedDelegate.Invoke(this.CellSign);
            }
        }

        public event Action<BoardSigns.eBoardSigns> m_ReportSignChangedDelegate;

        internal BoardCell()
        {
        }       
    }
}
