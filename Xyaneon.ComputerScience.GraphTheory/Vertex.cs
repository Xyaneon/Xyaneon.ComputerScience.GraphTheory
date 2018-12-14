using System;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents a vertex in a graph.
    /// </summary>
    public class Vertex : IEquatable<Vertex>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// </summary>
        public Vertex()
        {
            Label = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class
        /// with the given label.
        /// </summary>
        /// <param name="label">
        /// The label to use for this vertex.
        /// </param>
        public Vertex(string label)
        {
            Label = label;
        }

        #endregion // End constructors region.

        #region IEquatable<Vertex> implementation

        /// <summary>
        /// Indicates whether the current <see cref="Vertex"/> is equal
        /// to another <see cref="Vertex"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="Vertex"/> to compare with this object.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the other <see cref="Vertex"/> is equal
        /// to this <see cref="Vertex"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <seealso cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Vertex other)
        {
            if (other == null)
            {
                return false;
            }

            if (Label is null)
            {
                return other.Label is null;
            }

            return Label.Equals(other.Label);
        }

        #endregion // End IEquatable<Vertex> implementation region.

        #region Properties

        /// <summary>
        /// Gets or sets the label for this vertex.
        /// </summary>
        public string Label { get; set; }

        #endregion // End properties region.

        #region Public methods

        /// <summary>
        /// Determines whether the specified object is equal to
        /// this <see cref="Vertex"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to compare to the current <see cref="Vertex"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the specified object is equal to
        /// this <see cref="Vertex"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex);
        }

        /// <summary>
        /// Gets a hash code for this <see cref="Vertex"/>.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="Vertex"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Label?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> representation of this object.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> representation of this object.
        /// </returns>
        public override string ToString()
        {
            return Label;
        }

        #endregion // End public methods region.

        #region Operators

        /// <summary>
        /// Determines whether two <see cref="Vertex"/> instances are equal
        /// to each other.
        /// </summary>
        /// <param name="vertex1">
        /// The <see cref="Vertex"/> on the left hand of the expression.
        /// </param>
        /// <param name="vertex2">
        /// The <see cref="Vertex"/> on the right hand of the expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="vertex1"/> is equal to
        /// <paramref name="vertex2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(Vertex vertex1, Vertex vertex2)
        {
            if (ReferenceEquals(vertex1, vertex2))
            {
                return true;
            }

            if (vertex1 is null)
            {
                return false;
            }

            if (vertex2 is null)
            {
                return false;
            }

            return vertex1.Equals(vertex2);
        }

        /// <summary>
        /// Determines whether two <see cref="Vertex"/> instances are not equal
        /// to each other.
        /// </summary>
        /// <param name="vertex1">
        /// The <see cref="Vertex"/> on the left hand of the expression.
        /// </param>
        /// <param name="vertex2">
        /// The <see cref="Vertex"/> on the right hand of the expression.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="vertex1"/> is not equal to
        /// <paramref name="vertex2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(Vertex vertex1, Vertex vertex2)
        {
            if (ReferenceEquals(vertex1, vertex2))
            {
                return false;
            }

            if (vertex1 is null)
            {
                return true;
            }

            if (vertex2 is null)
            {
                return true;
            }

            return vertex1.Equals(vertex2);
        }

        #endregion // End operators region.
    }
}
