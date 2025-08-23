namespace BargainMagic.Api.Abstractions;

/// <summary>
/// Interface for API request specific vaidator classes.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IApiRequestValidator<T>
{
    /// <summary>
    /// Validates the given API request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// An <see cref="ApiRequestValidationResult"/> specifying if the request passes validation and reasoning if it 
    /// fails.
    /// </returns>
    Task<ApiRequestValidationResult> ValidateRequest(T request,
                                                     CancellationToken cancellationToken = default);
}
