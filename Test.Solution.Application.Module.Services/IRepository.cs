using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.Solution.Application.Module.Services
{
    public interface IRepository<T> where T:new() 
    {
        /// <summary>
        /// returns a list of all records
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> list();
        /// <summary>
        /// returns a list of all records by a lambda expression
        /// </summary>
        /// <param name="lanbdaExpresion"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> list(Func<T, bool> lanbdaExpresion);
        /// <summary>
        /// returns a list of all records by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> list(int id);
        /// <summary>
        /// Search for a record passing a id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> find(int id);
        /// <summary>
        /// Search for a record passing a lambda expression as a parameter
        /// </summary>
        /// <param name="lanbdaExpresion"></param>
        /// <returns></returns>
        Task<T> find(Func<T, bool> lanbdaExpresion);
        /// <summary>
        /// Insert an entity and return it with the id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> insert(T entity);
        /// <summary>
        /// Insert a list and return it with the id of each row
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<T> insert(IEnumerable<T> list);
        /// <summary>
        /// Modifies an entity and returns the same modified
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> edit(T entity);
        /// <summary>
        /// Modifies an entity passing a script as a parameter and returns the same modified
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<T> edit(string sql);
        /// <summary>
        /// Deletes a record passing an entity and an id as a parameter, returns a bool
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> delete(T entity, int id);
        /// <summary>
        /// Deletes a record passing an entity as a parameter, returns a bool
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> delete(T entity);
    }
}
