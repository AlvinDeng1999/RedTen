using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedTen.Models
{
    public class PlayerGame
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public bool Loser { get; set; }
        //public string Location { get; set; }
    }
}
