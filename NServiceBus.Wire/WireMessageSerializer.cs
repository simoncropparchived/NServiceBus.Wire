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
        readonly Serializer serializer;

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
            if (messageTypes == null || !messageTypes.Any())
            {
                throw new Exception("Wire requires message types to be specified");
            }

            var mi = serializer.GetType().GetMethod("Deserialize");
            var info = mi.MakeGenericMethod(messageTypes.ToArray());
            return new [] { info.Invoke(serializer, new[] {stream}) };
        }

        IEnumerable<Type> FindRootTypes(IEnumerable<Type> messageTypesToDeserialize)
        {
            Type currentRoot = null;
            foreach (var type in messageTypesToDeserialize)
            {
                if (currentRoot == null)
                {
                    currentRoot = type;
                    yield return currentRoot;
                    continue;
                }
                if (!type.IsAssignableFrom(currentRoot))
                {
                    currentRoot = type;
                    yield return currentRoot;
                }
            }
        }

        public string ContentType
        {
            get { return ContentTypes.Binary; }
        }
    }
}