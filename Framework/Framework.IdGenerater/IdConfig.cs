namespace Framework.IdGenerater
{
    /// <summary>
    /// Represents the configuration settings for machine identifier and sequence bit lengths used in ID generation.
    /// </summary>
    /// <remarks>This class is intended for internal use to configure parameters that influence the structure
    /// of generated IDs, such as the unique worker identifier and the bit allocation for worker and sequence numbers.
    /// Adjust these settings according to the requirements of your distributed ID generation strategy.</remarks>
    public class IdConfig
    {
        /// <summary>
        /// Gets or sets the unique identifier for the worker.
        /// </summary>
        public int WorkerId { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of bits allocated for the worker identifier in the ID generation scheme.
        /// </summary>
        /// <remarks>Adjusting this value changes the maximum number of unique worker nodes that can be
        /// supported. Increasing the bit length allows for more workers but reduces the number of bits available for
        /// other components of the ID.</remarks>
        public int WorkerIdBitLength { get; set; } = 6;

        /// <summary>
        /// Gets or sets the number of bits used to represent the sequence value.
        /// </summary>
        /// <remarks>Adjust this property to control the maximum value that the sequence can represent.
        /// Increasing the bit length allows for a larger range of sequence values, while decreasing it reduces the
        /// range.</remarks>
        public int SeqBitLength { get; set; } = 6;
    }
}