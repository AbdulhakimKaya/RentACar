using Application.Features.Fuels.Constants;
using FluentValidation;

namespace Application.Features.Fuels.Commands.Create;

public class CreateFuelValidator : AbstractValidator<CreateFuelCommand>
{
    public CreateFuelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(FuelMessages.FuelNameNotEmpty);
        
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage(FuelMessages.FuelNameLengthMinCharacterMessage);
    }
}