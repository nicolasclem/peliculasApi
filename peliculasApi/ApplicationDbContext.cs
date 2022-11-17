﻿using Microsoft.EntityFrameworkCore;
using peliculasApi.Entidades;

namespace peliculasApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Genero> Generos { get; set; }
        public DbSet <Actor> Actores { get; set; }
        public DbSet <Cine> Cines { get; set; } 
    }
}
