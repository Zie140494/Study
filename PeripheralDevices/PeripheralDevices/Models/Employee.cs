using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeripheralDevices.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FatherName { get; set; }
        public string Rank { get; set; }
        public string Position { get; set; }
        public int Phone { get; set; }
        public string Room { get; set; }
    }
}
