using Microsoft.AspNetCore.Mvc;
using peliculasApi.Entidades;
using peliculasApi.Repositorios;

namespace peliculasApi.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult<Genero> Get(int Id)
        {
            var genero = repositorio.ObtenerPorId(Id);
            if( genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put()
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
