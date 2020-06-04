using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeripheralDevices.Models
{
    public class Repair
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
        public DateTime RepairDate { get; set; }
    }
}
