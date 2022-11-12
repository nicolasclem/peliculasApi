using peliculasApi.Entidades;

namespace peliculasApi.Repositorios
{
    public interface IRepositorio
    {
        void CrearGenero(Genero genero);
        List<Genero> ObetenerTodosLosGeneros();
        Task<Genero> ObtenerPorId(int Id);
    }
}
