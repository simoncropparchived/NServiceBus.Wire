using NServiceBus;
using NServiceBus.Wire;
using Wire;

class Usage
{
    Usage(EndpointConfiguration configuration)
    {
        #region WireSerialization

        configuration.UseSerialization<WireSerializer>();

        #endregion
    }

    void CustomSettings(EndpointConfiguration configuration)
    {
        #region WireCustomSettings

        var options = new SerializerOptions(
            preserveObjectReferences: true);
        var serialization = configuration.UseSerialization<WireSerializer>();
        serialization.Options(options);

        #endregion
    }

    void ContentTypeKey(EndpointConfiguration configuration)
    {
        #region WireContentTypeKey

        var serialization = configuration.UseSerialization<WireSerializer>();
        serialization.ContentTypeKey("custom-key");

        #endregion
    }
}