using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace TSP
{
    class Program
    {
        static Node[] Cities;
        static int nodes;
        static int verticies;
        static Node[] Path;
        static Stopwatch stopWatch = new Stopwatch();

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
            stopWatch.Start();
            ReadGraph(filePath);
            FindPath();
            stopWatch.Stop();
            //PrintNodeArray();
            //PrintPath();
            WritePath();

        }

        static void ReadGraph(string fileName)
        {
            //StreamReader file = new StreamReader(fileName);
            int counter = 0;
            string line;
            string[] split;
            int source;
            int dest;
            int dist;
            using (StreamReader sr = File.OpenText(fileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (counter == 0)
                    {
                        split = Regex.Split(line, @"\D+");
                        nodes = int.Parse(split[split.Length - 2]);
                        verticies = int.Parse(split[split.Length-1]);
                        Cities = new Node[nodes];
                        //Console.WriteLine("Reading in Graph with {0} nodes and {1} verticies!", nodes, verticies);
                    }
                    else
                    {
                        split = Regex.Split(line, @"\D+");
                        source = int.Parse(split[split.Length - 3]);
                        dest = int.Parse(split[split.Length - 2]);
                        dist = int.Parse(split[split.Length - 1]);
                        if (Cities[source - 1] == null)
                        {
                            Cities[source - 1] = new Node(source - 1, nodes);
                        }
                        if (Cities[dest - 1] == null)
                        {
                            Cities[dest - 1] = new Node(dest - 1, nodes);
                        }
                        Cities[source - 1].SetNodeDistance(dest - 1, dist);
                        Cities[dest - 1].SetNodeDistance(source - 1, dist);
                        //Console.WriteLine("Writing Edge from {0} to {1} with distance {2}", source, dest, dist);
                    }
                    counter++;
                }
            }
            //Console.ReadKey();
        }

        static void FindPath()
        {
            Path = new Node[nodes + 1];
            Random rand = new Random();
            int source = rand.Next(0, nodes);
            int i;
            int x;
            Path[0] = Cities[source];
            Cities[source].SetVisted(true);
            int currentNode = source;
            
            for(i = 1; i < nodes; i++)
            {
                int nearestNode = -1;
                int currentDistance = 101;
                for  (x = 0; x < nodes; x++)
                {
                    if(Cities[currentNode].ReturnNodeDistance(x) < currentDistance && !Cities[x].GetVisted())
                    {
                        currentDistance = Cities[currentNode].ReturnNodeDistance(x);
                        nearestNode = x;
                    }
                }
                Path[i] = Cities[nearestNode];
                Cities[nearestNode].SetVisted(true);
                currentNode = nearestNode;
                
            }
            Path[nodes] = Cities[source];
            

        }
        static void PrintPath()
        {
            for(int x = 0;x < Path.Length; x++)
            {
                Console.WriteLine(Path[x].GetBase());
            }
            Console.ReadKey();
        }

        static void PrintNodeArray()
        {
            int x;
            int i;
            
            for (i = 0;i < Cities.Length; i++)
            {
                string concat = "";
                Console.Write("Distances for Node {0}: ", i);
                for (x = 0; x < Cities.Length; x++)
                {
                    concat += " " + Cities[i].ReturnNodeDistance(x);
                }
                Console.Write(concat + "\n");
            }
            Console.ReadKey();
        }

        static void WritePath()
        {
            Console.Write("Please Enter Path File Destination: ");
            string fileDest = "path" + nodes + ".txt";
            StreamWriter sw = new StreamWriter(fileDest, true);
            int pastDist = PathDistance();
            TimeSpan ts = stopWatch.Elapsed;
            sw.WriteLine("{0},{1},{2}", nodes, verticies, pastDist);
            for(int i = 1; i < Path.Length; i++)
            {
                sw.WriteLine("{0},{1},{2}", Path[i - 1].GetBase(), Path[i].GetBase(), Path[i - 1].ReturnNodeDistance(Path[i].GetBase()));
            }

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            sw.WriteLine(elapsedTime);
            sw.Close();
        }

        static int PathDistance()
        {
            int dist = 0;
            int i;
            for (i = 1; i < Path.Length; i++)
            {
                dist += Path[i - 1].ReturnNodeDistance(Path[i].GetBase());
            }
            return dist;
        }
    }
}
