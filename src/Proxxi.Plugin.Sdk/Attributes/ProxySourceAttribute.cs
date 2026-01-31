namespace Proxxi.Plugin.Sdk.Attributes;

/// <summary>
/// Attribute used to annotate a proxy source implementation with identifying metadata.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ProxySourceAttribute : Attribute
{
    /// <summary>
    /// Unique identifier for the proxy source implementation.
    /// </summary>
    /// <remarks><b>Format</b>: &lt;publisher&gt;.&lt;plugin-name&gt;<br/>Lowercase, dot-separated.</remarks>
    /// <example>imus663.free-proxy-list</example>
    public string Id { get; private init; }

    /// <summary>
    /// Human-readable name for the proxy source implementation.
    /// </summary>
    /// <example>Free Proxy List</example>
    public string Name { get; private init; }

    /// <summary>
    /// Optional description of the proxy source. May contain details about usage, limits, or source details.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// When true, indicates the source implementation should be treated as NOT supporting batch-style fetches for
    /// UI/factory consumers.
    /// </summary>
    /// <remarks>This attribute value is metadata only and does not by itself change runtime behavior.</remarks>
    public bool HideBatch { get; init; } = false;

    /// <summary>
    /// When true, indicates the source implementation should be treated as NOT supporting stream-style fetches
    /// for UI/factory consumers.
    /// </summary>
    /// <remarks>This attribute value is metadata only and does not by itself change runtime behavior.</remarks>
    public bool HideStream { get; init; } = false;

    /// <summary>
    /// Creates a new instance of the <see cref="ProxySourceAttribute"/> class.
    /// </summary>
    /// <param name="id">Unique identifier for the proxy source implementation.</param>
    /// <param name="name">Human-readable name for the proxy source implementation.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> or <paramref name="name"/> is null or whitespace.</exception>
    public ProxySourceAttribute(string id, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Id = id;
        Name = name;
    }
}