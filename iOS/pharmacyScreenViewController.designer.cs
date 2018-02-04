// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FYP.iOS
{
    [Register ("pharmacyScreenViewController")]
    partial class pharmacyScreenViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView pharmacyMap { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (pharmacyMap != null) {
                pharmacyMap.Dispose ();
                pharmacyMap = null;
            }
        }
    }
}