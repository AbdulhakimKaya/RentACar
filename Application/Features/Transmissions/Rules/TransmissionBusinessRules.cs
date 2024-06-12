using Application.Features.Transmissions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Transmissions.Rules;

public class TransmissionBusinessRules : BaseBusinessRules
{
    private readonly ITransmissionRepository _transmissionRepository;

    public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
    {
        _transmissionRepository = transmissionRepository;
    }

    public async Task TransmissionNameCannotBeDuplicatedWhenInserted(string name)
    {
        Transmission? result =
            await _transmissionRepository.GetAsync(predicate: t => t.Name.ToLower() == name.ToLower());

        if (result != null)
        {
            throw new BusinessException(TransmissionMessages.TransmissionNameExists);
        }
        {
            
        }
    }
}