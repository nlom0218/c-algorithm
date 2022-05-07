using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        Random _random = new Random();

        Board _board;

        public void Initialize(int posY, int posX, int destY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                // 0.1초 마다 실행될 로직
                int randValue = _random.Next(0, 5);
                switch (randValue)
                {
                    case 0: // 상
                        if (_board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        break;
                    case 1: // 하
                        if (_board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                    case 2: // 좌
                        if (_board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;
                    case 3: // 우
                        if (_board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        break;
                }

            }
        }
    }
}