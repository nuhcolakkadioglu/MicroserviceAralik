using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceAralik.RabbitMQ.Abstract;
public interface IRabbitMQPublisher
{
    void Publish<T>(string queuename, T message);
}
