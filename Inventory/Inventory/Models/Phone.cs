using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class Phone : Device
    {
        [Key]
        public int Id { get; set; }
    }
}
