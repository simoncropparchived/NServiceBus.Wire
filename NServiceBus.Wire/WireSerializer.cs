namespace NServiceBus.Wire
{
    using System;
    using MessageInterfaces;
    using Serialization;
    using Settings;

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
            return mapper =>
            {
                var options = settings.GetOptions();
                var contentTypeKey = settings.GetContentTypeKey();
                return new WireMessageSerializer(contentTypeKey, options);
            };
        }
    }
}