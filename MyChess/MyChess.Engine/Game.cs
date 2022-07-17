using MyChess.Engine.Constants;
using MyChess.Engine.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Engine
{
    public class Game
    {
        public void MakeMove(List<MapFieldDto> gameMap, PlayerColor playerColor,
            (VerticalFieldLabel x, HorizontalFieldLabel y) from, (VerticalFieldLabel x, HorizontalFieldLabel y) to)
        {
            var chessman = gameMap.FirstOrDefault(f => f.X == (int)from.x && f.Y == (int)from.y && f.PlayerColor == playerColor);

            if (chessman == null)
                throw new Exception(ErrorMessage.InvalidMove);


            if (playerColor == PlayerColor.White)
            {
                if (chessman.ChessmanType == ChessmanType.Pawn)
                {
                    if (to.y < from.y)
                        throw new Exception(ErrorMessage.PawnBackwardMove);
                    if (to.y == from.y && to.x != from.x)
                        throw new Exception(ErrorMessage.PawnSideMove);
                }
            }
            else
            {

            }


        }
    }

    public static class ErrorMessage
    {
        public const string InvalidMove = "Invalid Move";

        public const string PawnBackwardMove = "Pawn Cannot Move Backward";
        public const string PawnSideMove = "Pawn Cannot Move Sides";

    }

}
