using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNumeric.Models
{
    public class User
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Дата рождения")]
        public DateTime Date { get; set; }
    }
}