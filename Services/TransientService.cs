using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

public class TransientService : ITransientService
{
    public Guid Id { get; } = Guid.NewGuid();
}
