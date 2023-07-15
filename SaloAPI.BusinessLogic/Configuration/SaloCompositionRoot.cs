using Microsoft.Extensions.DependencyInjection;

namespace SaloAPI.BusinessLogic.Configuration;

public static class SaloCompositionRoot
{
    public static IServiceProvider Provider { get; set; }

    public static void SetProvider(IServiceProvider provider)
    {
        Provider = provider;
    }

    public static IServiceScope CreateScope()
    {
        var scope = Provider.CreateScope();
        return scope;
    }
}