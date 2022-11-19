namespace Webion.Asparagus.Storage.Abstractions;

public interface IFileStore
{
    ValueTask<string> StoreAsync(string basePath, Stream file, CancellationToken cancellationToken);
    ValueTask<Stream> RetrieveAsync(string path, CancellationToken cancellationToken);
}