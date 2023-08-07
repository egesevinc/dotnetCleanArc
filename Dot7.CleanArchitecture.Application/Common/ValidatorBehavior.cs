using FluentValidation;
using MediatR;

namespace Dot7.CleanArchitecture.Application.Common;
public class ValidatorBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
where TRequest : IRequest<Tresponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await
             Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

             var failures = validationResults.SelectMany(_ =>_.Errors).Where(_ => _ != null).ToList();

             if(failures.Count != 0){
                throw new FluentValidation.ValidationException(failures);
             }
            

        }
         return await next();

         
    }
}