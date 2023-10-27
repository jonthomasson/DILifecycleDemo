using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

public class SingletonService : ISingletonService
{
    public Guid Id { get; } = Guid.NewGuid();
}
