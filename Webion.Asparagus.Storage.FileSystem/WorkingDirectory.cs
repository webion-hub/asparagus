namespace Webion.Asparagus.Storage.FileSystem;

internal sealed class WorkingDirectory
{
    public readonly string _basePath;

    public WorkingDirectory(string basePath)
    {
        _basePath = basePath;
    }


    public void CreateDirectory(string path) => Directory.CreateDirectory(Locate(path));
    public bool DirectoryExists(string path) => Directory.Exists(Locate(path));
    public bool FileExists(string path) => File.Exists(Locate(path));
    public FileStream OpenWrite(string path) => File.OpenWrite(Locate(path));
    public FileStream OpenRead(string path) => File.OpenRead(Locate(path));

    private string Locate(string path) => Path.Combine(_basePath, path);
}