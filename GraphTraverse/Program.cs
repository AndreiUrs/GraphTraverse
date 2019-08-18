using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GraphTraverse
{
    class Program
    {
     
        static string mainGraph = ConfigurationManager.AppSettings["mainGraph"];
        static string miniGraph = ConfigurationManager.AppSettings["testGraph"];
        

        static void Main(string[] args)
        {
            List<Node> myGrapth = new List<Node>();

            var gb = new GraphGenerator();
            myGrapth = gb.GenerateFromFile(mainGraph);


            var firstNode = myGrapth.First();

            var sum = firstNode.GetMaxSum();
            var list = firstNode.GetBestPath();

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"Max Val : {sum}");

            Console.WriteLine("FINISH!");
            Console.ReadKey();
        }
    }
}
