using AutoMapper;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.V1;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InventorySystem.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly MovementCore _movementCore;

        public MovementController(ILogger<Movement> logger, IMapper mapper, IMovementRepository context)
        {
            _movementCore = new MovementCore(logger, mapper, context);
        }

        [HttpPost]
        public async Task<ActionResult<Movement>> InventoryEntry([FromBody] MovementCreateDto movement)
        {
            var response = await _movementCore.CreateMovementAsync(movement);
            return StatusCode((int)response.StatusHttp, response);
        }

    }
}
