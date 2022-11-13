using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasApi.Entidades;
using peliculasApi.Filtros;


namespace peliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
       
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;

        public GenerosController( 
            ILogger<GenerosController> logger,
            ApplicationDbContext context)
        {
           
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
       
        public async  Task<ActionResult<List<Genero>>> Get()
        {

            return await context.Generos.ToListAsync();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {

            context.Generos.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
            
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {

            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException(); ;
        }
    }
}
