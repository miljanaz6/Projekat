using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BojeController : ControllerBase
    {
        public GameContext Context { get; set; }

        public BojeController(GameContext context)
        {
            Context=context;
        }
        
        [Route("Boje")]
        [HttpGet]
         public async Task<ActionResult> PreuzmiBoje()
        {
          try
            {
                return Ok(await Context.Boje.Select(p => new { p.ID, p.red1,p.red2,p.red3,p.red4 }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
