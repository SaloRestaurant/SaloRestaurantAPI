namespace SaloAPI.Application.Interfaces;

public interface IBlobServiceSettings
{
    string SaloBlobContainerName { get; }

    // http://127.0.0.1:10000/devstoreaccount1/testcontainer
    string SaloBlobAccess { get; }
}