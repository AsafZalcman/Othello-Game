namespace OthelloLogic
{
   public static class BoardSigns
    {
        public enum eBoardSigns
        {
            Empty = 0,
            Player1Sign = 1,
            Player2Sign = 2,
            Option = 3,
        }

        public static eBoardSigns GetOpositeSign(eBoardSigns i_Sign)
        {
            eBoardSigns opositeSign = eBoardSigns.Player1Sign;

            if (i_Sign == eBoardSigns.Player1Sign)
            {
                opositeSign = eBoardSigns.Player2Sign;
            }

            return opositeSign;
        }
    }   
}
