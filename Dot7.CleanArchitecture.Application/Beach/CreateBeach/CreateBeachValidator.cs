using FluentValidation;

namespace Dot7.CleanArchitecture.Application.Beach.CreateBeach;
public class CreateBeachValidator : AbstractValidator<CreateBeachRequest>
{
    public CreateBeachValidator()
    {
        RuleFor(x => x.BeachName).NotEmpty();
        
    }

}