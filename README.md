# Twilio Voice Xamarin IOS

Twilio Voice iOS SDK binding for Xamarin

[![NuGet][nuget-img]][nuget-link]

[nuget-img]: https://img.shields.io/badge/nuget-6.0.2-blue.svg
[nuget-link]: https://www.nuget.org/packages/Twilio.Voice.iOS.XamarinBinding

## How to Build

### Twilio.Voice iOS 6.0.2 (November 4, 2020)
```
sh bootstrapper.sh
```

Add --registrar:static as additional mtouch arguments on iOS Build dialog for your iOS application
Sometimes adding --registrar:static -cxx -gcc_flags -dead_strip flags is required.

## Sample

####  I don't have C# version of twilio quickstart application, so I highly recommend you to read about using native library bindings for xamarin and check official Twilio quickstart guides.

[delegate sample](sample)

[voice-quickstart-swift](https://github.com/twilio/voice-quickstart-swift)

## Contributions

Members of the community have contributed to improving and update bindings:

- tuyen-vuduc (https://github.com/tuyen-vuduc)
- Rob Harwood

If you have a bugfix or an update you'd like to add, please open an issue. 
All pull requests should be opened against the `master` branch.
