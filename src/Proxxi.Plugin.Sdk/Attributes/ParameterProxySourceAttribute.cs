namespace Proxxi.Plugin.Sdk.Attributes;

/// <summary>
/// Attribute used to annotate a parameter of a proxy source implementation.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ParameterProxySourceAttribute : Attribute
{
    /// <summary>
    /// Parameter name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Parameter description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Indicates whether the parameter is required.
    /// </summary>
    public bool Required { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="ParameterProxySourceAttribute"/> class.
    /// </summary>
    /// <param name="name">Unique parameter name.</param>
    /// <param name="description">Description of the parameter.</param>
    /// <param name="required">Indicates whether the parameter is required.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> or <paramref name="description"/> is null or whitespace.</exception>
    public ParameterProxySourceAttribute(string name, string description, bool required = false)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        Name = name;
        Description = description;
        Required = required;
    }
}