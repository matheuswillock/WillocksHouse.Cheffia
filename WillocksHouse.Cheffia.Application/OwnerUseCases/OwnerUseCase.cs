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

    public OwnerUseCase(IOwnerRepository ownerRepository, ILogger<OwnerUseCase> logger)
    {
        _ownerRepository = ownerRepository;
        _logger = logger;
    }

    public async Task<Output> CreateOwner(OwnerInputDto ownerInput)
    {
        Output output = new();
        try
        {
            Owner ownerEntity = new(ownerInput.Name, ownerInput.Email, ownerInput.Password, ownerInput.Document);

            //var checkOwner = await CheckIfOwnerIsValid(ownerInput);

            //if (!checkOwner)
            //{
            //    _logger.LogError(
            //        "OwnerUseCase::CreateOwner - An Error occurred while creating the owner - error: Owner already exists");
            //    output.AddErrorMessage("Owner already exists");
            //    return output;
            //}

            await _ownerRepository.AddOwner(ownerEntity);

            var getOwner = await _ownerRepository.GetOwner(ownerEntity.Id);

            if (getOwner == null)
            {
                _logger.LogError("OwnerUseCase::CreateOwner - An Error occurred while creating the owner");
                output.AddErrorMessage("An Error occurred while creating the owner");
                return output;
            }

            OnwerOutputDto ownerOutput = new(getOwner.Name, getOwner.Email, getOwner.Document);

            output.AddResult(ownerOutput);
            return output;
        }
        catch (Exception e)
        {
            _logger.LogError($"OwnerUseCase::CreateOwner - An Error occurred while creating the owner - error: {e}",
                e.Message);
            output.AddErrorMessage(
                $"OwnerUseCase::CreateOwner - An Error occurred while creating the owner - error: {e.Message}");
            return output;
        }
    }

    //private async Task<bool> CheckIfOwnerIsValid(OwnerInputDto ownerInput)
    //{
    //    try
    //    {
    //        var getOwner = await _ownerRepository.GetOwnerByEmail(ownerInput.Email);

    //        if (getOwner != null) return false;

    //        return true;
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e);
    //        throw;
    //    }
    //}
}