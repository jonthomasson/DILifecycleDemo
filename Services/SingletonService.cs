using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

internal class SingletonService : ISingletonService
{
    public Guid Id => Guid.NewGuid();
}
