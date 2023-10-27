using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

internal class TransientService : ITransientService
{
    public Guid Id => Guid.NewGuid();
}
