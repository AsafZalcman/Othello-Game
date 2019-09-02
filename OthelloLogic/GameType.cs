using System;
using System.Collections.Generic;
using System.Text;

namespace OthelloLogic
{
    public static class GameType
    {
        public enum eGameType
        {
            playerVsPlayer = 1,
            playerVsPc = 2,
        }

        internal static bool IsPlayerVsPlayer(eGameType i_GameType)
        {
            return i_GameType == eGameType.playerVsPlayer;
        }

        internal static bool IsPlayerVsPc(eGameType i_GameType)
        {
            return !IsPlayerVsPlayer(i_GameType);
        }
    }
}
