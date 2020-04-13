using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public abstract class Device
    {
        public bool Status { get; set; }
        public string TypeDevice { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Provider { get; set; }
        public DateTime DateOfPurchase { get; set; }

    }
}
