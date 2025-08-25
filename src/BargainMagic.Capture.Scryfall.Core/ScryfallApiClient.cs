using BargainMagic.Capture.Scryfall.Abstractions;
using BargainMagic.Capture.Scryfall.Abstractions.Models;

using System.Net.Http.Json;

namespace BargainMagic.Capture.Scryfall.Core;

public class ScryfallApiClient : IScryfallApiClient
{
    private const string AcceptHeaderValue = "application/json";
    private const string GetBulkDataMetadataUri = "https://api.scryfall.com/bulk-data/default-cards";
    private const int RateLimitInMilliseconds = 100;
    private const string UserAgentHeaderValue = "BargainMagic";

    private readonly IHttpClientFactory httpClientFactory;
    private readonly TimeSpan rateLimitTimeSpan = TimeSpan.FromMilliseconds(RateLimitInMilliseconds);

    private DateTime? lastRequestSentDateTime = null;

    public ScryfallApiClient(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    // TODO: The error handling should improve here.
    /// <inheritdoc/>
    public async Task<BulkDataMetadata?> GetBulkDataMetadata(CancellationToken cancellationToken = default)
    {
        try
        {
            await WaitForTimeRateLimitReached(cancellationToken);

            lastRequestSentDateTime = DateTime.UtcNow;

            using (var httpClient = httpClientFactory.CreateClient())
            {
                SetRequiredHeaders(httpClient);

                return await httpClient.GetFromJsonAsync<BulkDataMetadata>(GetBulkDataMetadataUri,
                                                                           cancellationToken);
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HttpRequestException thrown calling GetBulkData. Error: {ex}");
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"Exception thrown calling GetBulkData. Error: {ex}");
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task<Stream?> GetBulkDataStream(string bulkCardDataUri,
                                                 CancellationToken cancellationToken = default)
    {
        try
        {
            await WaitForTimeRateLimitReached(cancellationToken);

            lastRequestSentDateTime = DateTime.UtcNow;

            using (var httpClient = httpClientFactory.CreateClient())
            {
                SetRequiredHeaders(httpClient);

                return await httpClient.GetStreamAsync(bulkCardDataUri,
                                                       cancellationToken);
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HttpRequestException thrown calling GetBulkData. Error: {ex}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception thrown calling GetBulkData. Error: {ex}");
        }

        return null;
    }

    /// <summary>
    /// Sets required headers for requests to the Scryfall API to be sent by the given <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient"></param>
    private void  SetRequiredHeaders(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Accept.ParseAdd(AcceptHeaderValue);
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgentHeaderValue);
    }

    /// <summary>
    /// Waits the remaining time span between the last sent request to the Scryfall API and the <see cref="rateLimitTimeSpan"/>. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    private async Task WaitForTimeRateLimitReached(CancellationToken cancellationToken = default)
    {
        if (lastRequestSentDateTime is null)
        {
            return;
        }

        var timeSinceLastRequest = DateTime.UtcNow - lastRequestSentDateTime.Value;

        if (timeSinceLastRequest >= rateLimitTimeSpan)
        {
            return;
        }

        var timeUntilRateLimitReached = rateLimitTimeSpan - timeSinceLastRequest;

        await Task.Delay(timeUntilRateLimitReached,
                         cancellationToken);
    }
}
