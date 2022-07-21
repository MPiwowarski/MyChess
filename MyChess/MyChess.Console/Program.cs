// See https://aka.ms/new-console-template for more information
using MyChess;
using MyChess.Engine;
using MyChess.Engine.Constants;
using MyChess.Engine.Mappers;

Console.WriteLine("Welcome to MyChess game!");
Console.WriteLine(string.Empty);

var gameFields = MapCreator.InitMap();
MapDrawer.DrawDefaultMap(gameFields);
Console.WriteLine(string.Empty);
MapDrawer.DrawForBlackPlayer(gameFields);

var isWhiteToMove = true;

while (true)
{
    (VerticalFieldLabel x, HorizontalFieldLabel y) from;
    (VerticalFieldLabel x, HorizontalFieldLabel y) to;

    if (isWhiteToMove)
    {
        Console.WriteLine("White Player Move:");
        var rawMove = Console.ReadLine();
        var move = rawMove.ToMapCoordinates();
        gameFields = Game.MakeMove(gameFields, PlayerColor.White, move.from, move.to);
    }
    else
    {
        Console.WriteLine("Black Player Move:");
        var move = Console.ReadLine();
    }

    MapDrawer.DrawForBlackPlayer(gameFields);
}

