namespace Webion.Asparagus.Api.Endpoints;

public sealed class Request
{
    public string BasePath { get; init; } = null!;
    public IFormFile File { get; init; } = null!;
}

public sealed class FileUploadEndpoint : Endpoint<Request, FileUploadResponse>
{
    private readonly IFileStore _storage;

    public FileUploadEndpoint(IFileStore storage)
    {
        _storage = storage;
    }


    public override void Configure()
    {
        Post("/upload/file");
        AllowFileUploads(dontAutoBindFormData: true);
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var result = await _storage.StoreAsync(
            basePath: req.BasePath,
            file: req.File.OpenReadStream(),
            cancellationToken: ct
        );

        await SendCreatedAtAsync<DownloadEndpoint>(
            routeValues: new
            {
                Path = result,
            },
            responseBody: new FileUploadResponse
            {
                Path = result,
            }
        );
    }
}