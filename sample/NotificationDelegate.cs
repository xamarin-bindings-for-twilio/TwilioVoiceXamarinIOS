using System;
using Foundation;
using Twilio.Voice.iOS;

namespace Sample
{
    public class NotificationDelegate : TVONotificationDelegate
    {
        #region Fields

        private static NotificationDelegate _instance;

        #endregion

        #region Properties

        public static NotificationDelegate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NotificationDelegate();
                }

                return _instance;
            }
        }

        #endregion

        #region Events

        public event EventHandler<TVOCallInvite> CallInviteReceivedEvent;
        public event EventHandler<(TVOCancelledCallInvite, NSError)> CancelledCallInviteReceivedEvent;

        #endregion

        #region Methods

        [Export("callInviteReceived:")]
        public override void CallInviteReceived(TVOCallInvite callInvite)
        {
            Console.WriteLine(nameof(NotificationDelegate), nameof(CallInviteReceived));
            CallInviteReceivedEvent?.Invoke(this, callInvite);
        }

        [Export("cancelledCallInviteReceived:error:")]
        public override void CancelledCallInviteReceived(TVOCancelledCallInvite cancelledCallInvite, NSError error)
        {
            Console.WriteLine(nameof(NotificationDelegate), nameof(CancelledCallInviteReceived));
            CancelledCallInviteReceivedEvent?.Invoke(this, (cancelledCallInvite, error));
        }

        #endregion
    }
}
