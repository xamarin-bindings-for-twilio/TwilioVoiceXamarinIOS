using Foundation;
using System;
using UIKit;

namespace Sample
{
    public partial class ViewController : UIViewController
    {
        private TwilioVoiceHelper twilioVoiceHelper;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            twilioVoiceHelper = new TwilioVoiceHelper();

            //twilioVoiceHelper.MakeCall("token", new NSDictionary<NSString, NSString>());
            twilioVoiceHelper.Register("token", NSData.FromString(""));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
