using Proxxi.Plugin.Sdk.Models;

namespace Proxxi.Plugin.Sdk.ProxySources;

/// <summary>
/// A proxy source that streams proxies asynchronously as they are produced or discovered.
/// </summary>
/// <remarks>
/// Consumers must call <see cref="IProxySource.InitializeAsync"/> before <see cref="FetchAsync"/> is used.
/// </remarks>
public interface IStreamProxySource : IProxySource
{
    /// <summary>
    /// Fetches proxies from the source as an asynchronous stream.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel
    /// the streaming operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{Proxy}"/> that yields proxies as they become available.</returns>
    public IAsyncEnumerable<Proxy> FetchAsync(CancellationToken cancellationToken = default);
}