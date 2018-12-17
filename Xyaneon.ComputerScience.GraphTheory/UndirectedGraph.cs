using System;
using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents an undirected graph.
    /// </summary>
    /// <typeparam name="TEdge">
    /// The type of edges used in this graph. Must be either
    /// <see cref="UndirectedEdge"/> or a derived class.
    /// </typeparam>
    /// <seealso cref="DirectedGraph{TEdge}"/>
    public class UndirectedGraph<TEdge> where TEdge : UndirectedEdge
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedGraph{TEdge}"/> class
        /// using the provided collections of edges and vertices.
        /// </summary>
        /// <param name="edges">
        /// The collection of edges in the graph.
        /// </param>
        /// <param name="vertices">
        /// The collection of vertices in the graph.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="edges"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="vertices"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="edges"/> contains an edge
        /// which has a <see cref="Vertex"/> which is not in <paramref name="vertices"/>.
        /// </exception>
        public UndirectedGraph(IEnumerable<TEdge> edges, IEnumerable<Vertex> vertices)
        {
            if (edges == null)
            {
                throw new ArgumentNullException(nameof(edges), "The collection of edges cannot be null.");
            }

            if (vertices == null)
            {
                throw new ArgumentNullException(nameof(vertices), "The collection of vertices cannot be null.");
            }

            foreach (var edge in edges)
            {
                if (!vertices.Contains(edge.Vertex1))
                {
                    throw new ArgumentException(
                        $"The supplied collection of vertices does not contain \"{edge.Vertex1}\".",
                        nameof(vertices));
                }

                if (!vertices.Contains(edge.Vertex2))
                {
                    throw new ArgumentException(
                        $"The supplied collection of vertices does not contain \"{edge.Vertex2}\".",
                        nameof(vertices));
                }
            }

            _edges = new List<TEdge>(edges);
            _vertices = new List<Vertex>(vertices);
        }

        #endregion // End constructors region.

        #region Properties

        /// <summary>
        /// Gets the read-only collection of edges in this graph.
        /// </summary>
        public IReadOnlyCollection<TEdge> Edges
        {
            get => _edges.AsReadOnly();
        }

        /// <summary>
        /// Gets the read-only collection of vertices in this graph.
        /// </summary>
        public IReadOnlyCollection<Vertex> Vertices
        {
            get => _vertices.AsReadOnly();
        }

        #endregion // End properties region.

        #region Fields

        private List<TEdge> _edges;
        private List<Vertex> _vertices;

        #endregion // End fields region.

        #region Public methods

        /// <summary>
        /// Adds the provided <paramref name="edge"/> to this graph.
        /// </summary>
        /// <param name="edge">
        /// The edge to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="edge"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="edge"/> is already in this graph.
        /// -or-
        /// <paramref name="edge"/> has a vertex which is not in this
        /// graph.
        /// -or-
        /// An edge is already in
        /// this graph which has the same vertices as
        /// <paramref name="edge"/>.
        /// </exception>
        public void AddEdge(TEdge edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge), "Cannot add a null edge to the graph.");
            }

            if (!Vertices.Contains(edge.Vertex1))
            {
                throw new ArgumentException(
                    $"The edge to add has vertex \"{edge.Vertex1}\", which is not in the graph.",
                    nameof(edge));
            }

            if (!Vertices.Contains(edge.Vertex2))
            {
                throw new ArgumentException(
                    $"The edge to add has vertex \"{edge.Vertex2}\", which is not in the graph.",
                    nameof(edge));
            }

            foreach (var existingEdge in Edges)
            {
                if ((edge.Vertex1 == existingEdge.Vertex1 && edge.Vertex2 == existingEdge.Vertex2)
                    || (edge.Vertex1 == existingEdge.Vertex2 && edge.Vertex2 == existingEdge.Vertex1))
                {
                    throw new ArgumentException("The edge to add already exists in the graph.", nameof(edge));
                }
            }

            _edges.Add(edge);
        }

        /// <summary>
        /// Adds the provided <paramref name="vertex"/> to this graph.
        /// </summary>
        /// <param name="vertex">
        /// The <see cref="Vertex"/> to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="vertex"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="vertex"/> is already in this graph.
        /// -or-
        /// A <see cref="Vertex"/> is already in this graph which has
        /// the same <see cref="Vertex.Label"/> property value as
        /// <paramref name="vertex"/>.
        /// </exception>
        public void AddVertex(Vertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex), "Cannot add a null vertex to the graph.");
            }

            foreach (var existingVertex in Vertices)
            {
                if (vertex == existingVertex)
                {
                    throw new ArgumentException("The vertex to add is already in the graph.", nameof(vertex));
                }
            }

            _vertices.Add(vertex);
        }

        /// <summary>
        /// Determines whether this graph contains a <see cref="Vertex"/> with
        /// the given <paramref name="label"/>.
        /// </summary>
        /// <param name="label">
        /// The label of the <see cref="Vertex"/> to check for.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if this graph contains a
        /// <see cref="Vertex"/> with the given <paramref name="label"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public bool ContainsVertex(string label)
        {
            foreach (var vertex in Vertices)
            {
                if (vertex.Label == label)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets a collection of all vertices in this graph which are adjacent
        /// to (i.e., share an edge with) the given <see cref="Vertex"/>.
        /// </summary>
        /// <param name="vertex">
        /// The <see cref="Vertex"/> to find the neighbors of.
        /// </param>
        /// <returns>
        /// A read-only collection of all vertices in this graph which are
        /// adjacent to (i.e., share an edge with) the given
        /// <see cref="Vertex"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="vertex"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="vertex"/> is not in this graph's collection of
        /// vertices.
        /// </exception>
        public IReadOnlyCollection<Vertex> GetAdjacentVertices(Vertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex), "The vertex to find the adjacent vertices of cannot be null.");
            }

            if (!Vertices.Contains(vertex))
            {
                throw new ArgumentException("The given vertex to find the adjacent vertices of is not in the graph.", nameof(vertex));
            }

            var adjacentVertices = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (edge.Vertex1 == vertex)
                {
                    adjacentVertices.Add(edge.Vertex2);
                }
                else if (edge.Vertex2 == vertex)
                {
                    adjacentVertices.Add(edge.Vertex1);
                }
            }

            return adjacentVertices.AsReadOnly();
        }

        /// <summary>
        /// Gets a collection of all vertices in this graph which are adjacent
        /// to (i.e., share an edge with) the <see cref="Vertex"/> with the
        /// given <paramref name="label"/>.
        /// </summary>
        /// <param name="label">
        /// The label of the <see cref="Vertex"/> to find the neighbors of.
        /// </param>
        /// <returns>
        /// A read-only collection of all vertices in this graph which are
        /// adjacent to (i.e., share an edge with) the requested
        /// <see cref="Vertex"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="label"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// A <see cref="Vertex"/> with a <see cref="Vertex.Label"/>
        /// property value equal to <paramref name="label"/> is not in this
        /// graph's collection of vertices.
        /// </exception>
        public IReadOnlyCollection<Vertex> GetAdjacentVertices(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label), "The label of the vertex to find the adjacent vertices of cannot be null.");
            }

            if (!ContainsVertex(label))
            {
                throw new ArgumentException("The given vertex label to find the adjacent vertices of is not in the graph.", nameof(label));
            }

            var adjacentVertices = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (edge.Vertex1.Label == label)
                {
                    adjacentVertices.Add(edge.Vertex2);
                }
                else if (edge.Vertex2.Label == label)
                {
                    adjacentVertices.Add(edge.Vertex1);
                }
            }

            return adjacentVertices.AsReadOnly();
        }

        /// <summary>
        /// Gets the edge stored in this graph with the given vertices.
        /// </summary>
        /// <param name="vertex1">
        /// The first <see cref="Vertex"/> of the requested edge.
        /// </param>
        /// <param name="vertex2">
        /// The second <see cref="Vertex"/> of the requested edge.
        /// </param>
        /// <returns>
        /// The edge stored in this graph with
        /// the requested vertices, if it exists; otherwise,
        /// <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="vertex1"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="vertex2"/> is <see langword="null"/>.
        /// </exception>
        public TEdge GetEdge(Vertex vertex1, Vertex vertex2)
        {
            if (vertex1 == null)
            {
                throw new ArgumentNullException(nameof(vertex1), "Cannot retrieve an edge from the graph using a null vertex.");
            }

            if (vertex2 == null)
            {
                throw new ArgumentNullException(nameof(vertex2), "Cannot retrieve an edge from the graph using a null vertex.");
            }

            var searchEdge = new UndirectedEdge(vertex1, vertex2);
            return GetEqualEdge(searchEdge);
        }

        /// <summary>
        /// Gets the edge stored in this graph with the given vertex labels.
        /// </summary>
        /// <param name="vertexLabel1">
        /// The first vertex label of the requested edge.
        /// </param>
        /// <param name="vertexLabel2">
        /// The second vertex label of the requested edge.
        /// </param>
        /// <returns>
        /// The edge stored in this graph with
        /// the requested vertex labels, if it exists; otherwise,
        /// <see langword="null"/>.
        /// </returns>
        public TEdge GetEdge(string vertexLabel1, string vertexLabel2)
        {
            var searchEdge = new UndirectedEdge(new Vertex(vertexLabel1), new Vertex(vertexLabel2));
            return GetEqualEdge(searchEdge);
        }

        /// <summary>
        /// Gets the <see cref="Vertex"/> stored in this graph with the given
        /// <paramref name="label"/>.
        /// </summary>
        /// <param name="label">
        /// The label of the <see cref="Vertex"/> to retrieve.
        /// </param>
        /// <returns>
        /// The <see cref="Vertex"/> with the given <paramref name="label"/>
        /// if it exists in this graph; otherwise, <see langword="null"/>.
        /// </returns>
        public Vertex GetVertex(string label)
        {
            foreach (var vertex in Vertices)
            {
                if (vertex.Label == label)
                {
                    return vertex;
                }
            }

            return null;
        }

        #endregion // End public methods region.

        #region Private methods

        private TEdge GetEqualEdge(UndirectedEdge searchEdge)
        {
            foreach (TEdge edge in Edges)
            {
                if (edge == searchEdge)
                {
                    return edge;
                }
            }

            return null;
        }

        #endregion // End private methods region.
    }
}
