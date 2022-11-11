﻿using peliculasApi.Entidades;

namespace peliculasApi.Repositorios
{

  
    public class RepositorioEnMemoria: IRepositorio
    {
        private List<Genero> _generos;

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
                {
                    new Genero(){Id= 1,Nombre="Comedia"},
                    new Genero(){Id= 2,Nombre="Accion"}
                };
        }

        public List<Genero> ObetenerTodosLosGeneros()
        {
            return _generos;
        }
    }
}
