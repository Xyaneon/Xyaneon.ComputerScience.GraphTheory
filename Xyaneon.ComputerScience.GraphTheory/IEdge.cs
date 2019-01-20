namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Exposes common members on graph edges.
    /// </summary>
    public interface IEdge
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether this edge is a self-loop.
        /// </summary>
        /// <remarks>
        /// A self-loop is defined as an edge whose two vertices are the same
        /// vertex.
        /// </remarks>
        bool IsSelfLoop { get; }

        #endregion // End properties region.
    }
}
