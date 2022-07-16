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
        /// <summary>
        /// The raw display for black player is a default one as iteration always starts from the top left corner
        /// </summary>
        public static void DrawRaw(IEnumerable<MapFieldDto> gameFields)
        {
            var mapFields = new List<(int x, int y, string display)>();

            for (int w = 0; w < MapProps.SideLenght; w++)
            {
                for (int h = 0; h < MapProps.SideLenght; h++)
                {
                    var field = gameFields.First(x => x.X == w && x.Y == h);
                    if (field.ChessmanType == Engine.ChessmanType.None)
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
        }

        public static void DrawForBlackPlayer(IEnumerable<MapFieldDto> gameFields)
        {
            var mapFields = new List<(int x, int y, string display)>();
            var mapDisplaySideLenght = MapProps.SideLenght + 2;
            var mapDisplayMaxArrayIndex = mapDisplaySideLenght - 1;

            mapFields.Add((0, 0, "  "));
            mapFields.Add((mapDisplayMaxArrayIndex, mapDisplayMaxArrayIndex, "  "));
            mapFields.Add((mapDisplayMaxArrayIndex, 0, "  "));
            mapFields.Add((0, mapDisplayMaxArrayIndex, "  "));

            // init vertical numbers
            for (int y = 0; y < MapProps.SideLenght; y++)
            {
                mapFields.Add((0, y + 1, $"{Convert.ToChar(64 + MapProps.SideLenght - y)} "));
                mapFields.Add((mapDisplaySideLenght - 1, y + 1, $"{Convert.ToChar(64 + MapProps.SideLenght - y)} "));
            }

            // init horizontal letters
            for (int x = 0; x < MapProps.SideLenght; x++)
            {
                mapFields.Add((x + 1, 0, $"{x + 1} "));
                mapFields.Add((x + 1, mapDisplaySideLenght - 1, $"{x + 1} "));
            }

            for (int x = 1; x < MapProps.SideLenght + 1; x++)
            {
                for (int y = 1; y < MapProps.SideLenght + 1; y++)
                {
                    var field = gameFields.First(f => f.X == x - 1 && f.Y == y - 1);
                    if (field.ChessmanType == Engine.ChessmanType.None)
                        mapFields.Add((x, y, $"{field.FieldColorShortcut} "));
                    else
                        mapFields.Add((x, y, $"{field.PlayerColorShortcut}{field.ChessmanType.GetAttribute<DisplayAttribute>()?.Name}"));
                }
            }


            for (int x = 0; x < mapDisplaySideLenght; x++)
            {
                var rowPrint = string.Empty;
                for (int y = 0; y < mapDisplaySideLenght; y++)
                {
                    var field = mapFields.First(f => f.x == x && f.y == y);
                    rowPrint += $"{field.display} ";
                }
                Console.WriteLine(rowPrint);
            }
        }
    }
}
