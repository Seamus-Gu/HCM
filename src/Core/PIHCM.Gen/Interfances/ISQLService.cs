namespace PIHCM.Gen.Interfances
{
    public interface ISQLService
    {
        public Task<bool> ParseCreateTableSql(SQLGenerateDto createTableSql);
    }
}
