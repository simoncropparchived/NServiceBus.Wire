using System;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using NServiceBus.Settings;

namespace NServiceBus.Wire
{
    /// <summary>
    /// Defines the capabilities of the Wire serializer
    /// </summary>
    public class WireSerializer : SerializationDefinition
    {
        /// <summary>
        /// <see cref="SerializationDefinition.Configure"/>
        /// </summary>
        public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings)
        {
            Guard.AgainstNull(settings, nameof(settings));
            return mapper =>
            {
                var options = settings.GetOptions();
                var contentTypeKey = settings.GetContentTypeKey();
                return new WireMessageSerializer(contentTypeKey, options);
            };
        }
    }
}