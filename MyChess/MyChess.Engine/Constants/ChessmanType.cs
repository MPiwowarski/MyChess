using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Engine.Constants
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
        [Display(Name = "P")]
        Pawn = 1,
        [Display(Name = "K")]
        Knight = 2,
        [Display(Name = "B")]
        Bishop = 3,
        [Display(Name = "R")]
        Rook = 4,
        [Display(Name = "Q")]
        Queen = 5,
        [Display(Name = "M", Description = "King aka (M)aster")]
        King = 6
    }
}
