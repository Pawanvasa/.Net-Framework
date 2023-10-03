using ConnectAndSell.Common.EventBus;
using RabbitMQBus;
using RabbitMQBus.RabbitMqConnection;
using RabbitMQConsumer.EventConsumer;
using RabbitMQConsumer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<TestProductIntegrationEventHandler>();
builder.Services.AddTransient<TestProductIntegrationEventHandler>();
builder.Services.AddTransient<IIntegrationEventHandler<TestProduceIntegrationEvent>, TestProductIntegrationEventHandler>();
builder.Services.AddSingleton<IEventBusSubscriptionManager, EventBusSubscriptionManager>();
//builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>(sp =>
//{
//    var rabbitMqConnection = sp.GetRequiredService<RabbitMQConnection>();
//    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionManager>();
//    return new RabbitMQEventBus(eventBusSubcriptionsManager, rabbitMqConnection, sp);
//});

builder.Services.AddSingleton<ConsumerService>();
builder.Services.AddSingleton<RabbitMQConnection>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEventBusSubscriptionManager();
builder.Services.RegisterWorker();
builder.Services.RegisterEventHandlers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
