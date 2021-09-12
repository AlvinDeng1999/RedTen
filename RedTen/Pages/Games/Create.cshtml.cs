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
    public class CreateModel : PageModel
    {
        private readonly RedTen.Data.ApplicationDbContext _context;
        public List<Player> Available { get; set; }
        public List<Player> PlayersInGame { get; set; }


        public CreateModel(RedTen.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {

            PlayersInGame = new List<Player>();

            Available =  _context.Player.ToList();

            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            /*
             * var players = this.Request.Form["PlayersInGame"].Select(p => int.Parse(p));
            var playersInGame = _context.Player.Where(p => players.Contains(p.PlayerId));

            ICollection<PlayerGame> gamePlayers = playersInGame.Select(p => new PlayerGame()
            {
                GameId = Game.GameId,
                PlayerId = p.PlayerId
            }).ToArray();
            foreach (var gp in gamePlayers)
                _context.PlayerGame.Add(gp).State = EntityState.Added;
             * */


            _context.Game.Add(Game);

            await _context.SaveChangesAsync();

            var playersInGame = this.Request.Form["PlayersInGame"].Select(p => int.Parse(p));
            IEnumerable<PlayerGame> gamePlayers = playersInGame.Select(p => new PlayerGame()
            {
                GameId = Game.GameId,
                PlayerId = p
            });
            foreach (var gp in gamePlayers) _context.PlayerGame.Add(gp).State = EntityState.Added;

            await _context.SaveChangesAsync();
            

            return RedirectToPage("./Index");
        }
    }
}
