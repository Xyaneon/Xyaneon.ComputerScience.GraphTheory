using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.ComputerScience.GraphTheory.Tests
{
    /// <summary>
    /// Provides unit testing methods for the
    /// <see cref="UndirectedEdge{TVertex}"/> class.
    /// </summary>
    [TestClass]
    public class UndirectedEdgeTests
    {
        /// <summary>
        /// Tests constructing a new <see cref="UndirectedEdge{TVertex}"/>
        /// instance with initial data.
        /// </summary>
        [TestMethod]
        public void UndirectedEdge_InitializationWithValuesTest()
        {
            // Arrange.
            UndirectedEdge<Vertex> edge;
            Vertex vertex1;
            Vertex vertex2;
            string expectedVertex1Label = "My label 1";
            string expectedVertex2Label = "My label 2";

            // Act.
            vertex1 = new Vertex(expectedVertex1Label);
            vertex2 = new Vertex(expectedVertex2Label);
            edge = new UndirectedEdge<Vertex>(vertex1, vertex2);

            // Assert.
            Assert.IsNotNull(edge.Vertex1);
            Assert.AreSame(vertex1, edge.Vertex1);
            Assert.IsNotNull(edge.Vertex2);
            Assert.AreSame(vertex2, edge.Vertex2);
        }

        /// <summary>
        /// Tests that constructing a new <see cref="UndirectedEdge{TVertex}"/>
        /// with the same vertex used for both ends correctly makes its
        /// <see cref="IEdge.IsSelfLoop"/> property return
        /// <see langword="true"/>.
        /// </summary>
        [TestMethod]
        public void UndirectedEdge_IsSelfLoopTest()
        {
            // Arrange.
            UndirectedEdge<Vertex> edge;
            Vertex vertex1;
            Vertex vertex2;
            string expectedVertex1Label = "My label 1";

            // Act.
            vertex1 = new Vertex(expectedVertex1Label);
            vertex2 = vertex1;
            edge = new UndirectedEdge<Vertex>(vertex1, vertex2);

            // Assert.
            Assert.IsTrue(edge.IsSelfLoop);
        }

        /// <summary>
        /// Tests the equality of two <see cref="UndirectedEdge{TVertex}"/>
        /// instances with the same data and vertex order.
        /// </summary>
        [TestMethod]
        public void UndirectedEdge_EqualsWithSameVertexOrderTest()
        {
            // Arrange.
            UndirectedEdge<Vertex> edge1;
            UndirectedEdge<Vertex> edge2;
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
            edge1 = new UndirectedEdge<Vertex>(vertex1, vertex2);
            edge2 = new UndirectedEdge<Vertex>(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the equality of two <see cref="UndirectedEdge{TVertex}"/>
        /// instances with the same data but different vertex order.
        /// </summary>
        [TestMethod]
        public void UndirectedEdge_EqualsWithDifferentVertexOrderTest()
        {
            // Arrange.
            UndirectedEdge<Vertex> edge1;
            UndirectedEdge<Vertex> edge2;
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
            edge1 = new UndirectedEdge<Vertex>(vertex1, vertex2);
            edge2 = new UndirectedEdge<Vertex>(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="UndirectedEdge{TVertex}"/>
        /// instances with different vertex data.
        /// </summary>
        [TestMethod]
        public void UndirectedEdge_NotEqualsVerticesTest()
        {
            // Arrange.
            UndirectedEdge<Vertex> edge1;
            UndirectedEdge<Vertex> edge2;
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
            edge1 = new UndirectedEdge<Vertex>(vertex1, vertex2);
            edge2 = new UndirectedEdge<Vertex>(vertex3, vertex4);

            // Assert.
            Assert.AreNotSame(edge1, edge2);
            Assert.AreNotEqual(edge1, edge2);
        }

        /// <summary>
        /// Tests that constructing a new <see cref="UndirectedEdge{TVertex}"/>
        /// with different vertices used for both ends correctly makes its
        /// <see cref="IEdge.IsSelfLoop"/> property return
        /// <see langword="false"/>.
        /// </summary>
        [TestMethod]
        public void UndirectedEdge_NotIsSelfLoopTest()
        {
            // Arrange.
            UndirectedEdge<Vertex> edge;
            Vertex vertex1;
            Vertex vertex2;
            string expectedVertex1Label = "My label 1";
            string expectedVertex2Label = "My label 2";

            // Act.
            vertex1 = new Vertex(expectedVertex1Label);
            vertex2 = new Vertex(expectedVertex2Label);
            edge = new UndirectedEdge<Vertex>(vertex1, vertex2);

            // Assert.
            Assert.IsFalse(edge.IsSelfLoop);
        }
    }
}
