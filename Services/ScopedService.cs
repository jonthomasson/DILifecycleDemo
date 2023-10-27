using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

public class ScopedService : IScopedService
{
    public Guid Id { get; } = Guid.NewGuid();
}
