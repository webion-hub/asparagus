namespace Webion.Asparagus.Api.Endpoints;

public sealed class DownloadEndpoint : Endpoint<DownloadRequest>
{
    private readonly IFileStore _storage;

    public DownloadEndpoint(IFileStore storage)
    {
        _storage = storage;
    }


    public override void Configure()
    {
        Get("/download/{Path}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DownloadRequest req, CancellationToken ct)
    {
        using var fs = await _storage.RetrieveAsync(
            path: req.Path,
            cancellationToken: ct
        );

        await SendStreamAsync(fs);
    }
}