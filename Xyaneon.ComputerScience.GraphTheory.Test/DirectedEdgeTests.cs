using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.ComputerScience.GraphTheory.Tests
{
    /// <summary>
    /// Provides unit testing methods for the
    /// <see cref="DirectedEdge"/> class.
    /// </summary>
    [TestClass]
    public class DirectedEdgeTests
    {
        /// <summary>
        /// Tests constructing a new <see cref="DirectedEdge"/>
        /// instance with initial data.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_InitializationWithValuesTest()
        {
            // Arrange.
            DirectedEdge edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";
            string expectedDestinationVertexLabel = "My label 2";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = new Vertex(expectedDestinationVertexLabel);
            edge = new DirectedEdge(SourceVertex, DestinationVertex);

            // Assert.
            Assert.IsNotNull(edge.SourceVertex);
            Assert.AreSame(SourceVertex, edge.SourceVertex);
            Assert.IsNotNull(edge.DestinationVertex);
            Assert.AreSame(DestinationVertex, edge.DestinationVertex);
        }

        /// <summary>
        /// Tests the equality of two <see cref="DirectedEdge"/>
        /// instances with the same data and vertex order.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_EqualsWithSameVertexOrderTest()
        {
            // Arrange.
            DirectedEdge edge1;
            DirectedEdge edge2;
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
            edge1 = new DirectedEdge(SourceVertex, DestinationVertex);
            edge2 = new DirectedEdge(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedEdge"/>
        /// instances with the same data but different vertex order.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_NotEqualsWithDifferentVertexOrderTest()
        {
            // Arrange.
            DirectedEdge edge1;
            DirectedEdge edge2;
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
            edge1 = new DirectedEdge(SourceVertex, DestinationVertex);
            edge2 = new DirectedEdge(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedEdge"/>
        /// instances with different vertex data.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_NotEqualsVerticesTest()
        {
            // Arrange.
            DirectedEdge edge1;
            DirectedEdge edge2;
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
            edge1 = new DirectedEdge(SourceVertex, DestinationVertex);
            edge2 = new DirectedEdge(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }
    }
}
