using peliculasApi.Entidades;

namespace peliculasApi.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObetenerTodosLosGeneros();
        Task<Genero> ObtenerPorId(int Id);
    }
}
