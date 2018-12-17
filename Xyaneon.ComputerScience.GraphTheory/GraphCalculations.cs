using System;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Provides functionality for performing some common calculations
    /// relating to graphs.
    /// </summary>
    public static class GraphCalculations
    {
        #region Constants

        private const string ArgumentOutOfRangeException_NumberOfVerticesLessThanZero = "The number of vertices in a graph cannot be negative.";

        #endregion // End constants region.

        #region Methods

        #region Public methods

        /// <summary>
        /// Calculates the number of edges which would be present in a complete
        /// directed graph containing the provided number of vertices.
        /// </summary>
        /// <param name="numberOfVertices">
        /// The number of vertices in the complete graph.
        /// </param>
        /// <returns>
        /// The number of edges which would be present in a complete
        /// directed graph containing the provided number of vertices.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="numberOfVertices"/> is less than zero.
        /// </exception>
        /// <seealso cref="CalculateNumberOfEdgesInCompleteUndirectedGraph(int)"/>
        public static int CalculateNumberOfEdgesInCompleteDirectedGraph(int numberOfVertices)
        {
            if (numberOfVertices < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfVertices), numberOfVertices, ArgumentOutOfRangeException_NumberOfVerticesLessThanZero);
            }

            return (numberOfVertices * (numberOfVertices - 1));
        }

        /// <summary>
        /// Calculates the number of edges which would be present in a complete
        /// undirected graph containing the provided number of vertices.
        /// </summary>
        /// <param name="numberOfVertices">
        /// The number of vertices in the complete graph.
        /// </param>
        /// <returns>
        /// The number of edges which would be present in a complete
        /// undirected graph containing the provided number of vertices.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="numberOfVertices"/> is less than zero.
        /// </exception>
        /// <seealso cref="CalculateNumberOfEdgesInCompleteDirectedGraph(int)"/>
        public static int CalculateNumberOfEdgesInCompleteUndirectedGraph(int numberOfVertices)
        {
            if (numberOfVertices < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfVertices), numberOfVertices, ArgumentOutOfRangeException_NumberOfVerticesLessThanZero);
            }

            return (numberOfVertices * (numberOfVertices - 1)) / 2;
        }

        #endregion // End public methods region.

        #region Private methods

        #endregion // End private methods region.

        #endregion // End methods region.
    }
}
