using System;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents a weighted edge in an undirected graph.
    /// </summary>
    /// <seealso cref="UndirectedEdge"/>
    public class UndirectedWeightedEdge : UndirectedEdge, IEquatable<UndirectedWeightedEdge>, IWeighted
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedWeightedEdge"/> class
        /// using the provided vertices and weight.
        /// </summary>
        /// <param name="vertex1">
        /// The first vertex.
        /// </param>
        /// <param name="vertex2">
        /// The second vertex.
        /// </param>
        /// <param name="weight">
        /// The edge's weight.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="vertex1"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="vertex2"/> is <see langword="null"/>.
        /// </exception>
        public UndirectedWeightedEdge(Vertex vertex1, Vertex vertex2, int weight) : base(vertex1, vertex2)
        {
            Weight = weight;
        }

        #endregion // End constructors region.

        #region IEquatable<UndirectedWeightedEdge> implementation

        /// <summary>
        /// Indicates whether the current <see cref="UndirectedWeightedEdge"/>
        /// is equal to another <see cref="UndirectedWeightedEdge"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="UndirectedWeightedEdge"/> to compare with this
        /// object.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the other
        /// <see cref="UndirectedWeightedEdge"/> is equal to this
        /// <see cref="UndirectedWeightedEdge"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <seealso cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(UndirectedWeightedEdge other)
        {
            if (other == null)
            {
                return false;
            }

            bool sameVerticesSameOrder =
                Vertex1.Equals(other.Vertex1) && Vertex2.Equals(other.Vertex2);

            bool sameVerticesDifferentOrder =
                Vertex1.Equals(other.Vertex2) && Vertex2.Equals(other.Vertex1);

            return (sameVerticesSameOrder || sameVerticesDifferentOrder)
                && Weight.Equals(other.Weight);
        }

        #endregion // End IEquatable<UndirectedWeightedEdge> implementation region.

        #region IWeighted implementation

        /// <summary>
        /// Gets or sets the weight of this edge.
        /// </summary>
        public int Weight { get; set; }

        #endregion // End IWeighted implementation region.

        #region Public methods

        /// <summary>
        /// Determines whether the specified object is equal to
        /// this <see cref="UndirectedWeightedEdge"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to compare to the current
        /// <see cref="UndirectedWeightedEdge"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the specified object is equal to
        /// this <see cref="UndirectedWeightedEdge"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as UndirectedWeightedEdge);
        }

        /// <summary>
        /// Gets a hash code for this <see cref="UndirectedWeightedEdge"/>.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="UndirectedWeightedEdge"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Vertex1.GetHashCode()
                ^ Vertex2.GetHashCode()
                ^ Weight.GetHashCode();
        }

        #endregion // End public methods region.

        #region Operators

        /// <summary>
        /// Determines whether two <see cref="UndirectedWeightedEdge"/>
        /// instances are equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="UndirectedWeightedEdge"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="UndirectedWeightedEdge"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(UndirectedWeightedEdge edge1, UndirectedWeightedEdge edge2)
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
        /// Determines whether two <see cref="UndirectedWeightedEdge"/>
        /// instances are not equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="UndirectedWeightedEdge"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="UndirectedWeightedEdge"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is not equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(UndirectedWeightedEdge edge1, UndirectedWeightedEdge edge2)
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
