namespace Proxxi.Plugin.Sdk.ProxySources;

public interface IProxySource : IAsyncDisposable
{
    /// <summary>
    /// Initializes the proxy source with configuration parameters.
    /// </summary>
    /// <param name="parameters">A read-only dictionary of configuration parameters.
    /// Implementations should document supported keys and expected formats for values.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to
    /// cancel the initialization operation.</param>
    /// <returns>A <see cref="Task"/> that completes when initialization is finished.</returns>
    public Task InitializeAsync(IReadOnlyDictionary<string, string> parameters,
        CancellationToken cancellationToken = default);
}