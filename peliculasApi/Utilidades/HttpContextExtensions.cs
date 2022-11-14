using Microsoft.EntityFrameworkCore;

namespace peliculasApi.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginasEnCabecera<T>
            (this HttpContext httpContext,IQueryable<T> queryable)
        {
            if(httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            double cantidad = await queryable.CountAsync();

            httpContext.Response.Headers.Add("canidadTotalRegistros", cantidad.ToString());
        }
    }
}
