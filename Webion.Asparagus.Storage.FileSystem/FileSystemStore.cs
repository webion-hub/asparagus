namespace Webion.Asparagus.Storage.FileSystem;

public sealed class FileSystemStore : IFileStore
{
    private readonly StorageOptions _options;
    private readonly WorkingDirectory _workDir;

    public FileSystemStore(IOptions<StorageOptions> options)
    {
        _options = options.Value;
        _workDir = new WorkingDirectory(_options.BasePath);
    }


    public ValueTask<Stream> RetrieveAsync(string path, CancellationToken cancellationToken)
    {
        if (!_workDir.FileExists(path))
            throw new FileNotFoundException();

        return ValueTask.FromResult<Stream>(
            result: _workDir.OpenRead(path)
        );
    }

    public async ValueTask<string> StoreAsync(string basePath, Stream file, CancellationToken cancellationToken)
    {
        var fileName = Path.GetRandomFileName();
        var filePath = Path.Combine(basePath, fileName);

        _workDir.CreateDirectory(basePath);
        using var fs = _workDir.OpenWrite(filePath);
        await file.CopyToAsync(fs);

        return filePath;
    }
}