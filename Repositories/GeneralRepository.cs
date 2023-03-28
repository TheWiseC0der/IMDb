using System.Text.Json;
namespace IMDb.Repositories
{
    public static class GeneralRepository
    {

        /// <summary>
        /// find the default value of given object
        /// </summary>
        /// <param name="type"></param>
        /// <param name="defaultValue"></param>
        public static void FindGenericValue(Type type, out object? defaultValue) =>
            defaultValue = type == typeof(string) ? string.Empty : Activator.CreateInstance(type, null);
    }

}
