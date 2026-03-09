namespace Proxxi.Plugin.Sdk.Exceptions;

/// <summary>
/// Exception thrown when an error occurs during proxy source fetch.
/// </summary>
public sealed class ProxySourceFetchException : ProxySourceException
{
    public ProxySourceFetchException(string message) : base(message) { }
    public ProxySourceFetchException(string message, Exception innerException) : base(message, innerException) { }
}