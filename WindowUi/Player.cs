using System;
using System.Collections.Generic;
using System.Text;

namespace WindowUi
{
    public class Player
    {
        private readonly string m_Name;

        public string Name
        {
            get { return m_Name; }
        }

        private int m_Score;

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Score = 0;
        }
    }
}
