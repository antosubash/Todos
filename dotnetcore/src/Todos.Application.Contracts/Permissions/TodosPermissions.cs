namespace Todos.Permissions
{
    public static class TodosPermissions
    {
        public const string GroupName = "Todos";
        public static class Todo
        {
            public const string Default = GroupName + ".Todo";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}