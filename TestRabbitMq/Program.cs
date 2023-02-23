using RabbitMQ.Client;
using System.Text;

var factor = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factor.CreateConnection())
using (var channel =connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "Test",
                            type: "diret",
                            autoDelete: true,
                            durable: false);

    var message = "Hello abdo";
    var body=Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "Test",
                         routingKey: "TestLog",
                         basicProperties: null,
                         body: body);

    Console.WriteLine($" sent message =  {message}");
}