﻿// See https://aka.ms/new-console-template for more information
using MyChess;
using MyChess.Engine;

Console.WriteLine("Welcome to MyChess game!");
Console.WriteLine(string.Empty);

var gameFields = MapCreator.InitMap();
MapDrawer.DrawDefaultMap(gameFields);
Console.WriteLine(string.Empty);
MapDrawer.DrawForBlackPlayer(gameFields);

