using NServiceBus.Features;
using NServiceBus.MessageInterfaces;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;

namespace NServiceBus.Wire
{
    public class WireSerialization : Feature
    {
        internal WireSerialization()
        {
            EnableByDefault();
            Prerequisite(this.ShouldSerializationFeatureBeEnabled, "WireSerialization not enabled since serialization definition not detected.");
        }

        protected override void Setup(FeatureConfigurationContext context)
        {
            var container = context.Container;
            container.ConfigureComponent<MessageMapper>(DependencyLifecycle.SingleInstance);
            container.ConfigureComponent(builder =>
            {
                var messageMapper = builder.Build<IMessageMapper>();
                return new WireMessageSerializer(messageMapper);
            }, DependencyLifecycle.SingleInstance);
        }
    }
}
