﻿using MyChess.Engine.Dtos;

namespace MyChess.Engine
{
    public static class Game
    {
        public static int MapWidth = 8;
        public static int MapHeight = 8;

        /// <summary>
        /// The map array starts at element [0,0] and ends up at [7,7]
        /// </summary>
        public static int MapArrayLastIndex = 7;

        public static List<GameMapDto> InitMap()
        {
            var gameMap = new List<GameMapDto>();

            CreateEmptyMap(gameMap);
            InitWhitePlayerChessmen(gameMap);
            InitWhitePlayerChessmen(gameMap);

            return gameMap;
        }

        private static void InitWhitePlayerChessmen(List<GameMapDto> gameMap)
        {
            // init pawns
            for (int i = 0; i < MapWidth; i++)
            {
               gameMap.Where(field => field.X == i && field.Y == 0)
                    .Select(field => { field.ChessmanType = ChessmanType.Pawn; field.PlayerColor = PlayerColor.White; return field; })
                    .ToList();
            }

            // init rooks
            gameMap.Where(field => field.X == 0 && field.Y == 0)
                .Select(field => { field.ChessmanType = ChessmanType.Rook; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();
            gameMap.Where(field => field.X == 0 && field.Y == 7)
                .Select(field => { field.ChessmanType = ChessmanType.Rook; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();

            // init knights
            gameMap.Where(field => field.X == 0 && field.Y == 1)
                .Select(field => { field.ChessmanType = ChessmanType.Knight; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();
            gameMap.Where(field => field.X == 0 && field.Y == 6)
                .Select(field => { field.ChessmanType = ChessmanType.Knight; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();

            // init bishops
            gameMap.Where(field => field.X == 0 && field.Y == 2)
                .Select(field => { field.ChessmanType = ChessmanType.Bishop; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();
            gameMap.Where(field => field.X == 0 && field.Y == 5)
                .Select(field => { field.ChessmanType = ChessmanType.Bishop; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();

            // init queen
            gameMap.Where(field => field.X == 0 && field.Y == 4)
                .Select(field => { field.ChessmanType = ChessmanType.Queen; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();

            // init king
            gameMap.Where(field => field.X == 0 && field.Y == 5)
                .Select(field => { field.ChessmanType = ChessmanType.King; field.PlayerColor = PlayerColor.White; return field; })
                .ToList();
        }

        private static void InitBlackPlayerChessmen(List<GameMapDto> gameMap)
        {
            // init pawns
            for (int i = 0; i < MapWidth; i++)
            {
                gameMap.Where(field => field.X == i && field.Y == MapArrayLastIndex - 1)
                     .Select(field => { field.ChessmanType = ChessmanType.Pawn; field.PlayerColor = PlayerColor.Black; return field; })
                     .ToList();
            }

            // init rooks
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 0)
                .Select(field => { field.ChessmanType = ChessmanType.Rook; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 7)
                .Select(field => { field.ChessmanType = ChessmanType.Rook; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();

            // init knights
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 1)
                .Select(field => { field.ChessmanType = ChessmanType.Knight; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 6)
                .Select(field => { field.ChessmanType = ChessmanType.Knight; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();

            // init bishops
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 2)
                .Select(field => { field.ChessmanType = ChessmanType.Bishop; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 5)
                .Select(field => { field.ChessmanType = ChessmanType.Bishop; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();

            // init queen
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 4)
                .Select(field => { field.ChessmanType = ChessmanType.Queen; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();

            // init king
            gameMap.Where(field => field.X == MapArrayLastIndex && field.Y == 5)
                .Select(field => { field.ChessmanType = ChessmanType.King; field.PlayerColor = PlayerColor.Black; return field; })
                .ToList();
        }

        private static void CreateEmptyMap(List<GameMapDto> gameMap)
        {
            for (int w = 0; w < MapWidth; w++)
            {
                for (int h = 0; h < MapHeight; h++)
                {
                    gameMap.Add(new GameMapDto()
                    {
                        X = w,
                        Y = h,
                    });
                }
            }
        }
    }
}