using Framework.Orm;

namespace HCM.Core.Migrations
{
    public class _20260501_init : Migration
    {
        protected override void Up()
        {
            CreateTable("gen_table", "代码生成表")
                .CreateId()
                .CreateProperty("name", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "名称" })
                .CreateProperty("namespace", typeof(string), new SugarColumn() { Length = 20, ColumnDescription = "所属命名空间" })
                .CreateProperty("table_name", typeof(string), new SugarColumn() { Length = 20, ColumnDescription = "数据库表名" })
                .CreateProperty("entity_name", typeof(string), new SugarColumn() { Length = 20, ColumnDescription = "实体名称" })
                .CreateProperty("description", typeof(string), new SugarColumn() { IsNullable = true, ColumnDescription = "描述" })
                .CreateProperty("entity_type", typeof(int), new SugarColumn() { IsNullable = true, ColumnDescription = "实体类别" })
                .CreateProperty("has_pagination", typeof(bool), new SugarColumn() { ColumnDescription = "需要分页" })
                .CreateProperty("has_combo", typeof(bool), new SugarColumn() { ColumnDescription = "需要Combo下拉" })
                .CreateProperty("has_frontend", typeof(bool), new SugarColumn() { ColumnDescription = "需要前端" })
                .CreateProperty("translation_key", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "翻译键值" })
                .CreateProperty("created_by", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "创建者" })
                .CreateProperty("created_at", typeof(DateTime), new SugarColumn() { ColumnDescription = "创建时间" })
                .CreateProperty("updated_by", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "更新者" })
                .CreateProperty("updated_at", typeof(DateTime), new SugarColumn() { IsNullable = true, ColumnDescription = "更新时间" });

            CreateTable("gen_column", "代码生成列")
              .CreateId()
              .CreateProperty("column_name", typeof(string), new SugarColumn() { Length = 20, ColumnDescription = "列名" })
              .CreateProperty("column_type", typeof(string), new SugarColumn() { ColumnDescription = "列类型" })
              .CreateProperty("column_desc", typeof(string), new SugarColumn() { ColumnDescription = "列描述(注释)" })
              .CreateProperty("is_nullable", typeof(bool), new SugarColumn() { ColumnDescription = "是否必填" })
              .CreateProperty("type_length", typeof(int), new SugarColumn() { IsNullable = true, ColumnDescription = "字段长度" })
              .CreateProperty("point", typeof(int), new SugarColumn() { IsNullable = true, ColumnDescription = "小数点" })
              .CreateProperty("translation_key", typeof(string), new SugarColumn() { ColumnDescription = "国际化键值" })
              .CreateProperty("is_hidden", typeof(bool), new SugarColumn() { ColumnDescription = "是否在页面隐藏" })
              .CreateProperty("component_type", typeof(int), new SugarColumn() { IsNullable = true, ColumnDescription = "组件类型" })
              .CreateProperty("table_id", typeof(long), new SugarColumn() { ColumnDescription = "所属表id" })
              .CreateProperty("created_by", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "创建者" })
              .CreateProperty("created_at", typeof(DateTime), new SugarColumn() { ColumnDescription = "创建时间" })
              .CreateProperty("updated_by", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "更新者" })
              .CreateProperty("updated_at", typeof(DateTime), new SugarColumn() { IsNullable = true, ColumnDescription = "更新时间" });
        }

        protected override void Down()
        {
            DropTable("sys_user");
        }
    }
}
