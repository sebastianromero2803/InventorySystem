using Microsoft.EntityFrameworkCore;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InventorySystem.Contracts.Repository;

namespace InventorySystem.Repositories.ImplementRepositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly SqlServerContext _context;

        public ArticleRepository()
        {
            _context = new SqlServerContext();
        }
        public async Task<Tuple<Article, bool>> AddAsync(Article entity)
        {

            try
            {
                var result = _context.Article.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Article>> GetAllAsync()
        {
            try
            {
                var result = await _context.Article.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Article>> GetByFilterAsync(Expression<Func<Article, bool>> expressionFilter)
        {
            try
            {
                return await _context.Article.Where(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.Article.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Article entity)
        {
            try
            {
                var result = _context.Article.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStockAsync(Movement entity)
        {
            try
            {
                Article article = await _context.Article.FindAsync(entity.IdArticle);
                article.Stock += entity.Quantity * entity.MovementType;
                _context.Article.Update(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
