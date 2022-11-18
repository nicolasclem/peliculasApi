using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace peliculasApi.Utilidades
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombrePropiedad = bindingContext.ModelName;
            var valor = bindingContext.ValueProvider.GetValue(nombrePropiedad);

            if( valor == ValueProviderResult.None)
            {
                return Task.CompletedTask;  
            }
            try
            {
                var valorDesearlizado = JsonConvert.DeserializeObject<T>(valor.FirstValue);
                bindingContext.Result= ModelBindingResult.Success(valorDesearlizado);
            }
            catch 
            {

                bindingContext.ModelState.TryAddModelError(nombrePropiedad, "El valor dado no es del tipo adecuando");
            }
            return Task.CompletedTask;  
        }
    }
}
