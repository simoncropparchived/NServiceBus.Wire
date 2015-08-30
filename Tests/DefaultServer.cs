namespace NServiceBus.AcceptanceTests.EndpointTemplates
{
    using System.Collections.Generic;
    using NServiceBus.Wire;

    public partial class DefaultServer
    {
        public void SetSerializer(IDictionary<string, string> settings, BusConfiguration builder)
        {
//            var options = new Options(
//                dateFormat: DateTimeFormat.MicrosoftStyleMillisecondsSinceUnixEpoch,
//                includeInherited: true);

            builder.UseSerialization<WireSerializer>();
        }
    }
}