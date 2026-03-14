namespace Proxxi.Plugin.Sdk.Exceptions;

/// <summary>
/// Exception thrown when a parameter is invalid.
/// </summary>
public class ProxySourceParameterException : ProxySourceException
{
    /// <summary>
    /// Name of the missing or invalid parameter.
    /// </summary>
    public string ParameterName { get; }

    public ProxySourceParameterException(string parameterName, string message) : base(message)
    {
        ParameterName = parameterName;
    }

    public ProxySourceParameterException(string parameterName, string message, Exception innerException)
        : base(message, innerException)
    {
        ParameterName = parameterName;
    }
}