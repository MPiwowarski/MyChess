using MyChess.Engine;
using MyChess.Engine.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Tests.ConsoleTests
{
    public class MapDrawerTests
    {
        [Test]
        public void DrawDefaultMap_should_return_proper_fields()
        {
            var expectedMapForDefault = new string[MapProps.SideLenght, MapProps.SideLenght] {
                { "wR", "wK","wB", "wQ","wM", "wB","wK", "wR" },
                { "wP", "wP","wP", "wP","wP", "wP","wP", "wP" },
                { "w ", "b ","w ", "b ","w ", "b ","w ", "b " },
                { "b ", "w ","b ", "w ","b ", "w ","b ", "w " },
                { "w ", "b ","w ", "b ","w ", "b ","w ", "b " },
                { "b ", "w ","b ", "w ","b ", "w ","b ", "w " },
                { "bP", "bP","bP", "bP","bP", "bP","bP", "bP" },
                { "bR", "bK","bB", "bQ","bM", "bB","bK", "bR" }
            };

            var fields = MapDrawer.DrawDefaultMap(Game.InitMap());
            for (int x = 0; x < MapProps.SideLenght; x++)
            {
                for (int y = 0; y < MapProps.SideLenght; y++)
                {
                    var expectedDispaly = expectedMapForDefault[x, y];
                    var actualDisplay = fields.First(f => f.x == x && f.y == y).display;
                    Assert.That(actualDisplay, Is.EqualTo(expectedDispaly));
                }
            }
        }

        [Test]
        public void ExpectedMapForBlackPlayer_should_return_proper_fields()
        {
            var expectedMapForBlackPlayer = new string[,] {
                { "  ","H ", "G ","F ", "E ","D ", "C ","B ", "A ", "  " },
                { "1 ","wR", "wK","wB", "wQ","wM", "wB","wK", "wR", "1 " },
                { "2 ","wP", "wP","wP", "wP","wP", "wP","wP", "wP", "2 " },
                { "3 ","w ", "b ","w ", "b ","w ", "b ","w ", "b ", "3 " },
                { "4 ","b ", "w ","b ", "w ","b ", "w ","b ", "w ", "4 " },
                { "5 ","w ", "b ","w ", "b ","w ", "b ","w ", "b ", "5 " },
                { "6 ","b ", "w ","b ", "w ","b ", "w ","b ", "w ", "6 " },
                { "7 ","bP", "bP","bP", "bP","bP", "bP","bP", "bP", "7 " },
                { "8 ","bR", "bK","bB", "bQ","bM", "bB","bK", "bR", "8 " },
                { "  ","H ", "G ","F ", "E ","D ", "C ","B ", "A ", "  " },
            };

            var fields = MapDrawer.DrawForBlackPlayer(Game.InitMap());
            for (int x = 0; x < MapDrawer.MapDisplaySideLenght; x++)
            {
                for (int y = 0; y < MapDrawer.MapDisplaySideLenght; y++)
                {
                    var expectedDispaly = expectedMapForBlackPlayer[x, y];
                    var actualDisplay = fields.First(f => f.x == x && f.y == y).display;
                    Assert.That(actualDisplay, Is.EqualTo(expectedDispaly));
                }
            }
        }
    }
}
