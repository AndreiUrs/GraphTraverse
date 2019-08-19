using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraverse
{
    public class GraphGenerator : IGraphGeneratorFromFile
    {   
        private List<Node> Graph { get; set; }

        public GraphGenerator()
        {
            Graph = new List<Node>();
        }

        /// <summary>
        /// Generate a directed graph 
        /// from input file
        /// </summary> 
        public List<Node> GenerateGraph(string path)
        {
            //keep track of parent nodes, know where to attach children
            List<Node> parentNodes = new List<Node>();
            string[] allLines = File.ReadAllLines(path);

            //first node does not have a parent
            Node firstNode = new Node(Convert.ToInt32(allLines[0]));
            Graph.Add(firstNode);
            parentNodes.Add(firstNode);
            
            for (int i = 1; i < allLines.Length; i++)
            {
                //split each line into an array of values
                var lineValues = allLines[i].Split(' ');

                //keep track of newly created nodes
                List<Node> newNodes = new List<Node>();
                
                for (int l = 0; l < lineValues.Length; l++)
                {
                    //create a new node,and add it to the right parent
                    Node node = new Node(Convert.ToInt32(lineValues[l]));
                    Graph.Add(node);
                    newNodes.Add(node);

                    //first and last node have one parent,otherwise 2
                    if (l == 0)
                    {
                        parentNodes[l].Children.Add(node);
                    }
                    else if (l == lineValues.Length - 1)
                    {
                        parentNodes[l - 1].Children.Add(node);
                    }
                    else
                    {
                        parentNodes[l].Children.Add(node);
                        parentNodes[l - 1].Children.Add(node);
                    }
                }

                //the new nodes will become parents for the next row 
                parentNodes = newNodes;
            }

            return Graph;
        }
    }
}
