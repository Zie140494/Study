using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public SysBlock SysBlock { get; set; }
        public SysBlock Monitor { get; set; }
        public SysBlock Printer { get; set; }
        public SysBlock Phone { get; set; }
    }
}
