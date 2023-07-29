using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;
using SaloAPI.Application.Interfaces;
using SaloAPI.Application.Services;

namespace SaloAPI.BusinessLogic.DependencyInjection;

public static class AzureBlobDependencyInjection
{
    public static IServiceCollection AddAzureBlobServices(
        this IServiceCollection services,
        string saloBlobUrl,
        string saloBlobContainerName,
        string saloBlobAccess)
    {
        var blobClient = new BlobServiceClient(saloBlobUrl);

        var saloBlobService = new BlobServiceSettings(saloBlobContainerName, saloBlobAccess);

        services.AddSingleton(blobClient);

        services.AddSingleton<IBlobServiceSettings, BlobServiceSettings>(_ => saloBlobService);

        services.AddScoped<IBlobService, BlobService>(_ => new BlobService(blobClient, saloBlobService));

        return services;
    }
}