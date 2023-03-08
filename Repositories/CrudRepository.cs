using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static IMDb.Repositories.PropertyRepository;
using static IMDb.Repositories.GeneralRepository;
using static IMDb.Repositories.LinqRepository;
using IMDb.Database;

namespace IMDb.Repositories
{
    public class CrudRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;


        /// <summary>
        /// constructor of <see cref="CrudRepository"/>
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public CrudRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// finds all database key types in given generic class type
        /// </summary>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>all keys</returns>
        private static List<IKey>? FindKeys<T>(DbContext context) =>
            context.Model.FindEntityType(typeof(T))?.GetKeys().ToList();

        /// <summary>
        /// Sets all primary keys to their default value
        /// whether it be a <see cref="Guid"/>, <see cref="string"/>, etc
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        private void SetPrimaryKeysToDefault<T>(object? obj, DbContext context) where T : class, new()
        {
            //foreach key in generic class type
            FindKeys<T>(context)?.ForEach(x =>
            {
                //foreach key property
                x.Properties.ToList().ForEach(property =>
                {
                    //find property type
                    var type = property.ClrType;

                    //find generic value
                    FindGenericValue(type, out var defaultValue);

                    //if property isn't a primary key return
                    if (!property.IsPrimaryKey()) return;

                    //if property is a generic value 
                    if (property == defaultValue || defaultValue == null) return;
                    //set key to generic value
                    SetValueByName(obj, property.Name, defaultValue);
                });
            });
        }

        /// <summary>
        /// removes rows from database
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public async Task RemoveRows<T>(List<T>? obj) where T : new() =>
            await Template(context => obj?.ForEach(x =>
            {
                if (x != null) context.Remove(x);
            }));

        /// <summary>
        /// removes row from database
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public async Task RemoveRow<T>(T obj) where T : new() =>
            await Template(context =>
            {
                if (obj != null) context.Remove(obj);
            });

        /// <summary>
        /// updates rows from database
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public async Task UpdateRows<T>(List<T>? obj) where T : class, new() =>
            await Template(context => obj?.ForEach(x => context.Update(x)));

        /// <summary>
        /// updates a row from database
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public async Task UpdateRow<T>(T? obj) =>
            await Template(context =>
            {
                if (obj != null) context.Update(obj);
            });


        /// <summary>
        /// adds rows to database
        /// if you don't want to set primary keys to generic value you can set <see cref="bool"/> to false
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="setKeys"></param>
        /// <typeparam name="T"></typeparam>
        public async Task AddRows<T>(List<T> obj, bool setKeys = true) where T : class, new() =>
            await Template(context =>
                obj.ForEach(x =>
                {
                //check if keys have to be set
                    if (setKeys) SetPrimaryKeysToDefault<T>(x, context);
                //add to database
                    context.Add(x);
                }));

        /// <summary>
        /// adds row to the database
        /// if you don't want to set primary keys to generic value you can set <see cref="bool"/> to false
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="setKeys"></param>
        /// <typeparam name="T"></typeparam>
        public async Task AddRow<T>(T obj, bool setKeys = true) where T : class, new() =>
            await Template(context =>
            {
            //check if keys have to be set
                if (setKeys) SetPrimaryKeysToDefault<T>(obj, context);
            //add row to database
                context.Add(obj);
            });

        /// <summary>
        /// Template for using the database
        /// </summary>
        /// <param name="action"></param>
        private async Task Template(Action<DbContext>? action = default)
        {
            //using serviceScopeFactory to create a scope of AuthDbContext
            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            {
                //AuthDbContext
                var context = scope.ServiceProvider.GetService<AuthDbContext>();

                //check if AuthDbContext isn't null
                if (context == null) return;

                //invoke action
                action?.Invoke(context);

                //save database changes
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// reads all rows from the database
        /// from generic class type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>list of rows</returns>
        public async Task<List<T>> ReadAllRows<T>() where T : class
        {
            //create new generic list
            var result = new List<T>();

            //read all rows from database
            await Template(context => { context.Set<T>().ToList().ForEach(x => result.Add(x)); });

            //return
            return result;
        }

        /// <summary>
        /// finds rows with supplied value
        /// </summary>
        /// <param name="match"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>list of object class that have the supplied value in them</returns>
        public async Task<List<T>> FindRowsWithValue<T>(Predicate<T> match) where T : class, new()
        {
            //create new generic list
            var result = new List<T>();

            //use template
            await Template(context =>
            {
                //fill result with all of the found values
                result = context.Set<T>().ToList().Where(x => match(x)).ToListOrDefault();
            });

            //return
            return result;
        }

        /// <summary>
        /// finds row with supplied value
        /// </summary>
        /// <param name="match"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>list of object class that have the supplied value in them</returns>
        public async Task<T> FindRowWithValue<T>(Predicate<T> match) where T : class, new()
        {
            //create new generic list
            var result = new T();

            //use template
            await Template(context =>
            {
                //finds the first result, or sets result to null
                result = context.Set<T>().ToList().FirstOrDefault(x => match(x));
            });

            //return result
            return result;
        }

        /// <summary>
        /// finds closest date out of all generic class type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>generic class type</returns>
        public T? FindClosestToDate<T>() where T : class => ReadAllRows<T>().Result.GetClosestDate();
    }

}
