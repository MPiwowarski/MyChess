using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Engine.Dtos
{
    public class MapFieldDto
    {
        /// <summary>
        /// X co-ordinate; starts with 0 as it refers to array
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y co-ordinate; starts with 0 as it refers to array
        /// </summary>
        public int Y { get; set; }

        public string XChar { get => (X + 1).ToString(); }

        public bool IsWhite { get => X + Y % 2 == 0; }

        public bool IsBlack { get => X + Y % 2 != 0; }

        public string FieldColorShortcut { get => IsWhite ? "w" : "b"; }

        public string YChar
        {
            // 65 represents char 'a' in Utf
            get => Convert.ToChar(Y + 65).ToString();
        }

        public ChessmanType ChessmanType { get; set; }

        public PlayerColor PlayerColor { get; set; }

        public string PlayerColorShortcut { get => PlayerColor == PlayerColor.White ? "w" : "b"; }
    }
}
