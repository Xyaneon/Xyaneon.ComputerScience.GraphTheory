using System;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents an edge in a directed graph.
    /// </summary>
    /// <typeparam name="TVertex">
    /// The type of <see cref="Vertex"/> stored in this edge.
    /// </typeparam>
    /// <seealso cref="UndirectedEdge"/>
    /// <seealso cref="Vertex"/>
    public class DirectedEdge<TVertex> : IEquatable<DirectedEdge<TVertex>> where TVertex : Vertex
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedEdge{TVertex}"/> class
        /// using the provided vertices.
        /// </summary>
        /// <param name="source">
        /// The source vertex.
        /// </param>
        /// <param name="destination">
        /// The destination vertex.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="destination"/> is <see langword="null"/>.
        /// </exception>
        public DirectedEdge(TVertex source, TVertex destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "The source vertex for a directed edge cannot be null.");
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination), "The destination vertex for a directed edge cannot be null.");
            }

            SourceVertex = source;
            DestinationVertex = destination;
        }

        #endregion // End constructors region.

        #region IEquatable<DirectedEdge> implementation

        /// <summary>
        /// Indicates whether the current <see cref="DirectedEdge{TVertex}"/>
        /// is equal to another <see cref="DirectedEdge{TVertex}"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="DirectedEdge{TVertex}"/> to compare with this
        /// object.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the other
        /// <see cref="DirectedEdge{TVertex}"/> is equal to this
        /// <see cref="DirectedEdge{TVertex}"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <seealso cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(DirectedEdge<TVertex> other)
        {
            if (other == null)
            {
                return false;
            }

            return SourceVertex.Equals(other.SourceVertex) && DestinationVertex.Equals(other.DestinationVertex);
        }

        #endregion // End IEquatable<DirectedEdge> implementation region.

        #region Properties

        /// <summary>
        /// Gets or sets the source vertex of this edge.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// The supplied value is <see langword="null"/>.
        /// </exception>
        public TVertex SourceVertex
        {
            get => _sourceVertex;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The source vertex for a directed edge cannot be null.");
                }
                _sourceVertex = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination vertex of this edge.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// The supplied value is <see langword="null"/>.
        /// </exception>
        public TVertex DestinationVertex
        {
            get => _destinationVertex;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The destination vertex for a directed edge cannot be null.");
                }
                _destinationVertex = value;
            }
        }

        #endregion // End properties region.

        #region Fields

        private TVertex _sourceVertex;
        private TVertex _destinationVertex;

        #endregion // End fields region.

        #region Public methods

        /// <summary>
        /// Determines whether the specified object is equal to
        /// this <see cref="DirectedEdge{TVertex}"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to compare to the current
        /// <see cref="DirectedEdge{TVertex}"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the specified object is equal to
        /// this <see cref="DirectedEdge{TVertex}"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as DirectedEdge<TVertex>);
        }

        /// <summary>
        /// Gets a hash code for this <see cref="DirectedEdge{TVertex}"/>.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="DirectedEdge{TVertex}"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return SourceVertex.GetHashCode() ^ DestinationVertex.GetHashCode();
        }

        #endregion // End public methods region.

        #region Operators

        /// <summary>
        /// Determines whether two <see cref="DirectedEdge{TVertex}"/>
        /// instances are equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="DirectedEdge{TVertex}"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="DirectedEdge{TVertex}"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(DirectedEdge<TVertex> edge1, DirectedEdge<TVertex> edge2)
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
        /// Determines whether two <see cref="DirectedEdge{TVertex}"/>
        /// instances are not equal to each other.
        /// </summary>
        /// <param name="edge1">
        /// The <see cref="DirectedEdge{TVertex}"/> on the left hand of the
        /// expression.
        /// </param>
        /// <param name="edge2">
        /// The <see cref="DirectedEdge{TVertex}"/> on the right hand of the
        /// expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="edge1"/> is not equal to
        /// <paramref name="edge2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(DirectedEdge<TVertex> edge1, DirectedEdge<TVertex> edge2)
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
