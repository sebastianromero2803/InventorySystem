using AutoMapper;
using Microsoft.Extensions.Logging;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.ErrorsHandler;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using InventorySystem.Entities.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace InventorySystem.Core.Core.V1
{
    public class MovementCore
    {
        private readonly IMovementRepository _context;
        private readonly ILogger<Movement> _logger;
        private readonly ErrorHandler<Movement> _errorHandler;
        private readonly IMapper _mapper;

        public MovementCore(ILogger<Movement> logger, IMapper mapper, IMovementRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Movement>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<Movement>> CreateMovementAsync(MovementCreateDto entity)
        {
            Movement newMovement = new();
            newMovement = _mapper.Map<Movement>(entity);

            try
            {
                var newMovementCreated = await _context.AddAsync(newMovement);
                return new ResponseService<Movement>(false, "Succefully created Movement", HttpStatusCode.Created, newMovementCreated.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateMovementAsync", new Movement());
            }
        }
    }
}
