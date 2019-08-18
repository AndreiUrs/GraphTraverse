using System.Collections.Generic;

namespace GraphTraverse
{
    public interface IGraphGenerator
    {
        List<Node> GenerateFromFile(string path);
    }
}