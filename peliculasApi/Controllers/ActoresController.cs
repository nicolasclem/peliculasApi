using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasApi.DTOs;
using peliculasApi.Entidades;
using peliculasApi.Utilidades;

namespace peliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "actores";

        public ActoresController(ApplicationDbContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]

        public async Task<ActionResult<List<ActorDTO>>> Get()
        {

            var actores = await context.Actores.ToListAsync();      
            return mapper.Map<List<ActorDTO>>(actores);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            if(actorCreacionDTO.Foto != null)
            {
               actor.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, actorCreacionDTO.Foto);
            }
            context.Actores.Add(actor); 
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
