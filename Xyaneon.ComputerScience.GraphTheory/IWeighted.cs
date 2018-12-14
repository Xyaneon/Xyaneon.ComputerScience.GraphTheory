namespace Xyaneon.ComputerScience.GraphTheory
{
    /// <summary>
    /// Exposes properties on classes which have an associated weight.
    /// </summary>
    public interface IWeighted
    {
        /// <summary>
        /// Gets or sets the weight of this edge.
        /// </summary>
        int Weight { get; set; }
    }
}
