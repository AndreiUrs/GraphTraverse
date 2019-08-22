using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using GraphTraverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphTraverseTest
{
    [TestClass]
    public class GraphTraverseTest
    {
        private readonly string testGraph = ConfigurationManager.AppSettings["testGraph"];
      
        public GraphTraverseTest()
        {

        }

        [TestMethod]
        public void GenerateGraph()
        {
          var gb = new GraphGenerator();
          var  myGrapth = gb.GenerateGraph(testGraph);

          Assert.IsNotNull(myGrapth);
          Assert.IsTrue(myGrapth.Count > 0);

        }

        [TestMethod]
        public void MaxSum()
        {
            const int expectedSum = 16;

            var gb = new GraphGenerator();
            var fistNode = gb.GenerateGraph(testGraph).FirstOrDefault();
         
            var calculatedSum = fistNode.GetMaxSum();

            Assert.AreEqual(expectedSum, calculatedSum);
        }

        [TestMethod]
        public void BestPath()
        {
            List<int> expectedPath = new List<int> { 1, 8, 5, 2 };

            var gb = new GraphGenerator();
            var firstNode = gb.GenerateGraph(testGraph).FirstOrDefault();

            //we must calculate sum before we get path
            firstNode.GetMaxSum();

            var calculatedPath = firstNode.GetBestPath();

            for (int i = 0; i < expectedPath.Count; i++)
            {
                Assert.AreEqual(expectedPath[i], calculatedPath[i]);
            }

        }

    }
}
