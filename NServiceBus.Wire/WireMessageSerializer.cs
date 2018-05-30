using System;
using System.Collections.Generic;
using System.IO;
using NServiceBus.Serialization;
using Wire;

class WireMessageSerializer : IMessageSerializer
{
    Serializer serializer;

    public WireMessageSerializer(string contentType, SerializerOptions options)
    {
        if (options == null)
        {
            serializer = new Serializer();
        }
        else
        {
            serializer = new Serializer(options);
        }

        if (contentType == null)
        {
            ContentType = "wire";
        }
        else
        {
            ContentType = contentType;
        }
    }

    public void Serialize(object message, Stream stream)
    {
        var messageType = message.GetType();
        if (messageType.Name.EndsWith("__impl"))
        {
            throw new Exception("Interface based message are not currently supported. Create a class that implements the desired interface.");
        }

        serializer.Serialize(message, stream);
    }

    public object[] Deserialize(Stream stream, IList<Type> messageTypes = null)
    {
        return new[] {serializer.Deserialize(stream)};
    }

    public string ContentType { get; }
}