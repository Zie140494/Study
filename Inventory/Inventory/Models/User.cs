using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public SysBlock SysBlock { get; set; }
        public Monitor Monitor { get; set; }
        public Printer Printer { get; set; }
        public Phone Phone { get; set; }
    }
}
