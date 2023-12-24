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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return Ok(await Services.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AnimeDTO anime)
        {
            try
            {
                if (anime == null)
                {
                    return NotFound();
                }

                await Services.Create(anime);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}", Name = "GetAnime")]
        public async Task<IActionResult> GetById(int id)
        {            
            try
            {
                AnimeDTO anime = await Services.GetById(id);

                if (anime == null)
                {
                    return NotFound();
                }

                return Ok(anime);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName(string nome)
        {
            try
            {
                List<AnimeDTO> anime = await Services.GetByName(nome);

                if (anime == null)
                {
                    return NotFound();
                }

                return Ok(anime);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AnimeDTO anime)
        {
            /*Estou com um problema com o try catch, porém, estou procurando qual a melhor forma de 
             * implementar o try catch.
             * 
             * try
            {
                if (anime == null) return NotFound();
                if (anime.Id != id) return NotFound();

                await Services.Update(anime);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }*/
            if (anime == null) return NotFound();
            if (anime.Id != id) return NotFound();

            await Services.Update(anime);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                AnimeDTO anime = await Services.GetById(id);

                if (anime == null) return NotFound();

                await Services.Delete(id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
