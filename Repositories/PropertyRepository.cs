namespace IMDb.Repositories
{
    using System.Reflection;
    public static class PropertyRepository
    { //TODO probably need fix some method names, currently it's pretty terrible
        public static List<PropertyInfo> GetPropertyTypes<T>(Type? type) =>
            typeof(T).GetProperties().ToList().Where(x => x.PropertyType == type).ToList();

        public static PropertyInfo? GetPropertyByType(object? obj, Type? type) =>
            obj?.GetType().GetProperties().ToList().Find(x => x.PropertyType == type);

        public static object? GetPropertyValueByType(object? obj, Type? type) =>
            GetPropertyValueByName(obj, GetPropertyByType(obj, type)?.Name);


        public static object? GetPropertyValueByName(object? obj, string? propertyName, BindingFlags bindingFlags) =>
            obj?.GetType().GetProperty(propertyName ?? string.Empty, bindingFlags)
                ?.GetValue(obj, null);

        public static object? GetPropertyValueByName(object? obj, string? propertyName) =>
            obj?.GetType().GetProperty(propertyName ?? string.Empty)
                ?.GetValue(obj, null);


        public static void SetValueByName(object? obj, string? propertyName, object? value, BindingFlags bindFlags) =>
            obj?.GetType().GetProperty(propertyName ?? string.Empty, bindFlags)
                ?.SetValue(obj, value, null);

        public static void SetValueByName(object? obj, string? propertyName, object? value) =>
            obj?.GetType().GetProperty(propertyName ?? string.Empty)
                ?.SetValue(obj, value, null);


        public static void SetValueByTypes<T>(T? obj, Type? type, object? value) =>
            GetPropertyTypes<T>(type).ForEach(info =>
                obj?.GetType().GetProperty(info.Name)?.SetValue(obj, value, null));

        public static List<object?> GetPropertyValuesByName(List<object> objs, List<string?> propertyNames)
        {
            var result = new List<object?>();
            objs.ForEach(obj => { propertyNames.ForEach(name => result.Add(GetPropertyValueByName(obj, name))); });
            return result;
        }
    }

}
