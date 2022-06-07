using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using System;
using System.Threading.Tasks;
using InventorySystem.Contracts.Repository;

namespace InventorySystem.Repositories.ImplementRepositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly SqlServerContext _context;

        public MovementRepository()
        {
            _context = new SqlServerContext();
        }
        public async Task<Tuple<Movement, bool>> AddAsync(Movement entity)
        {
            try
            {
                Article article = await _context.Article.FindAsync(entity.IdArticle);
                article.Stock += entity.Quantity * entity.MovementType;
                _context.Article.Update(article);

                var result = _context.Movement.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
