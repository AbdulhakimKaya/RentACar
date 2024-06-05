using Application.Features.Fuels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Fuels.Rules;

public class FuelBusinessRules : BaseBusinessRules
{

    private readonly IFuelRepository _fuelRepository;

    public FuelBusinessRules(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }


    public async Task FuelMustBeUnique(string Name)
    {

        var fuel = await _fuelRepository.Query().AnyAsync(x => x.Name.Equals(Name));

        if (fuel)
        {
            throw new BusinessException(FuelMessages.FuelMustBeUnique);
        }
    }
}