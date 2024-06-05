using Application.Features.Cars.Constants;
using Application.Features.Fuels.Commands.Create;
using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Plate).NotEmpty().NotEmpty().NotNull().WithMessage(CarMessages.CarPlateNotNullAndEmpty);
    }
}