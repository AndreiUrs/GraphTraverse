using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraverse
{
    /// <summary>
    /// Max value = keeps track of Max Sum calculated
    /// Best Child = keeps track of the best Node to go when calculating/finding the best path
    /// IsValid = flag that helps optimizing the algorithm
    /// IsCalculated = flag that stops the backtrack
    /// </summary>
    public class Node : INode
    {
        public int Value { get; set; }
        public List<Node> Children { get; set; }

        
        private int MaxValue { get; set; } = int.MinValue;
        private Node BestChild { get; set; } = null;
        private bool IsValid { get; set; } = true;
        private bool IsCalculated { get; set; } = false;

        public Node(int val)
        {
            Value = val;
            Children = new List<Node>();            
        }

        /// <summary>
        /// Returns the max sum calculated in directed grapth
        /// </summary>
        /// <returns></returns>
        public int GetMaxSum()
        {
            FindMaxValue();
            return MaxValue;
        }

        /// <summary>
        /// Return a list containing the values of best children
        /// </summary>
        /// <returns></returns>
        public List<int> GetBestPath()
        {
            List<int> list = new List<int>();
            list.Add(Value);
            if (BestChild != null) list.AddRange(BestChild.GetBestPath());

            return list;
        }
        
        /// <summary>
        /// Find max value starting from the node
        /// </summary>
        private void FindMaxValue()
        {
            //base case of recursion 
            //if calculated, job done
            if (IsCalculated) return;

            //this is leaf node in my graph
            if (Children.Count == 0) { MaxValue = Value; }
            else
            {
                //iterate over all children and calculate the max value
                foreach (var c in Children)
                {
                    c.FindMaxValue();
                }

                foreach (var c in Children)
                {
                    //check the partity of children 
                    if (c.Value % 2 != Value % 2)
                    {
                        //do not calculate best child if is invalid(optimization)
                        if (c.IsValid)
                        {
                            //pick the first child
                            if (BestChild == null)
                            {
                                BestChild = c;
                            }
                            //compare with best child
                            else if (c.MaxValue > BestChild.MaxValue)
                            {
                                BestChild = c;
                            }
                        }
                    }
                }
                //if children have same parity as parent, no best child (case 1)
                //if children of current node are invalid (case 2)
                if (BestChild == null)
                {
                    IsValid = false;
                }
                else
                {
                    MaxValue = BestChild.MaxValue + Value;
                }
                IsCalculated = true;
            }
        }
        
    }
}
