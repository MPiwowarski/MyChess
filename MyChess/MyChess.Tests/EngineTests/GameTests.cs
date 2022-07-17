using MyChess.Engine;
using MyChess.Engine.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Tests.EngineTests
{
    public class GameTests
    {
        public string[,] ExpectedMap = new string[MapProps.SideLenght, MapProps.SideLenght] {
            { "wR", "wK","wB", "wQ","wM", "wB","wK", "wR" },
            { "wP", "wP","wP", "wP","wP", "wP","wP", "wP" },
            { "w ", "b ","w ", "b ","w ", "b ","w ", "b " },
            { "b ", "w ","b ", "w ","b ", "w ","b ", "w " },
            { "w ", "b ","w ", "b ","w ", "b ","w ", "b " },
            { "b ", "w ","b ", "w ","b ", "w ","b ", "w " },
            { "bP", "bP","bP", "bP","bP", "bP","bP", "bP" },
            { "bR", "bK","bB", "bQ","bM", "bB","bK", "bR" }
        };

        [Test]
        public void InitMap_should_return_proper_fields()
        {
            var fields = Game.InitMap();
            for (int x = 0; x < MapProps.SideLenght; x++)
            {
                for (int y = 0; y < MapProps.SideLenght; y++)
                {
                    var expectedDispaly = ExpectedMap[x,y];
                    var actualDisplay = fields.First(f => f.X == x && f.Y == y).Display;
                    Assert.That(actualDisplay, Is.EqualTo(expectedDispaly));
                }
            }
        }
    }
}
