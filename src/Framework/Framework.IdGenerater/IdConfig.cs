namespace Framework.IdGenerater
{
    //请使用中文注释
    /// <summary>
    /// 表示用于唯一标识生成方案的工作节点配置。
    /// </summary>
    /// <remarks>此类型用于配置分布式ID生成器的工作节点标识及其相关位数分配。通过调整各属性，可以灵活适配不同规模的分布式部署场景。</remarks>
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