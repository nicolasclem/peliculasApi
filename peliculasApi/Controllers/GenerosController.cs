using Microsoft.AspNetCore.Mvc;
using peliculasApi.Entidades;
using peliculasApi.Repositorios;

namespace peliculasApi.Controllers
{
    [Route("api/generos")]
    public class GenerosController
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public List<Genero> Get()
        {
            return repositorio.ObetenerTodosLosGeneros();
        }
    }
}
