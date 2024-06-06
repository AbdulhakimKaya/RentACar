using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules // : BaseBusinessRules
{
    // private readonly ICarRepository _carRepository;
    //
    // public CarBusinessRules(ICarRepository carRepository)
    // {
    //     _carRepository = carRepository;
    // }
    //
    //
    // public async Task CarPlateMustBeUnique(string name, CancellationToken cancellationToken)
    // {
    //     var plate = await _carRepository.AnyAsync(predicate: x=> x.Plate.Equals(name), cancellationToken: cancellationToken);
    //     if (plate)
    //     {
    //         throw new BusinessException(CarMessages.CarPlateMustBeUniqueMessage);
    //     }
    // }
}