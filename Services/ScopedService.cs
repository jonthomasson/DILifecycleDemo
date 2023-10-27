using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

internal class ScopedService : IScopedService
{
    public Guid Id => Guid.NewGuid();
}
