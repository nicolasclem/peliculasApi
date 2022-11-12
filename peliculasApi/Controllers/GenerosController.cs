using Microsoft.AspNetCore.Mvc;
using peliculasApi.Entidades;
using peliculasApi.Repositorios;

namespace peliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObetenerTodosLosGeneros();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            var genero = await repositorio.ObtenerPorId(Id);
            if( genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
           
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
           
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
