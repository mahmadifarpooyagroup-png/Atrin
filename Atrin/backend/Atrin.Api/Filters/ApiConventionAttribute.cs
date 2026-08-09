using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;

namespace Atrin.Api.Filters;

public class ApiConventionAttribute : Attribute, IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        foreach (var action in controller.Actions)
        {
            action.Filters.Add(new ProducesDefaultResponseTypeAttribute());
            action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
            action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status403Forbidden));
        }
    }
}

