using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class Monitor : Device
    {
       
        public int Id { get; set; }
        public string Diagonal { get; set; }
    }
}
