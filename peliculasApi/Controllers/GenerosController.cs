using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasApi.DTOs;
using peliculasApi.Entidades;
using peliculasApi.Filtros;
using peliculasApi.Utilidades;

namespace peliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
       
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController( 
            ILogger<GenerosController> logger,
            ApplicationDbContext context,
            IMapper mapper)
        {
           
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
       
        public async  Task<ActionResult<List<GeneroDTO>>> Get()
        {

           var generos = await context.Generos.ToListAsync();
           return  mapper.Map<List<GeneroDTO>>(generos);
            
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GeneroDTO>> Get(int Id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id );
            if (genero == null) NotFound();

            return mapper.Map<GeneroDTO>(genero);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {

            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Generos.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
            
        }
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id,[FromBody] GeneroCreacionDTO generoCreacionDTO)
        {

            var genero= await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);
            if(genero == null) NotFound();
            genero = mapper.Map(generoCreacionDTO,genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe= await context.Generos.AnyAsync(x => x.Id == id);
            if(!existe) NotFound();
            context.Remove(new Genero() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
