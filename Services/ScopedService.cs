using DILifecycleDemo.Interfaces;

namespace DILifecycleDemo.Services;

public class ScopedService : IScopedService
{
	private ITransientService _transientService;
	public ScopedService(ITransientService transientService)
	{
		//_transientService = transientService; //with di
		_transientService = new TransientService(); //without di
	}
	public Guid Id { get; } = Guid.NewGuid();
}
