namespace Proxxi.Plugin.Sdk.Models;

/// <summary>
/// Represents a network proxy endpoint and optional authentication information.
/// </summary>
/// <param name="Host">Hostname or IP address of the proxy server.</param>
/// <param name="Port">Port number of the proxy server.</param>
/// <param name="Username">Optional username for authenticated proxies.</param>
/// <param name="Password">Optional password for authenticated proxies.</param>
/// <param name="Protocols">Protocols supported by the proxy, as a <see cref="Protocols"/> flag value.</param>
public record Proxy(
    string Host,
    int Port,
    string? Username = null,
    string? Password = null,
    Protocols Protocols = Protocols.None
);