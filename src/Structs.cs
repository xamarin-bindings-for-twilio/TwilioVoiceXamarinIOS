using System;
using Foundation;
using ObjCRuntime;

namespace Twilio.Voice.iOS
{
    [Native]
    public enum TVOIceTransportPolicy : ulong
    {
        All = 0,
        Relay = 1
    }

    static class CFunctions
    {
        // extern void TVOAudioDeviceFormatChanged (TVOAudioDeviceContext _Nonnull context);
        [Export("TVOAudioDeviceFormatChanged")]
        static extern unsafe void TVOAudioDeviceFormatChanged(IntPtr context);

        // extern void TVOAudioDeviceWriteCaptureData (TVOAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes);
        [Export("TVOAudioDeviceWriteCaptureData")]
        static extern unsafe void TVOAudioDeviceWriteCaptureData(IntPtr context, sbyte* data, ulong sizeInBytes);

        // extern void TVOAudioDeviceReadRenderData (TVOAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes);
        [Export("TVOAudioDeviceReadRenderData")]
        static extern unsafe void TVOAudioDeviceReadRenderData(IntPtr context, sbyte* data, ulong sizeInBytes);

        // extern void TVOAudioDeviceExecuteWorkerBlock (TVOAudioDeviceContext _Nonnull context, TVOAudioDeviceWorkerBlock _Nonnull block);
        [Export("TVOAudioDeviceExecuteWorkerBlock")]
        static extern unsafe void TVOAudioDeviceExecuteWorkerBlock(IntPtr context, IntPtr block);

        // extern void TVOAudioSessionActivated (TVOAudioDeviceContext _Nonnull context);
        [Export("TVOAudioSessionActivated")]
        static extern unsafe void TVOAudioSessionActivated(IntPtr context);

        // extern void TVOAudioSessionDeactivated (TVOAudioDeviceContext _Nonnull context);
        [Export("TVOAudioSessionDeactivated")]
        static extern unsafe void TVOAudioSessionDeactivated(IntPtr context);
    }

    [Native]
    public enum TVOCallState : ulong
    {
        Connecting = 0,
        Ringing,
        Connected,
        Disconnected
    }

    [Native]
    public enum TVOCallFeedbackScore : ulong
    {
        NotReported = 0,
        OnePoint,
        TwoPoints,
        ThreePoints,
        FourPoints,
        FivePoints
    }

    [Native]
    public enum TVOCallFeedbackIssue : ulong
    {
        NotReported = 0,
        DroppedCall,
        AudioLatency,
        OneWayAudio,
        ChoppyAudio,
        NoisyCall,
        Echo
    }

    [Native]
    public enum TVOError : ulong
    {
        AccessTokenInvalidError = 20101,
        AccessTokenHeaderInvalidError = 20102,
        AccessTokenIssuerInvalidError = 20103,
        AccessTokenExpiredError = 20104,
        AccessTokenNotYetValidError = 20105,
        AccessTokenGrantsInvalidError = 20106,
        AccessTokenSignatureInvalidError = 20107,
        AuthFailureCodeError = 20151,
        ExpirationTimeExceedsMaxTimeAllowedError = 20157,
        AccessForbiddenError = 20403,
        ApplicationNotFoundError = 21218,
        ConnectionError = 31005,
        CallCancelledError = 31008,
        MalformedRequestError = 31100,
        AuthorizationError = 31201,
        RegistrationError = 31301,
        TokenAuthenticationRejected = 51007,
        SignalingConnectionDisconnectedError = 53001,
        MediaClientLocalDescFailedError = 53400,
        MediaServerLocalDescFailedError = 53401,
        MediaClientRemoteDescFailedError = 53402,
        MediaServerRemoteDescFailedError = 53403,
        MediaNoSupportedCodecError = 53404,
        MediaConnectionError = 53405
    }

    [Native]
    public enum TVOIceCandidatePairState : ulong
    {
        Succeeded,
        Frozen,
        Waiting,
        InProgress,
        Failed,
        Cancelled,
        Unknown
    }

    [Native]
    public enum TVOLogLevel : ulong
    {
        Off = 0,
        Fatal,
        Error,
        Warning,
        Info,
        Debug,
        Trace,
        All
    }

    [Native]
    public enum TVOLogModule : ulong
    {
        Core = 0,
        Platform,
        Signaling,
        WebRTC
    }
}
