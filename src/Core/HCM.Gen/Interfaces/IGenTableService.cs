namespace HCM.Gen.Interfaces
{
    public interface IGenTableService
    {
        public Task<List<GenTable>> GetPageList(GenTableQueryDto query);

        public Task<GenTable> GetGenTableById(long id);

        /// <summary>
		/// 修改代码生成表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> EditGenTable(GenTable entity);

        /// <summary>
        /// 删除代码生成表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> RemoveGenTableById(long id);

        public Task<List<GenTemplateDto>> GenerateCode(long tableId);

        public Task<MemoryStream> ExportCode(long tableId);
    }
}
