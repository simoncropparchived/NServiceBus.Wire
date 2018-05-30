using NServiceBus.Configuration.AdvancedExtensibility;
using NServiceBus.Serialization;
using NServiceBus.Settings;
using NServiceBus.Wire;
using Wire;

namespace NServiceBus
{
    /// <summary>
    /// Extensions for <see cref="SerializationExtensions{T}"/> to manipulate how messages are serialized via Wire.
    /// </summary>
    public static class WireConfigurationExtensions
    {
        /// <summary>
        /// Configures the <see cref="SerializerOptions"/> to use.
        /// </summary>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="options">The <see cref="SerializerOptions"/> to use.</param>
        public static void Options(this SerializationExtensions<WireSerializer> config, SerializerOptions options)
        {
            Guard.AgainstNull(config, nameof(config));
            var settings = config.GetSettings();
            settings.Set<SerializerOptions>(options);
        }

        internal static SerializerOptions GetOptions(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<SerializerOptions>();
        }

        /// <summary>
        /// Configures string to use for <see cref="Headers.ContentType"/> headers.
        /// </summary>
        /// <remarks>
        /// Defaults to "wire".
        /// </remarks>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="contentTypeKey">The content type key to use.</param>
        public static void ContentTypeKey(this SerializationExtensions<WireSerializer> config, string contentTypeKey)
        {
            Guard.AgainstNull(config, nameof(config));
            Guard.AgainstNullOrEmpty(contentTypeKey, nameof(contentTypeKey));
            var settings = config.GetSettings();
            settings.Set("NServiceBus.Wire.ContentTypeKey", contentTypeKey);
        }

        internal static string GetContentTypeKey(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<string>("NServiceBus.Wire.ContentTypeKey");
        }
    }
}