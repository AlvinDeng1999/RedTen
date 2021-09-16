using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RedTen.Data;
using RedTen.Models;

namespace RedTen.Pages.Games
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly RedTen.Data.ApplicationDbContext _context;
        public List<Player> Players { get; set; }
        public List<Player> Losers { get; set; }
        public DetailsModel(RedTen.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.FirstOrDefaultAsync(m => m.GameId == id);

            var playerGames = await _context.PlayerGame.Where(gp => gp.GameId == id).ToListAsync();
            Players = await _context.Player.Where(p => playerGames.Select(pg => pg.PlayerId).Contains(p.PlayerId)).ToListAsync();

            var LoserIDs = playerGames.Where(pg => pg.Loser).Select(pg => pg.PlayerId);
            Losers = Players.Where(pg => LoserIDs.Contains(pg.PlayerId)).ToList();
            Players = Players.Except(Losers).ToList();

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
