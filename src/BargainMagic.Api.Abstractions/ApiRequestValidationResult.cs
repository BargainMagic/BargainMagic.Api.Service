namespace BargainMagic.Api.Abstractions;

public record ApiRequestValidationResult
{
    /// <summary>
    /// Indicates if the request was successfully validated.
    /// </summary>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// The failure reason description if <see cref="IsSuccessful"/> indicates the request failed validation.
    /// </summary>
    public string? FailureReason { get; set; }

    public static ApiRequestValidationResult FailureResult(string failureReason)
    {
        return new ApiRequestValidationResult
        {
            IsSuccessful = false,
            FailureReason = failureReason
        };
    }

    public static ApiRequestValidationResult SuccessResult()
    {
        return new ApiRequestValidationResult
               {
                   IsSuccessful = true
               };
    }
}
