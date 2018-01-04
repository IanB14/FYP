using Foundation;
using System;
using UIKit;

namespace FYP.iOS
{
    public partial class LoginScreen : UIViewController
    {
        public LoginScreen (IntPtr handle) : base (handle)
        {
        }

        [Action("UnwindToLoginScreen:")]
        public void UnwindToLoginScreen(UIStoryboardSegue segue)
        {

        }
    }
}