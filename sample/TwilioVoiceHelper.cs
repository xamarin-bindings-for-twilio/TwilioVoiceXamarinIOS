using System;
using Foundation;
using Twilio.Voice.iOS;

namespace Sample
{
    public class TwilioVoiceHelper : IDisposable
    {
        #region Fields

        private CallDelegate _callDelegate;
        private NotificationDelegate _notificationDelegate;
        private string _registeredAccessToken;
        private NSData _registeredDeviceToken;

        #endregion

        #region Properties

        public TVOCallInvite CallInvite { get; private set; }
        public TVOCall Call { get; private set; }

        #endregion

        #region Events

        public event EventHandler Registered;
        public event EventHandler<NSError> RegisteredWithError;
        public event EventHandler CallInviteReceived;
        public event EventHandler CallDidConnect;
        public event EventHandler<NSError> CallDidDisconnectWithError;
        public event EventHandler<NSError> CallDidFailToConnectWithError;
        public event EventHandler<(TVOCancelledCallInvite, NSError)> CancelledCallInviteReceived;

        #endregion

        #region Constructors

        public TwilioVoiceHelper()
        {
#if DEBUG
            TwilioVoiceSDK.LogLevel = TVOLogLevel.Debug;
#endif
            _callDelegate = CallDelegate.Instance;
            _notificationDelegate = NotificationDelegate.Instance;
            _callDelegate.CallDidConnectEvent -= CallDelegateOnCallDidConnectEvent;
            _callDelegate.CallDidDisconnectWithErrorEvent -= CallDelegateOnCallDidDisconnectWithError;
            _callDelegate.CallDidFailToConnectWithErrorEvent -= CallDelegateOnCallDidFailToConnectWithErrorEvent;
            _notificationDelegate.CallInviteReceivedEvent -= NotificationDelegateOnCallInviteReceivedEvent;
            _notificationDelegate.CancelledCallInviteReceivedEvent -= NotificationDelegateOnCancelledCallInviteReceivedEvent;

            _callDelegate.CallDidConnectEvent += CallDelegateOnCallDidConnectEvent;
            _callDelegate.CallDidDisconnectWithErrorEvent += CallDelegateOnCallDidDisconnectWithError;
            _callDelegate.CallDidFailToConnectWithErrorEvent += CallDelegateOnCallDidFailToConnectWithErrorEvent;
            _notificationDelegate.CallInviteReceivedEvent += NotificationDelegateOnCallInviteReceivedEvent;
            _notificationDelegate.CancelledCallInviteReceivedEvent += NotificationDelegateOnCancelledCallInviteReceivedEvent;
        }

        #endregion

        #region Methods

