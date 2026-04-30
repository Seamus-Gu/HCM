using Framework.Orm;

namespace HCM.Core.Migrations
{
    public class _20260501_init : Migration
    {
        protected override void Up()
        {
            CreateTable("sys_user", "用户表")
                .CreateId()
                .CreateProperty("user_name", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "用户名" })
                .CreateProperty("nick_name", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "昵称" })
                .CreateProperty("email", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "邮箱" })
                .CreateProperty("phone_number", typeof(string), new SugarColumn() { IsNullable = true, Length = 11, ColumnDescription = "手机号" })
                .CreateProperty("sex", typeof(int), new SugarColumn() { IsNullable = true, ColumnDescription = "性别" })
                .CreateProperty("avatar", typeof(string), new SugarColumn() { IsNullable = true, ColumnDescription = "头像" })
                .CreateProperty("password", typeof(string), new SugarColumn() { ColumnDescription = "密码" })
                .CreateProperty("user_status", typeof(int), new SugarColumn() { ColumnDescription = "用户状态" })
                .CreateProperty("del_flag", typeof(bool), new SugarColumn() { ColumnDescription = "是否删除" })
                .CreateProperty("login_ip", typeof(string), new SugarColumn() { IsNullable = true, ColumnDescription = "最后登录IP" })
                .CreateProperty("login_date", typeof(DateTime), new SugarColumn() { IsNullable = true, ColumnDescription = "最后登录时间" })
                .CreateProperty("sys_dept_id", typeof(long), new SugarColumn() { IsNullable = true, ColumnDescription = "部门ID" })
                .CreateProperty("created_by", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "创建者" })
                .CreateProperty("created_at", typeof(DateTime), new SugarColumn() { ColumnDescription = "创建时间" })
                .CreateProperty("updated_by", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "更新者" })
                .CreateProperty("updated_at", typeof(DateTime), new SugarColumn() { IsNullable = true, ColumnDescription = "更新时间" });

            CreateTable("sys_menu", "系统菜单表")
                .CreateId()
                .CreateProperty("menu_name", typeof(string), new SugarColumn() { Length = 255, ColumnDescription = "菜单名称" })
                .CreateProperty("path", typeof(string), new SugarColumn() { IsNullable = true, Length = 255, ColumnDescription = "路由地址" })
                .CreateProperty("component", typeof(string), new SugarColumn() { IsNullable = true, Length = 255, ColumnDescription = "组件路径" })
                .CreateProperty("is_cache", typeof(bool), new SugarColumn() { IsNullable = true, ColumnDescription = "是否缓存" })
                .CreateProperty("visible", typeof(bool), new SugarColumn() { IsNullable = true, ColumnDescription = "是否启用" })
                .CreateProperty("menu_type", typeof(int), new SugarColumn() { ColumnDescription = "菜单类型（M目录 C菜单 F按钮）" })
                .CreateProperty("menu_status", typeof(int), new SugarColumn() { ColumnDescription = "菜单状态（0正常 1停用）" })
                .CreateProperty("permission", typeof(string), new SugarColumn() { IsNullable = true, Length = 255, ColumnDescription = "权限标识" })
                .CreateProperty("icon", typeof(string), new SugarColumn() { IsNullable = true, Length = 255, ColumnDescription = "图标" })
                .CreateProperty("parent_id", typeof(long), new SugarColumn() { ColumnDescription = "父菜单ID", })
                .CreateProperty("node_level", typeof(int), new SugarColumn() { ColumnDescription = "" })
                .CreateProperty("order_num", typeof(int), new SugarColumn() { ColumnDescription = "显示顺序" })
                .CreateProperty("tree_ids", typeof(string), new SugarColumn() { IsNullable = true, Length = 255, ColumnDescription = "" })
                .CreateProperty("created_by", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "创建者" })
                .CreateProperty("created_at", typeof(DateTime), new SugarColumn() { ColumnDescription = "创建时间" })
                .CreateProperty("updated_by", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "更新者" })
                .CreateProperty("updated_at", typeof(DateTime), new SugarColumn() { IsNullable = true, ColumnDescription = "更新时间" });

            CreateTable("sys_role", "系统角色表")
                .CreateId()
                .CreateProperty("role_name", typeof(string), new SugarColumn() { Length = 255, ColumnDescription = "" })
                .CreateProperty("role_key", typeof(string), new SugarColumn() { Length = 255, ColumnDescription = "" })
                .CreateProperty("order_num", typeof(int), new SugarColumn() { ColumnDescription = "显示顺序" })
                .CreateProperty("role_status", typeof(int), new SugarColumn() { ColumnDescription = "角色状态（0正常 1停用）" })
                .CreateProperty("del_flag", typeof(bool), new SugarColumn() { IsNullable = true, ColumnDescription = "是否删除" })
                .CreateProperty("created_by", typeof(string), new SugarColumn() { Length = 50, ColumnDescription = "创建者" })
                .CreateProperty("created_at", typeof(DateTime), new SugarColumn() { ColumnDescription = "创建时间" })
                .CreateProperty("updated_by", typeof(string), new SugarColumn() { IsNullable = true, Length = 50, ColumnDescription = "更新者" })
                .CreateProperty("updated_at", typeof(DateTime), new SugarColumn() { IsNullable = true, ColumnDescription = "更新时间" });

            InsertData("sys_user")
                .Column("sys_user_id", "user_name", "nick_name", "email", "phone_number", "sex", "avatar", "password", "user_status", "data_status", "login_ip", "login_date", "sys_dept_id", "created_by", "created_at", "updated_by", "updated_at")
                .Values(797055167626885, "admin", "超级管理员", null, null, null, null, "$2a$10$7JB720yubVSZvUI0rEqK/.VqGOZTH.ulu33dHOiBE8ByOhJIrdAu2", 0, 0, null, null, null, "init", DateTime.Now, null, null);
        }

        protected override void Down()
        {
            DropTable("sys_user");
        }
    }
}
