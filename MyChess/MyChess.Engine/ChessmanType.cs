using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Engine
{
    public static class ChessmanTypeName
    {
        public static string Pawn = "Pawn";
        public static string Knight = "Knight";
        public static string Bishop = "Bishop";
        public static string Rook = "Rook";
        public static string Queen = "Queen";
        public static string King = "King";
    }

    public enum ChessmanType
    {
        None = 0,
        Pawn = 1,
        Knight = 2,
        Bishop = 3,
        Rook = 4,
        Queen = 5,
        King = 6
    }
}
