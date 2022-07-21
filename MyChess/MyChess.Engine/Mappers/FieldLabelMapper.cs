using MyChess.Engine.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Engine.Mappers
{
    public static class FieldLabelMapper
    {
        public static HorizontalFieldLabel ToHorizontalFieldLabel(this char horizontalFieldLabel)
        {
            switch (horizontalFieldLabel)
            {
                case '1':
                    return HorizontalFieldLabel._1;
                case '2':
                    return HorizontalFieldLabel._2;
                case '3':
                    return HorizontalFieldLabel._3;
                case '4':
                    return HorizontalFieldLabel._4;
                case '5':
                    return HorizontalFieldLabel._5;
                case '6':
                    return HorizontalFieldLabel._6;
                case '7':
                    return HorizontalFieldLabel._7;
                case '8':
                    return HorizontalFieldLabel._8;
                default:
                    throw new Exception("Wrong Value");
            }
        }

        public static VerticalFieldLabel ToVerticalFieldLabel(this char horizontalFieldLabel)
        {
            switch (horizontalFieldLabel)
            {
                case 'A':
                    return VerticalFieldLabel.A;
                case 'B':
                    return VerticalFieldLabel.B;
                case 'C':
                    return VerticalFieldLabel.C;
                case 'D':
                    return VerticalFieldLabel.D;
                case 'E':
                    return VerticalFieldLabel.E;
                case 'F':
                    return VerticalFieldLabel.F;
                case 'G':
                    return VerticalFieldLabel.G;
                case 'H':
                    return VerticalFieldLabel.H;
                default:
                    throw new Exception("Wrong Value");
            }
        }

        public static ((VerticalFieldLabel x, HorizontalFieldLabel y) from, (VerticalFieldLabel x, HorizontalFieldLabel y) to) ToMapCoordinates(this string? move)
        {
            if (string.IsNullOrWhiteSpace(move) || move.Length != 5)
            {
                throw new Exception("Invalid move format. The proper format is e.g.'A2 A3'.");
            }

            (VerticalFieldLabel x, HorizontalFieldLabel y) from;
            (VerticalFieldLabel x, HorizontalFieldLabel y) to;

            var moves = move.Split(" ");

            from = (moves[0][0].ToVerticalFieldLabel(), moves[0][1].ToHorizontalFieldLabel());
            to = (moves[1][0].ToVerticalFieldLabel(), moves[1][1].ToHorizontalFieldLabel());

            return (from, to);
        }
    }
}
