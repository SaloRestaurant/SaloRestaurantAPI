namespace SaloAPI.Application.Interfaces;

public interface ICorrelationContext
{
    public Guid GetUserId();
}