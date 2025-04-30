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
        var transactionCreatedTopic = configuration["AppSettings:TransactionCreatedTopic"];
        var transactionUpdatedTopic = configuration["AppSettings:TransactionUpdatedTopic"];
        var groupId = configuration["AppSettings:GroupId"];
        var kafkaHost = configuration["AppSettings:KafkaHost"];

        return services.AddMassTransit(x =>
        {
            x.UsingInMemory();

            x.AddRider(rider =>
            {
                rider.AddConsumer<TransactionCreatedConsumer>();
                rider.AddProducer<TransactionUpdatedContract>(transactionUpdatedTopic);

                rider.UsingKafka((context, k) =>
                {
                    k.Host(kafkaHost);

                    k.TopicEndpoint<TransactionCreatedContract>(transactionCreatedTopic, groupId, e =>
                    {
                        e.ConfigureConsumer<TransactionCreatedConsumer>(context);
                        e.CreateIfMissing();
                    });
                });
            });
        });
    }
}