using Microsoft.Extensions.DependencyInjection;

namespace Webion.Asparagus.Storage.FileSystem;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFileSystemStorage(this IServiceCollection services,
        Action<StorageOptions> config
    )
    {
        services.Configure(config);
        services.AddTransient<IFileStore, FileSystemStore>();
        return services;
    }
}