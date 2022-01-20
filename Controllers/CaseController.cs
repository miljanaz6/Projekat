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
    public class CaseController : ControllerBase
    {
        public GameContext Context { get; set; }

        public CaseController(GameContext context)
        {
            Context=context;
        }


        [Route("CaseBoje1")]
        [HttpGet]
         public async Task<ActionResult> PreuzmiPrviNivo()
        {
          try
            {
                var caseBoje = Context.Case
                .Include(p=>p.TecnostBoje)
                .Where(p=>p.TecnostBoje.CasaId==p.ID && (p.Oznaka=="caša11" || p.Oznaka=="caša12" || p.Oznaka=="caša13"));
                
                var casaBoja=await caseBoje.ToListAsync();
                return Ok(
                    casaBoja.Select(p=>
                    new{
                        Oznaka=p.Oznaka,
                        Kapacitet=p.Kapacitet,
                        Napunjenost=p.Napunjenost,
                        red1=p.TecnostBoje.red1,
                        red2=p.TecnostBoje.red2,
                        red3=p.TecnostBoje.red3,
                        red4=p.TecnostBoje.red4
                    }
                    ).ToList()
                    
                    );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("CaseBoje2")]
        [HttpGet]
         public async Task<ActionResult> PreuzmiDrugiNivo()
        {
          try
            {
                var caseBoje = Context.Case
                .Include(p=>p.TecnostBoje)
                .Where(p=>p.TecnostBoje.CasaId==p.ID && (p.Oznaka=="caša21" || p.Oznaka=="caša22" || p.Oznaka=="caša23"|| p.Oznaka=="caša24" || p.Oznaka=="caša25"));
                
                var casaBoja=await caseBoje.ToListAsync();
                return Ok(
                    casaBoja.Select(p=>
                    new{
                        Oznaka=p.Oznaka,
                        Kapacitet=p.Kapacitet,
                        Napunjenost=p.Napunjenost,
                        red1=p.TecnostBoje.red1,
                        red2=p.TecnostBoje.red2,
                        red3=p.TecnostBoje.red3,
                        red4=p.TecnostBoje.red4
                    }
                    ).ToList()
                    
                    );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("Case1")]
        [HttpGet]
         public async Task<ActionResult> PreuzmiCase1()
        {
          try
            {
                return Ok(await Context.Case.Select(p => new { p.ID, p.Oznaka,p.Kapacitet,p.Napunjenost })
                .Where(p=>p.Oznaka=="caša11"|| p.Oznaka=="caša12" || p.Oznaka=="caša13" ).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Case2")]
        [HttpGet]
         public async Task<ActionResult> PreuzmiCase2()
        {
          try
            {
                return Ok(await Context.Case.Select(p => new { p.ID, p.Oznaka,p.Kapacitet,p.Napunjenost })
                .Where(p=>p.Oznaka=="caša21"|| p.Oznaka=="caša22" || p.Oznaka=="caša23"|| p.Oznaka=="caša24" || p.Oznaka=="caša25").ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("DodatiCasu")]
        [HttpPost]
        public async Task<ActionResult> DodatiCasu([FromBody] Casa casa)
        {
            if(string.IsNullOrWhiteSpace(casa.Oznaka) || casa.Oznaka.Length>50) 
            {
                return BadRequest("Pogresna oznaka!");
            }
            try
            {
                Context.Case.Add(casa);
                await Context.SaveChangesAsync();
                return Ok($"Casa je dodata! ID je:{casa.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromenitiCasu")]
        [HttpPut]
        public async Task<ActionResult> PromenitiCasu([FromBody] Casa casa)
        {
            if(casa.ID<=0) 
            {
                return BadRequest("Pogresan ID!");
            }
            try
            {
                var casaZaPromenu=await Context.Case.FindAsync(casa.ID);
                casaZaPromenu.Oznaka=casa.Oznaka;
                casaZaPromenu.Napunjenost=casa.Napunjenost;
                casaZaPromenu.Kapacitet=casa.Kapacitet;
                await Context.SaveChangesAsync();
                return Ok($"Casa je izmenjena! ID je:{casa.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzbrisatiCasu/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiCasu(int id)
        {
            if(id<=0)
            {
                return BadRequest("Pogresan ID!");
            }
            try
            {
                var casa=await Context.Case.FindAsync(id);
                string oznaka=casa.Oznaka;
                Context.Case.Remove(casa);
                await Context.SaveChangesAsync();
                return Ok($"Casa je izbrisana! I to je:{oznaka}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
