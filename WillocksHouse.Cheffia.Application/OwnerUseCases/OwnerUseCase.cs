using Microsoft.Extensions.Logging;
using WillocksHouse.Cheffia.Application.Library;
using WillocksHouse.Cheffia.Application.OwnerUseCases.OwnerDtos;
using WillocksHouse.Cheffia.Domain.Entities;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

namespace WillocksHouse.Cheffia.Application.OwnerUseCases;

public class OwnerUseCase : IOwnerUseCase
{
    private readonly ILogger<OwnerUseCase> _logger;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IOutput _output;

    public OwnerUseCase(IOwnerRepository ownerRepository, ILogger<OwnerUseCase> logger, IOutput output)
    {
        _ownerRepository = ownerRepository;
        _logger = logger;
        _output = output;
    }

    public async Task<IOutput> CreateOwner(OwnerInputDto ownerInput)
    {
        try
        {
            Owner ownerEntity = new(ownerInput.Name, ownerInput.Email, ownerInput.Password, ownerInput.Document);

            var checkOwner = await CheckIfOwnerIsValid(ownerInput);

            if (!checkOwner)
            {
                _logger.LogError(
                    "OwnerUseCase::CreateOwner - An Error occurred while creating the owner - error: Owner already exists");
                _output.AddErrorMessage("Owner already exists");
                return _output;
            }

            await _ownerRepository.AddOwner(ownerEntity);

            var getOwner = await _ownerRepository.GetOwner(ownerEntity.Id);

            if (getOwner == null)
            {
                _logger.LogError("OwnerUseCase::CreateOwner - An Error occurred while creating the owner");
                _output.AddErrorMessage("An Error occurred while creating the owner");
                return _output;
            }

            OnwerOutputDto ownerOutput = new(getOwner.Name, getOwner.Email, getOwner.Document);

            _output.AddResult(ownerOutput);
            return _output;
        }
        catch (Exception e)
        {
            _logger.LogError($"OwnerUseCase::CreateOwner - An Error occurred while creating the owner - error: {e}",
                e.Message);
            _output.AddErrorMessage(
                $"OwnerUseCase::CreateOwner - An Error occurred while creating the owner - error: {e.Message}");
            return _output;
        }
    }

    private async Task<bool> CheckIfOwnerIsValid(OwnerInputDto ownerInput)
    {
        try
        {
            var getOwner = await _ownerRepository.GetOwnerByEmail(ownerInput.Email) == null;

            return getOwner;
        }
        catch (Exception e)
        {
            _logger.LogError($"OwnerUseCase::CheckIfOwnerIsValid - An Error occurred while creating the owner - error: {e}",
                e.Message);
            
            return false;
        }
    }
}