using static IMDb.Repositories.PropertyRepository;
using static IMDb.Repositories.GeneralRepository;

namespace IMDb.Repositories
{
    public static class LinqRepository
    {

        /// <summary>
        /// converts the <see cref="IEnumerable{T}"/> to a list or null
        /// </summary>
        /// <param name="seq"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>nullable list</returns>
        public static List<T>? ToListOrNull<T>(this IEnumerable<T>? seq) =>
            seq == null ? null : seq.ToList().Any() ? seq.ToList() : null;

        /// <summary>
        /// converts the <see cref="IEnumerable{T}"/> to a list or default if the <see cref="IEnumerable{T}"/> is null
        /// </summary>
        /// <param name="seq"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ToListOrDefault<T>(this IEnumerable<T>? seq) =>
            seq == null ? new List<T>() : seq.ToList();


        /// <summary>
        /// finds closest date from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <param name="seq"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>generic class type</returns>
        public static T? GetClosestDate<T>(this IEnumerable<T> seq) =>
            seq.MinBy(obj =>
            {
            //find all datetime objects in T
                var date = GetPropertyValueByType(obj, typeof(DateTime));

            //if date is null make a new datetime
                var dateTime = (DateTime)(date ?? new DateTime(2000, 0, 0));

            //return the difference
                return DateDifference(dateTime);
            });

        /// <summary>
        /// orders the <see cref="IEnumerable{T}"/> by date and converts it to a list
        /// </summary>
        /// <param name="seq"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> OrderByDateList<T>(this IEnumerable<T>? seq) =>
            (seq ?? Array.Empty<T>()).OrderBy(obj => GetPropertyValueByType(obj, typeof(DateTime)))
            .ToList();
    }

}
