using System;
using UIKit;
using CoreLocation;
using MapKit;

namespace FYP.iOS
{
    partial class pharmacyScreenViewController : UIViewController
    {
        MyMapDelegate mapDel;
        UISearchController searchController;
        CLLocationManager locationManager = new CLLocationManager();

        public pharmacyScreenViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            locationManager.RequestWhenInUseAuthorization();

            // set map type and show user location
            pharmacyMap.MapType = MKMapType.Standard;
            pharmacyMap.ShowsUserLocation = true;
            pharmacyMap.Bounds = View.Bounds;

            // set map center and region
            // These co-ordinates correspond to UL's Main Building
            // Region sets the view height
            const double lat = 52.67398493270342;
            const double lon = -8.571852478434721;
            var mapCenter = new CLLocationCoordinate2D(lat, lon);
            var mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 2000, 2000);
            pharmacyMap.CenterCoordinate = mapCenter;
            pharmacyMap.Region = mapRegion;

            // add an annotation
            pharmacyMap.AddAnnotation(new MKPointAnnotation
            {
                Title = "TestAnnotation - UCH",
                Coordinate = new CLLocationCoordinate2D(52.67441754129811, -8.573552998950163)
            });

            // set the map delegate
            mapDel = new MyMapDelegate();
            pharmacyMap.Delegate = mapDel;

            // add a custom annotation
            var customAnnotationLocation = 
                new CLLocationCoordinate2D(52.67329535225272, -8.573483261515776);
            pharmacyMap.AddAnnotation(new MonkeyAnnotation("Test", customAnnotationLocation));


            var searchResultsController = new SearchResultsViewController(pharmacyMap);


            var searchUpdater = new SearchResultsUpdator();
            searchUpdater.UpdateSearchResults += searchResultsController.Search;

            //add the search controller
            searchController = new UISearchController(searchResultsController)
            {
                SearchResultsUpdater = searchUpdater
            };

            searchController.SearchBar.SizeToFit();
            searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
            searchController.SearchBar.Placeholder = "Enter a search query";

            searchController.HidesNavigationBarDuringPresentation = false;
            NavigationItem.TitleView = searchController.SearchBar;
            DefinesPresentationContext = true;
        }

        public class SearchResultsUpdator : UISearchResultsUpdating
        {
            public event Action<string> UpdateSearchResults = delegate { };

            public override void UpdateSearchResultsForSearchController(UISearchController searchController)
            {
                this.UpdateSearchResults(searchController.SearchBar.Text);
            }
        }

        class MyMapDelegate : MKMapViewDelegate
        {
            string pId = "PinAnnotation";
            string mId = "MonkeyAnnotation";

            public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
            {
                MKAnnotationView anView;

                if (annotation is MKUserLocation)
                    return null;

                if (annotation is MonkeyAnnotation)
                {

                    // show monkey annotation
                    anView = mapView.DequeueReusableAnnotation(mId);

                    if (anView == null)
                        anView = new MKAnnotationView(annotation, mId);

                    anView.Image = UIImage.FromFile("pharmacyMapPinSMALL.png");
                    anView.CanShowCallout = true;
                    anView.Draggable = false;
                    anView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);

                }
                else
                {

                    // show pin annotation
                    anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);

                    if (anView == null)
                        anView = new MKPinAnnotationView(annotation, pId);

                    ((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Red;
                    anView.CanShowCallout = true;
                }

                return anView;
            }

            public override void CalloutAccessoryControlTapped(MKMapView mapView, MKAnnotationView view, UIControl control)
            {
                var monkeyAn = view.Annotation as MonkeyAnnotation;

                if (monkeyAn != null)
                {
                    var alert = new UIAlertView("Monkey Annotation", monkeyAn.Title, null, "OK");
                    alert.Show();
                }
            }

            public override MKOverlayView GetViewForOverlay(MKMapView mapView, IMKOverlay overlay)
            {
                var circleOverlay = overlay as MKCircle;
                var circleView = new MKCircleView(circleOverlay);
                circleView.FillColor = UIColor.Red;
                circleView.Alpha = 0.4f;
                return circleView;
            }
        }
    }
}