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

    }

}
