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

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="objA"></param>
        /// <param name="objB"></param>
        /// <returns></returns>
        public static bool ObjectContentEquals(this object objA, object objB)
            => JsonSerializer.Serialize(objA) == JsonSerializer.Serialize(objB);


        /// <summary>
        /// find the date difference in ticks
        /// second parameter doesn't have to be filled in, if you don't it will compare with current date
        /// </summary>
        /// <param name="dateTimeA"></param>
        /// <param name="dateTimeB"></param>
        /// <returns>difference in ticks</returns>
        public static long DateDifference(DateTime dateTimeA, DateTime? dateTimeB = null) =>
            ((dateTimeA.Date - (dateTimeB ?? DateTime.Now.Date)).Ticks);
    }

}
