using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FYP.iOS
{
    public class CustomPrescriptionCell: UITableViewCell
    {
        UILabel headingLabel, subheadingLabel;

        public CustomPrescriptionCell(NSString cellID) : base(UITableViewCellStyle.Default, cellID)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;

            headingLabel = new UILabel(){
                TextColor = UIColor.FromRGB(128, 205, 61)
            };

            subheadingLabel = new UILabel(){
            TextColor = UIColor.Black
            };

            ContentView.Add(headingLabel);
            ContentView.Add(subheadingLabel);
        }


        public void UpdateCell(string caption, string subtitle)
        {
            headingLabel.Text = caption;
            subheadingLabel.Text = subtitle;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            headingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
            subheadingLabel.Frame = new CGRect(100, 18, 100, 20);
        }
    }
}
