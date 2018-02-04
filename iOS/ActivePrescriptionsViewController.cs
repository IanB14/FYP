using System;
using CoreGraphics;
using System.Collections.Generic;
using UIKit;

namespace FYP.iOS
{
    public partial class ActivePrescriptionsViewController : UIViewController
    {
        UITableView table;

        public ActivePrescriptionsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var width = View.Bounds.Width;
            var height = View.Bounds.Height;

            table = new UITableView(new CGRect(25, 75, 275, 500));
            table.AutoresizingMask = UIViewAutoresizing.All;
            CreateTableItems();
            Add(table);
        }

        protected void CreateTableItems()
        {
            List<string> tableItems = new List<string>();
            tableItems.Add("Lexapro (Escitalopram)");
            tableItems.Add("Diazemuls (Diazepam)");
            tableItems.Add("Xanax (Alprazolam)");
            table.Source = new TableSource(tableItems.ToArray(), this);
        }
    }
}