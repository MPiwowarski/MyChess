using MyChess.Engine.Constants;
using MyChess.Engine.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChess.Common;

namespace MyChess
{
    public static class MapDrawer
    {
        public const int MapDisplaySideLenght = MapProps.SideLenght + 2;
        public const int MapDisplayMaxArrayIndex = MapDisplaySideLenght - 1;

        /// <summary>
        /// The raw display for black player is a default one as iteration always starts from the top left corner
        /// </summary>
        public static IEnumerable<(int x, int y, string display)> DrawDefaultMap(IEnumerable<MapFieldDto> gameFields)
        {
            var mapFields = new List<(int x, int y, string display)>();

            for (int w = 0; w < MapProps.SideLenght; w++)
            {
                for (int h = 0; h < MapProps.SideLenght; h++)
                {
                    var field = gameFields.First(x => x.X == w && x.Y == h);
                    if (field.ChessmanType == ChessmanType.None)
                        mapFields.Add((w, h, $"{field.FieldColorShortcut} "));
                    else
                        mapFields.Add((w, h, $"{field.PlayerColorShortcut}{field.ChessmanType.GetAttribute<DisplayAttribute>()?.Name}"));
                }
            }

            for (int x = 0; x < MapProps.SideLenght; x++)
            {
                var rowPrint = string.Empty;
                for (int y = 0; y < MapProps.SideLenght; y++)
                {
                    var field = mapFields.First(f => f.x == x && f.y == y);
                    rowPrint += $"{field.display} ";
                }
                Console.WriteLine(rowPrint);
            }

            return mapFields;
        }

        public static IEnumerable<(int x, int y, string display)> DrawForBlackPlayer(IEnumerable<MapFieldDto> gameFields)
        {
            var mapFields = new List<(int x, int y, string display)>
            {
                (0, 0, "  "),
                (MapDisplayMaxArrayIndex, MapDisplayMaxArrayIndex, "  "),
                (MapDisplayMaxArrayIndex, 0, "  "),
                (0, MapDisplayMaxArrayIndex, "  ")
            };

            // init vertical numbers
            for (int y = 0; y < MapProps.SideLenght; y++)
            {
                mapFields.Add((0, y + 1, $"{Convert.ToChar(64 + MapProps.SideLenght - y)} "));
                mapFields.Add((MapDisplaySideLenght - 1, y + 1, $"{Convert.ToChar(64 + MapProps.SideLenght - y)} "));
            }

            // init horizontal letters
            for (int x = 0; x < MapProps.SideLenght; x++)
            {
                mapFields.Add((x + 1, 0, $"{x + 1} "));
                mapFields.Add((x + 1, MapDisplaySideLenght - 1, $"{x + 1} "));
            }

            for (int x = 1; x < MapProps.SideLenght + 1; x++)
            {
                for (int y = 1; y < MapProps.SideLenght + 1; y++)
                {
                    var field = gameFields.First(f => f.X == x - 1 && f.Y == y - 1);
                    mapFields.Add((x, y, field.Display));
                }
            }

            for (int x = 0; x < MapDisplaySideLenght; x++)
            {
                var rowPrint = string.Empty;
                for (int y = 0; y < MapDisplaySideLenght; y++)
                {
                    var field = mapFields.First(f => f.x == x && f.y == y);
                    rowPrint += $"{field.display} ";
                }
                Console.WriteLine(rowPrint);
            }

            return mapFields;
        }
    }
}
