namespace PIHCM.Gen.Interfances
{
    public interface IGenTableService
    {
        public Task<List<GenTable>> GetList();
    }
}
