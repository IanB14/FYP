using Foundation;
using System;
using UIKit;

namespace FYP.iOS
{
    public partial class MainMenu2 : UIViewController
    {
        public MainMenu2 (IntPtr handle) : base (handle)
        {
        }

        [Action("UnwindToMainMenu2:")]
        public void UnwindToMainMenu2(UIStoryboardSegue segue)
        {

        }
    }
}