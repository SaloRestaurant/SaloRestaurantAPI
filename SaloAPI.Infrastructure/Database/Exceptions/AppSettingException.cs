using System.Runtime.Serialization;

namespace SaloAPI.Infrastructure.Database.Exceptions;

[Serializable]
public class AppSettingException : Exception
{
    protected AppSettingException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
        base(serializationInfo, streamingContext)
    {
    }

    public AppSettingException(string message) : base($"App setting variable does not exist: {message}.")
    {
    }
}