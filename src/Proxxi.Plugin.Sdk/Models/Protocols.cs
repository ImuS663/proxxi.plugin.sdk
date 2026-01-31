namespace Proxxi.Plugin.Sdk.Models;

/// <summary>
/// Flags describing the network protocols proxy.
/// </summary>
[Flags]
public enum Protocols
{
    /// <summary>
    /// No protocol specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Supports plain HTTP.
    /// </summary>
    Http = 1 << 0,

    /// <summary>
    /// Supports HTTPS (HTTP over TLS).
    /// </summary>
    Https = 1 << 1,

    /// <summary>
    /// Supports SOCKS4 protocol.
    /// </summary>
    Socks4 = 1 << 2,

    /// <summary>
    /// Supports SOCKS5 protocol.
    /// </summary>
    Socks5 = 1 << 3
}