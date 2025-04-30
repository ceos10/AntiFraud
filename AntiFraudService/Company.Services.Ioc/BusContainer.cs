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
                rider.AddConsumer<TransactionCreatedConsumer>();
                rider.AddProducer<TransactionUpdatedContract>("transaction-updated");

                rider.UsingKafka((context, k) =>
                {
                    k.Host("localhost:9092");

                    k.TopicEndpoint<TransactionCreatedContract>("transaction-created", "consumer-transaction", e =>
                    {
                        e.ConfigureConsumer<TransactionCreatedConsumer>(context);
                        e.CreateIfMissing();
                    });
                });
            });
        });
    }
}