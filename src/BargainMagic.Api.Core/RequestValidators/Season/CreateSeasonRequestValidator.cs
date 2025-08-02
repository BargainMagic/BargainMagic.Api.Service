using BargainMagic.Api.Abstractions;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

namespace BargainMagic.Api.Core.RequestValidators.Season
{
    public class CreateSeasonRequestValidator : IApiRequestValidator<CreateSeasonRequest>
    {
        /// <inheritdoc/>
        public async Task<ApiRequestValidationResult> ValidateRequest(CreateSeasonRequest request,
                                                                      CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return ApiRequestValidationResult.FailureResult("Season name must be provided.");
            }

            return ApiRequestValidationResult.SuccessResult();
        }
    }
}
