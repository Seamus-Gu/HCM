namespace Framework.Scriban.Models;

public sealed class DatabaseColumn
{
    public string Name { get; init; } = string.Empty;

    public string DataType { get; init; } = string.Empty;

    public bool IsNullable { get; init; }

    public bool IsPrimaryKey { get; init; }

    public string? Description { get; init; }
}
