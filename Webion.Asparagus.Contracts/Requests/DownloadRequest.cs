namespace Webion.Asparagus.Contracts.Requests;

public sealed class DownloadRequest
{
    public string Path { get; init; } = null!;
}