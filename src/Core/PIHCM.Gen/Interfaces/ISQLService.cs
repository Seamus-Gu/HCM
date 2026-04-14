namespace PIHCM.Gen.Interfaces
{
    public interface ISQLService
    {
        public Task<bool> ParseCreateTableSql(SQLGenerateDto createTableSql);
    }
}
