﻿using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;

            const char CIRCLE = '\u25cf';

            int lastTick = 0;
            while(true)
            {
                #region 프레임 관
                // 만약에 경과한 시간이 1/30초보다 작다면
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick;
                #endregion


                // FPS 프레임 (60프레임 OK 30프레임 이하로 NO)
                // 입력
                // 로직
                // 렌더링
                Console.SetCursorPosition(0, 0);

                for(int i = 0; i< 25; i++)
                {
                    for(int j = 0; j<25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
