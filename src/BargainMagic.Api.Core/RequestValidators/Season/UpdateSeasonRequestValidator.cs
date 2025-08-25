using BargainMagic.Api.Abstractions;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

namespace BargainMagic.Api.Core.RequestValidators.Season
{
    public class UpdateSeasonRequestValidator : IApiRequestValidator<UpdateSeasonRequest>
    {
        /// <inheritdoc/>
        public async Task<ApiRequestValidationResult> ValidateRequest(UpdateSeasonRequest request,
                                                                      CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return ApiRequestValidationResult.FailureResult("Season name must be provided.");
            }

            return ApiRequestValidationResult.SuccessResult();
        }
    }
}
