using DependecyInjection.Interfaces;

namespace DependecyInjection.Services;

internal sealed class WelcomeService : IWelcomeService
{
    private DateTime _serviceCreated;
    private Guid _serviceId;

    public WelcomeService()
    {
        _serviceCreated = DateTime.Now;
        _serviceId = Guid.NewGuid();                
    }

    public string GetWelcomeMessage()
    {
        return string.Format("A data e hora atual é: {0}. \nO ID dessa instância é: {1}",_serviceCreated, _serviceId);
    }
}
