using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Twilio.Voice.iOS
{
	// typedef void (^TVOAudioDeviceWorkerBlock)();
	delegate void TVOAudioDeviceWorkerBlock();
	
	[Native]
	public enum TVOIceTransportPolicy : ulong
	{
		All = 0,
		Relay = 1
	}

	public static class CFunctions
	{
		// extern void TVOAudioDeviceFormatChanged (TVOAudioDeviceContext _Nonnull context) __attribute__((swift_name("AudioDeviceFormatChanged(context:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVOAudioDeviceFormatChanged (void* context);

		// extern void TVOAudioDeviceWriteCaptureData (TVOAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes) __attribute__((swift_name("AudioDeviceWriteCaptureData(context:data:sizeInBytes:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVOAudioDeviceWriteCaptureData (void* context, sbyte* data, nuint sizeInBytes);

		// extern void TVOAudioDeviceReadRenderData (TVOAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes) __attribute__((swift_name("AudioDeviceReadRenderData(context:data:sizeInBytes:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVOAudioDeviceReadRenderData (void* context, sbyte* data, nuint sizeInBytes);

		// extern void TVOAudioDeviceExecuteWorkerBlock (TVOAudioDeviceContext _Nonnull context, TVOAudioDeviceWorkerBlock _Nonnull block) __attribute__((swift_name("AudioDeviceExecuteWorkerBlock(context:block:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVOAudioDeviceExecuteWorkerBlock (void* context, TVOAudioDeviceWorkerBlock block);

		// extern void TVOAudioSessionActivated (TVOAudioDeviceContext _Nonnull context) __attribute__((swift_name("AudioSessionActivated(context:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVOAudioSessionActivated (void* context);

		// extern void TVOAudioSessionDeactivated (TVOAudioDeviceContext _Nonnull context) __attribute__((swift_name("AudioSessionDeactivated(context:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVOAudioSessionDeactivated (void* context);
	}

	[Native]
	public enum TVOCallState : ulong
	{
		Connecting = 0,
		Ringing,
		Connected,
		Reconnecting,
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
	public enum TVOCallQualityWarning : ulong
	{
		HighRtt = 0,
		HighJitter,
		HighPacketsLostFraction,
		LowMos,
		ConstantAudioInputLevel
	}

	[Native]
	public enum TVOError : long
	{
		ErrorAccessTokenInvalidError = 20101,
		ErrorAccessTokenHeaderInvalidError = 20102,
		ErrorAccessTokenIssuerInvalidError = 20103,
		ErrorAccessTokenExpiredError = 20104,
		ErrorAccessTokenNotYetValidError = 20105,
		ErrorAccessTokenGrantsInvalidError = 20106,
		ErrorAccessTokenSignatureInvalidError = 20107,
		ErrorAuthFailureCodeError = 20151,
		ErrorExpirationTimeExceedsMaxTimeAllowedError = 20157,
		ErrorAccessForbiddenError = 20403,
		ErrorApplicationNotFoundError = 21218,
		ErrorConnectionError = 31005,
		ErrorCallCancelledError = 31008,
		ErrorTransportError = 31009,
		ErrorMalformedRequestError = 31100,
		ErrorAuthorizationError = 31201,
		ErrorRegistrationError = 31301,
		ErrorUnsupportedCancelMessageError = 31302,
		ErrorBadRequestError = 31400,
		ErrorForbiddenError = 31403,
		ErrorNotFoundError = 31404,
		ErrorRequestTimeoutError = 31408,
		ErrorConflictError = 31409,
		ErrorUpgradeRequiredError = 31426,
		ErrorTooManyRequestsError = 31429,
		ErrorTemporarilyUnavailableError = 31480,
		ErrorCallDoesNotExistError = 31481,
		ErrorAddressIncompleteError = 31484,
		ErrorBusyHereError = 31486,
		ErrorRequestTerminatedError = 31487,
		ErrorInternalServerError = 31500,
		ErrorBadGatewayError = 31502,
		ErrorServiceUnavailableError = 31503,
		ErrorGatewayTimeoutError = 31504,
		ErrorDNSResolutionError = 31530,
		ErrorBusyEverywhereError = 31600,
		ErrorDeclineError = 31603,
		ErrorDoesNotExistAnywhereError = 31604,
		ErrorTokenAuthenticationRejected = 51007,
		ErrorSignalingConnectionDisconnectedError = 53001,
		ErrorMediaClientLocalDescFailedError = 53400,
		ErrorMediaServerLocalDescFailedError = 53401,
		ErrorMediaClientRemoteDescFailedError = 53402,
		ErrorMediaServerRemoteDescFailedError = 53403,
		ErrorMediaNoSupportedCodecError = 53404,
		ErrorMediaConnectionError = 53405,
		MediaDtlsTransportFailedErrorCode = 53407
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
