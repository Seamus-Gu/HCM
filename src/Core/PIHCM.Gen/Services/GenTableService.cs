namespace PIHCM.Gen.Services
{
    public class GenTableService : IGenTableService, IScopeService
    {
        private readonly GenTableRepository _repository;

        public GenTableService(GenTableRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GenTable>> GetPageList(GenTableQueryDto query)
        {
            return await _repository.SelectPageList(query);
        }

        public void GenerateCode(string tableName, string outputPath)
        {
            //            var columns = _repository.GetColumns(tableName);

            //            // Define a simple template
            //            var template = @"using System;

            //namespace GeneratedCode
            //{
            //    public class {TableName}
            //    {
            //{Properties}
            //    }
            //}";

            //            // Generate properties based on columns
            //            var propertiesBuilder = new StringBuilder();
            //            foreach (var column in columns)
            //            {
            //                propertiesBuilder.AppendLine($"        public {MapDataType(column.DataType)} {column.ColumnName} {{ get; set; }}");
            //            }

            //            // Replace placeholders in the template
            //            var code = template.Replace("{TableName}", tableName)
            //                               .Replace("{Properties}", propertiesBuilder.ToString());

            //            // Write the generated code to a file
            //            File.WriteAllText(Path.Combine(outputPath, $"{tableName}.cs"), code);
        }

        private string MapDataType(string sqlDataType)
        {
            return sqlDataType switch
            {
                "int" => "int",
                "varchar" => "string",
                "datetime" => "DateTime",
                _ => "object"
            };
        }
    }
}