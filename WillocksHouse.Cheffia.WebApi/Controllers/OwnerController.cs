using Microsoft.AspNetCore.Mvc;
using WillocksHouse.Cheffia.Application.OwnerUseCases;
using WillocksHouse.Cheffia.Application.OwnerUseCases.OwnerDtos;

namespace WillocksHouse.Cheffia.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase
{
    private readonly ILogger<OwnerController> _logger;
    private readonly IOwnerUseCase _ownerUseCase;

    public OwnerController(ILogger<OwnerController> logger, IOwnerUseCase ownerUseCase)
    {
        _logger = logger;
        _ownerUseCase = ownerUseCase;
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateOwner([FromBody] OwnerInputDto ownerInput)
    {
        try
        {
            var input = await _ownerUseCase.CreateOwner(ownerInput);

            if (!input.IsValid)
            {
                var getErrorMessages = input.ErrorMessages;
                return BadRequest(getErrorMessages);
            }

            var getResults = input.GetResult();
            return Ok(getResults);
        }
        catch (Exception error)
        {
            _logger.LogError(
                $"OwnerController::CreateOwner - An Error occurred while creating the owner - error: {error}",
                error.Message);
            return StatusCode(500, "An Error occurred while creating the owner");
        }
    }
}