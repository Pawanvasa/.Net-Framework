﻿using RabbitMQPublisher.Model;

namespace RabbitMQBus
{
    public class TestProduceIntegrationEvent : IntegrationEvent
    {
        public string Key { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public List<Persons>? Person { get; set; }

    }
}