using System.Threading.Tasks;

namespace InventorySystem.Contracts.Generics
{
    public interface IGenericActionDbUpdate<T> where T : class
    {
        Task<bool> UpdateAsync(T entity);
    }
}
