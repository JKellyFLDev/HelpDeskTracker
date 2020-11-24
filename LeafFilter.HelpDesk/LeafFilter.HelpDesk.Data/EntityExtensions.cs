using Microsoft.EntityFrameworkCore;

namespace LeafFilter.HelpDesk.Data
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Removes all records from a specified DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
