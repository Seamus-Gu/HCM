namespace PIHCM.Gen.Entities
{
    public class GenColumn
    {
        public string Name { get; init; } = string.Empty;

        public string DataType { get; init; } = string.Empty;

        public bool IsNullable { get; init; }

        public bool IsPrimaryKey { get; init; }

        public string? Description { get; init; }
    }
}
