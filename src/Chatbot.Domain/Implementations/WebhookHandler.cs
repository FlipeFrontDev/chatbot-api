﻿using Chatbot.Domain.DTOs;
using Chatbot.Domain.Interfaces;
using Chatbot.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Chatbot.Domain.Implementations
{
    public class WebhookHandler : IWebhookHandler
    {
        private readonly IClientMessageBroker _clientMessageBroker;
        private const string QueueName = "from-facebook";

        public WebhookHandler(IClientMessageBroker clientMessageBroker)
        {
            _clientMessageBroker = clientMessageBroker;
        }

        public async Task Handle(WebhookDto webhookDto)
        {
            var message = new MessageProcess(text: webhookDto?.Text);

            await _clientMessageBroker.PublishMessageOnQueue(QueueName, message);
        }
    }
}