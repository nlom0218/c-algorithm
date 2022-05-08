using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            {-1, 15, -1, 35, -1, -1},
            {15, -1, 05, 10, -1, -1},
            {-1, 05, -1, -1, -1, -1},
            {35, 10, -1, -1, 05, -1},
            {-1, -1, -1, 05, -1, 05},
            {-1, -1, -1, -1, 05, -1},
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() {1, 3},
            new List<int>() {0, 2, 3},
            new List<int>() {1},
            new List<int>() {0, 1, 4},
            new List<int>() {3, 5},
            new List<int>() {4},
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보를 찾는다 (가장 가까이에 있는)

                // 가장 유력한 후보의 거리와 번호를 저장한다.
                int closest = Int32.MaxValue;
                int now = -1;
                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                        continue;
                    // 아직 발견(예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int16.MaxValue || distance[i] >= closest)
                        continue;
                    // 여태껏 발견한 가장 후보라는 의미니까, 정보를 갱신
                    closest = distance[i];
                    now = i;
                }
                // 다음 후보가 하나도 없다. => 종료
                if (now == -1)
                    break;

                // 제일 좋은 후보를 찾았으니가 방문한다.
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해서, 상황에 따라 발견한 최단거리를 갱신한다.
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않는 정점은 스킵
                    if (adj[now, next] == -1)
                        continue;
                    //이미 방문한 정점은 스킵
                    if (visited[next])
                        continue;

                    // 새로 조사된 정점의 최단거리를 계산한다.
                    int nextDist = distance[now] + adj[now, next];
                    // 만약에 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면, 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }

        }

        bool[] visited = new bool[6];
        // 1) 우선 now부터 방문하고,
        // 2) now와 연결된 정점들을 하나씩 확인해서, [아직 미발견(미방문) 상태라면] 방문한다.
        public void DFS(int now)
        {
            System.Console.WriteLine(now);
            visited[now] = true; // 1) 우선 now부터 방문하고,

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0) // 연결되어 있지 않으면 스킵
                    continue;
                if (visited[next]) // 이미 방문한 상태라면 스킵
                    continue;
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            System.Console.WriteLine(now);
            visited[now] = true; // 1) 우선 now부터 방문하고,

            foreach (var next in adj2[now])
            {
                if (visited[next])
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
                if (visited[now] == false)
                    DFS(now);
        }

        public void BFS(int start)
        {
            bool[] found = new bool[6];

            Queue<int> q = new Queue<int>(); // 예약 시스템
            q.Enqueue(start);
            found[start] = true;

            while (q.Count > 0)
            {
                int now = q.Dequeue();
                System.Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0) // 인접하지 않았으면 스킵
                        continue;
                    if (found[next]) // 이미 발견했으면 스킵
                        continue;
                    q.Enqueue(next);
                    found[next] = true;

                }
            }
        }
    }


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
            Graph graph = new Graph();
            // graph.BFS(0);

            // 2. BFS (Breadth First Search) 너비 우선 탐색

            // 3. 다익스트라
            graph.Dijikstra(0);
        }
    }
}