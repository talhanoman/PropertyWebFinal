using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWebApp.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<string> GetAllErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        }
    }
}
