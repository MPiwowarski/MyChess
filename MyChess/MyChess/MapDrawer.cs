using MyChess.Engine.Constants;
using MyChess.Engine.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess
{
    public static class MapDrawer
    {
        public static void Draw(IEnumerable<MapFieldDto> gameFields)
        {
            var mapFields = new List<(int x, int y, string display)>();
            mapFields.Add((0, 0, " "));

            // init horizontal letters
            for (int w = 1; w < MapProps.MapWidth + 1; w++)
            {
                mapFields.Add((w, 0, Convert.ToChar(w + 64).ToString()));
            }
            // init vertical numbers
            for (int h = 1; h < MapProps.MapHeight + 1; h++)
            {
                mapFields.Add((0, h, h.ToString()));
            }

            for (int w = 0; w < MapProps.MapWidth; w++)
            {
                for (int h = 0; h < MapProps.MapHeight; h++)
                {
                    var field = gameFields.First(x => x.X == w && x.Y == h);
                    if (field.ChessmanType == Engine.ChessmanType.None)
                        mapFields.Add((w + 1, h + 1, field.FieldColorShortcut));
                    else
                        mapFields.Add((w + 1, h + 1, $"{field.PlayerColorShortcut}{field.ChessmanType.ToString()}"));
                }
            }

            for (int w = 0; w < MapProps.MapWidth + 1; w++)
            {
                for (int h = 0; h < MapProps.MapHeight + 1; h++)
                {
                    var field = mapFields.First(f => f.x == w && f.y == h);
                    Console.WriteLine(field.display);
                }
            }
        }
    }
}
