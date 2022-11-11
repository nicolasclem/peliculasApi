using peliculasApi.Entidades;

namespace peliculasApi.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObetenerTodosLosGeneros();
    }
}
