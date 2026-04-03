namespace PIHCM.Gen.Repositories
{
    public class GenTableRepository : BaseRepository<GenTable>
    {

        public GenTableRepository(ISqlSugarClient context) : base(context)
        {
        }

        public async Task<List<GenTable>> SelectPageList(GenTableQueryDto filter)
        {
            var q = AsQueryable();

            return await PaginationListAsync(q, filter);
        }
    }
}