        public void Register(string accessToken, NSData deviceToken)
        {
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(Register), $"AccessToken: {accessToken}, DeviceToken: {deviceToken}");
            if (accessToken == null || deviceToken == null) return;
            TwilioVoiceSDK.RegisterWithAccessToken(accessToken, deviceToken,
                                                error =>
                                                {
                                                    if (error == null)
                                                    {
                                                        Console.WriteLine("Successfully registered for VoIP push notifications");
                                                        _registeredAccessToken = accessToken;
                                                        _registeredDeviceToken = deviceToken;
                                                        Registered?.Invoke(this, EventArgs.Empty);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"An error occurred while registering: {error.LocalizedDescription}");
                                                        RegisteredWithError?.Invoke(this, error);
                                                    }
                                                });
        }

        public void Unregister()
        {
            if (_registeredAccessToken == null || _registeredDeviceToken == null) return;
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(Unregister));
            TwilioVoiceSDK.UnregisterWithAccessToken(_registeredAccessToken, _registeredDeviceToken,
                                                error =>
                                                {
                                                    if (error == null)
                                                    {
                                                        Console.WriteLine("Successfully unregistered for VoIP push notifications");
                                                        _registeredAccessToken = null;
                                                        _registeredDeviceToken = null;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"An error occurred while unregistering: {error.LocalizedDescription}");
                                                    }
                                                });
        }

        public void MakeCall(string accessToken, NSDictionary<NSString, NSString> parameters)
        {
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(MakeCall));
            if (accessToken == null || Call != null) return;
            var connectionOptions = TVOConnectOptions.OptionsWithAccessToken(accessToken,
                (arg0) =>
                {
                    arg0.Params = parameters;
                });
            Call = TwilioVoiceSDK.ConnectWithOptions(connectionOptions, _callDelegate);
        }

        public void RejectCallInvite()
        {
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(RejectCallInvite));
            CallInvite?.Reject();
            CallInvite = null;
        }

        public void IgnoreCallInvite()
        {
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(IgnoreCallInvite));
            CallInvite = null;
        }

        public void AcceptCallInvite()
        {
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(AcceptCallInvite));
            Call = CallInvite?.AcceptWithDelegate(_callDelegate);
            CallInvite = null;
        }

        public void Dispose()
        {
            if (CallInvite != null)
            {
                CallInvite.Reject();
                CallInvite.Dispose();
                CallInvite = null;
            }

            if (Call != null)
            {
                Call.Disconnect();
                Call.Dispose();
                Call = null;
            }

            if (_callDelegate != null)
            {
                _callDelegate.CallDidConnectEvent -= CallDelegateOnCallDidConnectEvent;
                _callDelegate.CallDidDisconnectWithErrorEvent -= CallDelegateOnCallDidDisconnectWithError;
                _callDelegate.CallDidFailToConnectWithErrorEvent -= CallDelegateOnCallDidFailToConnectWithErrorEvent;
                _callDelegate = null;
            }

            if (_notificationDelegate != null)
            {
                _notificationDelegate.CallInviteReceivedEvent -= NotificationDelegateOnCallInviteReceivedEvent;
                _notificationDelegate.CancelledCallInviteReceivedEvent += NotificationDelegateOnCancelledCallInviteReceivedEvent;
                _notificationDelegate = null;
            }
        }

        #endregion

        #region Event handlers

        private void CallDelegateOnCallDidConnectEvent(object sender, TVOCall e)
        {
            Call = e;
            CallDidConnect?.Invoke(this, EventArgs.Empty);
        }

        private void CallDelegateOnCallDidDisconnectWithError(object sender, (TVOCall call, NSError error) e)
        {
            if (e.error == null)
                Console.WriteLine("Call disconnected");
            else
                Console.WriteLine($"Call failed: {e.error.LocalizedDescription}");
            Call = null;
            CallDidDisconnectWithError?.Invoke(this, e.error);
        }

        private void CallDelegateOnCallDidFailToConnectWithErrorEvent(object sender, (TVOCall call, NSError error) e)
        {
            Call = null;
            CallDidFailToConnectWithError?.Invoke(this, e.error);
        }

        private void NotificationDelegateOnCallInviteReceivedEvent(object sender, TVOCallInvite e)
        {
            Console.WriteLine(nameof(TwilioVoiceHelper), nameof(NotificationDelegateOnCallInviteReceivedEvent));
            if (CallInvite != null)
            {
                Console.WriteLine($"Already a pending call invite. Ignoring incoming call invite from {e.From}");
                return;
            }
            if (Call != null && Call.State == TVOCallState.Connected)
            {
                Console.WriteLine($"Already an active call. Ignoring incoming call invite from {e.From}");
                return;
            }

            CallInvite = e;
            CallInviteReceived?.Invoke(this, EventArgs.Empty);
        }

        private void NotificationDelegateOnCancelledCallInviteReceivedEvent(object sender, (TVOCancelledCallInvite e, NSError error) invite)
        {
            // We've already accepted the invite.
            if (Call != null) return;
            CancelledCallInviteReceived?.Invoke(this, (invite.e, invite.error));
        }

        #endregion
    }
}
