namespace BargainMagic.Api.Abstractions;

public interface IApiRequestValidator<T>
{
    Task<ApiRequestValidationResult> ValidateRequest(T request,
                                                     CancellationToken cancellationToken);
}
