using System;

using UIKit;

namespace FYP.iOS.ViewControllers
{
    public partial class mainViewController : UIViewController
    {
        public mainViewController(IntPtr p) : base("mainViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

