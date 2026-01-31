using Proxxi.Plugin.Sdk.Models;

namespace Proxxi.Plugin.Sdk.ProxySources;

/// <summary>
/// A proxy source that provides proxies as a single batch (an enumerable returned from an async Task).
/// </summary>
/// <remarks>
/// Consumers must call <see cref="IProxySource.InitializeAsync"/> before <see cref="FetchAsync"/> is used.
/// </remarks>
public interface IBatchProxySource : IProxySource
{
    /// <summary>
    /// Fetches all available proxies from the source as a collection.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel
    /// the fetch operation.</param>
    /// <returns> A <see cref="Task"/> that, when completed, yields an <see cref="IEnumerable{Proxy}"/>
    /// containing the fetched proxies.</returns>
    public Task<IEnumerable<Proxy>> FetchAsync(CancellationToken cancellationToken = default);
}