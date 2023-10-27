using DILifecycleDemo.Interfaces;
using DILifecycleDemo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Set composition root
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Setup DI
builder.Services.AddTransient<ITransientService, TransientService>();   //transient: new instance every time its requested. 
builder.Services.AddScoped<IScopedService, ScopedService>();            //scoped: single instance is created and shared with a given scope.
builder.Services.AddSingleton<ISingletonService, SingletonService>();   //singleton: one instance across application
builder.Services.AddLogging(config => config.AddConsole());

using IHost host = builder.Build();

// Create scopes. Note in a web api a scope will be new for each HTTP request.
using var scope1 = host.Services.CreateScope();
var singleton1A = scope1.ServiceProvider.GetRequiredService<ISingletonService>();
var singleton1B = scope1.ServiceProvider.GetRequiredService<ISingletonService>();
var scoped1A = scope1.ServiceProvider.GetRequiredService<IScopedService>();
var scoped1B = scope1.ServiceProvider.GetRequiredService<IScopedService>();
var transient1A = scope1.ServiceProvider.GetRequiredService<ITransientService>();
var transient1B = scope1.ServiceProvider.GetRequiredService<ITransientService>();

using var scope2 = host.Services.CreateScope();
var singleton2A = scope2.ServiceProvider.GetRequiredService<ISingletonService>();
var singleton2B = scope2.ServiceProvider.GetRequiredService<ISingletonService>();
var scoped2A = scope2.ServiceProvider.GetRequiredService<IScopedService>();
var scoped2B = scope2.ServiceProvider.GetRequiredService<IScopedService>();
var transient2A = scope2.ServiceProvider.GetRequiredService<ITransientService>();
var transient2B = scope2.ServiceProvider.GetRequiredService<ITransientService>();

// Display results
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Singleton Services:");
Console.WriteLine($"Singleton1A ID: {singleton1A.Id}");
Console.WriteLine($"Singleton1B ID: {singleton1B.Id}");
Console.WriteLine($"Singleton2A ID: {singleton2A.Id}");
Console.WriteLine($"Singleton2B ID: {singleton2B.Id}");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\nScoped Services:");
Console.WriteLine($"Scoped1A ID: {scoped1A.Id}");
Console.WriteLine($"Scoped1B ID: {scoped1B.Id}");
Console.WriteLine($"Scoped2A ID: {scoped2A.Id}");
Console.WriteLine($"Scoped2B ID: {scoped2B.Id}");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\nTransient Services:");
Console.WriteLine($"Transient1A ID: {transient1A.Id}");
Console.WriteLine($"Transient1B ID: {transient1B.Id}");
Console.WriteLine($"Transient2A ID: {transient2A.Id}");
Console.WriteLine($"Transient2B ID: {transient2B.Id}");

Console.ResetColor();
Console.WriteLine("\nDifferent Scope Comparisons:");
Console.WriteLine($"Singleton Ids equal: {singleton1A.Id == singleton2A.Id}"); // True
Console.WriteLine($"Scoped Ids equal: {scoped1A.Id == scoped2A.Id}"); // False
Console.WriteLine($"Transient Ids equal: {transient1A.Id == transient2A.Id}"); // False

Console.WriteLine($"\nSame Scope Comparisons:");
Console.WriteLine($"Singleton Ids in Scope1 equal: {singleton1A.Id == singleton1B.Id}"); // True
Console.WriteLine($"Scoped Ids in Scope1 equal: {scoped1A.Id == scoped1B.Id}"); // True
Console.WriteLine($"Transient Ids in Scope1 equal: {transient1A.Id == transient1B.Id}"); // False
