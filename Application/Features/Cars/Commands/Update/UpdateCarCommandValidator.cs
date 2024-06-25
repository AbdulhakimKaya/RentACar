using FluentValidation;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandValidator  : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(x => x.Plate).NotEmpty().NotEmpty().NotNull().WithMessage(CarMessages.CarPlateNotNullAndEmpty);
    }
}