using FluentValidation;

namespace Dot7.CleanArchitecture.Application.Beach.UpdateBeach;
public class UpdateBeachValidator : AbstractValidator<UpdateBeachRequest>
{
    public UpdateBeachValidator()
    {
        RuleFor(x => x.BeachName).NotEmpty();
    }
}