﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class Monitor : Device
    {
       
        public string Diagonal { get; set; }
    }
}
