using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.ComputerScience.GraphTheory.Tests
{
    /// <summary>
    /// Provides unit testing methods for the
    /// <see cref="DirectedWeightedEdge{TVertex}"/> class.
    /// </summary>
    [TestClass]
    public class DirectedWeightedEdgeTests
    {
        /// <summary>
        /// Tests constructing a new <see cref="DirectedWeightedEdge{TVertex}"/> 
        /// instance with initial data.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_InitializationWithValuesTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            DirectedWeightedEdge<Vertex> edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";
            string expectedDestinationVertexLabel = "My label 2";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = new Vertex(expectedDestinationVertexLabel);
            edge = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight);

            // Assert.
            Assert.IsNotNull(edge.SourceVertex);
            Assert.AreSame(SourceVertex, edge.SourceVertex);
            Assert.IsNotNull(edge.DestinationVertex);
            Assert.AreSame(DestinationVertex, edge.DestinationVertex);
            Assert.AreEqual(expectedWeight, edge.Weight);
        }

        /// <summary>
        /// Tests the equality of two <see cref="DirectedWeightedEdge{TVertex}"/> 
        /// instances with the same data and vertex order.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_EqualsWithSameVertexOrderTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            DirectedWeightedEdge<Vertex> edge1;
            DirectedWeightedEdge<Vertex> edge2;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1SourceVertexLabel = "My label a";
            string expectedEdge1DestinationVertexLabel = "My label b";
            string expectedEdge2SourceVertexLabel = "My label a";
            string expectedEdge2DestinationVertexLabel = "My label b";

            // Act.
            SourceVertex = new Vertex(expectedEdge1SourceVertexLabel);
            DestinationVertex = new Vertex(expectedEdge1DestinationVertexLabel);
            vertex3 = new Vertex(expectedEdge2SourceVertexLabel);
            vertex4 = new Vertex(expectedEdge2DestinationVertexLabel);
            edge1 = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight);
            edge2 = new DirectedWeightedEdge<Vertex>(vertex3, vertex4, expectedWeight);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests that constructing a new <see cref="DirectedWeightedEdge{TVertex}"/>
        /// with the same vertex used for both ends correctly makes its
        /// <see cref="IEdge.IsSelfLoop"/> property return
        /// <see langword="true"/>.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_IsSelfLoopTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            DirectedWeightedEdge<Vertex> edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = SourceVertex;
            edge = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight);

            // Assert.
            Assert.IsTrue(edge.IsSelfLoop);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedWeightedEdge{TVertex}"/> 
        /// instances with the same data but different vertex order.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_NotEqualsWithDifferentVertexOrderTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            DirectedWeightedEdge<Vertex> edge1;
            DirectedWeightedEdge<Vertex> edge2;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1SourceVertexLabel = "My label a";
            string expectedEdge1DestinationVertexLabel = "My label b";
            string expectedEdge2SourceVertexLabel = "My label b";
            string expectedEdge2DestinationVertexLabel = "My label a";

            // Act.
            SourceVertex = new Vertex(expectedEdge1SourceVertexLabel);
            DestinationVertex = new Vertex(expectedEdge1DestinationVertexLabel);
            vertex3 = new Vertex(expectedEdge2SourceVertexLabel);
            vertex4 = new Vertex(expectedEdge2DestinationVertexLabel);
            edge1 = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight);
            edge2 = new DirectedWeightedEdge<Vertex>(vertex3, vertex4, expectedWeight);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedWeightedEdge{TVertex}"/> 
        /// instances with different vertex data.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_NotEqualsVerticesTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            DirectedWeightedEdge<Vertex> edge1;
            DirectedWeightedEdge<Vertex> edge2;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1SourceVertexLabel = "My label a";
            string expectedEdge1DestinationVertexLabel = "My label b";
            string expectedEdge2SourceVertexLabel = "My label a";
            string expectedEdge2DestinationVertexLabel = "My label c";

            // Act.
            SourceVertex = new Vertex(expectedEdge1SourceVertexLabel);
            DestinationVertex = new Vertex(expectedEdge1DestinationVertexLabel);
            vertex3 = new Vertex(expectedEdge2SourceVertexLabel);
            vertex4 = new Vertex(expectedEdge2DestinationVertexLabel);
            edge1 = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight);
            edge2 = new DirectedWeightedEdge<Vertex>(vertex3, vertex4, expectedWeight);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedWeightedEdge{TVertex}"/> 
        /// instances with different weight data.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_NotEqualsWeightTest()
        {
            // Arrange.
            const int expectedWeight1 = 2;
            const int expectedWeight2 = 5;
            DirectedWeightedEdge<Vertex> edge1;
            DirectedWeightedEdge<Vertex> edge2;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            Vertex vertex3;
            Vertex vertex4;
            string expectedEdge1SourceVertexLabel = "My label a";
            string expectedEdge1DestinationVertexLabel = "My label b";
            string expectedEdge2SourceVertexLabel = "My label a";
            string expectedEdge2DestinationVertexLabel = "My label b";

            // Act.
            SourceVertex = new Vertex(expectedEdge1SourceVertexLabel);
            DestinationVertex = new Vertex(expectedEdge1DestinationVertexLabel);
            vertex3 = new Vertex(expectedEdge2SourceVertexLabel);
            vertex4 = new Vertex(expectedEdge2DestinationVertexLabel);
            edge1 = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight1);
            edge2 = new DirectedWeightedEdge<Vertex>(vertex3, vertex4, expectedWeight2);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests that constructing a new <see cref="DirectedWeightedEdge{TVertex}"/>
        /// with different vertices used for both ends correctly makes its
        /// <see cref="IEdge.IsSelfLoop"/> property return
        /// <see langword="false"/>.
        /// </summary>
        [TestMethod]
        public void DirectedWeightedEdge_NotIsSelfLoopTest()
        {
            // Arrange.
            const int expectedWeight = 2;
            DirectedWeightedEdge<Vertex> edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";
            string expectedDestinationVertexLabel = "My label 2";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = new Vertex(expectedDestinationVertexLabel);
            edge = new DirectedWeightedEdge<Vertex>(SourceVertex, DestinationVertex, expectedWeight);

            // Assert.
            Assert.IsFalse(edge.IsSelfLoop);
        }
    }
}
