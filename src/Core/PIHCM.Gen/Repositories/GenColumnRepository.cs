namespace PIHCM.Gen.Repositories
{
    public class GenColumnRepository : BaseRepository<GenColumn>
    {

        public GenColumnRepository(ISqlSugarClient context) : base(context)
        {
        }

        public Task<List<GenColumn>> SelectListByTableId(long tableId)
        {
            var q = AsQueryable()
                .Where(g => g.TableId == tableId);

            return q.ToListAsync();
        }

        /// <summary>
        /// 获取代码生成列分页列表
        /// </summary>
        public Task<List<GenColumn>> SelectGenColumnPageList(Pagination filter)
        {
            var q = AsQueryable();

            return PaginationListAsync(q, filter);
        }
    }
}