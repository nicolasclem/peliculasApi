﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public GenerosController( ILogger<GenerosController> logger)
        {
           
            this.logger = logger;
        }

        [HttpGet]
       
        public ActionResult<List<Genero>> Get()
        {

            return new List<Genero>() { new Genero() { Id = 1, Nombre = "Comedia" } };
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {

            throw new NotImplementedException();
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
