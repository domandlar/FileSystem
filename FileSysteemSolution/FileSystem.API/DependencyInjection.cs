using FileSystem.API.Repositories.Files;
using FileSystem.API.Repositories.Folders;
using FileSystem.API.Services.Files;
using FileSystem.API.Services.Folders;
using FileSystem.Application.Repositories.Files;
using FileSystem.Application.Repositories.Folders;
using FileSystem.Application.Services.Files;
using FileSystem.Application.Services.Folders;

namespace FileSystem.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // configure DI for application services
            services.AddScoped<IFolderService, FolderService>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFolderRepository, FolderRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            return services;
        }
    }
}
