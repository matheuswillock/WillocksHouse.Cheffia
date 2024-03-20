using WillocksHouse.Cheffia.Application.Library;
using WillocksHouse.Cheffia.Application.OwnerUseCases.OwnerDtos;

namespace WillocksHouse.Cheffia.Application.OwnerUseCases;

public interface IOwnerUseCase
{
    Task<Output> CreateOwner(OwnerInputDto ownerInput);
}