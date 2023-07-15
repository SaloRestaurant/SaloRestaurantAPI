namespace SaloAPI.Application.Interfaces;

public interface IBlobService
{
    Task<string> GetBlobAsync(string fileName);

    Task<bool> UploadFileBlobAsync(Stream stream, string contentType, string uniqueName);

    Task<bool> DeleteBlobAsync(string fileName);
}