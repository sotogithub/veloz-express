using Express.Application.Common.Models;
using FluentValidation;
using MediatR;

namespace Express.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);
        var failures = validators
            .Select(v => v.Validate(context))
            .SelectMany(r => r.Errors)
            .Where(e => e is not null)
            .ToList();

        if (failures.Count == 0) return await next();

        var errors = string.Join(" | ", failures.Select(f => f.ErrorMessage));

        var responseType = typeof(TResponse);

        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var innerType = responseType.GetGenericArguments()[0];
            var method = typeof(Result<>)
                .MakeGenericType(innerType)
                .GetMethod(nameof(Result<object>.Failure), [typeof(string), typeof(int)])!;
            return (TResponse)method.Invoke(null, [errors, 422])!;
        }

        if (responseType == typeof(Result))
        {
            return (TResponse)(object)Result.Failure(errors, 422);
        }

        throw new ValidationException(failures);
    }
}
