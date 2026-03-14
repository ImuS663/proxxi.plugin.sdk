namespace Proxxi.Plugin.Sdk.Exceptions;

/// <summary>
/// Exception thrown when a required parameter is missing.
/// </summary>
public sealed class ProxySourceParameterRequiredException : ProxySourceParameterException
{
    public ProxySourceParameterRequiredException(string parameterName)
        : base(parameterName, $"Parameter '{parameterName}' is required.") { }

    public ProxySourceParameterRequiredException(string parameterName, Exception innerException)
        : base(parameterName, $"Parameter '{parameterName}' is required.", innerException) { }
}