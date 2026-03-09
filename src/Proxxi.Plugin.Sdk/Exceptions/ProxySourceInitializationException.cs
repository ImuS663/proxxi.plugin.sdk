namespace Proxxi.Plugin.Sdk.Exceptions;

/// <summary>
/// Exception thrown when an error occurs during proxy source initialization.
/// </summary>
public sealed class ProxySourceInitializationException : ProxySourceException
{
    public ProxySourceInitializationException(string message) : base(message) { }

    public ProxySourceInitializationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}