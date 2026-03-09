namespace Proxxi.Plugin.Sdk.Exceptions;

/// <summary>
/// Base class for all exceptions thrown by proxy sources.
/// </summary>
public abstract class ProxySourceException : Exception
{
    protected ProxySourceException(string message) : base(message) { }
    protected ProxySourceException(string message, Exception innerException) : base(message, innerException) { }
}