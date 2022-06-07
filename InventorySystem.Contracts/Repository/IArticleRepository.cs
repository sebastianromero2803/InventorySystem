using InventorySystem.Contracts.Generics;
using InventorySystem.Entities.Entities;

namespace InventorySystem.Contracts.Repository
{
    public interface IArticleRepository: IGenericActionDbAdd<Article>, IGenericActionDbQuery<Article>, IGenericActionDbUpdate<Article>
    {
    }
}
