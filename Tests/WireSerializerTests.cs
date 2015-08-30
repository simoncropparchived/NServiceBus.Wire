using System;
using System.IO;
using System.Linq;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;
using NServiceBus.Wire;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WireSerializerTests
    {
        public class Person
        {
            public Guid Id { get; set; }
        }

        public class Human : Person
        {
            public string Name { get; set; }
        }

        [Test]
        public void Can_serialize_and_deserialize_types()
        {
            var serializer = new WireMessageSerializer(new MessageMapper());

            Human deserialized;
            var person = new Human { Id = Guid.NewGuid(), Name = "Igal" };
            using (var s = new MemoryStream())
            {
                serializer.Serialize(person, s);

                s.Position = 0;

                deserialized = serializer.Deserialize(s, new [] { typeof(Human) }).Cast<Human>().First();
            }

            Assert.AreEqual(deserialized.Id, person.Id);
            Assert.AreEqual(deserialized.Name, person.Name);
        }
    }
}