using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedTen.Data;
using RedTen.Models;

namespace RedTen.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly RedTen.Data.ApplicationDbContext _context;
        public List<Player> Available { get; set; }
        public List<Player> PlayersInGame { get; set; }
        public EditModel(RedTen.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.FirstOrDefaultAsync(m => m.GameId == id);
            

            var playerGames = await _context.PlayerGame.Where(gp=>gp.GameId==id).ToListAsync();
            PlayersInGame = await _context.Player.Where(p => playerGames.Select(pg => pg.PlayerId).Contains(p.PlayerId)).ToListAsync();

            Available = await _context.Player.Where(p => !playerGames.Select(pg => pg.PlayerId).Contains(p.PlayerId)).ToListAsync();
            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var players = this.Request.Form["PlayersInGame"].Select(p => int.Parse(p));
            var playersInGame = _context.Player.Where(p => players.Contains(p.PlayerId));

            ICollection<PlayerGame> gamePlayers = playersInGame.Select(p => new PlayerGame()
            {
                GameId = Game.GameId,
                PlayerId = p.PlayerId
            }).ToArray();
            foreach (var gp in gamePlayers)
                _context.PlayerGame.Add(gp).State = EntityState.Added;
           
            //_context.Attach(Game).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(Game.GameId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}
