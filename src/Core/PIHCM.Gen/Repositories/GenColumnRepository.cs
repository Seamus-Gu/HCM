namespace PIHCM.Gen.Repositories
{
    public class GenColumnRepository : BaseRepository<GenColumn>
    {

        public GenColumnRepository(ISqlSugarClient context) : base(context)
        {
        }
    }
}