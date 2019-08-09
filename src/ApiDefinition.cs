using System;
using AudioToolbox;
using CoreFoundation;
using Foundation;
using ObjCRuntime;

namespace Twilio.Voice.iOS
{
	// @interface TVOAudioCodec : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOAudioCodec
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	// @interface TVOIceServer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOIceServer
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull urlString;
		[Export ("urlString")]
		string UrlString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
		string Password { get; }

		// -(instancetype _Null_unspecified)initWithURLString:(NSString * _Nonnull)serverURLString;
		[Export ("initWithURLString:")]
		IntPtr Constructor (string serverURLString);

		// -(instancetype _Null_unspecified)initWithURLString:(NSString * _Nonnull)serverURLString username:(NSString * _Nullable)username password:(NSString * _Nullable)password;
		[Export ("initWithURLString:username:password:")]
		IntPtr Constructor (string serverURLString, [NullAllowed] string username, [NullAllowed] string password);
	}

	// @interface TVOIceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOIceOptionsBuilder
	{
		// @property (nonatomic, strong) NSArray<TVOIceServer *> * _Nullable servers;
		[NullAllowed, Export ("servers", ArgumentSemantic.Strong)]
		TVOIceServer[] Servers { get; set; }

		// @property (assign, nonatomic) TVOIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		TVOIceTransportPolicy TransportPolicy { get; set; }
	}

	// typedef void (^TVOIceOptionsBuilderBlock)(TVOIceOptionsBuilder * _Nonnull);
	delegate void TVOIceOptionsBuilderBlock (TVOIceOptionsBuilder arg0);

	// @interface TVOIceOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVOIceOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<TVOIceServer *> * _Nonnull servers;
		[Export ("servers", ArgumentSemantic.Copy)]
		TVOIceServer[] Servers { get; }

		// @property (readonly, assign, nonatomic) TVOIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		TVOIceTransportPolicy TransportPolicy { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVOIceOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVOIceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVOIceOptions OptionsWithBlock (TVOIceOptionsBuilderBlock block);
	}

	// @interface TVOCallOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCallOptionsBuilder
	{
		// @property (nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; set; }

		// @property (nonatomic, strong) TVOIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		TVOIceOptions IceOptions { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull region;
		[Export ("region")]
		string Region { get; set; }

		// @property (copy, nonatomic) NSArray<TVOAudioCodec *> * _Nonnull preferredAudioCodecs;
		[Export ("preferredAudioCodecs", ArgumentSemantic.Copy)]
		TVOAudioCodec[] PreferredAudioCodecs { get; set; }

		// @property (assign, nonatomic) BOOL enableInsights;
		[Export ("enableInsights")]
		bool EnableInsights { get; set; }
	}

	// @interface CallKit (TVOCallOptionsBuilder)
	[Category]
	[BaseType (typeof(TVOCallOptionsBuilder))]
	interface TVOCallOptionsBuilder_CallKit
	{
		// @property (nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid GetUuid ();

		[NullAllowed, Export ("setUuid:", ArgumentSemantic.Strong)]
		void SetUuid (NSUuid uuid);
	}

	// @interface TVOCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCallOptions
	{
		// @property (readonly, nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; }

		// @property (readonly, nonatomic, strong) TVOIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		TVOIceOptions IceOptions { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull region;
		[Export ("region")]
		string Region { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVOAudioCodec *> * _Nonnull preferredAudioCodecs;
		[Export ("preferredAudioCodecs", ArgumentSemantic.Copy)]
		TVOAudioCodec[] PreferredAudioCodecs { get; }

		// @property (readonly, assign, nonatomic) BOOL enableInsights;
		[Export ("enableInsights")]
		bool EnableInsights { get; }
	}

	// @interface CallKit (TVOCallOptions)
	[Category]
	[BaseType (typeof(TVOCallOptions))]
	interface TVOCallOptions_CallKit
	{
		// @property (readonly, nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid GetUuid ();
	}

	// @interface TVOAcceptOptionsBuilder : TVOCallOptionsBuilder
	[BaseType (typeof(TVOCallOptionsBuilder))]
	[DisableDefaultCtor]
	interface TVOAcceptOptionsBuilder
	{
	}

	// typedef void (^TVOAcceptOptionsBuilderBlock)(TVOAcceptOptionsBuilder * _Nonnull);
	delegate void TVOAcceptOptionsBuilderBlock (TVOAcceptOptionsBuilder arg0);

	// @interface TVOAcceptOptions : TVOCallOptions
	[BaseType (typeof(TVOCallOptions))]
	[DisableDefaultCtor]
	interface TVOAcceptOptions
	{
		// +(instancetype _Nonnull)optionsWithCallInvite:(TVOCallInvite * _Nonnull)callInvite;
		[Static]
		[Export ("optionsWithCallInvite:")]
		TVOAcceptOptions OptionsWithCallInvite (TVOCallInvite callInvite);

		// +(instancetype _Nonnull)optionsWithCallInvite:(TVOCallInvite * _Nonnull)callInvite block:(TVOAcceptOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithCallInvite:block:")]
		TVOAcceptOptions OptionsWithCallInvite (TVOCallInvite callInvite, TVOAcceptOptionsBuilderBlock block);
	}

	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const uint32_t TVOAudioSampleRate8000;
		[Field ("TVOAudioSampleRate8000", "__Internal")]
		uint TVOAudioSampleRate8000 { get; }

		// extern const uint32_t TVOAudioSampleRate16000;
		[Field ("TVOAudioSampleRate16000", "__Internal")]
		uint TVOAudioSampleRate16000 { get; }

		// extern const uint32_t TVOAudioSampleRate24000;
		[Field ("TVOAudioSampleRate24000", "__Internal")]
		uint TVOAudioSampleRate24000 { get; }

		// extern const uint32_t TVOAudioSampleRate32000;
		[Field ("TVOAudioSampleRate32000", "__Internal")]
		uint TVOAudioSampleRate32000 { get; }

		// extern const uint32_t TVOAudioSampleRate44100;
		[Field ("TVOAudioSampleRate44100", "__Internal")]
		uint TVOAudioSampleRate44100 { get; }

		// extern const uint32_t TVOAudioSampleRate48000;
		[Field ("TVOAudioSampleRate48000", "__Internal")]
		uint TVOAudioSampleRate48000 { get; }

		// extern const size_t TVOAudioChannelsMono;
		[Field ("TVOAudioChannelsMono", "__Internal")]
		ulong TVOAudioChannelsMono { get; }

		// extern const size_t TVOAudioChannelsStereo;
		[Field ("TVOAudioChannelsStereo", "__Internal")]
		ulong TVOAudioChannelsStereo { get; }
	}

	// @interface TVOAudioFormat : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOAudioFormat
	{
		// @property (readonly, assign, nonatomic) size_t numberOfChannels;
		[Export ("numberOfChannels")]
		ulong NumberOfChannels { get; }

		// @property (readonly, assign, nonatomic) uint32_t sampleRate;
		[Export ("sampleRate")]
		uint SampleRate { get; }

		// @property (readonly, assign, nonatomic) size_t framesPerBuffer;
		[Export ("framesPerBuffer")]
		ulong FramesPerBuffer { get; }

		// -(instancetype _Nullable)initWithChannels:(size_t)channels sampleRate:(uint32_t)sampleRate framesPerBuffer:(size_t)framesPerBuffer;
		[Export ("initWithChannels:sampleRate:framesPerBuffer:")]
		IntPtr Constructor (nuint channels, uint sampleRate, ulong framesPerBuffer);

		// -(size_t)bufferSize;
		[Export ("bufferSize")]
		//[Verify (MethodToProperty)]
		ulong BufferSize { get; }

		// -(AudioStreamBasicDescription)streamDescription;
		[Export ("streamDescription")]
		//[Verify (MethodToProperty)]
		AudioStreamBasicDescription StreamDescription { get; }
	}

	// typedef void (^TVOAudioDeviceWorkerBlock)();
	delegate void TVOAudioDeviceWorkerBlock ();

	// @protocol TVOAudioDeviceRenderer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVOAudioDeviceRenderer
	{
		// @required -(TVOAudioFormat * _Nullable)renderFormat;
		[Abstract]
		[NullAllowed, Export ("renderFormat")]
		//[Verify (MethodToProperty)]
		TVOAudioFormat RenderFormat { get; }

		// @required -(BOOL)initializeRenderer;
		[Abstract]
		[Export ("initializeRenderer")]
		//[Verify (MethodToProperty)]
		bool InitializeRenderer { get; }

		// @required -(BOOL)startRendering:(TVOAudioDeviceContext _Nonnull)context;
		[Abstract]
		[Export ("startRendering:")]
		unsafe bool StartRendering (IntPtr context);

		// @required -(BOOL)stopRendering;
		[Abstract]
		[Export ("stopRendering")]
		//[Verify (MethodToProperty)]
		bool StopRendering { get; }
	}

	// @protocol TVOAudioDeviceCapturer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVOAudioDeviceCapturer
	{
		// @required -(TVOAudioFormat * _Nullable)captureFormat;
		[Abstract]
		[NullAllowed, Export ("captureFormat")]
		//Verify (MethodToProperty)]
		TVOAudioFormat CaptureFormat { get; }

		// @required -(BOOL)initializeCapturer;
		[Abstract]
		[Export ("initializeCapturer")]
		//[Verify (MethodToProperty)]
		bool InitializeCapturer { get; }

		// @required -(BOOL)startCapturing:(TVOAudioDeviceContext _Nonnull)context;
		[Abstract]
		[Export ("startCapturing:")]
		unsafe bool StartCapturing (IntPtr context);

		// @required -(BOOL)stopCapturing;
		[Abstract]
		[Export ("stopCapturing")]
		//[Verify (MethodToProperty)]
		bool StopCapturing { get; }
	}

	// @protocol TVOAudioDevice <TVOAudioDeviceRenderer, TVOAudioDeviceCapturer>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVOAudioDevice : TVOAudioDeviceRenderer, TVOAudioDeviceCapturer
	{
	}

    interface ITVOAudioDevice { }

	// @interface TVOBaseTrackStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOBaseTrackStats
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackId;
		[Export ("trackId")]
		string TrackId { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsLost;
		[Export ("packetsLost")]
		nuint PacketsLost { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull codec;
		[Export ("codec")]
		string Codec { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull ssrc;
		[Export ("ssrc")]
		string Ssrc { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }
	}

	// typedef void (^TVOCallGetStatsBlock)(NSArray<TVOStatsReport *> * _Nonnull);
	delegate void TVOCallGetStatsBlock (TVOStatsReport[] arg0);

	// @interface TVOCall : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCall
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable from;
		[NullAllowed, Export ("from", ArgumentSemantic.Strong)]
		string From { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable to;
		[NullAllowed, Export ("to", ArgumentSemantic.Strong)]
		string To { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sid;
		[Export ("sid", ArgumentSemantic.Strong)]
		string Sid { get; }

		// @property (getter = isMuted, assign, nonatomic) BOOL muted;
		[Export ("muted")]
		bool Muted { [Bind ("isMuted")] get; set; }

		// @property (readonly, assign, nonatomic) TVOCallState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVOCallState State { get; }

		// @property (getter = isOnHold, nonatomic) BOOL onHold;
		[Export ("onHold")]
		bool OnHold { [Bind ("isOnHold")] get; set; }

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)sendDigits:(NSString * _Nonnull)digits;
		[Export ("sendDigits:")]
		void SendDigits (string digits);

		// -(void)getStatsWithBlock:(TVOCallGetStatsBlock _Nonnull)block;
		[Export ("getStatsWithBlock:")]
		void GetStatsWithBlock (TVOCallGetStatsBlock block);

		// -(void)postFeedback:(TVOCallFeedbackScore)score issue:(TVOCallFeedbackIssue)issue;
		[Export ("postFeedback:issue:")]
		void PostFeedback (TVOCallFeedbackScore score, TVOCallFeedbackIssue issue);
	}

	// @interface CallKit (TVOCall)
	[Category]
	[BaseType (typeof(TVOCall))]
	interface TVOCall_CallKit
	{
		// @property (readonly, nonatomic, strong) NSUUID * _Nonnull uuid;
		[Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid GetUuid ();
	}

	// @protocol TVOCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVOCallDelegate
	{
		// @required -(void)callDidConnect:(TVOCall * _Nonnull)call;
		[Abstract]
		[Export ("callDidConnect:")]
		void CallDidConnect (TVOCall call);

		// @required -(void)call:(TVOCall * _Nonnull)call didFailToConnectWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("call:didFailToConnectWithError:")]
		void CallDidFailToConnectWithError (TVOCall call, NSError error);

		// @required -(void)call:(TVOCall * _Nonnull)call didDisconnectWithError:(NSError * _Nullable)error;
		[Abstract]
		[Export ("call:didDisconnectWithError:")]
		void CallDidDisconnectWithError (TVOCall call, [NullAllowed] NSError error);

		// @optional -(void)callDidStartRinging:(TVOCall * _Nonnull)call;
		[Export ("callDidStartRinging:")]
		void CallDidStartRinging (TVOCall call);

		// @optional -(void)call:(TVOCall * _Nonnull)call isReconnectingWithError:(NSError * _Nonnull)error;
		[Export ("call:isReconnectingWithError:")]
		void CallIsReconnectingWithError (TVOCall call, NSError error);

		// @optional -(void)callDidReconnect:(TVOCall * _Nonnull)call;
		[Export ("callDidReconnect:")]
		void CallDidReconnect (TVOCall call);
	}

	// @interface TVOCallInvite : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCallInvite
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable from;
		[NullAllowed, Export ("from")]
		string From { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull to;
		[Export ("to")]
		string To { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull callSid;
		[Export ("callSid")]
		string CallSid { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nullable customParameters;
		[NullAllowed, Export ("customParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> CustomParameters { get; }

		// -(TVOCall * _Nonnull)acceptWithDelegate:(id<TVOCallDelegate> _Nonnull)delegate;
		[Export ("acceptWithDelegate:")]
		TVOCall AcceptWithDelegate (TVOCallDelegate @delegate);

		// -(TVOCall * _Nonnull)acceptWithOptions:(TVOAcceptOptions * _Nonnull)options delegate:(id<TVOCallDelegate> _Nonnull)delegate;
		[Export ("acceptWithOptions:delegate:")]
		TVOCall AcceptWithOptions (TVOAcceptOptions options, TVOCallDelegate @delegate);

		// -(void)reject;
		[Export ("reject")]
		void Reject ();
	}

	// @interface CallKit (TVOCallInvite)
	[Category]
	[BaseType (typeof(TVOCallInvite))]
	interface TVOCallInvite_CallKit
	{
		// @property (readonly, copy, nonatomic) NSUUID * _Nonnull uuid;
		[Export ("uuid", ArgumentSemantic.Copy)]
		NSUuid GetUuid ();
	}

	// @interface TVOCancelledCallInvite : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCancelledCallInvite
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable from;
		[NullAllowed, Export ("from")]
		string From { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull to;
		[Export ("to")]
		string To { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull callSid;
		[Export ("callSid")]
		string CallSid { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nullable customParameters;
		[NullAllowed, Export ("customParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> CustomParameters { get; }
	}

	// @interface TVOConnectOptionsBuilder : TVOCallOptionsBuilder
	[BaseType (typeof(TVOCallOptionsBuilder))]
	[DisableDefaultCtor]
	interface TVOConnectOptionsBuilder
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull params;
		[Export ("params", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Params { get; set; }
	}

	// typedef void (^TVOConnectOptionsBuilderBlock)(TVOConnectOptionsBuilder * _Nonnull);
	delegate void TVOConnectOptionsBuilderBlock (TVOConnectOptionsBuilder arg0);

	// @interface TVOConnectOptions : TVOCallOptions
	[BaseType (typeof(TVOCallOptions))]
	[DisableDefaultCtor]
	interface TVOConnectOptions
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable accessToken;
		[NullAllowed, Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull params;
		[Export ("params", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Params { get; }

		// +(instancetype _Nonnull)optionsWithAccessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("optionsWithAccessToken:")]
		TVOConnectOptions OptionsWithAccessToken (string accessToken);

		// +(instancetype _Nonnull)optionsWithAccessToken:(NSString * _Nonnull)accessToken block:(TVOConnectOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithAccessToken:block:")]
		TVOConnectOptions OptionsWithAccessToken (string accessToken, TVOConnectOptionsBuilderBlock block);
	}

	// typedef void (^TVOAVAudioSessionConfigurationBlock)();
	delegate void TVOAVAudioSessionConfigurationBlock ();

	// @interface TVODefaultAudioDevice : NSObject <TVOAudioDevice>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVODefaultAudioDevice : TVOAudioDevice
	{
		// @property (copy, nonatomic) TVOAVAudioSessionConfigurationBlock _Nonnull block;
		[Export ("block", ArgumentSemantic.Copy)]
		TVOAVAudioSessionConfigurationBlock Block { get; set; }

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// +(instancetype _Nonnull)audioDevice;
		[Static]
		[Export ("audioDevice")]
		TVODefaultAudioDevice AudioDevice ();

		// +(instancetype _Nonnull)audioDeviceWithBlock:(TVOAVAudioSessionConfigurationBlock _Nonnull)block;
		[Static]
		[Export ("audioDeviceWithBlock:")]
		TVODefaultAudioDevice AudioDeviceWithBlock (TVOAVAudioSessionConfigurationBlock block);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kTVOErrorDomain;
		[Field ("kTVOErrorDomain", "__Internal")]
		NSString kTVOErrorDomain { get; }
	}

	// @interface TVOIceCandidatePairStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOIceCandidatePairStats
	{
		// @property (readonly, getter = isActiveCandidatePair, assign, nonatomic) BOOL activeCandidatePair;
		[Export ("activeCandidatePair")]
		bool ActiveCandidatePair { [Bind ("isActiveCandidatePair")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable relayProtocol;
		[NullAllowed, Export ("relayProtocol")]
		string RelayProtocol { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transportId;
		[NullAllowed, Export ("transportId")]
		string TransportId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localCandidateId;
		[NullAllowed, Export ("localCandidateId")]
		string LocalCandidateId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localCandidateIp;
		[NullAllowed, Export ("localCandidateIp")]
		string LocalCandidateIp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteCandidateId;
		[NullAllowed, Export ("remoteCandidateId")]
		string RemoteCandidateId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteCandidateIp;
		[NullAllowed, Export ("remoteCandidateIp")]
		string RemoteCandidateIp { get; }

		// @property (readonly, assign, nonatomic) TVOIceCandidatePairState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVOIceCandidatePairState State { get; }

		// @property (readonly, assign, nonatomic) uint64_t priority;
		[Export ("priority")]
		ulong Priority { get; }

		// @property (readonly, getter = isNominated, assign, nonatomic) BOOL nominated;
		[Export ("nominated")]
		bool Nominated { [Bind ("isNominated")] get; }

		// @property (readonly, getter = isWritable, assign, nonatomic) BOOL writable;
		[Export ("writable")]
		bool Writable { [Bind ("isWritable")] get; }

		// @property (readonly, getter = isReadable, assign, nonatomic) BOOL readable;
		[Export ("readable")]
		bool Readable { [Bind ("isReadable")] get; }

		// @property (readonly, assign, nonatomic) uint64_t bytesSent;
		[Export ("bytesSent")]
		ulong BytesSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t bytesReceived;
		[Export ("bytesReceived")]
		ulong BytesReceived { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval totalRoundTripTime;
		[Export ("totalRoundTripTime")]
		double TotalRoundTripTime { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval currentRoundTripTime;
		[Export ("currentRoundTripTime")]
		double CurrentRoundTripTime { get; }

		// @property (readonly, assign, nonatomic) double availableOutgoingBitrate;
		[Export ("availableOutgoingBitrate")]
		double AvailableOutgoingBitrate { get; }

		// @property (readonly, assign, nonatomic) double availableIncomingBitrate;
		[Export ("availableIncomingBitrate")]
		double AvailableIncomingBitrate { get; }

		// @property (readonly, assign, nonatomic) uint64_t requestsReceived;
		[Export ("requestsReceived")]
		ulong RequestsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t requestsSent;
		[Export ("requestsSent")]
		ulong RequestsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t responsesReceived;
		[Export ("responsesReceived")]
		ulong ResponsesReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t responsesSent;
		[Export ("responsesSent")]
		ulong ResponsesSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t retransmissionsReceived;
		[Export ("retransmissionsReceived")]
		ulong RetransmissionsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t retransmissionsSent;
		[Export ("retransmissionsSent")]
		ulong RetransmissionsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentRequestsReceived;
		[Export ("consentRequestsReceived")]
		ulong ConsentRequestsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentRequestsSent;
		[Export ("consentRequestsSent")]
		ulong ConsentRequestsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentResponsesReceived;
		[Export ("consentResponsesReceived")]
		ulong ConsentResponsesReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentResponsesSent;
		[Export ("consentResponsesSent")]
		ulong ConsentResponsesSent { get; }
	}

	// @interface TVOIceCandidateStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOIceCandidateStats
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable candidateType;
		[NullAllowed, Export ("candidateType")]
		string CandidateType { get; }

		// @property (readonly, getter = isDeleted, assign, nonatomic) BOOL deleted;
		[Export ("deleted")]
		bool Deleted { [Bind ("isDeleted")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable ip;
		[NullAllowed, Export ("ip")]
		string Ip { get; }

		// @property (readonly, getter = isRemote, assign, nonatomic) BOOL remote;
		[Export ("remote")]
		bool Remote { [Bind ("isRemote")] get; }

		// @property (readonly, assign, nonatomic) long port;
		[Export ("port")]
		nint Port { get; }

		// @property (readonly, assign, nonatomic) long priority;
		[Export ("priority")]
		nint Priority { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable protocol;
		[NullAllowed, Export ("protocol")]
		string Protocol { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transportId;
		[NullAllowed, Export ("transportId")]
		string TransportId { get; }
	}

	// @interface TVOLocalTrackStats : TVOBaseTrackStats
	[BaseType (typeof(TVOBaseTrackStats))]
	[DisableDefaultCtor]
	interface TVOLocalTrackStats
	{
		// @property (readonly, assign, nonatomic) int64_t bytesSent;
		[Export ("bytesSent")]
		long BytesSent { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsSent;
		[Export ("packetsSent")]
		nuint PacketsSent { get; }

		// @property (readonly, assign, nonatomic) int64_t roundTripTime;
		[Export ("roundTripTime")]
		long RoundTripTime { get; }
	}

	// @interface TVOLocalAudioTrackStats : TVOLocalTrackStats
	[BaseType (typeof(TVOLocalTrackStats))]
	[DisableDefaultCtor]
	interface TVOLocalAudioTrackStats
	{
		// @property (readonly, assign, nonatomic) NSUInteger audioLevel;
		[Export ("audioLevel")]
		nuint AudioLevel { get; }

		// @property (readonly, assign, nonatomic) NSUInteger jitter;
		[Export ("jitter")]
		nuint Jitter { get; }
	}

	// @protocol TVONotificationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVONotificationDelegate
	{
		// @required -(void)callInviteReceived:(TVOCallInvite * _Nonnull)callInvite;
		[Abstract]
		[Export ("callInviteReceived:")]
		void CallInviteReceived (TVOCallInvite callInvite);

		// @required -(void)cancelledCallInviteReceived:(TVOCancelledCallInvite * _Nonnull)cancelledCallInvite;
		[Abstract]
		[Export ("cancelledCallInviteReceived:")]
		void CancelledCallInviteReceived (TVOCancelledCallInvite cancelledCallInvite);
	}

	// @interface TVOOpusCodec : TVOAudioCodec
	[BaseType (typeof(TVOAudioCodec))]
	interface TVOOpusCodec
	{
		// -(instancetype _Null_unspecified)initWithMaxAverageBitrate:(NSUInteger)maxAverageBitrate;
		[Export ("initWithMaxAverageBitrate:")]
		IntPtr Constructor (nuint maxAverageBitrate);

		// @property (readonly, assign, nonatomic) NSUInteger maxAverageBitrate;
		[Export ("maxAverageBitrate")]
		nuint MaxAverageBitrate { get; }
	}

	// @interface TVOPcmuCodec : TVOAudioCodec
	[BaseType (typeof(TVOAudioCodec))]
	interface TVOPcmuCodec
	{
	}

	// @interface TVORemoteTrackStats : TVOBaseTrackStats
	[BaseType (typeof(TVOBaseTrackStats))]
	[DisableDefaultCtor]
	interface TVORemoteTrackStats
	{
		// @property (readonly, assign, nonatomic) int64_t bytesReceived;
		[Export ("bytesReceived")]
		long BytesReceived { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsReceived;
		[Export ("packetsReceived")]
		nuint PacketsReceived { get; }
	}

	// @interface TVORemoteAudioTrackStats : TVORemoteTrackStats
	[BaseType (typeof(TVORemoteTrackStats))]
	[DisableDefaultCtor]
	interface TVORemoteAudioTrackStats
	{
		// @property (readonly, assign, nonatomic) NSUInteger audioLevel;
		[Export ("audioLevel")]
		nuint AudioLevel { get; }

		// @property (readonly, assign, nonatomic) NSUInteger jitter;
		[Export ("jitter")]
		nuint Jitter { get; }
	}

	// @interface TVOStatsReport : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOStatsReport
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull peerConnectionId;
		[Export ("peerConnectionId")]
		string PeerConnectionId { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVOLocalAudioTrackStats *> * _Nonnull localAudioTrackStats;
		[Export ("localAudioTrackStats", ArgumentSemantic.Strong)]
		TVOLocalAudioTrackStats[] LocalAudioTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVORemoteAudioTrackStats *> * _Nonnull remoteAudioTrackStats;
		[Export ("remoteAudioTrackStats", ArgumentSemantic.Strong)]
		TVORemoteAudioTrackStats[] RemoteAudioTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVOIceCandidateStats *> * _Nonnull iceCandidateStats;
		[Export ("iceCandidateStats", ArgumentSemantic.Strong)]
		TVOIceCandidateStats[] IceCandidateStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVOIceCandidatePairStats *> * _Nonnull iceCandidatePairStats;
		[Export ("iceCandidatePairStats", ArgumentSemantic.Strong)]
		TVOIceCandidatePairStats[] IceCandidatePairStats { get; }
	}

	// @interface TwilioVoice : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TwilioVoice
	{
		// @property (assign, nonatomic, class) TVOLogLevel logLevel;
		[Static]
		[Export ("logLevel", ArgumentSemantic.Assign)]
		TVOLogLevel LogLevel { get; set; }

		// @property (nonatomic, strong, class) id<TVOAudioDevice> _Nonnull audioDevice;
		[Static]
		[Export ("audioDevice", ArgumentSemantic.Strong)]
		ITVOAudioDevice AudioDevice { get; set; }

		// +(NSString * _Nonnull)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		//[Verify (MethodToProperty)]
		string SdkVersion { get; }

		// +(void)setLogLevel:(TVOLogLevel)logLevel module:(TVOLogModule)module;
		[Static]
		[Export ("setLogLevel:module:")]
		void SetLogLevel (TVOLogLevel logLevel, TVOLogModule module);

		// +(TVOLogLevel)logLevelForModule:(TVOLogModule)module;
		[Static]
		[Export ("logLevelForModule:")]
		TVOLogLevel LogLevelForModule (TVOLogModule module);

		// +(void)registerWithAccessToken:(NSString * _Nonnull)accessToken deviceToken:(NSString * _Nonnull)deviceToken completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Static]
		[Export ("registerWithAccessToken:deviceToken:completion:")]
		void RegisterWithAccessToken (string accessToken, string deviceToken, [NullAllowed] Action<NSError> completion);

		// +(void)unregisterWithAccessToken:(NSString * _Nonnull)accessToken deviceToken:(NSString * _Nonnull)deviceToken completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Static]
		[Export ("unregisterWithAccessToken:deviceToken:completion:")]
		void UnregisterWithAccessToken (string accessToken, string deviceToken, [NullAllowed] Action<NSError> completion);

		// +(BOOL)handleNotification:(NSDictionary * _Nonnull)payload delegate:(id<TVONotificationDelegate> _Nonnull)delegate;
		[Static]
		[Export ("handleNotification:delegate:")]
		bool HandleNotification (NSDictionary payload, TVONotificationDelegate @delegate);

		// +(TVOCall * _Nonnull)connectWithAccessToken:(NSString * _Nonnull)accessToken delegate:(id<TVOCallDelegate> _Nonnull)delegate;
		[Static]
		[Export ("connectWithAccessToken:delegate:")]
		TVOCall ConnectWithAccessToken (string accessToken, TVOCallDelegate @delegate);

		// +(TVOCall * _Nonnull)connectWithOptions:(TVOConnectOptions * _Nonnull)options delegate:(id<TVOCallDelegate> _Nonnull)delegate;
		[Static]
		[Export ("connectWithOptions:delegate:")]
		TVOCall ConnectWithOptions (TVOConnectOptions options, TVOCallDelegate @delegate);
	}

	// @interface CallKitIntegration (TwilioVoice)
	[Category]
	[BaseType (typeof(TwilioVoice))]
	interface TwilioVoice_CallKitIntegration
	{
	}
}
