using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace GraphTraverse
{
    public static class Application
    {
        public static void Run()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                 string mainGraph = ConfigurationManager.AppSettings["mainGraph"];
                 string miniGraph = ConfigurationManager.AppSettings["testGraph"];

                List<Node> myGrapth = new List<Node>();

                var gb = new GraphGenerator();
                myGrapth = gb.GenerateGraph(mainGraph);


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
}
