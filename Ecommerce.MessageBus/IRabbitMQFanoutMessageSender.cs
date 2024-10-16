using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.MessageBus
{
    public interface IRabbitMQFanoutMessageSender
    {
        void SendMessage(Object message, string queueName);
    }
}
