using System;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents an edge in an undirected graph.
    /// </summary>
    /// <seealso cref="IEdge"/>
    /// <seealso cref="DirectedEdge{TVertex}"/>
    /// <seealso cref="Vertex"/>
    public class UndirectedEdge<TVertex> : IEdge, IEquatable<UndirectedEdge<TVertex>> where TVertex : Vertex
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedEdge{TVertex}"/> class
        /// using the provided vertices and weight.
        /// </summary>
        /// <param name="vertex1">
        /// The first vertex.
        /// </param>
        /// <param name="vertex2">
        /// The second vertex.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="vertex1"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="vertex2"/> is <see langword="null"/>.
        /// </exception>
        public UndirectedEdge(TVertex vertex1, TVertex vertex2)
        {
            if (vertex1 == null)
            {
                throw new ArgumentNullException(nameof(vertex1), "Neither of the supplied vertices for an edge can be null.");
            }

            if (vertex2 == null)
            {
                throw new ArgumentNullException(nameof(vertex2), "Neither of the supplied vertices for an edge can be null.");
            }

            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        #endregion // End constructors region.

        #region IEdge implementation

        /// <summary>
        /// Gets a value indicating whether this edge is a self-loop.
        /// </summary>
        /// <remarks>
        /// A self-loop is defined as an edge whose two vertices are the same
        /// vertex.
        /// </remarks>
        /// <seealso cref="IEdge.IsSelfLoop"/>
        public bool IsSelfLoop { get => Vertex1 == Vertex2; }

        #endregion // End IEdge implementation region.

        #region IEquatable<UndirectedEdge> implementation

        /// <summary>
        /// Indicates whether the current <see cref="UndirectedEdge{TVertex}"/>
        /// is equal to another <see cref="UndirectedEdge{TVertex}"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="UndirectedEdge{TVertex}"/> to compare with this
        /// object.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the other
        /// <see cref="UndirectedEdge{TVertex}"/> is equal to this
        /// <see cref="UndirectedEdge{TVertex}"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <seealso cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(UndirectedEdge<TVertex> other)
        {
            if (other == null)
            {
                return false;
            }

            bool sameVerticesSameOrder =
                Vertex1.Equals(other.Vertex1) && Vertex2.Equals(other.Vertex2);

            bool sameVerticesDifferentOrder =
                Vertex1.Equals(other.Vertex2) && Vertex2.Equals(other.Vertex1);

            return (sameVerticesSameOrder || sameVerticesDifferentOrder);
        }

        #endregion // End IEquatable<UndirectedEdge> implementation region.

        #region Properties

        /// <summary>
        /// Gets or sets the first vertex of this edge.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// The supplied value is <see langword="null"/>.
        /// </exception>
        public TVertex Vertex1
        {
            get => _vertex1;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The vertex for an edge cannot be null.");
                }
                _vertex1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the second vertex of this edge.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// The supplied value is <see langword="null"/>.
        /// </exception>
        public TVertex Vertex2
        {
            get => _vertex2;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The vertex for an edge cannot be null.");
                }
                _vertex2 = value;
            }
        }

        #endregion // End properties region.

        #region Fields

        private TVertex _vertex1;
        private TVertex _vertex2;

        #endregion // End fields region.

        #region Public methods

        /// <summary>
        /// Determines whether the specified object is equal to
        /// this <see cref="UndirectedEdge{TVertex}"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to compare to the current
        /// <see cref="UndirectedEdge{TVertex}"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the specified object is equal to
        /// this <see cref="UndirectedEdge{TVertex}"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as UndirectedEdge<TVertex>);
        }

        /// <summary>
        /// Gets a hash code for this <see cref="UndirectedEdge{TVertex}"/>.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="UndirectedEdge{TVertex}"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Vertex1.GetHashCode() ^ Vertex2.GetHashCode();
        }

        #endregion // End public methods region.

        #region Operators

        /// <summary>
        /// Determines whether two <see cref="UndirectedEdge{TVertex}"/>
        /// instances are equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="UndirectedEdge{TVertex}"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="UndirectedEdge{TVertex}"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(UndirectedEdge<TVertex> edge1, UndirectedEdge<TVertex> edge2)
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
        /// Determines whether two <see cref="UndirectedEdge{TVertex}"/>
        /// instances are not equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="UndirectedEdge{TVertex}"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="UndirectedEdge{TVertex}"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is not equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(UndirectedEdge<TVertex> edge1, UndirectedEdge<TVertex> edge2)
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
