using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OthelloLogic;

namespace WindowUi
{
    public class OthelloBoardButton : PictureBox
    {
        public static readonly int sr_ButtonSize = 40;

        private readonly int r_RowIndex;

        public int RowIndex
        {
            get { return r_RowIndex; }
        }

        private readonly int r_ColIndex;

        public int ColIndex
        {
            get { return r_ColIndex; }
        }

        public OthelloBoardButton(int i_RowIndex, int i_ColIndex, int i_ButtonXPosition, int i_ButtonYPosition)
        {
            r_RowIndex = i_RowIndex;
            r_ColIndex = i_ColIndex;
            Name = string.Format("{0}x{1} button", r_RowIndex, r_ColIndex);
            Width = sr_ButtonSize;
            Height = sr_ButtonSize;
            Location = new Point(i_ButtonXPosition, i_ButtonYPosition);
        }

        public void ChangeButtonStatus(BoardSigns.eBoardSigns i_Sign)
        {
            switch (i_Sign)
            {
                case BoardSigns.eBoardSigns.Player1Sign:
                    {
                        BackColor = Color.LightGray;
                        Image = Properties.Resources.RedCoin;
                        BorderStyle = BorderStyle.Fixed3D;
                        SizeMode = PictureBoxSizeMode.StretchImage;
                        Enabled = false;                       
                        break;
                    }

                case BoardSigns.eBoardSigns.Player2Sign:
                    {
                        BackColor = Color.LightGray;
                        Image = Properties.Resources.YellowCoin;                        
                        BorderStyle = BorderStyle.Fixed3D;
                        SizeMode = PictureBoxSizeMode.StretchImage;
                        Enabled = false;
                        break;
                    }

                case BoardSigns.eBoardSigns.Option:
                    {
                        BackColor = Color.Green;
                        Image = null;
                        Enabled = true;
                        BorderStyle = BorderStyle.Fixed3D;
                        break;
                    }

                case BoardSigns.eBoardSigns.Empty:
                    {
                        BackColor = Color.LightGray;
                        Image = null;                      
                        Enabled = false;       
                        BorderStyle = BorderStyle.Fixed3D;
                        break;
                    }
            }
        }
    }
}
