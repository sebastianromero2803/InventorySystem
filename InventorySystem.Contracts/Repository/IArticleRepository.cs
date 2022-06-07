using InventorySystem.Contracts.Generics;
using InventorySystem.Entities.Entities;
using System.Threading.Tasks;

namespace InventorySystem.Contracts.Repository
{
    public interface IArticleRepository: IGenericActionDbAdd<Article>, IGenericActionDbQuery<Article>, IGenericActionDbUpdate<Article>
    {
        Task<bool> UpdateStockAsync(Movement entity);
    }
}
