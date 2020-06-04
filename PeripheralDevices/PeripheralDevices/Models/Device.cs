using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeripheralDevices.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public Employee Employee { get; set; }
        public Transfer Transfer { get; set; }
        public Repair Repair { get; set; }
    }
}
