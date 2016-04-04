using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TSP
{
    class Program
    {
        Node[] Cities;
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
        }

        static void ReadFile(string File)
        {

        }
    }
}
