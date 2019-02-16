using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.ComputerScience.GraphTheory.Tests
{
    /// <summary>
    /// Provides unit testing methods for the <see cref="Vertex"/> class.
    /// </summary>
    [TestClass]
    public class VertexTests
    {
        /// <summary>
        /// Tests constructing a new <see cref="Vertex"/> instance with a label.
        /// </summary>
        [TestMethod]
        public void Vertex_InitializationWithValueTest()
        {
            // Arrange.
            Vertex vertex;
            string expectedLabel = "My label";
            string actualLabel;

            // Act.
            vertex = new Vertex(expectedLabel);
            actualLabel = vertex.Label;

            // Assert.
            Assert.AreEqual(expectedLabel, actualLabel);
        }

        /// <summary>
        /// Tests the equality of two <see cref="Vertex"/> instances with
        /// the same label.
        /// </summary>
        [TestMethod]
        public void Vertex_EqualsTest()
        {
            // Arrange.
            Vertex vertex1;
            Vertex vertex2;
            string label = "My label";

            // Act.
            vertex1 = new Vertex(label);
            vertex2 = new Vertex(label);

            // Assert.
            Assert.AreNotSame(vertex1, vertex2);
            Assert.AreEqual(vertex1, vertex2);
            Assert.IsTrue(vertex1 == vertex2);
            Assert.IsFalse(vertex1 != vertex2);
        }

        /// <summary>
        /// Tests the inequality of two <see cref="Vertex"/> instances with
        /// different labels.
        /// </summary>
        [TestMethod]
        public void Vertex_NotEqualsTest()
        {
            // Arrange.
            Vertex vertex1;
            Vertex vertex2;
            string label1 = "My label 1";
            string label2 = "My label 2";

            // Act.
            vertex1 = new Vertex(label1);
            vertex2 = new Vertex(label2);

            // Assert.
            Assert.AreNotSame(vertex1, vertex2);
            Assert.AreNotEqual(vertex1, vertex2);
            Assert.IsFalse(vertex1 == vertex2);
            Assert.IsTrue(vertex1 != vertex2);
        }
    }
}
