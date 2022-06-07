using System;
using System.Threading.Tasks;

namespace InventorySystem.Contracts.Generics
{
    public interface IGenericActionDbAdd<T> where T : class
    {
        Task<Tuple<T, bool>> AddAsync(T entity);
    }
}
