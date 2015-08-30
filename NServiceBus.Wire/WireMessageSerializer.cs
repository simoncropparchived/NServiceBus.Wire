using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using Wire;

namespace NServiceBus.Wire
{
    public class WireMessageSerializer : IMessageSerializer
    {
        MethodInfo deserializationMethod;
        Serializer serializer;

        public WireMessageSerializer(IMessageMapper messageMapper, SerializerOptions options = null)
        {
            serializer = options == null ? new Serializer() : new Serializer(options);
        }

        public void Serialize(object message, Stream stream)
        {
            serializer.Serialize(message, stream);
        }

        public object[] Deserialize(Stream stream, IList<Type> messageTypes = null)
        {
            return new [] { serializer.Deserialize(stream) };
        }

        public string ContentType
        {
            get { return ContentTypes.Binary; }
        }
    }
}