# <img src="/src/icon.png" height="30px"> NServiceBus.Wire

[![Build status](https://ci.appveyor.com/api/projects/status/sjv1mlf4s3iv6iba/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-wire)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.Wire.svg)](https://www.nuget.org/packages/NServiceBus.Wire/)

Add support for [NServiceBus](https://particular.net/nservicebus) message serialization via [Wire](https://github.com/rogeralsing/Wire) binary serializer.

toc

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) to use this tool. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**

Thanks to the current backers.

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## NuGet package

https://nuget.org/packages/NServiceBus.Wire/


## Usage

snippet: WireSerialization

This serializer does not support [messages defined as interfaces](https://docs.particular.net/nservicebus/messaging/messages-as-interfaces). If an explicit interface is sent, an exception will be thrown with the following message:

```
Interface based message are not supported.
Create a class that implements the desired interface
```

Instead, use a public class with the same contract as the interface. The class can optionally implement any required interfaces.


### Custom settings

Customizes the instance of `SerializerOptions` used for serialization.

snippet: WireCustomSettings


### Custom content key

When using [additional deserializers](https://docs.particular.net/nservicebus/serialization/#specifying-additional-deserializers) or transitioning between different versions of the same serializer it can be helpful to take explicit control over the content type a serializer passes to NServiceBus (to be used for the [ContentType header](https://docs.particular.net/nservicebus/messaging/headers#serialization-headers-nservicebus-contenttype)).

snippet: WireContentTypeKey


## Release Notes

See [closed milestones](../../milestones?state=closed).


## Icon

[Insulated Wire](https://thenounproject.com/term/insulated-wire/116162) designed by [Arthur Shlain](https://thenounproject.com/ArtZ91/) from [The Noun Project](https://thenounproject.com).