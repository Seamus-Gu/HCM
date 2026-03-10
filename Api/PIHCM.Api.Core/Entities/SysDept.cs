namespace Seed.Core.Entities
{
    public class SysDept : TreeEntity<SysDept>
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public virtual string DeptName { get; set; } = string.Empty;

        /// <summary>
        /// 部门状态
        /// </summary>
        public virtual StatusEnum DeptStatus { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        public virtual StatusEnum DataStatus { get; set; }
    }
}