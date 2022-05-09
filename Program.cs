using System;
using System.Collections.Generic;

namespace Algorithm
{

    class Program
    {
        // static TreeNode<string> MakeTree()
        // {
        //     TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
        //     {
        //         {
        //             TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
        //             // node.Children.Add(new TreeNode<string>() { Data = "전투" });
        //             // node.Children.Add(new TreeNode<string>() { Data = "경제" });
        //             // node.Children.Add(new TreeNode<string>() { Data = "스토리" });
        //             root.Children.Add(node);
        //         }
        //         {
        //             TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
        //             node.Children.Add(new TreeNode<string>() { Data = "서버" });
        //             node.Children.Add(new TreeNode<string>() { Data = "클라" });
        //             node.Children.Add(new TreeNode<string>() { Data = "엔진" });
        //             root.Children.Add(node);
        //         }
        //         {
        //             TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
        //             // node.Children.Add(new TreeNode<string>() { Data = "배경" });
        //             // node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
        //             root.Children.Add(node);
        //         }
        //     }
        //     return root;
        // }

        // static void PrintTree(TreeNode<string> root)
        // {
        //     // 접근
        //     System.Console.WriteLine(root.Data);

        //     foreach (TreeNode<string> child in root.Children)
        //     {
        //         PrintTree(child);
        //     }
        // }
        // static int GetHeight(TreeNode<string> root)
        // {
        //     int height = 0;
        //     foreach (TreeNode<string> child in root.Children)
        //     {
        //         int newHeigth = GetHeight(child) + 1;
        //         // if (height < newHeigth)
        //         //     height = newHeigth;
        //         height = Math.Max(height, newHeigth);
        //     }
        //     return height;
        // }

        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;

            int lastTick = 0;

            while (true)
            {
                #region 프레임 관리
                // 만약에 경과한 시간인 1/30초보다 작다면
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                player.Update(deltaTick);

                Console.SetCursorPosition(0, 0);
                board.Render();
            }

            // 스택: LIFO(후입선출 Last in First out)
            // 큐: FIFO(선입선출 First in First out)

            // [1] [2] [3] [4]

            // Stack<int> stack = new Stack<int>();
            // stack.Push(101);
            // stack.Push(102);
            // stack.Push(103);
            // stack.Push(104);
            // stack.Push(105);

            // int data = stack.Pop();
            // int data2 = stack.Peek();

            // Queue<int> queue = new Queue<int>();
            // queue.Enqueue(101);
            // queue.Enqueue(102);
            // queue.Enqueue(103);
            // queue.Enqueue(104);
            // queue.Enqueue(105);

            // int data3 = queue.Dequeue();
            // int data4 = queue.Peek();

            // 왜 스택과 큐를 사용하는가? 의사소통에 큰 도움이 된다. 
            // 연결리스트, 동적 배열의 축소판이다.

            // 그래프 순회
            // 1. DFS (Depth First Search) 깊이 우선 탐색
            // Graph graph = new Graph();
            // graph.BFS(0);

            // 2. BFS (Breadth First Search) 너비 우선 탐색

            // 3. 다익스트라
            // graph.Dijikstra(0);
            // TreeNode<string> root = MakeTree();
            // PrintTree(root);
            // System.Console.WriteLine(GetHeight(root));
        }
    }
}