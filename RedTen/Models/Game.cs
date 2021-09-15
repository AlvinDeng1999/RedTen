using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedTen.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Display(Name="Session Time")]
        [Required]
        public DateTime Session_Time { get; set; }
        [Required]
        public string Location { get; set; }
        //public List<Player> Players { get; set; }
        //public List<Player> Winners { get; set; }
        //public List<Player> Losers { get; set; }

    }
}
