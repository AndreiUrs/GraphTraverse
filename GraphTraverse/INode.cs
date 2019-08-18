using System.Collections.Generic;

namespace GraphTraverse
{
    public interface INode
    {
        List<Node> Children { get; set; }
        int Value { get; set; }

        List<int> GetBestPath();
        int GetMaxSum();
    }
}