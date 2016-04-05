using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;


namespace TSP
{
    class Program
    {
        static Node[] Cities;
        static int nodes;
        static int verticies;
        static Node[] Path;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Sovler for the Travelling Salesman Problem");

            GenerateMenu();
        }

        static void GenerateMenu()
        {
            Console.Write("Please type the file path for the Graph: ");
            String filePath = Console.ReadLine();
            Console.WriteLine("\t" + filePath);
            ReadGraph(filePath);
        }

        static void ReadGraph(string File)
        {
            StreamReader file = new StreamReader(File);
            int counter = 0;
            string line;
            string[] split;
            int source;
            int dest;
            int dist;
            
            while((line = file.ReadLine()) != null)
            {
                if(counter == 0)
                {
                    split = Regex.Split(line, @"\D+");
                    nodes = int.Parse(split[0]);
                    verticies = int.Parse(split[1]);
                    Cities = new Node[nodes];
                }
                else
                {
                    split = Regex.Split(line, @"\D+");
                    source = int.Parse(split[0]);
                    dest = int.Parse(split[1]);
                    dist = int.Parse(split[2]);
                    Cities[source-1].SetNodeDistance(dest-1, dist);
                    Cities[dest-1].SetNodeDistance(source-1, dist);
                }
                counter++;
            }
            Console.ReadKey();
        }

        static void FindPath()
        {
            Path = new Node[nodes + 1];
            Random rand = new Random();
            int source = rand.Next(0, nodes);
            int i;
            Path[0] = Cities[source];
            Cities[source].SetVisted(true);
            for(i = 1; i < nodes; i++)
            {
                Node nearestNode;
                for (int x = 0; x < nodes; x++)
                {
                    
                    Cities[i].ReturnNodeDistance(x);

                }
            }

        }
    }
}
