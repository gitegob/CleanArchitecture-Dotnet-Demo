using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Validation;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validator is null) return await next();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid) return await next();
        var validationErrors =
            string.Join(" ", validationResult.Errors.ConvertAll(e => $"[{e.ErrorMessage}]"));
        // Only using this because I am sure that the validation errors are wrapped in ErrorOr because I did that in this previous line
        return (dynamic)Error.Validation("Validation failed", validationErrors);
    }
}