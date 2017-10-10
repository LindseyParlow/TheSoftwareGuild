using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "Must add State Abbreviation!")]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "Must add State name!")]
        public string StateName { get; set; }
    }
}