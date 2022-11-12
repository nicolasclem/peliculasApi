using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using peliculasApi.Filtros;
using peliculasApi.Repositorios;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<FiltroDeAccion>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddResponseCaching();
// Add services to the container.
builder.Services.AddTransient<IRepositorio ,RepositorioEnMemoria>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FiltroDeExcepcion));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


//app.Use(async (context, next) =>
//{
//    using (var swapStream = new MemoryStream())
//    {
//        var respuestaOriginal = context.Response.Body;
//        context.Response.Body = swapStream;

//        await next.Invoke();

//        swapStream.Seek(0, SeekOrigin.Begin);
//        string respuesta = new StreamReader(swapStream).ReadToEnd();
//        swapStream.Seek(0,SeekOrigin.Begin);

//        await swapStream.CopyToAsync(respuestaOriginal);
//        context.Response.Body = respuestaOriginal;

//        Console.WriteLine(respuesta);
//    }
//});


app.Map("/mapa1", (app) =>
{
    app.Run(async context =>
    {
    await context.Response.WriteAsync("Estoy interceptando el pipeline");
    });

});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
