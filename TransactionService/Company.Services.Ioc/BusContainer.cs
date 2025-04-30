using Company.Services.Bus.Contracts;
using Company.Services.Business.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Company.Services.Ioc;

public static class BusContainer
{
    public static IServiceCollection RegisterKafka(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMassTransit(x =>
        {
            x.UsingInMemory();

            x.AddRider(rider =>
            {
                rider.AddConsumer<TransactionUpdatedConsumer>();
                rider.AddProducer<TransactionCreatedContract>("transaction-created");

                rider.UsingKafka((context, k) =>
                {
                    k.Host("localhost:9092");
                    k.TopicEndpoint<TransactionCreatedContract>("transaction-updated", "consumer-transaction", e =>
                    {
                        e.ConfigureConsumer<TransactionUpdatedConsumer>(context);
                        e.CreateIfMissing();
                    });
                });
            });
        });
    }
}