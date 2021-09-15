using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MinLength(1, ErrorMessage ="Please have at least 1 winner selected")]
        public List<Player> Players { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please have at least 1 loser selected")]
        public List<Player> Losers { get; set; }
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var playerGames = await _context.PlayerGame.Where(gp => gp.GameId == Game.GameId).ToListAsync();
            var losers = this.Request.Form["Losers"].Select(p => int.Parse(p));

            foreach(var pg in playerGames)
            {
                pg.Loser = losers.Contains(pg.PlayerId);
            }

            foreach (var gp in playerGames) _context.PlayerGame.Add(gp).State = EntityState.Modified;
            _context.Game.Update(Game);
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
