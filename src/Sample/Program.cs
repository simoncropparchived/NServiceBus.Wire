using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Wire;

class Program
{
    static async Task Main()
    {
        var configuration = new EndpointConfiguration("WireSerializerSample");
        configuration.UseSerialization<WireSerializer>();
        configuration.UseTransport<LearningTransport>();
        configuration.EnableInstallers();

        var endpoint = await Endpoint.Start(configuration);
        var message = new MyMessage
        {
            DateSend = DateTime.Now,
        };
        await endpoint.SendLocal(message);
        Console.WriteLine("\r\nPress any key to stop program\r\n");
        Console.Read();
        await endpoint.Stop();
    }
}