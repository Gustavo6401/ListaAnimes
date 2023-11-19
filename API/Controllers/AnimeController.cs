using Dominio.DTOs;
using Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private IAnimeServices Services { get; }
        public AnimeController(IAnimeServices services)
        {
            Services = services;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await Services.GetAll());
        }

        public async Task<IActionResult> Create([FromBody] AnimeDTO anime)
        {
            if(anime == null)
            {
                return NotFound();
            }

            await Services.Create(anime);

            return Ok();
        }

        public async Task<IActionResult> GetById(int id)
        {            
            AnimeDTO anime = await Services.GetById(id);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }
        
        public async Task<IActionResult> GetByName(string nome)
        {
            AnimeDTO anime = await Services.GetByName(nome);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }

        public async Task<IActionResult> Update(int id, AnimeDTO anime)
        {
            // Verifica se o Id está correto. 
            AnimeDTO dto = await Services.GetById(id);

            if(dto == null) return NotFound();
            if (anime == null) return NotFound();
            if(anime.Id != id) return NotFound();            

            await Services.Update(anime);

            return Ok();
        }

        public async Task<IActionResult> Delete(int id)
        {
            AnimeDTO anime = await Services.GetById(id);

            if (anime == null) return NotFound();

            await Services.Delete(id);

            return Ok();
        }
    }
}
