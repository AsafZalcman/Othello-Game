using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OthelloLogic;

namespace WindowUi
{
    public partial class GameSettingsForm : Form
    {
        private const int k_MaxBoardSize = 12;
        private const int k_MinBoardSize = 6;
        private int m_BoardSize = 6;

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        private GameType.eGameType m_GameType;
        
        public GameType.eGameType GameType
        {
            get { return m_GameType; }          
        }

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void GameSettingsForm_Load(object sender, EventArgs e)
        {
            BoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSize);           
        }

        private void BoardSizeButton_Click(object sender, EventArgs e)
        {
            if (m_BoardSize == k_MaxBoardSize) 
            {
                m_BoardSize = k_MinBoardSize;
            }
            else
            {
                m_BoardSize += 2;
            }

            BoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSize);
        }

        private void PlayerVsPcButton_Click(object sender, EventArgs e)
        {
            m_GameType = OthelloLogic.GameType.eGameType.playerVsPc;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PlayerVsPlayerButton_Click(object sender, EventArgs e)
        {
           m_GameType = OthelloLogic.GameType.eGameType.playerVsPlayer;
           DialogResult = DialogResult.OK;
           Close();
        }     
    }
}
