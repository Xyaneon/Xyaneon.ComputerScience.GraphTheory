using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.ComputerScience.GraphTheory.Tests
{
    /// <summary>
    /// Provides unit testing methods for the
    /// <see cref="UndirectedWeightedEdge"/> class.
    /// </summary>
    [TestClass]
    public class UndirectedWeightedEdgeTests
    {
        /// <summary>
        /// Tests constructing a new <see cref="UndirectedWeightedEdge"/>
        /// instance with initial data.
        /// </summary>
        [TestMethod]
        public void UndirectedWeightedEdge_InitializationWithValuesTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            UndirectedWeightedEdge edge;
            Vertex vertex1;
            Vertex vertex2;
            string expectedVertex1Label = "My label 1";
            string expectedVertex2Label = "My label 2";

            // Act.
            vertex1 = new Vertex(expectedVertex1Label);
            vertex2 = new Vertex(expectedVertex2Label);
            edge = new UndirectedWeightedEdge(vertex1, vertex2, expectedWeight);

            // Assert.
            Assert.IsNotNull(edge.Vertex1);
            Assert.AreSame(vertex1, edge.Vertex1);
            Assert.IsNotNull(edge.Vertex2);
            Assert.AreSame(vertex2, edge.Vertex2);
            Assert.AreEqual(expectedWeight, edge.Weight);
        }

        /// <summary>
        /// Tests the equality of two <see cref="UndirectedWeightedEdge"/>
        /// instances with the same data and vertex order.
        /// </summary>
        [TestMethod]
        public void UndirectedWeightedEdge_EqualsWithSameVertexOrderTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            UndirectedWeightedEdge edge1;
            UndirectedWeightedEdge edge2;
            Vertex vertex1;
            Vertex vertex2;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1Vertex1Label = "My label a";
            string expectedEdge1Vertex2Label = "My label b";
            string expectedEdge2Vertex1Label = "My label a";
            string expectedEdge2Vertex2Label = "My label b";

            // Act.
            vertex1 = new Vertex(expectedEdge1Vertex1Label);
            vertex2 = new Vertex(expectedEdge1Vertex2Label);
            vertex3 = new Vertex(expectedEdge2Vertex1Label);
            vertex4 = new Vertex(expectedEdge2Vertex2Label);
            edge1 = new UndirectedWeightedEdge(vertex1, vertex2, expectedWeight);
            edge2 = new UndirectedWeightedEdge(vertex3, vertex4, expectedWeight);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the equality of two <see cref="UndirectedWeightedEdge"/>
        /// instances with the same data but different vertex order.
        /// </summary>
        [TestMethod]
        public void UndirectedWeightedEdge_EqualsWithDifferentVertexOrderTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            UndirectedWeightedEdge edge1;
            UndirectedWeightedEdge edge2;
            Vertex vertex1;
            Vertex vertex2;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1Vertex1Label = "My label a";
            string expectedEdge1Vertex2Label = "My label b";
            string expectedEdge2Vertex1Label = "My label b";
            string expectedEdge2Vertex2Label = "My label a";

            // Act.
            vertex1 = new Vertex(expectedEdge1Vertex1Label);
            vertex2 = new Vertex(expectedEdge1Vertex2Label);
            vertex3 = new Vertex(expectedEdge2Vertex1Label);
            vertex4 = new Vertex(expectedEdge2Vertex2Label);
            edge1 = new UndirectedWeightedEdge(vertex1, vertex2, expectedWeight);
            edge2 = new UndirectedWeightedEdge(vertex3, vertex4, expectedWeight);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="UndirectedWeightedEdge"/>
        /// instances with different vertex data.
        /// </summary>
        [TestMethod]
        public void UndirectedWeightedEdge_NotEqualsVerticesTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            UndirectedWeightedEdge edge1;
            UndirectedWeightedEdge edge2;
            Vertex vertex1;
            Vertex vertex2;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1Vertex1Label = "My label a";
            string expectedEdge1Vertex2Label = "My label b";
            string expectedEdge2Vertex1Label = "My label a";
            string expectedEdge2Vertex2Label = "My label c";

            // Act.
            vertex1 = new Vertex(expectedEdge1Vertex1Label);
            vertex2 = new Vertex(expectedEdge1Vertex2Label);
            vertex3 = new Vertex(expectedEdge2Vertex1Label);
            vertex4 = new Vertex(expectedEdge2Vertex2Label);
            edge1 = new UndirectedWeightedEdge(vertex1, vertex2, expectedWeight);
            edge2 = new UndirectedWeightedEdge(vertex3, vertex4, expectedWeight);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="UndirectedWeightedEdge"/>
        /// instances with different weight data.
        /// </summary>
        [TestMethod]
        public void UndirectedWeightedEdge_NotEqualsWeightTest()
        {
            // Arrange.
            const int expectedWeight1 = 2;
            const int expectedWeight2 = 5;
            UndirectedWeightedEdge edge1;
            UndirectedWeightedEdge edge2;
            Vertex vertex1;
            Vertex vertex2;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1Vertex1Label = "My label a";
            string expectedEdge1Vertex2Label = "My label b";
            string expectedEdge2Vertex1Label = "My label a";
            string expectedEdge2Vertex2Label = "My label b";

            // Act.
            vertex1 = new Vertex(expectedEdge1Vertex1Label);
            vertex2 = new Vertex(expectedEdge1Vertex2Label);
            vertex3 = new Vertex(expectedEdge2Vertex1Label);
            vertex4 = new Vertex(expectedEdge2Vertex2Label);
            edge1 = new UndirectedWeightedEdge(vertex1, vertex2, expectedWeight1);
            edge2 = new UndirectedWeightedEdge(vertex3, vertex4, expectedWeight2);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }
    }
}
