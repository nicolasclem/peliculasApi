using Microsoft.EntityFrameworkCore;
using peliculasApi.Entidades;

namespace peliculasApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet <Genero> Generos { get; set; }
    }
}
