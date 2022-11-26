using System.Linq.Expressions;

namespace ApiRetailXYZ.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Delete(Guid id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Update(T entity);
        Task Insert(T entity);

        /// <summary>
        /// Get all without filter
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(Guid id);
    }
}
