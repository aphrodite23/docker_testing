using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tournament.Models;
using Tournament.Services;

namespace Tournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentService _tournamentService;

        public TournamentController(TournamentService tour)
        {
            _tournamentService = tour;
        }

        [HttpGet]
        public ActionResult<List<TournamentD>> Get() => _tournamentService.Get();

        [HttpPost]
        public ActionResult<TournamentD> Create(TournamentD tour)
        {
            _tournamentService.Create(tour);
            return CreatedAtRoute( new { id = tour.TournamentId.ToString() }, value: tour);
        }
        [HttpPut]
        public IActionResult Update(string id ,TournamentD game)
        {
            var tour = _tournamentService.Get(id: id );
            if (tour == null)
            {
                return NotFound();
            }
            _tournamentService.Update(id ,game);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var game = _tournamentService.Get(id);
            if (game == null)
            {
                return NotFound();
            }
            _tournamentService.Remove(id);
            return NoContent();
        }
    }
}