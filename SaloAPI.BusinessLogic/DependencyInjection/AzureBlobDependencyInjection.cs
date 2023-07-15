using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;
using SaloAPI.Application.Interfaces;
using SaloAPI.Application.Services;

namespace SaloAPI.BusinessLogic.DependencyInjection;

public static class AzureBlobDependencyInjection
{
    public static IServiceCollection AddAzureBlobServices(
        this IServiceCollection services,
        string mangoBlobUrl,
        string mangoBlobContainerName,
        string mangoBlobAccess)
    {
        var blobClient = new BlobServiceClient(mangoBlobUrl);

        var mangoBlobService = new BlobServiceSettings(mangoBlobContainerName, mangoBlobAccess);

        services.AddSingleton(_ => blobClient);

        services.AddSingleton<IBlobServiceSettings, BlobServiceSettings>(_ => mangoBlobService);

        services.AddScoped<IBlobService, BlobService>(_ => new BlobService(blobClient, mangoBlobService));

        return services;
    }
}