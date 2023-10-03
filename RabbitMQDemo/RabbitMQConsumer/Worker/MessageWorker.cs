using RabbitMQBus;
using RabbitMQConsumer.Services.EventBusConsumer;

public class MessageWorker : BackgroundService
{
    private readonly IEventBus _eventBus;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public MessageWorker(IEventBus eventBus)
    {
        _eventBus = eventBus;
        _cancellationTokenSource = new CancellationTokenSource();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        try
        {
            var subscription1Task = _eventBus.SubscribeAsync<TestProduceIntegrationEvent, Eventhandler>(_cancellationTokenSource.Token);
            //var subscription2Task = _eventBus.SubscribeAsync<OrderEvent, Eventhandler1>(_cancellationTokenSource.Token);

            // Await both subscription tasks to ensure they are started in the background
            await Task.WhenAll(subscription1Task);
        }
        catch (Exception)
        {
            throw;
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }

    public void StopWorker()
    {
        _cancellationTokenSource.Cancel();
    }
}