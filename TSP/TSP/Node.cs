using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Node
    {
        private bool Visited;
        private int[] Distance;

        public void SetDistanceLength(int length)
        {
            Distance = new int[length];
        }

        public int ReturnNodeDistance(int node)
        {
            int x = 0;
            if(Distance[node] > 0)
            {
                x = Distance[node];
            }
            return x;
        }

        public void SetNodeDistance(int node, int dist)
        {
            Distance[node] = dist;
        }

        public bool GetVisted()
        {
            return Visited;
        }

        public void SetVisted(bool visit)
        {
            Visited = visit;
        }
    }
}
