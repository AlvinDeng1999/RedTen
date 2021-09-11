using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedTen.Models
{
    public class Player
    {
        public int id { get; set; }

        [Display(Name="Player Name")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
