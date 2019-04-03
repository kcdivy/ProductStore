﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductQueryApi.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProductQueryApi.Queues.AMQP
{
    public class AMQPEventSubscriber : IEventSubscriber
    {
        private ILogger logger;
        private EventingBasicConsumer consumer;
        private QueueOptions queueOptions;
        private string consumerTag;
        private IModel channel;

        public AMQPEventSubscriber(ILogger<AMQPEventSubscriber> logger,
            IOptions<QueueOptions> queueOptions,
            EventingBasicConsumer consumer)
        {
            this.logger = logger;
            this.queueOptions = queueOptions.Value;
            this.consumer = consumer;

            this.channel = consumer.Model;

            Initialize();
        }

        private void Initialize()
        {
            channel.QueueDeclare(
                queue: queueOptions.ProductAddedEventQueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            logger.LogInformation($"Initialized event subscriber for queue {queueOptions.ProductAddedEventQueueName}");

            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;
                var msg = Encoding.UTF8.GetString(body);
                var evt = JsonConvert.DeserializeObject<NewProductEvent>(msg);
                logger.LogInformation($"Received incoming event, {body.Length} bytes.");
                if (ProductAddedEventReceived != null)
                {
                    ProductAddedEventReceived(evt);
                }
                channel.BasicAck(ea.DeliveryTag, false);
            };
        }

        public event ProductAddedEventReceivedDelegate ProductAddedEventReceived;

        public void Subscribe()
        {
            consumerTag = channel.BasicConsume(queueOptions.ProductAddedEventQueueName, false, consumer);
            logger.LogInformation("Subscribed to queue.");
        }

        public void Unsubscribe()
        {
            channel.BasicCancel(consumerTag);
            logger.LogInformation("Unsubscribed from queue.");
        }
    }
}
