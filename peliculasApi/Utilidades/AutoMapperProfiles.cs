using AutoMapper;
using NetTopologySuite.Geometries;
using peliculasApi.DTOs;
using peliculasApi.Entidades;
using System.Reflection.Metadata.Ecma335;

namespace peliculasApi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto, options => options.Ignore());
            CreateMap<CineCreacionDTO, Cine>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(dto =>
                geometryFactory.CreatePoint(new Coordinate(dto.Longitud, dto.Latitud))));
            CreateMap<Cine, CineDTO>()
                .ForMember(x => x.Latitud, dto => dto.MapFrom(campo => campo.Ubicacion.Y))
                .ForMember(x => x.Longitud, dto => dto.MapFrom(campo => campo.Ubicacion.X));
            CreateMap<PeliculasCreacionDTO, Pelicula>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.PeliculasGeneros, opciones => opciones.MapFrom(MapearPeliculasGeneros))
                .ForMember(x => x.PeliculasCines, opciones => opciones.MapFrom(MapearPeliculasCines))
                .ForMember(x => x.PeliculasActores, opciones => opciones.MapFrom(MapearPeliculasActores));


        }

        private List<PeliculasActores> MapearPeliculasActores(PeliculasCreacionDTO peliculasCreacionDTO , Pelicula pelicula)
        {
            var resultado = new List<PeliculasActores>();
            if (peliculasCreacionDTO.Actores== null) { return resultado; }
            foreach (var actor in peliculasCreacionDTO.Actores)
            {
                resultado.Add(new PeliculasActores() { ActorId = actor.Id, Personaje = actor.Personaje });
            }
            return resultado;

        }

        private List<PeliculasGeneros> MapearPeliculasGeneros(PeliculasCreacionDTO peliculasCreacionDTO,
            Pelicula pelicula)
        {
            var resultado = new List<PeliculasGeneros>();
            if (peliculasCreacionDTO.GenerosIds == null) { return resultado; }
            foreach (var id in peliculasCreacionDTO.GenerosIds)
            {
                resultado.Add(new PeliculasGeneros() { GeneroId = id });
            }
            return resultado;
        }
        private List<PeliculasCines> MapearPeliculasCines(PeliculasCreacionDTO peliculasCreacionDTO,
        Pelicula pelicula)
        {
            var resultado = new List<PeliculasCines>();
            if (peliculasCreacionDTO.CinesIds == null) { return resultado; }
            foreach (var id in peliculasCreacionDTO.CinesIds)
            {
                resultado.Add(new PeliculasCines() { CineId = id });
            }
            return resultado;
        }
    }
}
