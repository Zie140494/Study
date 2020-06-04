using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeripheralDevices.Models
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string Where { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
