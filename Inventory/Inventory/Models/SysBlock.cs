﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class SysBlock : Device
    {
        [Key]
        public int Id { get; set; }
        public string CPU { get; set; }
        public string Frequency { get; set; }
        public string RAM { get; set; }
        public string HDD { get; set; }
    }
}