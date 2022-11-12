using peliculasApi.Entidades;

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

        public async Task<Genero> ObtenerPorId(int Id)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return _generos.FirstOrDefault(x => x.Id == Id);
        }

        public void CrearGenero(Genero genero)
        {
            genero.Id = _generos.Count() + 1;
            _generos.Add(genero);   
        }
    }
}
