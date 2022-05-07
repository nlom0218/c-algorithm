using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Board board = new Board();
            // Player player = new Player();
            // board.Initialize(25, player);
            // player.Initialize(1, 1, board);

            // Console.CursorVisible = false;

            // const int WAIT_TICK = 1000 / 30;

            // int lastTick = 0;

            // while (true)
            // {
            //     #region 프레임 관리
            //     // 만약에 경과한 시간인 1/30초보다 작다면
            //     int currentTick = System.Environment.TickCount;
            //     if (currentTick - lastTick < WAIT_TICK)
            //         continue;
            //     int deltaTick = currentTick - lastTick;
            //     lastTick = currentTick;
            //     #endregion

            //     player.Update(deltaTick);

            //     Console.SetCursorPosition(0, 0);
            //     board.Render();
            // }

            // 스택: LIFO(후입선출 Last in First out)
            // 큐: FIFO(선입선출 First in First out)

            // [1] [2] [3] [4]

            Stack<int> stack = new Stack<int>();
            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);

            int data = stack.Pop();
            int data2 = stack.Peek();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);

            int data3 = queue.Dequeue();
            int data4 = queue.Peek();

            // 왜 스택과 큐를 사용하는가? 의사소통에 큰 도움이 된다. 
            // 연결리스트, 동적 배열의 축소판이다.
        }
    }
}