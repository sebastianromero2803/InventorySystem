using AutoMapper;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.V1;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventorySystem.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleCore _articleCore;

        public ArticleController(ILogger<Article> logger, IMapper mapper, IArticleRepository context)
        {
            _articleCore = new ArticleCore(logger, mapper, context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> Get()
        {
            var response = await _articleCore.GetArticlesAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpGet("stock")]
        public async Task<ActionResult<string>> GetStockBalances()
        {
            var response = await _articleCore.GetArticlesBalanceAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpGet("stock/{id}")]
        public async Task<ActionResult<Article>> GetStockBalanceById(int id)
        {
            var response = await _articleCore.GetArticleBalanceAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post([FromBody] ArticleCreateDto movement)
        {
            var response = await _articleCore.CreateArticleAsync(movement);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] Article article)
        {
            var response = await _articleCore.UpdateArticleAsync(article);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
