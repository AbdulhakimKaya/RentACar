using Application.Features.Colors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Colors.Rules;

public class ColorBusinessRules: BaseBusinessRules
{
    private readonly IColorRepository _colorRepository;

    public ColorBusinessRules(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    
    public async Task ColorNameCannotBeDuplicatedWhenInserted(string name)
    {
        Color? result = await _colorRepository.GetAsync(predicate: c => c.Name.ToLower() == name.ToLower());

        if (result != null)
        {
            throw new BusinessException(ColorMessages.ColorNameExists);
        }
    }
}