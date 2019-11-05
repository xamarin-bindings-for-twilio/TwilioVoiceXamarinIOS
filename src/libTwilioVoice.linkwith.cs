using ObjCRuntime;

[assembly: LinkWith("libTwilioVoice.a",
    LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    Frameworks = "SystemConfiguration AudioToolbox AVFoundation CoreTelephony PushKit CallKit",
    LinkerFlags = "-ObjC",
    SmartLink = true,
    ForceLoad = true)]