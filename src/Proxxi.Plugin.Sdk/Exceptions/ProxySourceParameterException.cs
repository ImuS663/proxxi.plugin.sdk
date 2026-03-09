namespace Proxxi.Plugin.Sdk.Exceptions;

/// <summary>
/// Exception thrown when a required parameter is missing or invalid.
/// </summary>
public sealed class ProxySourceParameterException : ProxySourceException
{
    /// <summary>
    /// Name of the missing or invalid parameter.
    /// </summary>
    public string ParameterName { get; }

    public ProxySourceParameterException(string parameterName) : base($"Parameter '{parameterName}' is required.")
    {
        ParameterName = parameterName;
    }

    public ProxySourceParameterException(string parameterName, string message) : base(message)
    {
        ParameterName = parameterName;
    }

    public ProxySourceParameterException(string parameterName, string message, Exception innerException) : base(message,
        innerException)
    {
        ParameterName = parameterName;
    }
}