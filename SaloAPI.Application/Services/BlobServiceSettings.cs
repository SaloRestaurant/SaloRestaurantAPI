using SaloAPI.Application.Interfaces;

namespace SaloAPI.Application.Services;

public class BlobServiceSettings : IBlobServiceSettings
{
    public BlobServiceSettings(string saloBlobContainerName, string saloBlobAccess)
    {
        SaloBlobContainerName = saloBlobContainerName;
        SaloBlobAccess = saloBlobAccess;
    }

    public string SaloBlobContainerName { get; }

    public string SaloBlobAccess { get; }
}