using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safebet.WebAPI.Data;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MatchesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatches()
        {
            var matches = await context.Matches.ToListAsync();

            return Ok(matches);
        }

        [HttpGet("{id}", Name = nameof(GetMatch))]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await context.Matches.FindAsync(id);

            if (match == null) {
                return NotFound();
            }

            return Ok(match);
        }
    }
}