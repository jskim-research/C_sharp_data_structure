using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class Graph
    {
        public enum DijkstraStatus
        {
            None,
            Candidate,
            Group,
        }

        public int[,] graph = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1},
            { 35, 10, -1, -1, 05, -1},
            { -1, -1, -1, 05, -1, 05},
            { -1, -1, -1, -1, 05, -1},
        };

        public void Initialize()
        {
            Dijkstra(0);
        }

        void Dijkstra(int v)
        {
            DijkstraStatus[] status = new DijkstraStatus[6];
            int[] dist = new int[6];
            int[] parent = new int[6];
            int min_v = -1, min_dist = Int32.MaxValue, num_selected = 0;
            

            Array.Fill<int>(dist, Int32.MaxValue);
            Array.Fill<int>(parent, -1);
            Array.Fill<DijkstraStatus>(status, DijkstraStatus.None);

            dist[v] = 0;
            parent[v] = v;
            status[v] = DijkstraStatus.Candidate;

            while (num_selected < 6)
            {
                min_dist = Int32.MaxValue;
                // 후보군에서 min distance를 가진 vertex 탐색
                for (int i=0; i<6; i++)
                {
                    if (status[i] == DijkstraStatus.Candidate && dist[i] < min_dist)
                    {
                        min_v = i;
                        min_dist = dist[i];
                    }
                }

                // 선택된 vertex => group
                status[min_v] = DijkstraStatus.Group;
                num_selected++;

                // 선택된 vertex 주변 distance 갱신
                for (int i=0; i<6; i++)
                {
                    // 연결되어있고, min_v를 경유해서 갔을 때 최단거리인 경우
                    if (graph[min_v, i] != -1 && dist[min_v] + graph[min_v, i] < dist[i])
                    {
                        parent[i] = min_v;
                        dist[i] = dist[min_v] + graph[min_v, i];
                        status[i] = DijkstraStatus.Candidate;
                    }
                }

            }
        }
    }
}
