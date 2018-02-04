using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace FYP.iOS
{
    public partial class ItemViewController : UITableView
    {
        List<Prescriptions> prescriptions;


        public ItemViewController (IntPtr handle) : base (handle)
        {
            prescriptions = new List<Prescriptions>{
                new Prescriptions{Name="Lexapro (Escitalopram)", ID= 97,
                                  Dosage= "10mg", Length="2-4 Weeks",
                                  Pickup = true, Instructions="Take one daily"},
                new Prescriptions{Name="Diazemuls (Diazepam)", ID= 95,
                                  Dosage= "5mg", Length="2months",
                                  Pickup = false, Instructions="Take two every four hours"},
                new Prescriptions{Name="Xanax (Alprazolam)", ID= 99,
                                  Dosage= "0.5mg", Length="3 Weeks",
                                  Pickup = true, Instructions="Take two once a day"}
            };
        }
    }
}