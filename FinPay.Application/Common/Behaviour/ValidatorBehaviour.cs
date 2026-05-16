using ErrorOr;
using FluentValidation;
using MediatR;

namespace FinPay.Application.Common.Behaviour;

public class ValidatorBehaviour<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, ErrorOr<TResponse>>
    where TRequest : IRequest<ErrorOr<TResponse>>
    where TResponse : notnull
{
    public async Task<ErrorOr<TResponse>> Handle(TRequest request, RequestHandlerDelegate<ErrorOr<TResponse>> next, CancellationToken cancellationToken)
    {
        if(validator is null) return await next();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid) return await next();
        
        var errors = validationResult.Errors
            .ConvertAll( validationFailure => 
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage)
            );
        
        return errors;
    }
}
