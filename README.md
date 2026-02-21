# Proxxi.Plugin.Sdk

SDK for building **proxy source plugins** for `proxxi`.

- **Target framework:** `net10.0`
- **Goal:** a small, stable contract for implementations that return proxies either as a batch or as a stream.
- **Package:** `Proxxi.Plugin.Sdk`

## Installation

Add the package to your plugin project:

```shell
dotnet add package Proxxi.Plugin.Sdk
```

### Project file configuration

When referencing the SDK in your plugin project, you must **exclude the runtime assets** to prevent conflicts:

```csproj
<!-- Default reference -->
<ItemGroup>
  <PackageReference Include="Proxxi.Plugin.Sdk" Version="x.y.z" />
</ItemGroup>
```

Modify it to:

```csproj
<ItemGroup>
  <PackageReference Include="Proxxi.Plugin.Sdk" Version="x.y.z">
    <Private>false</Private>
    <ExcludeAssets>runtime</ExcludeAssets>
  </PackageReference>
</ItemGroup>
```

## Publish

```shell
dotnet publish -c Release
```

To make sharing and storing your plugins easier, the SDK supports auto-packaging into a `.pxp` file.

### .pxp File Format

A `.pxp` file is a compressed **tar.gz** archive containing all the necessary assets, metadata, and compiled code for
your plugin. This format ensures that your plugin remains lightweight and easy to distribute across different
environments.

### Auto Packaging

When you are ready to release your plugin, you can use the built-in packaging targets:

```shell
dotnet public -c Release -t:PackPlugin
```

This will create a `.pxp` file in the `bin/Release` folder.

## Concepts

A plugin implements one of the following source shapes:

- `IBatchProxySource` – returns all proxies in one go: `Task<IEnumerable<Proxy>> FetchAsync(...)`
- `IStreamProxySource` – returns proxies as an async stream: `IAsyncEnumerable<Proxy> FetchAsync(...)`

Both derive from `IProxySource` and share the same lifecycle:

1. **Initialize**: `InitializeAsync(...)`
2. **Fetch**: `FetchAsync(...)` (batch or stream)
3. **Dispose**: `IAsyncDisposable()`

## Data model

### `Proxy`

Represents an endpoint and optional authentication:

- `Host` – hostname or IP
- `Port` – port number
- `Username` / `Password` – optional credentials
- `Protocols` – flags describing supported proxy protocols

### `Protocols`

A flags enum:

- `Http`, `Https`, `Socks4`, `Socks5` (combinable)

## Metadata via attributes

The SDK provides attributes to describe a source and its configuration parameters (metadata used by
UIs/factories/loaders):

### `ProxySourceAttribute`

Annotates an implementation class:

- `Id` – unique identifier in `<publisher>.<plugin-name>` format (lowercase, dot-separated)
- `Name` – human-readable name
- `Description` – optional description
- `HideBatch` / `HideStream` – hint for consumers to hide a mode (metadata only; does not change runtime behavior)

### `ParameterProxySourceAttribute`

Describes a configuration parameter (`AllowMultiple = true`):

- `Name` – parameter key
- `Description` – parameter description
- `Required` – whether it is required

## Example: Batch source

```csharp
[ProxySource("mypublisher.example-batch", "Example Batch Source")]
[Description("Demo batch source.")]
[ParameterProxySource("endpoint", "API URL to fetch proxies from", required: true)]
[ParameterProxySource("timeoutSeconds", "Request timeout in seconds", required: false)]
public sealed class ExampleBatchSource : IBatchProxySource
{
    public Task InitializeAsync(IReadOnlyDictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // Initialize source (read parameters, create HttpClient, etc.)
    }
    public Task<IEnumerable<Proxy>> FetchAsync(CancellationToken cancellationToken)
    {
        // Fetch proxies (HTTP requesting, parsing, etc.)
    }
    
    public ValueTask DisposeAsync()
    {
        // Clean up resources (dispose HttpClient, streams, etc.)
    }
}
```

## Example: Stream source

```csharp
[ProxySource("mypublisher.example-stream", "Example Stream Source")]
[Description("Demo stream source")]
public sealed class ExampleStreamSource : IStreamProxySource
{
    public Task InitializeAsync(IReadOnlyDictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // Initialize source (read parameters, create HttpClient, etc.)
    }

    public async IAsyncEnumerable<Proxy> FetchAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Fetch proxies (HTTP requesting, parsing, etc.)
    }

    public ValueTask DisposeAsync()
    {
        // Clean up resources (dispose HttpClient, streams, etc.)
    }
}
```

## Example: Both sources

```csharp
[ProxySource("mypublisher.example-source", "Example Source")]
[Description("Demo source")]
public sealed class ExampleBothSource : IBatchProxySource, IStreamProxySource
{
    public Task InitializeAsync(IReadOnlyDictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // Initialize source (read parameters, create HttpClient, etc.)
    }
    
    IAsyncEnumerable<Proxy> IStreamProxySource.FetchAsync(CancellationToken cancellationToken)
    {
        // Fetch proxies (HTTP requesting, parsing, etc.)
    }

    Task<IEnumerable<Proxy>> IBatchProxySource.FetchAsync(CancellationToken cancellationToken)
    {
        // Fetch proxies (HTTP requesting, parsing, etc.)
    }

    public ValueTask DisposeAsync()
    {
        // Clean up resources (dispose HttpClient, streams, etc.)
    }
}
```

## Implementation guidelines

- **Validate parameters** in `InitializeAsync` and throw clear exceptions (for example `ArgumentException`).
- **Honor `CancellationToken`** in network/long-running operations.

## License

This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.
