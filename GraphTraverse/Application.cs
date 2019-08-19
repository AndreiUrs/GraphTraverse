using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraverse
{
    public static class Application
    {
        /* For further maintability of the system, we can consider:
         * 1.Dependency injection (refractor the code)
         * 2.A logging tool
         */
        public static void Run()
        {
                //App settings allows us to change configuration througout the program, without recompiling(maintability)
                string mainGraph = ConfigurationManager.AppSettings["mainGraph"];

                List<Node> myGrapth = new List<Node>();

                var gb = new GraphGenerator();
                myGrapth = gb.GenerateGraph(mainGraph);
                
                var firstNode = myGrapth.First();

                var sum = firstNode.GetMaxSum();
                var list = firstNode.GetBestPath();
            
               StringBuilder sb = new StringBuilder();
               foreach (var i in list)
               {
                    sb.Append(i).Append(",");
               }

                Console.WriteLine($"Max sum : {sum}");
                Console.WriteLine($"Path : {sb.ToString()}");
                Console.ReadKey();
            }

        
    }
}
