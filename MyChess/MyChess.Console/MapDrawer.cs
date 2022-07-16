﻿using MyChess.Engine.Constants;
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

            for (int w = 0; w < MapProps.MapWidth; w++)
            {
                for (int h = 0; h < MapProps.MapHeight; h++)
                {
                    var field = gameFields.First(x => x.X == w && x.Y == h);
                    if (field.ChessmanType == Engine.ChessmanType.None)
                        mapFields.Add((w, h, $"{field.FieldColorShortcut} "));
                    else
                        mapFields.Add((w, h, $"{field.PlayerColorShortcut}{field.ChessmanType.GetAttribute<DisplayAttribute>()?.Name}"));
                }
            }

            for (int w = 0; w < MapProps.MapWidth; w++)
            {
                var rowPrint = string.Empty;
                for (int h = 0; h < MapProps.MapHeight; h++)
                {
                    var field = mapFields.First(f => f.x == w && f.y == h);
                    rowPrint += $"{field.display} ";
                }
                Console.WriteLine(rowPrint);
            }
        }

        public static void DrawForBlackPlayer(IEnumerable<MapFieldDto> gameFields)
        {
            var mapFields = new List<(int x, int y, string display)>();
            mapFields.Add((0, 8, "  "));

            // init horizontal letters
            for (int w = 1; w < MapProps.MapWidth + 1; w++)
            {
                mapFields.Add((w, MapProps.MapHeight, $"{Convert.ToChar(w + 64)} "));
            }
            // init vertical numbers
            for (int h = 0; h < MapProps.MapHeight; h++)
            {
                mapFields.Add((MapProps.MapHeight + 1, h, $"{MapProps.MapHeight - h} "));
            }

            for (int w = 1; w < MapProps.MapWidth + 1; w++)
            {
                for (int h = 0; h < MapProps.MapHeight; h++)
                {
                    var field = gameFields.First(x => x.X == w - 1 && x.Y == h);
                    if (field.ChessmanType == Engine.ChessmanType.None)
                        mapFields.Add((w, h, $"{field.FieldColorShortcut} "));
                    else
                        mapFields.Add((w, h, $"{field.PlayerColorShortcut}{field.ChessmanType.GetAttribute<DisplayAttribute>()?.Name}"));
                }
            }

            for (int w = 0; w < MapProps.MapWidth + 1; w++)
            {
                var rowPrint = string.Empty;
                for (int h = 0; h < MapProps.MapHeight + 1; h++)
                {
                    var field = mapFields.First(f => f.x == w && f.y == h);
                    rowPrint += $"{field.display} ";
                }
                Console.WriteLine(rowPrint);
            }
        }
    }
}
