using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Node
    {
        private bool Visited = false;
        private int[] Distance;
        private int Base;

        public Node()
        {

        }
        public Node(int b)
        {
            Base = b;

        }

        public Node(int b, int length)
        {
            Base = b;
            Distance = new int[length];
            Distance[Base] = 101;
        }
        public void SetDistanceLength(int length)
        {
            Distance = new int[length];
        }

        public int ReturnNodeDistance(int node)
        {
            return Distance[node];
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

        public int GetBase()
        {
            return Base;
        }
    }
}
