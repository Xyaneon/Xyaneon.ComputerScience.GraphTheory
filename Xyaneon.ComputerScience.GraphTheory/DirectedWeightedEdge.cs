using System;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents a weighted edge in a directed graph.
    /// </summary>
    /// <seealso cref="DirectedEdge"/>
    /// <seealso cref="UndirectedWeightedEdge"/>
    public class DirectedWeightedEdge : DirectedEdge, IEquatable<DirectedWeightedEdge>, IWeighted
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedWeightedEdge"/> class
        /// using the provided vertices and weight.
        /// </summary>
        /// <param name="source">
        /// The source vertex.
        /// </param>
        /// <param name="destination">
        /// The destination vertex.
        /// </param>
        /// <param name="weight">
        /// The edge's weight.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="destination"/> is <see langword="null"/>.
        /// </exception>
        public DirectedWeightedEdge(Vertex source, Vertex destination, int weight) : base(source, destination)
        {
            Weight = weight;
        }

        #endregion // End constructors region.

        #region IEquatable<DirectedWeightedEdge> implementation

        /// <summary>
        /// Indicates whether the current <see cref="DirectedWeightedEdge"/>
        /// is equal to another <see cref="DirectedWeightedEdge"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="DirectedWeightedEdge"/> to compare with this
        /// object.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the other
        /// <see cref="DirectedWeightedEdge"/> is equal to this
        /// <see cref="DirectedWeightedEdge"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <seealso cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(DirectedWeightedEdge other)
        {
            if (other == null)
            {
                return false;
            }

            return (SourceVertex.Equals(other.SourceVertex) && DestinationVertex.Equals(other.DestinationVertex))
                && Weight.Equals(other.Weight);
        }

        #endregion // End IEquatable<DirectedWeightedEdge> implementation region.

        #region IWeighted implementation

        /// <summary>
        /// Gets or sets the weight of this edge.
        /// </summary>
        public double Weight { get; set; }

        #endregion // End IWeighted implementation region.

        #region Public methods

        /// <summary>
        /// Determines whether the specified object is equal to
        /// this <see cref="DirectedWeightedEdge"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to compare to the current
        /// <see cref="DirectedWeightedEdge"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the specified object is equal to
        /// this <see cref="DirectedWeightedEdge"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as DirectedWeightedEdge);
        }

        /// <summary>
        /// Gets a hash code for this <see cref="DirectedWeightedEdge"/>.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="DirectedWeightedEdge"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return SourceVertex.GetHashCode()
                ^ DestinationVertex.GetHashCode()
                ^ Weight.GetHashCode();
        }

        #endregion // End public methods region.

        #region Operators

        /// <summary>
        /// Determines whether two <see cref="DirectedWeightedEdge"/>
        /// instances are equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="DirectedWeightedEdge"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="DirectedWeightedEdge"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(DirectedWeightedEdge edge1, DirectedWeightedEdge edge2)
        {
            if (ReferenceEquals(edge1, edge2))
            {
                return true;
            }

            if (edge1 is null)
            {
                return false;
            }

            if (edge2 is null)
            {
                return false;
            }

            return edge1.Equals(edge2);
        }

        /// <summary>
        /// Determines whether two <see cref="DirectedWeightedEdge"/>
        /// instances are not equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="DirectedWeightedEdge"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="DirectedWeightedEdge"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is not equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(DirectedWeightedEdge edge1, DirectedWeightedEdge edge2)
        {
            if (ReferenceEquals(edge1, edge2))
            {
                return false;
            }

            if (edge1 is null)
            {
                return true;
            }

            if (edge2 is null)
            {
                return true;
            }

            return edge1.Equals(edge2);
        }

        #endregion // End operators region.
    }
}
