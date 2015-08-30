using System;
using NServiceBus.Serialization;

namespace NServiceBus.Wire
{
    public class WireSerializer : SerializationDefinition
    {
        protected override Type ProvidedByFeature()
        {
            return typeof (WireSerialization);
        }
    }
}