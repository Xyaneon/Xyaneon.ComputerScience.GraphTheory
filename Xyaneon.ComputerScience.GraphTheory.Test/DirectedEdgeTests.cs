using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.ComputerScience.GraphTheory.Tests
{
    /// <summary>
    /// Provides unit testing methods for the
    /// <see cref="DirectedEdge{TVertex}"/> class.
    /// </summary>
    [TestClass]
    public class DirectedEdgeTests
    {
        /// <summary>
        /// Tests constructing a new <see cref="DirectedEdge{TVertex}"/>
        /// instance with initial data.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_InitializationWithValuesTest()
        {
            // Arrange.
            DirectedEdge<Vertex> edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";
            string expectedDestinationVertexLabel = "My label 2";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = new Vertex(expectedDestinationVertexLabel);
            edge = new DirectedEdge<Vertex>(SourceVertex, DestinationVertex);

            // Assert.
            Assert.IsNotNull(edge.SourceVertex);
            Assert.AreSame(SourceVertex, edge.SourceVertex);
            Assert.IsNotNull(edge.DestinationVertex);
            Assert.AreSame(DestinationVertex, edge.DestinationVertex);
        }

        /// <summary>
        /// Tests that constructing a new <see cref="DirectedEdge{TVertex}"/>
        /// with the same vertex used for both ends correctly makes its
        /// <see cref="IEdge.IsSelfLoop"/> property return
        /// <see langword="true"/>.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_IsSelfLoopTest()
        {
            // Arrange.
            DirectedEdge<Vertex> edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = SourceVertex;
            edge = new DirectedEdge<Vertex>(SourceVertex, DestinationVertex);

            // Assert.
            Assert.IsTrue(edge.IsSelfLoop);
        }

        /// <summary>
        /// Tests the equality of two <see cref="DirectedEdge{TVertex}"/>
        /// instances with the same data and vertex order.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_EqualsWithSameVertexOrderTest()
        {
            // Arrange.
            DirectedEdge<Vertex> edge1;
            DirectedEdge<Vertex> edge2;
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
            edge1 = new DirectedEdge<Vertex>(SourceVertex, DestinationVertex);
            edge2 = new DirectedEdge<Vertex>(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
            Assert.IsTrue(edge1 == edge2);
            Assert.IsFalse(edge1 != edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedEdge{TVertex}"/>
        /// instances with the same data but different vertex order.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_NotEqualsWithDifferentVertexOrderTest()
        {
            // Arrange.
            DirectedEdge<Vertex> edge1;
            DirectedEdge<Vertex> edge2;
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
            edge1 = new DirectedEdge<Vertex>(SourceVertex, DestinationVertex);
            edge2 = new DirectedEdge<Vertex>(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
            Assert.IsFalse(edge1 == edge2);
            Assert.IsTrue(edge1 != edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="DirectedEdge{TVertex}"/>
        /// instances with different vertex data.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_NotEqualsVerticesTest()
        {
            // Arrange.
            DirectedEdge<Vertex> edge1;
            DirectedEdge<Vertex> edge2;
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
            edge1 = new DirectedEdge<Vertex>(SourceVertex, DestinationVertex);
            edge2 = new DirectedEdge<Vertex>(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
            Assert.IsFalse(edge1 == edge2);
            Assert.IsTrue(edge1 != edge2);
        }

        /// <summary>
        /// Tests that constructing a new <see cref="DirectedEdge{TVertex}"/>
        /// with different vertices used for both ends correctly makes its
        /// <see cref="IEdge.IsSelfLoop"/> property return
        /// <see langword="false"/>.
        /// </summary>
        [TestMethod]
        public void DirectedEdge_NotIsSelfLoopTest()
        {
            // Arrange.
            DirectedEdge<Vertex> edge;
            Vertex SourceVertex;
            Vertex DestinationVertex;
            string expectedSourceVertexLabel = "My label 1";
            string expectedDestinationVertexLabel = "My label 2";

            // Act.
            SourceVertex = new Vertex(expectedSourceVertexLabel);
            DestinationVertex = new Vertex(expectedDestinationVertexLabel);
            edge = new DirectedEdge<Vertex>(SourceVertex, DestinationVertex);

            // Assert.
            Assert.IsFalse(edge.IsSelfLoop);
        }
    }
}
