using AutoMapper;
using Microsoft.Extensions.Logging;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.ErrorsHandler;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using InventorySystem.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace InventorySystem.Core.Core.V1
{
    public class ArticleCore
    {
        private readonly IArticleRepository _context;
        private readonly ILogger<Article> _logger;
        private readonly ErrorHandler<Article> _errorHandler;
        private readonly IMapper _mapper;

        public ArticleCore(ILogger<Article> logger, IMapper mapper, IArticleRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Article>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Article>>> GetArticlesAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Article>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetArticlesAsync", new List<Article>());
            }
        }

        public async Task<ResponseService<int>> GetArticleBalanceAsync(int id)
        {
            try
            {
                var article = await _context.GetByIdAsync(id);
                return new ResponseService<int>(false, article.Stock == 1 ? $"There is {article.Stock} unit in stock of the article" : $"There are {article.Stock} units in stock of the article", HttpStatusCode.OK, article.Stock);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetArticlesAsync", 0);
            }
        }

        public async Task<ResponseService<Dictionary<int, int>>> GetArticlesBalanceAsync()
        {
            try
            {
                var articles = await _context.GetAllAsync();
                var articlesId = articles.Select((art) => art.IdArticle).ToList();
                var articlesStock = articles.Select((art) => art.Stock).ToList();
                var dict = JsonConvert.SerializeObject( Enumerable.Range(0, articlesId.Count).ToDictionary(i => articlesId[i], i => articlesStock[i]) );
                return new ResponseService<Dictionary<int, int>>(false, $"The balance of all the articles is: {dict}", HttpStatusCode.OK, dict);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetArticlesAsync", new Dictionary<int, int>());
            }
        }

        public async Task<ResponseService<Article>> CreateArticleAsync(ArticleCreateDto entity)
        {
            Article newArticle = new();
            newArticle = _mapper.Map<Article>(entity);

            try
            {
                var newArticleCreated = await _context.AddAsync(newArticle);
                return new ResponseService<Article>(false, "Succefully created Article", HttpStatusCode.Created, newArticleCreated.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateArticleAsync", new Article());
            }
        }

        public async Task<ResponseService<bool>> UpdateArticleAsync(Article articleToUpdate)
        {
            try
            {
                var result = await _context.UpdateAsync(articleToUpdate);
                return new ResponseService<bool>(false, result == true?"Record Updated!!":"Record Not Updated", HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateArticleAsync", false);
            }
        }
    }
}
