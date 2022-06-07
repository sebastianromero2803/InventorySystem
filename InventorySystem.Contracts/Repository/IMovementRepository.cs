using InventorySystem.Contracts.Generics;
using InventorySystem.Entities.Entities;

namespace InventorySystem.Contracts.Repository
{
    public interface IMovementRepository: IGenericActionDbAdd<Movement>
    {
    }
}
