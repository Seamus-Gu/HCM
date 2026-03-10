using SqlSugar;
using Yitter.IdGenerator;

namespace Framework.WebApi
{
    /// <summary>
    /// Provides a base class for entities with common audit properties such as identifier and timestamps.
    /// </summary>
    /// <remarks>This abstract class is intended to be inherited by domain entities that require standard
    /// properties for identification and auditing. It includes properties for the primary key, creation and update
    /// timestamps, and user information related to creation and modification. Derived classes can extend this base to
    /// include additional domain-specific properties.</remarks>
    [Serializable]
    public abstract class BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the BaseEntity class with a unique identifier and the current creation time.
        /// </summary>
        public BaseEntity()
        {
            Id = YitIdHelper.NextId();
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public virtual long Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the entity.
        /// </summary>
        public virtual string CreateBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who last updated the entity.
        /// </summary>
        public virtual string? UpdateBy { get; set; }
    }
}