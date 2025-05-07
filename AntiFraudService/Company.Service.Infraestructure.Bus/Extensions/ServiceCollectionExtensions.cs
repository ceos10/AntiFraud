using Company.Service.Infraestructure.Bus.Consumers;
using Company.Service.Infraestructure.Bus.Messaging;
using Company.Services.Application.Interfaces;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Service.Infraestructure.Bus.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IMessageProducer<>), typeof(MessageProducer<>));

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
