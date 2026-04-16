using Dm.util;
using Framework.Core.Utils;
using Scriban;

namespace PIHCM.Gen.Services
{
    public class GenTableService : IGenTableService, IScopeService
    {
        private readonly GenTableRepository _genTableRepository;
        private readonly GenColumnRepository _genColumnRepository;
        private readonly ISqlSugarClient _db;

        public GenTableService(GenTableRepository repository, GenColumnRepository genColumnRepository, ISqlSugarClient db)
        {
            _genTableRepository = repository;
            _genColumnRepository = genColumnRepository;
            _db = db;
        }

        public async Task<List<GenTable>> GetPageList(GenTableQueryDto query)
        {
            return await _genTableRepository.SelectPageList(query);
        }

        /// <summary>
        /// 根据Id获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GenTable> GetGenTableById(long id)
        {
            var result = await _genTableRepository.GetByIdAsync(id);

            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> EditGenTable(GenTable entity)
        {
            var result = await _genTableRepository.UpdateAsync(entity);

            return result;
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveGenTableById(long tableId)
        {
            var tran = await _db.Ado.UseTranAsync(async () =>
            {
                await _genTableRepository.DeleteByIdAsync(tableId);

                _genColumnRepository.AsDeleteable()
                .Where(gc => gc.TableId == tableId);
            });

            if (!tran.IsSuccess)
            {
                return false;
            }

            return true;
        }

        public async Task<List<GenTemplateDto>> GenerateCode(long tableId)
        {
            var genTable = await _genTableRepository.GetByIdAsync(tableId);

            genTable.Columns = await _genColumnRepository.SelectListByTableId(tableId);

            var templateList = GetTemplateList(genTable);

            foreach (var item in templateList)
            {
                var template = Template.ParseLiquid(item.Content);

                var result = template.Render(genTable);

                var fileName = string.Format(item.FileName, genTable.EntityName);

                var path = Path.Combine(item.GenFolder, fileName);

                // 确保目标文件夹存在
                if (!Directory.Exists(item.GenFolder))
                {
                    Directory.CreateDirectory(item.GenFolder);
                }

                File.WriteAllText(path, result);

                item.Code = result;
            }

            return templateList;
        }

        public async Task<MemoryStream> ExportCode(long tableId)
        {
            string genFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Generate", tableId.toString());

            var ms = FileUtil.ZipStream(genFolder);

            return ms;
        }

        private List<GenTemplateDto> GetTemplateList(GenTable table)
        {
            string folder = Path.Combine(AppContext.BaseDirectory, "Templates", "Common");
            string genFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Generate", table.Id.toString());

            var result = new List<GenTemplateDto>
            {
                new GenTemplateDto
                {
                    Name = "Entity",
                    Content = File.ReadAllText($"{folder}/Entity.txt"),
                    GenFolder =  Path.Combine(genFolder,"Backend","Entities"),
                    FileName = "{0}.cs"
                },
                new GenTemplateDto
                {
                    Name = "Repository",
                    Content = File.ReadAllText($"{folder}/Repository.txt"),
                    GenFolder =  Path.Combine(genFolder,"Backend","Repositories"),
                    FileName = "{0}Repository.cs"
                },
                new GenTemplateDto
                {
                    Name = "Service",
                    Content = File.ReadAllText($"{folder}/Service.txt"),
                    GenFolder =  Path.Combine(genFolder,"Backend","Services"),
                    FileName = "{0}Services.cs"
                },
                new GenTemplateDto
                {
                    Name = "Interface",
                    Content = File.ReadAllText($"{folder}/Interface.txt"),
                    GenFolder =  Path.Combine(genFolder,"Backend","Interfaces"),
                    FileName = "I{0}Service.cs"
                },
                new GenTemplateDto
                {
                    Name = "Controller",
                    Content = File.ReadAllText($"{folder}/Controller.txt"),
                    GenFolder =  Path.Combine(genFolder,"Backend","Controllers"),
                    FileName = "{0}Controller.cs"
                },

            };

            if (table.HasFrontend)
            {
                result.Add(new GenTemplateDto
                {
                    Name = "Api",
                    Content = File.ReadAllText($"{folder}/Api.txt"),
                    GenFolder = Path.Combine(genFolder, "Frontend"),
                    FileName = $"{table.KebabName}.js"
                });

                result.Add(new GenTemplateDto
                {
                    Name = "View",
                    Content = File.ReadAllText($"{folder}/View.txt"),
                    GenFolder = Path.Combine(genFolder, "Frontend"),
                    FileName = "index.vue"
                });
            }


            return result;
        }
    }
}