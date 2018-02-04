using System;
using UIKit;
using Foundation;


namespace FYP.iOS
{
    public class PrescriptionRootTableSource: UITableViewSource
    {

        Prescriptions[] tableItems;
        string cellIdentifier = "prescriptionCell";

        public PrescriptionRootTableSource(Prescriptions[] items)
        {
            tableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier);

            cell.TextLabel.Text = tableItems[indexPath.Row].Name;
            
            
            
            if (tableItems[indexPath.Row].Pickup){
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            } else{
                cell.Accessory = UITableViewCellAccessory.None;
            }

            return cell;

        }

        public Prescriptions GetItem(int id){
            return tableItems[id];
        }


    }
}
