using System;
using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Represents a directed graph.
    /// </summary>
    /// <typeparam name="TEdge">
    /// The type of edges used in this graph. Must be either
    /// <see cref="DirectedEdge"/> or a derived class.
    /// </typeparam>
    /// <seealso cref="UndirectedGraph{TEdge}"/>
    public class DirectedGraph<TEdge> where TEdge : DirectedEdge
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedGraph"/> class
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
        /// <paramref name="edges"/> contains an <see cref="TEdge"/>
        /// which has a <see cref="Vertex"/> which is not in <paramref name="vertices"/>.
        /// </exception>
        public DirectedGraph(IEnumerable<TEdge> edges, IEnumerable<Vertex> vertices)
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
                if (!vertices.Contains(edge.SourceVertex))
                {
                    throw new ArgumentException(
                        $"The supplied collection of vertices does not contain \"{edge.SourceVertex}\".",
                        nameof(vertices));
                }

                if (!vertices.Contains(edge.DestinationVertex))
                {
                    throw new ArgumentException(
                        $"The supplied collection of vertices does not contain \"{edge.DestinationVertex}\".",
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
        /// The <see cref="TEdge"/> to add.
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
        /// An <see cref="TEdge"/> is already in
        /// this graph which has the same vertices as
        /// <paramref name="edge"/>.
        /// </exception>
        public void AddEdge(TEdge edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge), "Cannot add a null edge to the graph.");
            }

            if (!Vertices.Contains(edge.SourceVertex))
            {
                throw new ArgumentException(
                    $"The edge to add has vertex \"{edge.SourceVertex}\", which is not in the graph.",
                    nameof(edge));
            }

            if (!Vertices.Contains(edge.DestinationVertex))
            {
                throw new ArgumentException(
                    $"The edge to add has vertex \"{edge.DestinationVertex}\", which is not in the graph.",
                    nameof(edge));
            }

            foreach (var existingEdge in Edges)
            {
                if ((edge.SourceVertex == existingEdge.SourceVertex && edge.DestinationVertex == existingEdge.DestinationVertex)
                    || (edge.SourceVertex == existingEdge.DestinationVertex && edge.DestinationVertex == existingEdge.SourceVertex))
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
                if (edge.SourceVertex == vertex)
                {
                    adjacentVertices.Add(edge.DestinationVertex);
                }
                else if (edge.DestinationVertex == vertex)
                {
                    adjacentVertices.Add(edge.SourceVertex);
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
                if (edge.SourceVertex.Label == label)
                {
                    adjacentVertices.Add(edge.DestinationVertex);
                }
                else if (edge.DestinationVertex.Label == label)
                {
                    adjacentVertices.Add(edge.SourceVertex);
                }
            }

            return adjacentVertices.AsReadOnly();
        }

        /// <summary>
        /// Gets the edge stored in this graph with the given vertices.
        /// </summary>
        /// <param name="source">
        /// The source <see cref="Vertex"/> of the requested edge.
        /// </param>
        /// <param name="destination">
        /// The destination <see cref="Vertex"/> of the requested edge.
        /// </param>
        /// <returns>
        /// The <see cref="TEdge"/> stored in this graph with
        /// the requested vertices, if it exists; otherwise,
        /// <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is <see langword="null"/>.
        /// -or-
        /// <paramref name="destination"/> is <see langword="null"/>.
        /// </exception>
        public TEdge GetEdge(Vertex source, Vertex destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Cannot retrieve an edge from the graph using a null vertex.");
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination), "Cannot retrieve an edge from the graph using a null vertex.");
            }

            var searchEdge = new DirectedEdge(source, destination);
            return GetEqualEdge(searchEdge);
        }

        /// <summary>
        /// Gets the edge stored in this graph with the given vertex labels.
        /// </summary>
        /// <param name="sourceLabel">
        /// The source vertex label of the requested edge.
        /// </param>
        /// <param name="destinationLabel">
        /// The destination vertex label of the requested edge.
        /// </param>
        /// <returns>
        /// The <see cref="TEdge"/> stored in this graph with
        /// the requested vertex labels, if it exists; otherwise,
        /// <see langword="null"/>.
        /// </returns>
        public TEdge GetEdge(string sourceLabel, string destinationLabel)
        {
            var searchEdge = new DirectedEdge(new Vertex(sourceLabel), new Vertex(destinationLabel));
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

        private TEdge GetEqualEdge(DirectedEdge searchEdge)
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
