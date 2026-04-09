using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Rebus.Config;
using Rebus.Bus;
using Rebus.Handlers;

namespace BuildingBlocks.Messaging.MessageBus;
public static class Extensions
{
    public static IServiceCollection AddMessageBroker
        (this IServiceCollection services, string queueName, params Assembly[] assemblies)
    {
        foreach(var assembly in assemblies)
            services.AutoRegisterHandlersFromAssembly(assembly);

        services.AddRebus((configure, provider) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("rabbitmq");

            return configure
                   .Transport(t => t.UseRabbitMq(connectionString, queueName));

        });

        return services;
    }

    public static async Task SubscribeToHandledEvents(this IBus bus, Assembly handlerAssembly)
    {
        var handlerTypes = handlerAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.ImplementsGenericInterface(typeof(IHandleMessages<>)));

        var eventTypes = handlerTypes
            .SelectMany(t => t.GetInterfaces())
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandleMessages<>))
            .Select(i => i.GetGenericArguments()[0])
            .Distinct()
            .ToList();

        foreach (var eventType in eventTypes)
        {
            await bus.Subscribe(eventType);
        }
    }

    private static bool ImplementsGenericInterface(this Type type, Type genericInterface)
    {
        return type.GetInterfaces()
                   .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericInterface);
    }
}